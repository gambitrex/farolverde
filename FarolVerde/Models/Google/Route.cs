using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarolVerde.Models.Google
{
    public class Route
    {
        public List<Bound> bounds { get; set; }
        public string copyrights { get; set; }
        public List<Leg> legs { get; set; }
    }
}