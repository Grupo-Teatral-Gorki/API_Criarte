using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("projeto", Schema = "projeto")]
    public class Projeto
    {
        [Key]
        [Column("id_projeto")]
        public long IdProjeto { get; set; }

        [Column("nome_projeto")]
        public string? NomeProjeto { get; set; }

        [Column("id_proponente")]
        public int? IdProponente { get; set; }

        [Column("id_area")]
        public int? IdArea { get; set; }

        [Column("data_prevista_inicio")]
        public DateTime? DataPrevistaInicio { get; set; }

        [Column("data_prevista_fim")]
        public DateTime? DataPrevistaFim { get; set; }

        [Column("resumo_projeto")]
        public string? ResumoProjeto { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("objetivos")]
        public string? Objetivos { get; set; }

        [Column("justificativa_projeto")]
        public string? JustificativaProjeto { get; set; }

        [Column("contrapartida_projeto")]
        public string? ContrapartidaProjeto { get; set; }

        [Column("plano_democratizacao")]
        public string? PlanoDemocratizacao { get; set; }

        [Column("outras_informacoes")]
        public string? OutrasInformacoes { get; set; }

        [Column("ingresso")]
        public bool? Ingresso { get; set; }

        [Column("valor_ingresso")]
        public decimal? ValorIngresso { get; set; }

        [Column("id_edital")]
        public int? IdEdital { get; set; }

        [Column("id_modalidade")]
        public int? IdModalidade { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("id_usuario")]
        public long IdUsuario { get; set; }

        [Column("relevancia_pertinencia")]
        public string? RelevanciaPertinencia { get; set; }

        [Column("perfil_publico")]
        public string? PerfilPublico { get; set; }

        [Column("classificacao_indicativa")]
        public string? ClassificacaoIndicativa { get; set; }

        [Column("qtd_publico")]
        public string? QuantidadePublico { get; set; }

        [Column("proposta_contrapartida")]
        public string? PropostaContrapartida { get; set; }

        [Column("plano_divulgacao")]
        public string? PlanoDivulgacao { get; set; }
    }
}
