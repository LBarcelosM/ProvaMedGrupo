using AutoMapper;
using Prova.MedGrupo.Application.ViewModels;
using Prova.MedGrupo.Domain.Entities;

namespace Prova.MedGrupo.Application.AutoMapperConfig
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContatoViewModel, Contato>();
        }
    }
}