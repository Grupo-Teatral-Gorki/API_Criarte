using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("integrantes", Schema = "projeto")]
    public class Integrantes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Column("nome_completo")]
        public string NomeCompleto { get; set; }

        [Column("tipo_pessoa")]
        public char TipoPessoa { get; set; }

        [Column("funcao")]
        public string Funcao { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("cnpj")]
        public string Cnpj { get; set; }
    }
}
