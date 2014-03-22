using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models.DTO
{
    [DataContract]
    public class Point
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Lat { get; set; }
        [DataMember]
        public string Long { get; set; }
    }
}