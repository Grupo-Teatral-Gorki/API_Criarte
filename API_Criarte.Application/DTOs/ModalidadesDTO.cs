using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class ModalidadesDTO
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public double ValorTeto { get; set; }

        public bool PessoaJuridica { get; set; }
    }
}
