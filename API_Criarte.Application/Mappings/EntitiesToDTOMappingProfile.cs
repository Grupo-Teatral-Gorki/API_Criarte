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
            CreateMap<Proponentes, ProponenteDTO>().ReverseMap();
            CreateMap<Proponentes, CreateProponenteDTO>().ReverseMap();
            CreateMap<Modalidades, ModalidadesDTO>().ReverseMap();
            CreateMap<Edital, EditalDTO>().ReverseMap();
        }
    }
}
