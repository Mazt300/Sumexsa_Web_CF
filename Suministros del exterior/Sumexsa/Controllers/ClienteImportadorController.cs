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
    public class ClienteImportadorController : Controller
    {
        private readonly INotyfService notif;
        private ClienteImportadorService clienteImportadorService = new ClienteImportadorService();

        public ClienteImportadorController( INotyfService _notyf)
        {
            notif = _notyf;
        }

        // GET: ClienteImportador
        public ActionResult Index()
        {
            return View(clienteImportadorService.ObtenerClienteImportador());
        }

        // GET: ClienteImportador/Details/5
        public ActionResult Details(int? id)
        {
           try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var clienteImportador = clienteImportadorService.OBtenerClienteImportadorXid(id);
                if (clienteImportador == null)
                {
                    return NotFound();
                }

                return View(clienteImportador);
            }
            catch (Exception ex)
            {
                notif.Warning(ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ClienteImportador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteImportador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Idclienteimportador,Ruc_Cedula,Direccion,Telefono,Nombre,Estado")] ClienteImportador clienteImportador, [Bind("Nombre,Telefono,Correo")] PersonaContacto personaContacto)
        {
           try
            {
                if (clienteImportador != null && personaContacto != null)
                {
                    clienteImportador.PersonaContacto = personaContacto;
                    bool respuesta = clienteImportadorService.GuardarClienteImportador(clienteImportador);
                    if (respuesta)
                    {
                        notif.Success("Importador creado correctamente");
                    }
                }
                else
                {
                    notif.Error("Error en el guardado contactar con tecnología");
                    return View(clienteImportador);
                }
            }
            catch (Exception ex)
            {
                notif.Warning(ex.Message.ToString());
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ClienteImportador/Edit/5
        public ActionResult Edit(int? id)
        {
          try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var clienteImportador = clienteImportadorService.OBtenerClienteImportadorXid(id);
                if (clienteImportador == null)
                {
                    return NotFound();
                }
                return View(clienteImportador);
            }
            catch(Exception ex)
            {
                notif.Warning(ex.Message.ToString());
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ClienteImportador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Idclienteimportador,Ruc_Cedula,Direccion,Telefono,Nombre,Estado")] ClienteImportador clienteImportador, [Bind("IdPersonaContacto,Nombre,Telefono,Correo,TipoCliente")] PersonaContacto personaContacto)
        {
            try
            {
                if (id != clienteImportador.Idclienteimportador)
                {
                    return NotFound();
                }

                if (clienteImportador != null && personaContacto != null)
                {
                    try
                    {
                        clienteImportador.PersonaContacto = personaContacto;
                        bool respuesta = clienteImportadorService.EditarClienteImportador(clienteImportador);
                        if (respuesta)
                        {
                            notif.Success("Importador editado correctamente");
                        }
                        else
                        {
                            notif.Error("Error en la edición contactar con tecnología");
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClienteImportadorExists(clienteImportador.Idclienteimportador))
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
                return View(clienteImportador);
            }
            catch(Exception ex)
            {
                notif.Warning(ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ClienteImportador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clienteImportador = clienteImportadorService.OBtenerClienteImportadorXid(id);
            if (clienteImportador == null)
            {
                return NotFound();
            }

            return View(clienteImportador);
        }

        // POST: ClienteImportador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var clienteImportador = clienteImportadorService.OBtenerClienteImportadorXid(id);
                clienteImportador.Estado = "D";
                bool respuesta = clienteImportadorService.EditarClienteImportador(clienteImportador);
                if (respuesta)
                {
                    notif.Success("¡Se ha dado de baja al importador!",4);
                }
                else
                {
                    notif.Error("El cliente no se a podido dar de baja contacte con tecnología");
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                notif.Warning(ex.Message.ToString());
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ClienteImportadorExists(int id)
        {
            return clienteImportadorService.VerificarCliente(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult notificarlimpiezadecampos()
        {
            if(HttpContext.Request.Form.ContainsKey("btn_limpiar"))
            {
                notif.Warning("Los campos se han limpiado",4);
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
