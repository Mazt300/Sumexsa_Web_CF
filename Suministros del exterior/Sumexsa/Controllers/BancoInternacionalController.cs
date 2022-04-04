#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;
using Modelo.Modelo.TablasCatalogo;
using Servicio.LinQConsultas.PV;

namespace Sumexsa.Controllers
{
    public class BancoInternacionalController : Controller
    {
        private BancoService bancoService = new BancoService();
        private INotyfService notyf;

        public BancoInternacionalController(INotyfService _notyf)
        {
            notyf = _notyf;
        }

        // GET: Banco_Internacional
        public IActionResult Index()
        {
            return View(bancoService.ObtenerBancosInternacionales());
        }

        // GET: Banco_Internacional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancoInternacional = bancoService.ObtenerBancoInternacionalXId(id);
            if (bancoInternacional == null)
            {
                return NotFound();
            }

            return View(bancoInternacional);
        }

        // GET: Banco_Internacional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banco_Internacional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BancoInternacional bancoInternacional)
        {
            if (ModelState.IsValid)
            {
                bancoInternacional.Estado = "A";
                var respuesta = bancoService.GuardarBancoInternacional(bancoInternacional);
                if(respuesta)
                {
                    notyf.Success("Banco registrado correctamente");
                }
                else
                {
                    notyf.Error("Algo sucedio, contactar con tecnología");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bancoInternacional);
        }

        // GET: Banco_Internacional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancoInternacional = bancoService.ObtenerBancoInternacionalXId(id);
            if (bancoInternacional == null)
            {
                return NotFound();
            }
            return View(bancoInternacional);
        }

        // POST: Banco_Internacional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BancoInternacional bancoInternacional)
        {
            if (id != bancoInternacional.IdBancoInternacional)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bancoInternacional.Estado = "A";
                    var respuesta = bancoService.EditarBancoInternacional(bancoInternacional);
                    if (respuesta)
                    {
                        notyf.Success("Banco editado correctamente");
                    }
                    else
                    {
                        notyf.Error("Algo sucedio, contactar con tecnología");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BancoInternacionalExists(bancoInternacional.IdBancoInternacional))
                    {
                        return NotFound();
                    }
                    else
                    {
                        notyf.Error("Algo sucedio, contactar con tecnología"); 
                    }
                    notyf.Error("Algo sucedio, contactar con tecnología");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bancoInternacional);
        }

        // GET: Banco_Internacional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancoInternacional = bancoService.ObtenerBancoInternacionalXId(id);
            if (bancoInternacional == null)
            {
                return NotFound();
            }

            return PartialView(bancoInternacional);
        }

        // POST: Banco_Internacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var IdBancoInternacional = bancoService.ObtenerBancoInternacionalXId(id);
            IdBancoInternacional.Estado = "D";
            var bancoInternacional = bancoService.DarBajaBancoInternacional(IdBancoInternacional);
            return RedirectToAction(nameof(Index));
        }

        private bool BancoInternacionalExists(int id)
        {
            return bancoService.VerificarBancoInternacional(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult notificarlimpiezadecampos()
        {
            if (HttpContext.Request.Form.ContainsKey("btn_limpiar"))
            {
                notyf.Information("Los campos se han limpiado", 4);
            }
            return RedirectToAction(nameof(Create));
        }
        public ActionResult Redireccionar(int id)
        {
            if (id > 0)
            {
                DeleteConfirmed(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
