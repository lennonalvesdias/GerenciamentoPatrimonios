using AutoMapper;
using GP.Aplicacao.ViewModels;
using GP.Dominio.Entidades;

namespace GP.Aplicacao.AutoMapper
{
    public class ViewModelEntidadeMappingProfile : Profile
    {
        public ViewModelEntidadeMappingProfile()
        {
            CreateMap<PatrimonioViewModel, Patrimonio>();
            CreateMap<MarcaViewModel, Marca>();
        }
    }
}
