using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs.TipoChamado;
using API.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Controllers
{
    public class TipoChamadoController : Controller
    {
        private ITipoChamadoService _service;

        public TipoChamadoController(ITipoChamadoService service)
        {
            _service = service;
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
                return View(new List<TipoChamadoDto>());
            }
        }
        public IActionResult Create()
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao")] TipoChamadoCreateInput model)
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

            var categoria = await _service.GetAsync(id);
            if (categoria?.Data == null)
            {
                return NotFound();
            }

            return View(categoria.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Descricao")] TipoChamadoUpdateInput model)
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
