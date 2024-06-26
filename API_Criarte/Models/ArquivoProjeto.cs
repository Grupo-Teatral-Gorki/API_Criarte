using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API_Criarte.Models
{
    public class ArquivoProjeto
    {
        [NotNull]
        public int IdProjeto { get; set; }

        [NotNull]
        public int IdTipo { get; set; }

        [NotNull]
        //[MaxLength(10)]
        public IFormFile Archive { get; set; }
    }
}
