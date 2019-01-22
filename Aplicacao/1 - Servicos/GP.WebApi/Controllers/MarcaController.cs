using GP.Aplicacao.Interfaces.ServicosApp;
using GP.Aplicacao.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;
using System;

namespace GP.WebApi.Controllers
{
    public class MarcaController : BaseController
    {
        private readonly IMarcaServicoApp _marcaServicoApp;

        public MarcaController(INotificationHandler<NotificacaoDeDominio> notificacoes, IMarcaServicoApp marcaServicoApp) : base(notificacoes)
        {
            _marcaServicoApp = marcaServicoApp;
        }

        [HttpGet]
        [Route("marcas")]
        public IActionResult Get()
        {
            return Response(_marcaServicoApp.Listar());
        }

        [HttpGet]
        [Route("marcas/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_marcaServicoApp.Buscar(id));
        }

        [HttpPost]
        [Route("marcas")]
        public IActionResult Post([FromBody]MarcaViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _marcaServicoApp.Inserir(vm);

            return Response(vm);
        }

        [HttpPut]
        [Route("marcas/{id:guid}")]
        public IActionResult Put(Guid id, [FromBody]MarcaViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }
            
            _marcaServicoApp.Atualizar(id, vm);

            return Response(vm);
        }

        [HttpDelete]
        [Route("marcas/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _marcaServicoApp.Remover(id);

            return Response();
        }

        [HttpGet]
        [Route("marcas/{id:guid}/patrimonios")]
        public IActionResult GetPatrimonios(Guid id)
        {
            return Response(_marcaServicoApp.BuscarPatrimonios(id));
        }
    }
}
