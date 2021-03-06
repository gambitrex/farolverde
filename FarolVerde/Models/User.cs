﻿using FarolVerde.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models
{
    [DataContract, Table("Users")]
    public class User : IEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string FacebookId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public Gender Gender { get; set; }

        public void Save()
        {
            DBManager<Context>.Save(this);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}