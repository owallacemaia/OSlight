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
    public class fecharOsController : Controller
    {
        private readonly IFecharOSRepository _fecharOSRepository;
        private readonly IAbrirOSRepository _abrirOSRepository;
        private readonly IMapper _mapper;

        public fecharOsController(
            IFecharOSRepository fecharOSRepository,
            IMapper mapper,
            IAbrirOSRepository abrirOSRepository)
        {
            _fecharOSRepository = fecharOSRepository;
            _mapper = mapper;
            _abrirOSRepository = abrirOSRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FecharOSViewModel>>(await _fecharOSRepository.ObterTodosChamados()));
        }

        [Route("fechar-chamado/id:guid")]
        public IActionResult Create(Guid id)
        {
            var chamado = ObterChamado(id);
            int Status = chamado.Result.Status;
            if (Status == 2) return RedirectToRoute(new { controller = "abrirOs", action = "Edit", id = id });
            ViewData["AbrirOSId"] = chamado.Result.Id;
            return View();
        }

        [Route("fechar-chamado/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FecharOSViewModel fecharOSViewModel)
        {
            if (!ModelState.IsValid) return View(fecharOSViewModel);
            fecharOSViewModel.Id = Guid.NewGuid();
            await _fecharOSRepository.Adicionar(_mapper.Map<FecharOS>(fecharOSViewModel));
            var id = fecharOSViewModel.AbrirOSId;
            var abrirOSViewModel = _mapper.Map<AbrirOSViewModel>(await ObterChamado(id));
            abrirOSViewModel.Status = 2;
            await _abrirOSRepository.Atualizar(_mapper.Map<AbrirOS>(abrirOSViewModel));
            return RedirectToAction("Index");
        }

        [Route("editar-finalizacao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var chamado = await ObterFinal(id);
            return View(chamado);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-finalizacao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, FecharOSViewModel fecharOSViewModel)
        {
            if (!ModelState.IsValid) return View(fecharOSViewModel);
            var fecharOs = _mapper.Map<FecharOS>(fecharOSViewModel);
            await _fecharOSRepository.Atualizar(fecharOs);
            return RedirectToAction("Index");
        }



        private async Task<AbrirOSViewModel> ObterChamado(Guid id)
        {
            return _mapper.Map<AbrirOSViewModel>(await _abrirOSRepository.ObterChamado(id));
        }

        private async Task<FecharOSViewModel> ObterFinal(Guid id)
        {
            return _mapper.Map<FecharOSViewModel>(await _fecharOSRepository.ObterFinalChamado(id));
        }
    }

}
