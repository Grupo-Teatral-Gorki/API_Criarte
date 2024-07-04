using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("proponente", Schema = "geral")]
    public class Proponentes
    {
        [Key]
        [Column("id_proponente")]
        public int IdProponente { get; set; }

        [Column("razao_social")]
        public string RazaoSocial { get; set; }

        [Column("cnpj")]
        public string CNPJ { get; set; }

        [Column("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [Column("web_site")]
        public string WebSite { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        [Column("telefone_fixo")]
        public string TelefoneFixo { get; set; }

        [Column("telefone_outro")]
        public string TelefoneOutro { get; set; }

        [Column("responsavel_legal")]
        public string ResponsavelLegal { get; set; }

        [Column("cpf_responsavel")]
        public string CPFResponsavel { get; set; }

        [Column("rg_responsavel")]
        public string RGResponsavel { get; set; }

        [Column("nome_social")]
        public string NomeSocial { get; set; }

        [Column("data_nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Column("cargo")]
        public string Cargo { get; set; }

        [Column("cep_responsavel")]
        public string CEPResponsavel { get; set; }

        [Column("logradouro_responsavel")]
        public string LogradouroResponsavel { get; set; }

        [Column("numero_responsavel")]
        public int NumeroResponsavel { get; set; }

        [Column("complemento_responsavel")]
        public string ComplementoResponsavel { get; set; }

        [Column("bairro_responsavel")]
        public string BairroResponsavel { get; set; }

        [Column("cidade_responsavel")]
        public string CidadeResponsavel { get; set; }

        [Column("uf_responsavel")]
        public string UFResponsavel { get; set; }

        [Column("cep_pj")]
        public string CEPPJ { get; set; }

        [Column("logradouro_pj")]
        public string LogradouroPJ { get; set; }

        [Column("numero_pj")]
        public int NumeroPJ { get; set; }

        [Column("complemento_pj")]
        public string ComplementoPJ { get; set; }

        [Column("bairro_pj")]
        public string BairroPJ { get; set; }

        [Column("cidade_pj")]
        public string CidadePJ { get; set; }

        [Column("uf_pj")]
        public string UFPJ { get; set; }

        [Column("id_usuario_cadastro")]
        public int IdUsuarioCadastro { get; set; }
    }
}
