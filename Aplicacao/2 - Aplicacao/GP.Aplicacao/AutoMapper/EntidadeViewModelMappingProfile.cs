using AutoMapper;
using GP.Aplicacao.ViewModels;
using GP.Dominio.Entidades;

namespace GP.Aplicacao.AutoMapper
{
    public class EntidadeViewModelMappingProfile : Profile
    {
        public EntidadeViewModelMappingProfile()
        {
            CreateMap<Patrimonio, PatrimonioViewModel>();
            CreateMap<Marca, MarcaViewModel>();
        }
    }
}
