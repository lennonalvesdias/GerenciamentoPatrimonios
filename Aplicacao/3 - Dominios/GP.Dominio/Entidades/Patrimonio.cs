using RecursosCompartilhados.Dominio.Entidades;
using System;

namespace GP.Dominio.Entidades
{
    public class Patrimonio : BaseEntidade
    {
        public Patrimonio(string nome, string marcaId, string descricao)
        {
            Nome = nome;
            MarcaId = marcaId;
            Descricao = descricao;
            NumeroTombo = Guid.NewGuid().ToString();
        }

        protected Patrimonio() { }

        public string Nome { get; private set; }
        public string MarcaId { get; private set; }
        public string Descricao { get; private set; }
        public string NumeroTombo { get; internal set; }
    }
}
