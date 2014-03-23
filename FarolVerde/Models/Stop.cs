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
    [Table("stops")]
    public class Stop
    {
        [Key]
        public int stop_id { get; set; }
	    public string stop_name { get; set; }
	    public string stop_desc { get; set; }
	    public string stop_lat { get; set; }
        public string stop_lon { get; set; }

        public static List<Stop> Get()
        {
            using (Context context = new Context())
            {
                return (from e in context.Stops select e).ToList();
            }
        }
    }
}