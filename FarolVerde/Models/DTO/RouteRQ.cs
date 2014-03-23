using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models.DTO
{
    [DataContract]
    public class RouteRQ
    {
        [DataMember]
        public Point Origin { get; set; }
        [DataMember]
        public Point Destination { get; set; }
        [DataMember]
        public string DepartureTime { get; set; }
        [DataMember]
        public string ArrivalTime { get; set; }
        [DataMember]
        public Vehicle Vehicle { get; set; }
        [DataMember]
        public User User { get; set; }
    }
}