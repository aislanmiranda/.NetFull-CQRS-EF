using AutoMapper;
using Red.Domain.Commands;
using Red.Service.ViewModels;

namespace Red.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, RegisterNewUsuarioCommand>()
                .ConstructUsing(c => new RegisterNewUsuarioCommand(c.Nome, c.Email, c.Senha));
            CreateMap<UsuarioViewModel, UpdateUsuarioCommand>()
                .ConstructUsing(c => new UpdateUsuarioCommand(c.Id, c.Nome, c.Email, c.Senha));
        }
    }
}
