using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("proponente", Schema = "documentos")]
    public class DocumentosProponente
    {
        [Key]
        [Column("id_documento")]
        public int IdDocumento { get; set; }

        [Required]
        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [Required]
        [Column("id_tipo")]
        public int IdTipo { get; set; }

        [StringLength(50)]
        [Column("nome_arquivo")]
        public string NomeArquivo { get; set; }

        [StringLength(10)]
        [Column("formato")]
        public string Formato { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; }
    }
}
