using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IFontesFinanciamentoRepository
    {
        Task<List<FontesFinanciamento>> GetFontesFinanciamento();
        Task<List<FontesFinanciamento>> GetFontesFinanciamentoById(int idProjeto);
        Task<FontesFinanciamento> CreateFontesFinanciamento(FontesFinanciamento fontes);
        Task<int> UpdateFontesFinanciamento(FontesFinanciamento fontes);
    }
}
