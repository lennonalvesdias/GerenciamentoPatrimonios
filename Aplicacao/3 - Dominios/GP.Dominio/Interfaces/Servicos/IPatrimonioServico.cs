using GP.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GP.Dominio.Interfaces.Servicos
{
    public interface IPatrimonioServico : IBaseServicos<Patrimonio>
    {
        IList<Patrimonio> ListarPorMarca(Guid marcaId);
    }
}
