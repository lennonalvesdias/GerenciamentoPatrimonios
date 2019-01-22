using GP.Aplicacao.Interfaces.ServicosApp;
using GP.Aplicacao.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;
using System;

namespace GP.WebApi.Controllers
{
    public class PatrimonioController : BaseController
    {
        private readonly IPatrimonioServicoApp _patrimonioServicoApp;

        public PatrimonioController(INotificationHandler<NotificacaoDeDominio> notificacoes, IPatrimonioServicoApp patrimonioServicoApp) : base(notificacoes)
        {
            _patrimonioServicoApp = patrimonioServicoApp;
        }

        [HttpGet]
        [Route("patrimonios")]
        public IActionResult Get()
        {
            return Response(_patrimonioServicoApp.Listar());
        }

        [HttpGet]
        [Route("patrimonios/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_patrimonioServicoApp.Buscar(id));
        }

        [HttpPost]
        [Route("patrimonios")]
        public IActionResult Post([FromBody]PatrimonioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _patrimonioServicoApp.Inserir(vm);

            return Response(vm);
        }

        [HttpPut]
        [Route("patrimonios/{id:guid}")]
        public IActionResult Put(Guid id, [FromBody]PatrimonioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _patrimonioServicoApp.Atualizar(id, vm);

            return Response(vm);
        }

        [HttpDelete]
        [Route("patrimonios/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _patrimonioServicoApp.Remover(id);

            return Response();
        }
    }
}
