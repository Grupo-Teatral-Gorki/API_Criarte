using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class CreateProjetoDTO
    {
        public string? NomeProjeto { get; set; }

        public int? IdProponente { get; set; }

        public int? IdArea { get; set; }

        public DateTime? DataPrevistaInicio { get; set; }

        public DateTime? DataPrevistaFim { get; set; }

        public string? ResumoProjeto { get; set; }

        public string? Descricao { get; set; }

        public string? Objetivos { get; set; }

        public string? JustificativaProjeto { get; set; }

        public string? ContrapartidaProjeto { get; set; }

        public string? PlanoDemocratizacao { get; set; }

        public string? OutrasInformacoes { get; set; }

        public bool? Ingresso { get; set; }

        public decimal? ValorIngresso { get; set; }

        public int IdEdital { get; set; }

        public int IdModalidade { get; set; }

        public string Status { get; set; } = "Rascunho";
    }
}
