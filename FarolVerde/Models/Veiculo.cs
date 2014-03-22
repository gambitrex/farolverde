using FarolVerde.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models
{
    [DataContract, Table("veiculos")]
    public class Veiculo
    {
        public int id { get; set; }
	    public bool active { get; set; }
	    public string id_acidente { get; set; }
	    public string id_veiculo { get; set; }
	    public string tipo_veiculo { get; set; }
	    public string sexo_condutor { get; set; }
	    public string idade_condutor { get; set; }
	    public string categoria_habilitacao { get; set; }
	    public string usa_cinto_seguranca { get; set; }
	    public string estado_alcoolizacao { get; set; }
        public string escolaridade { get; set; }

        public static List<Veiculo> Get()
        {
            using (Context context = new Context())
            {
                return (from e in context.Veiculos select e).ToList();
            }
        }
    }
}