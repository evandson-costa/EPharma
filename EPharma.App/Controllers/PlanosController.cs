using AutoMapper;
using EPharma.App.ViewModels;
using EPharma.Business.Interfaces;
using EPharma.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPharma.App.Controllers
{
    public class PlanosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlanoRepository _planoRepository;
        private readonly IClienteRepository _clienteRepository;

        public PlanosController(
            IMapper mapper,
            IPlanoRepository planoRepository,
            IClienteRepository clienteRepository
        )
        {
            _mapper = mapper;
            _planoRepository = planoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PlanoViewModel>>(await _planoRepository.ObterTodos()));
        }

        [Route("detalhe-do-plano-de-saude/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var planoViewModel = await ObterPlano(id);

            if (planoViewModel == null)
            {
                return NotFound();
            }

            return View(planoViewModel);
        }

        [Route("criar-plano-de-saude")]
        public IActionResult Create()
        {
            return View();
        }     

        [HttpPost]
        public async Task<IActionResult> Create(PlanoViewModel planoViewModel)
        {
           
            if (!ModelState.IsValid) 
                return View(planoViewModel);

            await _planoRepository.Adicionar(_mapper.Map<Plano>(planoViewModel));

           // if (!OperacaoValida()) return View(planoViewModel);

            return RedirectToAction("Index");
        }

        //[ClaimsAuthorize("Produto", "Editar")]
        [Route("editar-plano-de-saude/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var planoViewModel = await ObterPlano(id);

            if (planoViewModel == null)
            {
                return NotFound();
            }

            return View(planoViewModel);
        }
           
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PlanoViewModel planoViewModel)
        {
            if (id != planoViewModel.Id) 
                return NotFound();
            
            if (!ModelState.IsValid) 
                return View(planoViewModel);

            //var plano = await ObterPlano(id);

            planoViewModel.DataCadastro = DateTime.Now;

            await _planoRepository.Atualizar(_mapper.Map<Plano>(planoViewModel));

            //if (!OperacaoValida()) return View(planoViewModel);

            return RedirectToAction("Index");
        }
                
        [Route("excluir-plano-de-saude/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var plano = await ObterPlano(id);

            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        //[ClaimsAuthorize("Produto", "Excluir")]
        //[Route("excluir-plano/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var plano = await ObterPlano(id);

                if (plano == null)
                {
                    return NotFound();
                }
               
                await _planoRepository.Remover(_mapper.Map<Plano>(plano));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }           

            //if (!OperacaoValida()) return View(plano);

            TempData["Sucesso"] = "Plano excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<PlanoViewModel> ObterPlano(Guid id)
        {
            return _mapper.Map<PlanoViewModel>(await _planoRepository.ObterPorId(id));
        }
    }
}
