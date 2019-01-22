using GP.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using System;

namespace GP.Dominio.Interfaces.Repositorios
{
    public interface IMarcaRepositorio : IBaseRepositorio<Marca>
    {
        bool ExisteMarca(Guid id, string nome);
    }
}
