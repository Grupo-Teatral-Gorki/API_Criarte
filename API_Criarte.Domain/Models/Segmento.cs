using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("segmentos", Schema = "geral")]
    public class Segmento
    {
        [Key]
        [Column("id_area")]
        public int IdSegmento { get; set; }

        [Column("nome_area")]
        public string NomeArea { get; set; }
    }
}
