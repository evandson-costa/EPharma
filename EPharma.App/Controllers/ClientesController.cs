using AutoMapper;
using EPharma.App.ViewModels;
using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPharma.App.Controllers
{
    public class ClientesController : BaseController
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

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var retorno = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());

            if (!String.IsNullOrEmpty(searchString))
            {
                retorno = retorno.Where(s => s.Nome.Contains(searchString)
                    || s.CpfCnpj.Contains(searchString));
            }

            return View(retorno);
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

            foreach (var item in clienteViewModel.PlanoId)
            {
                var plano = _planoRepository.ObterPorId(item).Result;
                plano.Cliente = cliente;
                await _planoRepository.Atualizar(plano);
            }           

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

            var planos = _planoRepository.ObterPlanosIdCliente(id);    

            await _clienteRepository.Remover(_mapper.Map<Cliente>(cliente));

            foreach (var item in planos)
            {
                item.ClienteId = null;
                await _planoRepository.Atualizar(item);
            }

            return RedirectToAction("Index");
        }       

        [Route("getPlanos")]
        [HttpGet]
        public IActionResult GetPlanos()
        {
            var id = Request.Query["handler"];
            return Json(_planoRepository.ObterPlanos((TipoCliente)Convert.ToInt32(id))); ;
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
