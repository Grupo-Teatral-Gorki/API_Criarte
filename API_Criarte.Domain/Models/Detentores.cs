using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("detentores", Schema = "projeto")]
    public class Detentores
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Column("detentor")]
        public string Detentor { get; set; }

        [Column("acervo_envolvido")]
        public string AcervoEnvolvido { get; set; }
    }
}
