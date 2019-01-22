using GP.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;

namespace GP.Dominio.Interfaces.Repositorios
{
    public interface IPatrimonioRepositorio : IBaseRepositorio<Patrimonio>
    {
        IList<Patrimonio> ListarPorMarca(string marcaId);
    }
}
