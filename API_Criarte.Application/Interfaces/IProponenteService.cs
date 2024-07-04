using API_Criarte.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces
{
    public interface IProponenteService
    {
        Task<ProponenteDTO> GetProponente(int id_proponente);
        Task<List<ProponenteDTO>> GetProponenteByIdUsuario();
        Task<bool> CreateProponente(CreateProponenteDTO proponente);
        Task<bool> UpdateProponente(ProponenteDTO proponente);
    }
}
