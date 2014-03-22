using FarolVerde.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models
{
    [DataContract, Table("acidentes")]
    public class Acidente
    {
        public int id { get; set; }
	    public bool active { get; set; }
	    public string id_acidente { get; set; }
	    public string codloga { get; set; }
	    public string logradouroA { get; set; }
	    public string codlogb { get; set; }
	    public string logradouroB { get; set; }
	    public string alt_num { get; set; }
	    public string referencia { get; set; }
	    public DateTime data { get; set; }
	    public string cod_acid { get; set; }
	    public string tipo_acidente { get; set; }
	    public string dp { get; set; }
	    public string numero_BO { get; set; }
	    public string sentido { get; set; }
	    public string pista { get; set; }
	    public string automovel { get; set; }
	    public string moto { get; set; }
	    public string onibus { get; set; }
	    public string caminhao { get; set; }
	    public string bicicleta { get; set; }
	    public string moto_taxi { get; set; }
	    public string onibus_fretado { get; set; }
	    public string onibus_urbano { get; set; }
	    public string microonibus { get; set; }
	    public string van { get; set; }
	    public string vuc { get; set; }
	    public string caminhonete { get; set; }
	    public string carreta { get; set; }
	    public string jipe { get; set; }
	    public string outros { get; set; }
	    public string sem_informacao { get; set; }
	    public string carroca { get; set; }
	    public string princ_a { get; set; }
	    public string paiA { get; set; }
	    public string princ_b { get; set; }
	    public string paiB { get; set; }
	    public string cod_distrito { get; set; }
	    public string distrito { get; set; }
	    public string vit_ferida { get; set; }
        public string vit_morta { get; set; }

        public static List<Acidente> Get()
        {
            using (Context context = new Context())
            {
                return (from e in context.Acidentes select e).ToList();
            }
        }
    }
}