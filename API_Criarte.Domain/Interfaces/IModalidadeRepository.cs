using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IModalidadeRepository
    {
        Task<List<Modalidades>> GetModalidades();
        Task<int> CreateModalidade(Modalidades modalidade);
    }
}
