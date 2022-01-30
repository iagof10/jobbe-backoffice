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
    }
}
