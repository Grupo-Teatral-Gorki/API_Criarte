using API_Criarte.Application.DTOs;
using API_Criarte.Domain.Models;
using AutoMapper;

namespace API_Criarte.Application.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Usuarios, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioLoginDTO, UsuarioDTO>().ReverseMap();
            CreateMap<Proponentes, ProponenteDTO>().ReverseMap();
            CreateMap<Proponentes, CreateProponenteDTO>().ReverseMap();
            CreateMap<Modalidades, ModalidadesDTO>().ReverseMap();
            CreateMap<Edital, EditalDTO>().ReverseMap();
            CreateMap<Segmento, SegmentoDTO>().ReverseMap();
            CreateMap<Projeto, CreateProjetoDTO>().ReverseMap();
            CreateMap<FontesFinanciamento, FontesFinanciamentoDTO>().ReverseMap();
            CreateMap<Despesas, DespesasDTO>().ReverseMap();
            CreateMap<ResponsaveisTecnicos, ResponsaveisTecnicosDTO>().ReverseMap();
            CreateMap<Locais, LocaisDTO>().ReverseMap();
            CreateMap<Integrantes, IntegrantesDTO>().ReverseMap();
            CreateMap<Detentores, DetentoresDTO>().ReverseMap();
        }
    }
}
