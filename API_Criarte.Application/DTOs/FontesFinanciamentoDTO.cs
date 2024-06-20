using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class FontesFinanciamentoDTO
    {
        public int IdProjeto { get; set; }

        public string TipoFonteFinanciamento { get; set; }

        public int IdFonteFinanciamento { get; set; }

        public decimal ValorFinanciamento { get; set; }

        public string? FonteFinanciamentoExterna { get; set; }
    }
}
