using API_Criarte.Application.DTOs;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;
using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Infra.Data.Context;
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

        public ProjetoService(ISegmentoRepository segmentoRepository, IFontesFinanciamentoRepository fontesFinanciamentoRepository, 
            IFonteFinanciamentoRepository fonteFinanciamentoRepository, IProjetoRepository projetoRepository, 
            IGrupoDespesasRepository grupoDespesasRepository, IRubricaRepository rubricaRepository, ITipoUnidadeRepository tipoUnidadeRepository, 
            IDespesasRepository despesasRepository, IResponsaveisTecnicosRepository responsaveisTecnicosRepository, 
            ILocaisRepository locaisRepository, IIntegrantesRepository integrantesRepository, IDetentoresRepository detentoresRepository, 
            dbContext dbContext)
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
        }

        public async Task<ApiResponse<List<ProjetosDTO>>> GetProjetos()
        {
            var projetos = await (from x in dbContext.Projeto
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

        public async Task<ApiResponse<List<ProjetosDTO>>> GetProjetoById(int idProjeto)
        {
            var projetos = await (from x in dbContext.Projeto
                                  where x.IdProjeto == idProjeto
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
    }
}
