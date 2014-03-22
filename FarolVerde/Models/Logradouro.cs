using FarolVerde.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models
{
    [DataContract, Table("logradouros")]
    public class Logradouro : IEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("codlog")]
        public string CodLog { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("preposicao")]
        public string Preposicao { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        public static List<Logradouro> Get()
        {
            using (Context context = new Context())
            {
                return (from e in context.Logradouros select e).ToList();
            }
        }
    }
}