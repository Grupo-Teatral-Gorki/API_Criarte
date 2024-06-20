using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class ProjetoCompletoDTO
    {
        public Projeto Projeto { get; set; }
        public List<FontesFinanciamento>? FontesFinanciamento { get; set; }
        public List<Despesas>? Despesas { get; set; }
        public List<ResponsaveisTecnicos>? ResponsaveisTecnicos { get; set; }
        public List<Locais>? Locais { get; set; }
        public List<Integrantes>? Integrantes { get; set; }
        public List<Detentores>? Detentores { get; set; }
    }
}
