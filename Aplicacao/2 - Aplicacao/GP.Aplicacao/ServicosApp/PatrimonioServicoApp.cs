using System;
using System.Collections.Generic;
using AutoMapper;
using GP.Aplicacao.Interfaces.ServicosApp;
using GP.Aplicacao.ViewModels;
using GP.Dominio.Entidades;
using GP.Dominio.Interfaces.Servicos;

namespace GP.Aplicacao.ServicosApp
{
    public class PatrimonioServicoApp : IPatrimonioServicoApp
    {
        private readonly IPatrimonioServico _patrimonioServico;
        private readonly IMapper _mapper;

        public PatrimonioServicoApp(IPatrimonioServico patrimonioServico, IMapper mapper)
        {
            _patrimonioServico = patrimonioServico;
            _mapper = mapper;
        }

        public void Atualizar(PatrimonioViewModel viewModel)
        {
            var patrimonio = _mapper.Map<Patrimonio>(viewModel);
            _patrimonioServico.Atualizar(patrimonio);
        }

        public void Atualizar(Guid id, PatrimonioViewModel viewModel)
        {
            viewModel.Id = id;
            var marca = _mapper.Map<Patrimonio>(viewModel);
            _patrimonioServico.Atualizar(marca);
        }

        public PatrimonioViewModel Buscar(Guid id)
        {
            var patrimonio = _patrimonioServico.Buscar(id);
            return _mapper.Map<PatrimonioViewModel>(patrimonio);
        }

        public void Dispose()
        {
            _patrimonioServico.Dispose();
        }

        public void Inserir(PatrimonioViewModel viewModel)
        {
            var patrimonio = _mapper.Map<Patrimonio>(viewModel);
            _patrimonioServico.Inserir(patrimonio);
        }

        public IList<PatrimonioViewModel> Listar()
        {
            var patrimonios = _patrimonioServico.Listar();
            return _mapper.Map<IList<PatrimonioViewModel>>(patrimonios);
        }

        public void Remover(Guid id)
        {
            _patrimonioServico.Remover(id);
        }

        public int Salvar()
        {
            return _patrimonioServico.Salvar();
        }
    }
}
