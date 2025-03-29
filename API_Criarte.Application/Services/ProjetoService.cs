using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Infra.Data.Context;
using API_Lib;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly ISegmentoRepository segmentoRepository;
        private readonly IFontesFinanciamentoRepository fontesFinanciamentoRepository;
        private readonly IFonteFinanciamentoRepository fonteFinanciamentoRepository;
        private readonly IProjetoRepository projetoRepository;
        private readonly IGrupoDespesasRepository grupoDespesasRepository;
        private readonly IRubricaRepository rubricaRepository;
        private readonly ITipoUnidadeRepository tipoUnidadeRepository;
        private readonly IDespesasRepository despesasRepository;
        private readonly IResponsaveisTecnicosRepository responsaveisTecnicosRepository;
        private readonly ILocaisRepository locaisRepository;
        private readonly IIntegrantesRepository integrantesRepository;
        private readonly IDetentoresRepository detentoresRepository;

        private readonly dbContext dbContext;
        private readonly IMapper mapper;

        private readonly IHttpContextAccessor user;
        private int id_usuario;
        private int id_tipo;

        public ProjetoService(ISegmentoRepository segmentoRepository, IFontesFinanciamentoRepository fontesFinanciamentoRepository, 
            IFonteFinanciamentoRepository fonteFinanciamentoRepository, IProjetoRepository projetoRepository, 
            IGrupoDespesasRepository grupoDespesasRepository, IRubricaRepository rubricaRepository, ITipoUnidadeRepository tipoUnidadeRepository, 
            IDespesasRepository despesasRepository, IResponsaveisTecnicosRepository responsaveisTecnicosRepository, 
            ILocaisRepository locaisRepository, IIntegrantesRepository integrantesRepository, IDetentoresRepository detentoresRepository, 
            dbContext dbContext, IMapper mapper, IHttpContextAccessor user)
        {
            this.segmentoRepository = segmentoRepository;
            this.fontesFinanciamentoRepository = fontesFinanciamentoRepository;
            this.fonteFinanciamentoRepository = fonteFinanciamentoRepository;
            this.projetoRepository = projetoRepository;
            this.grupoDespesasRepository = grupoDespesasRepository;
            this.rubricaRepository = rubricaRepository;
            this.tipoUnidadeRepository = tipoUnidadeRepository;
            this.despesasRepository = despesasRepository;
            this.responsaveisTecnicosRepository = responsaveisTecnicosRepository;
            this.locaisRepository = locaisRepository;
            this.integrantesRepository = integrantesRepository;
            this.detentoresRepository = detentoresRepository;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.user = user;

            id_usuario = Convert.ToInt32(AlterClaim.GetClaimValue(this.user.HttpContext.User, "id_usuario"));
            id_tipo = Convert.ToInt32(AlterClaim.GetClaimValue(this.user.HttpContext.User, "id_tipo"));
        }

        public async Task<ApiResponse<List<ProjetosDTO>>> GetProjetos()
        {
            if (id_usuario <= 0)
            {
                return new ApiResponse<List<ProjetosDTO>>(true, "Não é um usuario valido");
            }
            var projetos = await (from x in dbContext.Projeto
                                  where (x.IdUsuario == id_usuario || id_tipo != 1)
                                  join p in dbContext.Proponentes on x.IdProponente equals p.IdProponente into pGroup
                                  from p in pGroup.DefaultIfEmpty()
                                  join e in dbContext.Edital on x.IdEdital equals e.IdEdital into eGroup
                                  from e in eGroup.DefaultIfEmpty()
                                  join m in dbContext.Modalidades on x.IdModalidade equals m.IdModalidade into mGroup
                                  from m in mGroup.DefaultIfEmpty()
                                  select new ProjetosDTO()
                                  {
                                      NumeroInscricao = Convert.ToString(x.IdProjeto),
                                      NomeProjeto = x.NomeProjeto,
                                      NumeroEdital = e.Titulo,
                                      TituloEdital = e.Titulo,
                                      Modalidade = m.Titulo,
                                      Proponente = p.ResponsavelLegal,
                                      Status = x.Status

                                  }).AsNoTracking().ToListAsync().ConfigureAwait(false);

            if (!projetos.IsNullOrEmpty())
            {
                return new ApiResponse<List<ProjetosDTO>>(false, "Lista de projetos.", projetos);
            }
            else
            {
                return new ApiResponse<List<ProjetosDTO>>(true, "Nenhum projeto foi encontrado.");
            }
        }

        public async Task<ApiResponse<ProjetoCompletoDTO>> GetProjetoById(long idProjeto)
        {
            if (id_usuario <= 0)
            {
                return new ApiResponse<ProjetoCompletoDTO>(true, "Não é um usuario valido");
            }
            var projeto = await (from x in dbContext.Projeto
                                  where x.IdProjeto == idProjeto && (x.IdUsuario == id_usuario || id_tipo != 1)
                                  select new ProjetoCompletoDTO()
                                  {
                                      Projeto = x,
                                      FontesFinanciamento = dbContext.FontesFinanciamento.Where(x => x.IdProjeto.Equals(idProjeto))
                                                                            .AsNoTracking()
                                                                            .ToList(),
                                      Despesas = dbContext.Despesas.Where(x => x.IdProjeto.Equals(idProjeto))
                                                                            .AsNoTracking()
                                                                            .ToList(),
                                      ResponsaveisTecnicos = dbContext.ResponsaveisTecnicos.Where(x => x.IdProjeto.Equals(idProjeto))
                                                                            .AsNoTracking()
                                                                            .ToList(),
                                      Locais = dbContext.Locais.Where(x => x.IdProjeto.Equals(idProjeto))
                                                                            .AsNoTracking()
                                                                            .ToList(),
                                      Integrantes = dbContext.Integrantes.Where(x => x.IdProjeto.Equals(idProjeto))
                                                                            .AsNoTracking()
                                                                            .ToList(),
                                      Detentores = dbContext.Detentores.Where(x => x.IdProjeto.Equals(idProjeto))
                                                                            .AsNoTracking()
                                                                            .ToList()
        }).AsNoTracking().FirstOrDefaultAsync().ConfigureAwait(false);


            if (projeto != null)
            {
                return new ApiResponse<ProjetoCompletoDTO>(false, "Dados do Projeto.", projeto);
            }
            else
            {
                return new ApiResponse<ProjetoCompletoDTO>(true, "Nenhum projeto foi encontrado.");
            }
        }

        public async Task<ApiResponse<ProjetoCompletoDTO>> CreateProjeto(int idEdital, int idModalidade)
        {
            if(id_usuario <= 0)
            {
                return new ApiResponse<ProjetoCompletoDTO>(true, "Não é um usuario valido");
            }
            CreateProjetoDTO projetoDTO = new CreateProjetoDTO
            {
                IdEdital = idEdital,
                IdModalidade = idModalidade,
                IdUsuario = id_usuario
            };
            Projeto projeto = mapper.Map<Projeto>(projetoDTO);

            var idProjeto = await projetoRepository.CreateProjeto(projeto);

            if (idProjeto != 0)
            {
                ApiResponse<ProjetoCompletoDTO> CreatedProjeto = await GetProjetoById(idProjeto);
                return new ApiResponse<ProjetoCompletoDTO>(false, "Dados do Projeto.", CreatedProjeto.Data);
            }
            return new ApiResponse<ProjetoCompletoDTO>(true, "Nenhum projeto foi encontrado.");
        }

        public async Task<ApiResponse<int>> UpdateProjeto(Projeto projetoDTO)
        {
            int idProjeto = await projetoRepository.UpdateProjeto(projetoDTO);

            if (idProjeto != 0)
            {
                return new ApiResponse<int>(false, "Projeto atualizado com sucesso.");
            }
            return new ApiResponse<int>(true, "O projeto não foi atualizado.");
        }

        public async Task<ApiResponse<int>> AlterarStatus(int idProjeto, string status)
        {
            int result = await projetoRepository.AlterarStatus(idProjeto, status);

            if (result != 0)
            {
                return new ApiResponse<int>(false, "Projeto atualizado com sucesso.");
            }
            return new ApiResponse<int>(true, "O projeto não foi atualizado.");
        }
        public async Task<ApiResponse<List<FontesFinanciamento>>> GetFontesFinanceiras(int idProjeto)
        {
            List<FontesFinanciamento> fontes = await fontesFinanciamentoRepository.GetFontesFinanciamentoById(idProjeto);

            if (fontes is null)
            {
                return new ApiResponse<List<FontesFinanciamento>>(true, "Nenhuma fonte foi encontrada.");
            }
            return new ApiResponse<List<FontesFinanciamento>>(false, "Lista de fontes.", fontes);
        }

        public async Task<ApiResponse<FontesFinanciamento>> CreateFontesFinanceiras(FontesFinanciamentoDTO fonteDTO)
        {
            FontesFinanciamento fonte = mapper.Map<FontesFinanciamento>(fonteDTO);
            FontesFinanciamento result = await fontesFinanciamentoRepository.CreateFontesFinanciamento(fonte);

            if (result is null)
            {
                return new ApiResponse<FontesFinanciamento>(true, "Nenhuma fonte foi criada.");
            }
            return new ApiResponse<FontesFinanciamento>(false, "Fonte criada com sucesso.", result);
        }

        public async Task<ApiResponse<List<Despesas>>> GetDespesas(int idProjeto)
        {
            List<Despesas> despesas = await despesasRepository.GetDespesasById(idProjeto);

            if (despesas is null)
            {
                return new ApiResponse<List<Despesas>>(true, "Nenhuma despesa foi encontrada.");
            }
            return new ApiResponse<List<Despesas>>(false, "Lista de despesas.", despesas);
        }

        public async Task<ApiResponse<Despesas>> CreateDespesas(DespesasDTO despesaDTO)
        {
            Despesas despesa = mapper.Map<Despesas>(despesaDTO);
            Despesas result = await despesasRepository.CreateDespesas(despesa);

            if (result is null)
            {
                return new ApiResponse<Despesas>(true, "Nenhuma despesa foi criada.");
            }
            return new ApiResponse<Despesas>(false, "Despesa criada com sucesso.", result);
        }

        public async Task<ApiResponse<List<ResponsaveisTecnicos>>> GetResponsaveisTecnicos(int idProjeto)
        {
            List<ResponsaveisTecnicos> responsaveis = await responsaveisTecnicosRepository.GetResponsaveisTecnicosById(idProjeto);

            if (responsaveis is null)
            {
                return new ApiResponse<List<ResponsaveisTecnicos>>(true, "Nenhum responsavel foi encontrado.");
            }
            return new ApiResponse<List<ResponsaveisTecnicos>>(false, "Lista de responsaveis.", responsaveis);
        }

        public async Task<ApiResponse<ResponsaveisTecnicos>> CreateResponsaveisTecnicos(ResponsaveisTecnicosDTO responsavelDTO)
        {
            ResponsaveisTecnicos responsavel = mapper.Map<ResponsaveisTecnicos>(responsavelDTO);
            ResponsaveisTecnicos result = await responsaveisTecnicosRepository.CreateResponsaveisTecnicos(responsavel);

            if (result is null)
            {
                return new ApiResponse<ResponsaveisTecnicos>(true, "Nenhum responsavel foi criado.");
            }
            return new ApiResponse<ResponsaveisTecnicos>(false, "Responsavel criada com sucesso.", result);
        }

        public async Task<ApiResponse<List<Locais>>> GetLocais(int idProjeto)
        {
            List<Locais> Locais = await locaisRepository.GetLocaisById(idProjeto);

            if (Locais is null)
            {
                return new ApiResponse<List<Locais>>(true, "Nenhum Local foi encontrado.");
            }
            return new ApiResponse<List<Locais>>(false, "Lista de Locais.", Locais);
        }

        public async Task<ApiResponse<Locais>> CreateLocais(LocaisDTO responsavelDTO)
        {
            Locais responsavel = mapper.Map<Locais>(responsavelDTO);
            Locais result = await locaisRepository.CreateLocais(responsavel);

            if (result is null)
            {
                return new ApiResponse<Locais>(true, "Nenhum Local foi criado.");
            }
            return new ApiResponse<Locais>(false, "Local criado com sucesso.", result);
        }

        public async Task<ApiResponse<List<Integrantes>>> GetIntegrantes(int idProjeto)
        {
            List<Integrantes> integrantes = await integrantesRepository.GetIntegrantesById(idProjeto);

            if (integrantes is null)
            {
                return new ApiResponse<List<Integrantes>>(true, "Nenhum integrante foi encontrado.");
            }
            return new ApiResponse<List<Integrantes>>(false, "Lista de integrantes.", integrantes);
        }

        public async Task<ApiResponse<Integrantes>> CreateIntegrantes(IntegrantesDTO integranteDTO)
        {
            Integrantes integrante = mapper.Map<Integrantes>(integranteDTO);
            Integrantes result = await integrantesRepository.CreateIntegrantes(integrante);

            if (result is null)
            {
                return new ApiResponse<Integrantes>(true, "Nenhum integrante foi criado.");
            }
            return new ApiResponse<Integrantes>(false, "Integrante criado com sucesso.", result);
        }

        public async Task<ApiResponse<List<Detentores>>> GetDetentores(int idProjeto)
        {
            List<Detentores> detentores = await detentoresRepository.GetDetentoresById(idProjeto);

            if (detentores is null)
            {
                return new ApiResponse<List<Detentores>>(true, "Nenhum detentor foi encontrado.");
            }
            return new ApiResponse<List<Detentores>>(false, "Lista de detentores.", detentores);
        }

        public async Task<ApiResponse<Detentores>> CreateDetentores(DetentoresDTO detentorDTO)
        {
            Detentores detentor = mapper.Map<Detentores>(detentorDTO);
            Detentores result = await detentoresRepository.CreateDetentores(detentor);

            if (result is null)
            {
                return new ApiResponse<Detentores>(true, "Nenhum detentor foi criado.");
            }
            return new ApiResponse<Detentores>(false, "Detentor criado com sucesso.", result);
        }
    }
}
