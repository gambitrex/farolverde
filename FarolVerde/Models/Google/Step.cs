using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarolVerde.Models.Google
{
    public class Step
    {
        public TextValue distance { get; set; }
        public TextValue duration { get; set; }
        public Coordinate end_location { get; set; }
        public string html_instructions { get; set; }
        public string polyline { get; set; }
        public Coordinate start_location { get; set; }
        public List<Step> steps { get; set; }
        public string travel_mode { get; set; }
    }
}