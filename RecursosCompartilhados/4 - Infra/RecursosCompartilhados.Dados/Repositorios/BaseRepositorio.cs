using Microsoft.EntityFrameworkCore;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using System;
using System.Linq;

namespace RecursosCompartilhados.Dados.Repositorios
{
    public class BaseRepositorio<TEntidade, TContexto> : IBaseRepositorio<TEntidade> where TEntidade : class where TContexto : DbContext, new()
    {
        protected TContexto Contexto { get; set; } = new TContexto();
        protected readonly DbSet<TEntidade> DbSet;

        public BaseRepositorio() {
            DbSet = Contexto.Set<TEntidade>();
        }

        public virtual void Inserir(TEntidade entidade)
        {
            DbSet.Add(entidade);
            Salvar();
        }

        public virtual TEntidade Buscar(Guid codigo)
        {
            return DbSet.Find(codigo);
        }

        public virtual IQueryable<TEntidade> Listar()
        {
            return DbSet;
        }

        public virtual void Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            Salvar();
        }

        public virtual void Remover(Guid codigo)
        {
            DbSet.Remove(DbSet.Find(codigo));
            Salvar();
        }

        public int Salvar()
        {
            return Contexto.SaveChanges();
        }

        public void Descartar()
        {
            Contexto.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}