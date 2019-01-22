using GP.Aplicacao.ViewModels;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using System;
using System.Collections.Generic;

namespace GP.Aplicacao.Interfaces.ServicosApp
{
    public interface IMarcaServicoApp : IBaseServicosApp<MarcaViewModel>
    {
        void Atualizar(Guid id, MarcaViewModel viewModel);
        IList<PatrimonioViewModel> BuscarPatrimonios(Guid id);
    }
}
