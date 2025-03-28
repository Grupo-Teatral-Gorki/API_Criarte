using API_Criarte.Application.DTOs;
using API_Criarte.Domain;
using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<ApiResponse<List<ProjetosDTO>>> GetProjetos();
        Task<ApiResponse<ProjetoCompletoDTO>> GetProjetoById(int idProjeto);
        Task<ApiResponse<ProjetoCompletoDTO>> CreateProjeto(int idEdital, int idModalidade);
        Task<ApiResponse<int>> UpdateProjeto(Projeto projetoDTO);
        Task<ApiResponse<int>> AlterarStatus(int idProjeto, string status);
        Task<ApiResponse<List<FontesFinanciamento>>> GetFontesFinanceiras(int idProjeto);
        Task<ApiResponse<FontesFinanciamento>> CreateFontesFinanceiras(FontesFinanciamentoDTO fonteDTO);
        Task<ApiResponse<List<Despesas>>> GetDespesas(int idProjeto);
        Task<ApiResponse<Despesas>> CreateDespesas(DespesasDTO fonteDTO);
        Task<ApiResponse<List<ResponsaveisTecnicos>>> GetResponsaveisTecnicos(int idProjeto);
        Task<ApiResponse<ResponsaveisTecnicos>> CreateResponsaveisTecnicos(ResponsaveisTecnicosDTO fonteDTO);
        Task<ApiResponse<List<Locais>>> GetLocais(int idProjeto);
        Task<ApiResponse<Locais>> CreateLocais(LocaisDTO responsavelDTO);
        Task<ApiResponse<List<Integrantes>>> GetIntegrantes(int idProjeto);
        Task<ApiResponse<Integrantes>> CreateIntegrantes(IntegrantesDTO integranteDTO);
        Task<ApiResponse<List<Detentores>>> GetDetentores(int idProjeto);
        Task<ApiResponse<Detentores>> CreateDetentores(DetentoresDTO detentorDTO);
    }
}
