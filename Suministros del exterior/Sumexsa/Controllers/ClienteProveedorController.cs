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
    public class ClienteProveedorController : Controller
    {
        private readonly ClienteExtranjeroService clienteExtranjeroService = new ClienteExtranjeroService();
        private readonly INotyfService notyf;

        public ClienteProveedorController(INotyfService notyf_)
        {
            notyf = notyf_;
        }

        // GET: ClienteProveedor
        public ActionResult Index()
        {
            return View(clienteExtranjeroService.ObtenerClienteExtranjero());
        }

        // GET: ClienteProveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteProveedor = clienteExtranjeroService.OBtenerClienteExtranjeroXid(id);
            if (clienteProveedor == null)
            {
                return NotFound();
            }

            return View(clienteProveedor);
        }

        // GET: ClienteProveedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteProveedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdClienteProveedor,Nombre,Pais,Ciudad,Telefono,Direccion,Estado")] ClienteProveedor clienteProveedor, [Bind("Nombre,Telefono,Correo")] PersonaContacto personaContacto)
        {
            if (clienteProveedor != null && personaContacto != null)
            {
                clienteProveedor.Estado = "A";
                personaContacto.TipoCliente = "ClienteProveedor";
                clienteProveedor.PersonaContacto = personaContacto;
                bool respuesta = clienteExtranjeroService.GuardarClienteExtranjero(clienteProveedor);
                if(respuesta)
                {
                    notyf.Success("Registro ingresado correctamente");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    notyf.Error("Error al registrar información contacte con tecnología");
                    return View(clienteProveedor);
                }
            }
            return View(clienteProveedor);
        }

        // GET: ClienteProveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteProveedor = clienteExtranjeroService.OBtenerClienteExtranjeroXid(id);
            if (clienteProveedor == null)
            {
                return NotFound();
            }
            return View(clienteProveedor);
        }

        // POST: ClienteProveedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdClienteProveedor,Nombre,Pais,Ciudad,Telefono,Direccion,Estado")] ClienteProveedor clienteProveedor, [Bind("IdPersonaContacto,Nombre,Telefono,Correo,TipoCliente")] PersonaContacto personaContacto)
        {
            if (id != clienteProveedor.IdClienteProveedor)
            {
                return NotFound();
            }

            if (clienteProveedor != null && personaContacto != null)
            {
                try
                {
                    clienteProveedor.PersonaContacto = personaContacto;
                    bool respuesta = clienteExtranjeroService.EditarClienteExtranjero(clienteProveedor);
                    if (respuesta)
                    {
                        notyf.Success("Registro editado correctamente",4);
                    }
                    else
                    {
                        notyf.Error("Error en la edicion, contactar con tecnología",4);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteProveedorExists(clienteProveedor.IdClienteProveedor))
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
            return View(clienteProveedor);
        }

        // GET: ClienteProveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteProveedor = clienteExtranjeroService.OBtenerClienteExtranjeroXid(id);
            if (clienteProveedor == null)
            {
                return NotFound();
            }

            return View(clienteProveedor);
        }

        // POST: ClienteProveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var clienteProveedor = clienteExtranjeroService.OBtenerClienteExtranjeroXid(id);
            clienteProveedor.Estado = "D";
            bool respuesta = clienteExtranjeroService.EditarClienteExtranjero(clienteProveedor);
            if (respuesta)
            {
                notyf.Success("Cliente dado de baja correctamente");
            }
            else
            {
                notyf.Error("Error al dar baja, contactar con tecnología");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteProveedorExists(int id)
        {
            return clienteExtranjeroService.VerificarClienteExtranjero(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult notificarlimpiezadecampos()
        {
            if (HttpContext.Request.Form.ContainsKey("btn_limpiar"))
            {
                notyf.Warning("Los campos se han limpiado", 4);
            }
            return RedirectToAction(nameof(Create));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Redireccionar(int id)
        {

            if (HttpContext.Request.Form.ContainsKey("btn_confirmar"))
            {
                DeleteConfirmed(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
