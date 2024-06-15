using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("editais", Schema = "geral")]
    public class Edital
    {
        [Key]
        [Column("id_edital")]
        public int IdEdital { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("data_inicial")]
        public DateTime DataInicial { get; set; }

        [Column("data_final")]
        public DateTime DataFinal { get; set; }

        [Column("valor_projeto")]
        public double ValorProjeto { get; set; }
    }
}
