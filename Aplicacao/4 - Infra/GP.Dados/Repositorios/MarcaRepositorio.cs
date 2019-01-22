using GP.Dados.Contexto;
using GP.Dominio.Entidades;
using GP.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dados.Repositorios;
using System;
using System.Linq;

namespace GP.Dados.Repositorios
{
    public class MarcaRepositorio : BaseRepositorio<Marca, GPContexto>, IMarcaRepositorio
    {
        public bool ExisteMarca(Guid id, string nome)
        {
            return Contexto.Set<Marca>().Any(x => x.Id != id && x.Nome == nome);
        }
    }
}
