using GP.Dominio.Entidades;
using GP.Dominio.Interfaces.Repositorios;
using GP.Dominio.Interfaces.Servicos;
using MediatR;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;
using RecursosCompartilhados.Dominio.Servicos;
using System;
using System.Collections.Generic;

namespace GP.Dominio.Servicos
{
    public class PatrimonioServico : BaseServicos<Patrimonio>, IPatrimonioServico
    {
        private readonly GerenciadorDeNotificacoes _gerenciadorDeNotificacoes;

        private readonly IPatrimonioRepositorio _patrimonioRepositorio;

        public PatrimonioServico(IPatrimonioRepositorio patrimonioRepositorio, INotificationHandler<NotificacaoDeDominio> notificationHandler) : base(patrimonioRepositorio)
        {
            _patrimonioRepositorio = patrimonioRepositorio;
            _gerenciadorDeNotificacoes = (GerenciadorDeNotificacoes)notificationHandler;
        }

        public void Inserir(Patrimonio patrimonio)
        {
            patrimonio.NumeroTombo = Guid.NewGuid().ToString();
            _patrimonioRepositorio.Inserir(patrimonio);
        }

        public void Atualizar(Patrimonio patrimonio)
        {
            var patrimonioBase = _patrimonioRepositorio.Buscar(patrimonio.Id);
            patrimonio.NumeroTombo = patrimonioBase.NumeroTombo;
            _patrimonioRepositorio.Atualizar(patrimonio);
        }

        public IList<Patrimonio> ListarPorMarca(Guid marcaId)
        {
            return _patrimonioRepositorio.ListarPorMarca(marcaId.ToString());
        }
    }
}
