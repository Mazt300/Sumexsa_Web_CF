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
using Modelo.Modelo.TablaRelaciones;
using Modelo.Modelo.TablasCatalogo;
using Servicio.LinQConsultas.PV;

namespace Sumexsa.Controllers
{
    public class BancoProveedorController : Controller
    {
        private readonly BancoService bancoService = new BancoService();
        private readonly INotyfService notyf;
        public int id_bancoP = 0;

        public BancoProveedorController(INotyfService notyf_)
        {
            notyf = notyf_;
        }

        // GET: BancoInternacional
        public ActionResult Index()
        {
            return View(bancoService.ObtenerBancos());
        }

        // GET: BancoInternacional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool relacion = bancoService.ValidarBancoRelacion(id);
            BancoP_BancoI_Rel banco = new BancoP_BancoI_Rel();
            if (relacion)
            {
                banco = bancoService.ObtenerBancoProveedorXIdConRelacion(id);
            }
            else
            {
                banco = bancoService.ObtenerBancoProveedorXIdSinRelacion(id);
            }
            if (banco == null)
            {
                return NotFound();
            }

            return View(banco);
        }
        public void CargarBancosInternacionales()
        {
            var bancosinternacionales = bancoService.ObtenerBancosInternacionales();
            ViewData["Lista"] = new SelectList(bancosinternacionales, "IdBancoInternacional", "Nombre");
        }
        // GET: BancoInternacional/Create
        public IActionResult Create()
        {
            //Agregando la lista de bancos internacionales a un combobox o select
            CargarBancosInternacionales();
            return View();
        }

        // POST: BancoInternacional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(BancoP_BancoI_Rel bancoP_BancoI)
        {
            if (bancoP_BancoI != null)
            {

                bancoP_BancoI.Estado = "A";
                bancoP_BancoI.BancoP.Estado = "A";
                bool respuesta = bancoService.GuardarBancoProveedor(bancoP_BancoI);
                if (respuesta)
                {
                    notyf.Success("El banco se creo correctamente");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    notyf.Error("Error al registrar el banco, contacte con tecnología");
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: BancoInternacional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool relacion = bancoService.ValidarBancoRelacion(id);
            BancoP_BancoI_Rel banco = new BancoP_BancoI_Rel();
            if(relacion)
            {
                banco = bancoService.ObtenerBancoProveedorXIdConRelacion(id);
                CargarBancosInternacionales();
            }
            else
            {
                banco = bancoService.ObtenerBancoProveedorXIdSinRelacion(id);
                CargarBancosInternacionales();
            }
            if (banco == null)
            {
                return NotFound();
            }
            return View(banco);
        }

        // POST: BancoInternacional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BancoP_BancoI_Rel bancoP_BancoI)
        {
            if (id != bancoP_BancoI.BancoP.IdBanco)
            {
                return NotFound();
            }

            if (bancoP_BancoI != null)
            {
                try
                {
                    bancoP_BancoI.Estado = "A";
                    bancoP_BancoI.BancoP.Estado = "A";
                    bool respuesta = bancoService.EditarBancoProveedor(id,bancoP_BancoI);
                    if(respuesta)
                    {
                        notyf.Success("Banco modificado correctamente");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        notyf.Error("Error no se pudo modificar, contacte con tecnología");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BancoInternacionalExists(bancoP_BancoI.BancoP.IdBanco))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bancoP_BancoI);
        }

        // GET: BancoInternacional/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //id_bancoP = id;
            var bancoInternacional = bancoService.ObtenerBancoProveedorXId(id);
            if (bancoInternacional == null)
            {
                return NotFound();
            }

            return PartialView("Delete",bancoInternacional);
        }

        // POST: BancoInternacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bancoProveedor = bancoService.ObtenerBancoProveedorXId(id);
            bancoProveedor.Estado = "D";
            bool respuesta = bancoService.DarBajaBancoProveedor(bancoProveedor);
            if (respuesta)
            {
                notyf.Success("Banco dado de baja correctamente");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                notyf.Error("Error al dar de baja, contactar con tecnología");
                return RedirectToAction(nameof(Index));
            }
        }

        private bool BancoInternacionalExists(int id)
        {
            return bancoService.VerificarBanco(id);
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
    }
}
