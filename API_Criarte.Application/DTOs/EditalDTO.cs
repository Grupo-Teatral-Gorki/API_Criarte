using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class EditalDTO
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string DataInicial { get; set; }

        public string DataFinal { get; set; }

        public double ValorProjeto { get; set; }
    }
}
