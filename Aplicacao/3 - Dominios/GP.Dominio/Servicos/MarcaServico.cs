using GP.Dominio.Entidades;
using GP.Dominio.Interfaces.Repositorios;
using GP.Dominio.Interfaces.Servicos;
using MediatR;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;
using RecursosCompartilhados.Dominio.Servicos;

namespace GP.Dominio.Servicos
{
    public class MarcaServico : BaseServicos<Marca>, IMarcaServico
    {
        private readonly GerenciadorDeNotificacoes _gerenciadorDeNotificacoes;

        private readonly IMarcaRepositorio _marcaRepositorio;

        public MarcaServico(IMarcaRepositorio marcaRepositorio, INotificationHandler<NotificacaoDeDominio> notificationHandler) : base(marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
            _gerenciadorDeNotificacoes = (GerenciadorDeNotificacoes)notificationHandler;
        }

        public void Inserir(Marca marca)
        {
            if (_marcaRepositorio.ExisteMarca(marca.Id, marca.Nome))
            {
                _gerenciadorDeNotificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Já existe uma marca com esse nome."));
                return;
            }
            _marcaRepositorio.Inserir(marca);
        }

        public void Atualizar(Marca marca)
        {
            if (_marcaRepositorio.ExisteMarca(marca.Id, marca.Nome))
            {
                _gerenciadorDeNotificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Já existe uma marca com esse nome."));
                return;
            }
            _marcaRepositorio.Atualizar(marca);
        }
    }
}
