using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class UsuarioLogadoDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int TipoUsuario { get; set; }
        public int IdCidade { get; set; }
    }
}
