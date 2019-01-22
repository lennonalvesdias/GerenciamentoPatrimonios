using AutoMapper;
using GP.Aplicacao.Interfaces.ServicosApp;
using GP.Aplicacao.ViewModels;
using GP.Dominio.Entidades;
using GP.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GP.Aplicacao.ServicosApp
{
    public class MarcaServicoApp : IMarcaServicoApp
    {
        private readonly IMarcaServico _marcaServico;
        private readonly IPatrimonioServico _patrimonioServico;
        private readonly IMapper _mapper;

        public MarcaServicoApp(IMarcaServico marcaServico, IMapper mapper, IPatrimonioServico patrimonioServico)
        {
            _marcaServico = marcaServico;
            _mapper = mapper;
            _patrimonioServico = patrimonioServico;
        }

        public void Atualizar(MarcaViewModel viewModel)
        {
            var marca = _mapper.Map<Marca>(viewModel);
            _marcaServico.Atualizar(marca);
        }

        public void Atualizar(Guid id, MarcaViewModel viewModel)
        {
            viewModel.Id = id;
            var marca = _mapper.Map<Marca>(viewModel);
            _marcaServico.Atualizar(marca);
        }

        public MarcaViewModel Buscar(Guid id)
        {
            var marca = _marcaServico.Buscar(id);
            return _mapper.Map<MarcaViewModel>(marca);
        }

        public void Dispose()
        {
            _marcaServico.Dispose();
        }

        public void Inserir(MarcaViewModel viewModel)
        {
            var marca = _mapper.Map<Marca>(viewModel);
            _marcaServico.Inserir(marca);
        }

        public IList<MarcaViewModel> Listar()
        {
            var marcas = _marcaServico.Listar();
            return _mapper.Map<IList<MarcaViewModel>>(marcas);
        }

        public void Remover(Guid id)
        {
            _marcaServico.Remover(id);
        }

        public int Salvar()
        {
            return _marcaServico.Salvar();
        }

        public IList<PatrimonioViewModel> BuscarPatrimonios(Guid id)
        {
            var patrimonios = _patrimonioServico.ListarPorMarca(id);
            return _mapper.Map<IList<PatrimonioViewModel>>(patrimonios);
        }
    }
}
