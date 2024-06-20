using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.DTOs
{
    public class DespesasDTO
    {
        public int IdProjeto { get; set; }

        public int? IdGrupoDespesa { get; set; }

        public int? IdRubrica { get; set; }

        public int? IdTipoUnidade { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public decimal? Quantidade { get; set; }

        public decimal? ValorUnitario { get; set; }

        public string? Observacao { get; set; }
    }
}
