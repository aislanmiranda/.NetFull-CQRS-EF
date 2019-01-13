using AutoMapper;
using Red.Domain.Models;
using Red.Service.ViewModels;

namespace Red.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
