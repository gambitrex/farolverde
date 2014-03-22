using FarolVerde.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models
{
    [DataContract, Table("vitimas")]
    public class Vitima
    {
        public int id { get; set; }
	    public bool active { get; set; }
	    public string id_acidente { get; set; }
	    public string id_vitima { get; set; }
	    public string id_veiculo { get; set; }
	    public string sexo { get; set; }
	    public string idade { get; set; }
	    public string tipo_vitima { get; set; }
	    public string classificacao { get; set; }
	    public string tipo_veiculo { get; set; }
	    public string estado_alcoolizacao { get; set; }
	    public string escolaridade { get; set; }
        public string data_obito { get; set; }

        public static List<Vitima> Get()
        {
            using (Context context = new Context())
            {
                return (from e in context.Vitimas select e).ToList();
            }
        }
    }
}