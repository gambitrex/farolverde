using FarolVerde.Models.DTO;
using FarolVerde.Models.SPTrans;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace FarolVerde.Models
{
    public static class Engine
    {
        

        /// <summary>
        /// Given a GMaps route, calculate how good it is, based on cost, time and environment (CO2)    
        /// </summary>
        /// <param name="routeType">Route Type (eg. Bicycling, Car or Transit)</param>
        /// <param name="routes">Routes retrieved by GMaps</param>
        /// <returns>A RouteRS Object, containing main informations regarding this route.</returns>
        public static RouteRS Process(RouteType routeType, dynamic GMapsObject)
        {
            SPTransAPIManager sptransManager = SPTransAPIManager.Instance;
            var route = GMapsObject.routes[0]; // let's ignore alternative routes for now

            RouteRS response = new RouteRS();
            if (route.legs.Count == 0) // something strage happened. google went crazy?
                return null;
            var leg = route.legs[0];

            response.Distance = leg.distance.value;
            response.Duration = leg.duration.value;



            foreach (var step in leg.steps)
            {
                if (step.travel_mode == "TRANSIT" && step.transit_details.line.vehicle.type == "BUS")
                {
                    var busStops = sptransManager.ConsumeSPTransAPI(step.transit_details.line.short_name.ToString());
                    return response;
                }
            }

            return response;
        }
    }
}