using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models.DTO
{
    public class RouteRS : BaseRS
    {
        /// <summary>
        /// Duration of the route in MINUTES
        /// </summary>
        [DataMember]
        public int Duration { get; set; }

        /// <summary>
        /// Distance of the route in METERS
        /// </summary>
        [DataMember]
        public int Distance { get; set; }

        [DataMember]
        public RouteType RouteType { get; set; }
    }
}