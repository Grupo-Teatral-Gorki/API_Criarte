using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface ISegmentoRepository
    {
        Task<List<Segmento>> GetSegmentos();
        Task<int> CreateSegmento(Segmento segmento);
        Task<int> UpdateEdital(Segmento segmento);
    }
}
