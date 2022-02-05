using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs.Chamado;
using API.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Controllers
{
    public class ChamadoController : Controller
    {
        private IChamadoService _service;
        private ITipoChamadoService _serviceTipoChamado;
        private IChamadoCriticidadeService _servicoChamadoCriticidade;
        private IChamadoStatusService _servicoStatus;
        public ChamadoController(IChamadoService service, ITipoChamadoService serviceTipoChamado, IChamadoCriticidadeService servicoChamadoCriticidade, IChamadoStatusService servicoStatus)
        {
            _service = service;
            _serviceTipoChamado = serviceTipoChamado;
            _servicoChamadoCriticidade = servicoChamadoCriticidade;
            _servicoStatus = servicoStatus;
        }
        // GET: Projects
        public async Task<IActionResult> Index()
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var result = await _service.GetListAsync();
            if (result.Sucess)
            {
                return View(result.Data);
            }
            else
            {
                return View(new List<ChamadoDto>());
            }
        }
        public async Task<IActionResult> Create()
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var tipoChamadoService = await _serviceTipoChamado.GetListAsync();
            ViewBag.TipoChamados = tipoChamadoService.Data;

            var chamadoCriticidadeService = await _servicoChamadoCriticidade.GetListAsync();
            ViewBag.ChamadoCriticidades = chamadoCriticidadeService.Data;

            var chamadoStatusService = await _servicoStatus.GetListAsync();
            ViewBag.ChamadoStatus = chamadoStatusService.Data;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoChamado,DtChamadoAbertura,DtChamadoUltimaAcao,IdChamadoCriticidade,IdChamadoStatus,DescricaoChamado")] ChamadoCreateInput model)
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.Post(model);

            if (result.Sucess)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var chamado = await _service.GetAsync(id);
            if (chamado?.Data == null)
            {
                return NotFound();
            }

            var tipoChamadoService = await _serviceTipoChamado.GetListAsync();
            ViewBag.TipoChamados = tipoChamadoService.Data;

            var chamadoCriticidadeService = await _servicoChamadoCriticidade.GetListAsync();
            ViewBag.ChamadoCriticidades = chamadoCriticidadeService.Data;

            var servicoStatus = await _servicoStatus.GetListAsync();
            ViewBag.ChamadoStatus = servicoStatus.Data;

            return View(chamado.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Descricao,ImagemUrl")] ChamadoUpdateInput model)
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Put(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(long id)
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var categoria = await _service.GetAsync(id);
            if (categoria?.Data == null)
            {
                return NotFound();
            }

            return View(categoria.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
