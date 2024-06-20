using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class LocaisDTO
    {
        public int IdProjeto { get; set; }

        public int IdCidade { get; set; }

        public string? NomeLocal { get; set; }

        public int? Lotacao { get; set; }

        public int? QtdApresentacoes { get; set; }

        public string? EnderecoCompleto { get; set; }
    }
}
