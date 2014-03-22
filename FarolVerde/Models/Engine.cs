using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarolVerde.Models
{
    public static class Engine
    {
        
        public static object Process(dynamic routes)
        {
            var route = routes[0]; // let's ignore alternative routes for now
            int distance, duration; // meters and minutes
            if (route.legs.Count == 0) //something strage happened. 500?
                return null;
            var leg = route.legs[0];

            distance = leg.distance.value;
            duration = leg.duration.value;
            


            return null;

        }
    }
}