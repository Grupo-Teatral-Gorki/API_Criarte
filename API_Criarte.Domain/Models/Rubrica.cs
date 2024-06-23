using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("rubricas", Schema = "geral")]
    public class Rubrica
    {
        [Key]
        [Column("id_rubrica")]
        public int IdRubrica { get; set; }

        [Column("nome_rubrica")]
        public string NomeRubrica { get; set; }
    }
}
