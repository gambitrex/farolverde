using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace FarolVerde.Models.DataBase
{
    public class DBManager<TContext> where TContext : DbContext
    {
        public static void Save(IEntity entity)
        {
            using (Context context = new Context())
            {
                ToContext(entity, context);

                context.SaveChanges();
            }
        }

        public static void Remove<T>(object entity)
        {
            using (TContext context = (TContext)Activator.CreateInstance(typeof(T)))
            {
                context.Set(typeof(T)).Remove(entity);
                context.Entry(entity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        private static void ToContext(IEntity entity, Context context)
        {
            if (entity != null)
            {
                if (entity.Id == 0)
                    context.Set(entity.GetType()).Add(entity);
                else
                {
                    context.Set(entity.GetType()).Attach(entity);
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                }

                ToContext(context, entity);

                AddRemoveArrayContext(context, entity);
            }
        }

        private static void AddRemoveArrayContext(Context context, IEntity entity)
        {
            var properties = entity.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(RemoveContextAttribute)));

            foreach (var item in properties)
            {
                var obj = item.GetValue(entity);

                if (obj != null && obj.GetType().IsArray)
                {
                    CallRemoveContextCore(context, entity, obj.GetType().GetElementType());

                    ToContext((ICollection<IEntity>)obj, context);
                }
            }
        }

        private static void ToContext(Context context, IEntity entity)
        {
            var properties = entity.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ToContextAttribute)));

            foreach (var item in properties)
            {
                var obj = item.GetValue(entity);

                if (obj != null && obj.GetType().IsArray)
                    ToContext((ICollection<IEntity>)item.GetValue(entity), context);
                else
                    ToContext((IEntity)item.GetValue(entity), context);
            }
        }

        private static void ToContext(ICollection<IEntity> entities, Context context)
        {
            foreach (var item in entities)
                ToContext(item, context);
        }

        private static void CallRemoveContextCore(Context context, IEntity parentEntity, Type type)
        {
            var instance = Activator.CreateInstance("WaleAssessoria.Core", "WaleAssessoria.Core." + type.Name).Unwrap();

            var methodInfo = instance.GetType().GetMethod("RemoveContext");

            if (methodInfo != null)
            {
                object[] parameters = new object[] { parentEntity };

                methodInfo.Invoke(null, parameters);
            }
        }
    }
}