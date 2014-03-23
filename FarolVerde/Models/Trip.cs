using FarolVerde.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models
{
    [DataContract, Table("trips")]
    public class Trip
    {
        public string route_id { get; set; }
	    public string service_id { get; set; }
        [Key]
	    public string trip_id { get; set; }
	    public string trip_headsign { get; set; }
	    public int direction_id { get; set; }
        public int shape_id { get; set; }

        public virtual List<Stop> Stops { get; set; }

        public static Trip Get(string tripId)
        {
            using (Context context = new Context())
            {
                var trip = context.Database.SqlQuery<Trip>("Select * From Trips WHERE trip_id = '" + tripId + "'").FirstOrDefault();

                if(trip != null)
                {
                    trip.Stops = context.Database.SqlQuery<Stop>("select * from stops AS s INNER JOIN stop_times AS st ON st.stop_id = s.stop_id" +
                    " INNER JOIN trips as t on t.trip_id = st.trip_id AND t.trip_id = '" + tripId + "'").ToList();
                }

                return trip;
            }
        }
    }
}