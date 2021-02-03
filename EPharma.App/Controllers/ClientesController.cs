using AutoMapper;
using EPharma.App.ViewModels;
using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPharma.App.Controllers
{
    public class ClientesController : Controller
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IPlanoRepository _planoRepository;

        public ClientesController(
            IClienteRepository clienteRepository, 
            IMapper mapper,
            IPlanoRepository planoRepository
        )
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _planoRepository = planoRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }

        [Route("detalhe-de-clientes/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var clientesviewModel = await ObterClientePlanosPorId(id);

            if (clientesviewModel == null)
            {
                return NotFound();
            }

            return View(clientesviewModel);
        }

        [Route("novo-de-clientes")]
        public IActionResult Create()
        {    
            return View();
        }

        [Route("novo-de-clientes")]
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) 
                return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            cliente.DataCadastro = DateTime.Now;

            await _clienteRepository.Adicionar(cliente);

            //if (!OperacaoValida()) return View(clienteViewModel);

            return RedirectToAction("Index");
        }

        [Route("editar-de-cliente/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = await ObterClientePorId(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [Route("editar-de-cliente/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteRepository.Atualizar(cliente);

           // if (!OperacaoValida()) return View(await ObterFornecedorProdutosEndereco(id));

            return RedirectToAction("Index");
        }

        [Route("excluir-de-cliente/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = await ObterClientePorId(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [Route("excluir-de-cliente/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cliente = await ObterClientePorId(id);

            if (cliente == null)
                return NotFound();

            await _clienteRepository.Remover(_mapper.Map<Cliente>(cliente));

            return RedirectToAction("Index");
        }

        private async Task<ClienteViewModel> ObterClientePorId(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }

        private async Task<ClienteViewModel> ObterClientePlanosPorId(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClientesPlanos(id));
        }
    }
}
