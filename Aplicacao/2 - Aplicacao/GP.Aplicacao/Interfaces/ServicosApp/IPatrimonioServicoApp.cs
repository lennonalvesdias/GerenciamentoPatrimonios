using GP.Aplicacao.ViewModels;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using System;

namespace GP.Aplicacao.Interfaces.ServicosApp
{
    public interface IPatrimonioServicoApp : IBaseServicosApp<PatrimonioViewModel>
    {
        void Atualizar(Guid id, PatrimonioViewModel viewModel);
    }
}
