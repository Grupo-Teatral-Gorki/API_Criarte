using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class ProjetosDTO
    {
        public string NumeroInscricao {  get; set; }
        public string NomeProjeto { get; set; }
        public string NumeroEdital { get; set; }
        public string TituloEdital { get; set; }
        public string Modalidade { get; set; }
        public string Proponente { get; set; }
        public string Status { get; set; }
    }
}
