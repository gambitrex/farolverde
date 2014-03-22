using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarolVerde.Models.Google
{
    public class Leg
    {
        public PointTime arrival_time { get; set; }
        public PointTime departure_time { get; set; }
        public TextValue distance { get; set; }
        public TextValue duration { get; set; }
        public string end_address { get; set; }
        public Coordinate end_location { get; set; }
        public string start_address { get; set; }
        public Coordinate start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<string> via_waypoint { get; set; }
    }
}