using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IDetentoresRepository
    {
        Task<List<Detentores>> GetDetentores();
        Task<List<Detentores>> GetDetentoresById(int idProjeto);
        Task<Detentores> CreateDetentores(Detentores detentor);
        Task<int> UpdateDetentores(Detentores detentor);
    }
}
