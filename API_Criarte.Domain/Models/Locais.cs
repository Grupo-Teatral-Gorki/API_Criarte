using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("locais", Schema = "projeto")]
    public class Locais
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Column("id_cidade")]
        public int IdCidade { get; set; }

        [Column("nome_local")]
        public string NomeLocal { get; set; }

        [Column("lotacao")]
        public int? Lotacao { get; set; }

        [Column("qtd_apresentacoes")]
        public int? QtdApresentacoes { get; set; }

        [Column("endereco_completo")]
        public string EnderecoCompleto { get; set; }
    }
}
