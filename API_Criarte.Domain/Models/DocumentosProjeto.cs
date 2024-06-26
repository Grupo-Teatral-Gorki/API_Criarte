using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Models
{
    [Table("projeto", Schema = "documentos")]
    public class DocumentosProjeto
    {
        [Key]
        public int IdDocumento { get; set; }

        [Required]
        public int IdProjeto { get; set; }

        [Required]
        public int IdTipo { get; set; }

        [StringLength(50)]
        public string NomeArquivo { get; set; }

        [StringLength(10)]
        public string Formato { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
