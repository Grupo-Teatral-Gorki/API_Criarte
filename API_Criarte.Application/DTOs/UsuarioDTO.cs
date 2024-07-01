using API_Criarte.Domain.Validation;
using API_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class UsuarioDTO
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int IdCidade { get; set; }
    }
}
