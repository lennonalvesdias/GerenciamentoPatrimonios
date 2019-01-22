using System;
using System.Linq;

namespace RecursosCompartilhados.Dominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio<TEntidade> : IDisposable where TEntidade : class
    {
        void Inserir(TEntidade entidade);
        TEntidade Buscar(Guid id);
        IQueryable<TEntidade> Listar();
        void Atualizar(TEntidade entidade);
        void Remover(Guid id);
        int Salvar();
    }
}