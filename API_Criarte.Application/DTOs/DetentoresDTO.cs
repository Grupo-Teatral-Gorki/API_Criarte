using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class DetentoresDTO
    {
        public int IdProjeto { get; set; }

        public string Detentor { get; set; }

        public string AcervoEnvolvido { get; set; }
    }
}
