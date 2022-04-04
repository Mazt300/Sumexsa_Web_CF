using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Sumexsa.Models;
using System.Diagnostics;

namespace Sumexsa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService notyfService;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf)
        {
            _logger = logger;
            notyfService = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Notificar()
        {
            if(HttpContext.Request.Form.ContainsKey("btn1"))
            {
                notyfService.Warning("NO TIENE NADA QUE GUARDAR");
            }
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult MostrarMensaje()
        {
            return PartialView("ConfirmacionRedireccionamiento");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Redireccionar(int ruta)
        {
            if (HttpContext.Request.Form.ContainsKey("btn_gestionBancoProveedor"))
            {
                if (ruta == 1)
                {
                    return RedirectToAction("Index","BancoProveedor");
                }
            }
            if (HttpContext.Request.Form.ContainsKey("btn_gestionCuentaProveedor"))
            {
                if (ruta == 2)
                {
                    return RedirectToAction("Index", "CuentaBancariaCliente");
                }
            }
            if (HttpContext.Request.Form.ContainsKey("btn_gestionBancoInternacional"))
            {
                if (ruta == 3)
                {
                    return RedirectToAction("Index", "BancoInternacional");
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}