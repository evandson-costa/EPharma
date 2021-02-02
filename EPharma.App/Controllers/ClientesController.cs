using AutoMapper;
using EPharma.App.ViewModels;
using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await ObterClientePorId(id));
        }
     
        public async Task<IActionResult> Create()
        {    
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) 
                return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Adicionar(cliente);

            //if (!OperacaoValida()) return View(clienteViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = await _clienteRepository.ObterPorId(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
           // await _clienteService.Atualizar(fornecedor);

           // if (!OperacaoValida()) return View(await ObterFornecedorProdutosEndereco(id));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = await ObterClientePorId(id);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedor = await ObterClientePorId(id);

            if (fornecedor == null) return NotFound();

            await _clienteRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ClienteViewModel> ObterClientePorId(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }

        private async Task<ClienteViewModel> PopularPlanos(ClienteViewModel cliente)
        {
            cliente.Planos = _mapper.Map<IEnumerable<PlanoViewModel>>(await _planoRepository.ObterPlanos((TipoCliente)cliente.TipoCliente));

            return cliente;
        }
    }
}
