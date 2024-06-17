using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("fontes_financiamento", Schema = "geral")]
    public class FonteFinanciamento
    {
        [Key]
        [Column("id_fonte_financiamento")]
        public int IdFonteFinanciamento { get; set; }

        [Column("nome_fonte")]
        public string NomeFonte { get; set; }
    }
}
