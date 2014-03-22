using FarolVerde.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FarolVerde.Models
{
    [DataContract, Table("Ocorrencias")]
    public class Logradouro : IEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("Ocorrência")]
        public string Ocorrencias { get; set; }

        [Column("Código")]
        public string Codigo { get; set; }

        [Column("Local da Ocorrência")]
        public string LocalOcorrencia { get; set; }

        [Column("Altura Numérica")]
        public string AlturaNumerica { get; set; }

        public string Sentido { get; set; }

        public string Pista { get; set; }

        [Column("Faixa Ocupação")]
        public string FaixaOcupacao { get; set; }

        [Column("Total de Faixas")]
        public string TotalFaixas { get; set; }

        [Column("Data Hora (Chegada)")]
        public DateTime DataHoraChegada { get; set; }

        [Column("Data Hora (Chegada Man )")]
        public DateTime DataHoraChegadaMan { get; set; }

        [Column("Data Hora (Rem Sol)")]
        public DateTime DataHoraRemSol { get; set; }

        [Column("Data Hora (Rem Sol Ma)")]
        public DateTime DataHoraRemSolMa { get; set; }

        public static List<Ocorrencia> Get()
        {
            using (Context context = new Context())
            {
                return (from e in context.Ocorrencias select e).ToList();
            }
        }
    }
}