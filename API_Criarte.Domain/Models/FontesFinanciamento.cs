using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("fontes_financiamento", Schema = "projeto")]
    public class FontesFinanciamento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Column("tipo_fonte_financiamento")]
        public string TipoFonteFinanciamento { get; set; }

        [Column("id_fonte_financiamento")]
        public int IdFonteFinanciamento { get; set; }

        [Column("valor_financiamento")]
        public decimal ValorFinanciamento { get; set; }

        [Column("fonte_financiamento_externa")]
        public string? FonteFinanciamentoExterna { get; set; }
    }
}
