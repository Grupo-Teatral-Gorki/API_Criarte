using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("responsaveis_tecnicos", Schema = "projeto")]
    public class ResponsaveisTecnicos
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }
    }
}
