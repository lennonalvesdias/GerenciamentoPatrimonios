using GP.Dados.Contexto;
using GP.Dominio.Entidades;
using GP.Dominio.Interfaces.Repositorios;
using RecursosCompartilhados.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GP.Dados.Repositorios
{
    public class PatrimonioRepositorio : BaseRepositorio<Patrimonio, GPContexto>, IPatrimonioRepositorio
    {
        public IList<Patrimonio> ListarPorMarca(string marcaId)
        {
            return Contexto.Set<Patrimonio>().Where(x => x.MarcaId == marcaId).ToList();
        }
    }
}
