using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class IntegrantesDTO
    {
        public int IdProjeto { get; set; }

        public string NomeCompleto { get; set; }

        public char TipoPessoa { get; set; }

        public string Funcao { get; set; }

        public string? Cpf { get; set; }

        public string? Cnpj { get; set; }
    }
}
