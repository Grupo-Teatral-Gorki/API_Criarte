using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IFonteFinanciamentoRepository
    {
        Task<List<FonteFinanciamento>> GetFonteFinanciamento();
        Task<int> CreateFonteFinanciamento(FonteFinanciamento fontes);
        Task<int> UpdateFonteFinanciamento(FonteFinanciamento fontes);
    }
}
