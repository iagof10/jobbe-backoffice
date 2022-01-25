using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.DTOs.SubCategoria;
using API.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Controllers
{
    public class SubCategoriaController : Controller
    {
        private ISubCategoriaService _service;
        private ICategoriaService _serviceCategoria;

        public SubCategoriaController(ISubCategoriaService service, ICategoriaService serviceCategoria)
        {
            _service = service;
            _serviceCategoria = serviceCategoria;
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
                return View(new List<SubCategoriaDto>());
            }
        }

        public async Task<IActionResult> Create()
        {
            if (HttpContext?.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var categoriaService = await _serviceCategoria.GetListAsync();
            ViewBag.Categorias = categoriaService.Data;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Descricao,ImagemUrl")] SubCategoriaCreateInput model)
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
    }
}
