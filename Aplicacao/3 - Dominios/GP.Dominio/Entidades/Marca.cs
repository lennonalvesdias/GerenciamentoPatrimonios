using RecursosCompartilhados.Dominio.Entidades;

namespace GP.Dominio.Entidades
{
    public class Marca : BaseEntidade
    {
        public Marca(string nome)
        {
            Nome = nome;
        }

        protected Marca() { }

        public string Nome { get; private set; }
    }
}
