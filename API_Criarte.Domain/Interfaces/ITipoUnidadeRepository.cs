using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface ITipoUnidadeRepository
    {
        Task<List<TipoUnidade>> GetTipoUnidade();
        Task<int> CreateTipoUnidade(TipoUnidade tipo);
        Task<int> UpdateTipoUnidade(TipoUnidade tipo);
    }
}
