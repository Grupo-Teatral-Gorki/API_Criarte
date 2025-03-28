using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class AlterarStatusDTO
    {
        public int IdProjeto {  get; set; }
        public string Status { get; set; }
    }
}
