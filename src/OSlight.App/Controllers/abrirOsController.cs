using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OSlight.App.ViewModels;
using OSlight.Business.Interfaces;
using OSlight.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OSlight.App.Controllers
{
    public class abrirOsController : Controller
    {
        private readonly IAbrirOSRepository _abrirOSRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public abrirOsController(
            IAbrirOSRepository abrirOSRepository,
            IMapper iMapper,
            IEnderecoRepository enderecoRepositoy)
        {
            _abrirOSRepository = abrirOSRepository;
            _mapper = iMapper;
            _enderecoRepository = enderecoRepositoy;
        }

        [Route("lista-de-chamados")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AbrirOSViewModel>>(await _abrirOSRepository.ObterTodosChamados()));
        }

        [Route("dados-do-chamado/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var abrirOsViewModel = await ObterChamado(id);
            if (abrirOsViewModel == null) return NotFound();
            return View(abrirOsViewModel);
        }

        [Route("novo-chamado")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-chamado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AbrirOSViewModel abrirOSViewModel)
        {
            if (!ModelState.IsValid) return View(abrirOSViewModel);
            var abriros = _mapper.Map<AbrirOS>(abrirOSViewModel);
            await _abrirOSRepository.Adicionar(abriros);
            return RedirectToAction("Index");
        }

        [Route("editar-chamado/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var abrirOsViewModel = await ObterEndereco(id);
            if (abrirOsViewModel == null) return NotFound();
            return View(abrirOsViewModel);
        }
        [Route("editar-chamado/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AbrirOSViewModel abrirOSViewModel)
        {
            if (id != abrirOSViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(abrirOSViewModel);
            var abriros = _mapper.Map<AbrirOS>(abrirOSViewModel);
            await _abrirOSRepository.Atualizar(abriros);
            return RedirectToAction("Index");
        }

        [Route("excluir-chamado/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var abrirOsViewModel = await ObterEndereco(id);
            if (abrirOsViewModel == null) return NotFound();
            return View(abrirOsViewModel);
        }
        [Route("excluir-chamado/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var abrirOsViewModel = ObterEndereco(id);
            if (abrirOsViewModel == null) return NotFound();
            await _abrirOSRepository.Remover(id);
            return RedirectToAction("Index");
        }

        [Route("atualizar-endereco-chamado/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var chamado = await ObterEndereco(id);
            if (chamado == null) return NotFound();
            return View("AtualizarEndereco", new AbrirOSViewModel { Endereco = chamado.Endereco });
        }

        [HttpPost]
        [Route("atualizar-endereco-chamado/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(AbrirOSViewModel abrirOSViewModel)
        {
            ModelState.Remove("Titulo");
            ModelState.Remove("Descricao");
            ModelState.Remove("NumeroPoste");
            ModelState.Remove("NomeReclamante");
            if (!ModelState.IsValid) return View("AtualizarEndereco");
            await _enderecoRepository.Atualizar(_mapper.Map<Endereco>(abrirOSViewModel.Endereco));
            return RedirectToAction("Edit", new { id = abrirOSViewModel.Endereco.AbrirOSId });
        }

        private async Task<AbrirOSViewModel> ObterEndereco(Guid id)
        {
            return _mapper.Map<AbrirOSViewModel>(await _abrirOSRepository.ObterEnderecoOs(id));
        }

        private async Task<AbrirOSViewModel> ObterChamado(Guid id)
        {
            return _mapper.Map<AbrirOSViewModel>(await _abrirOSRepository.ObterChamado(id));
        }

    }
}
