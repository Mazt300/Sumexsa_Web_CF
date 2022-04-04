#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;
using Modelo.Modelo.TablasCatalogo;

namespace Sumexsa.Controllers
{
    public class CuentaBancariaClienteController : Controller
    {
        private readonly DbContexto _context;

        public CuentaBancariaClienteController(DbContexto context)
        {
            _context = context;
        }

        // GET: CuentaBancariaCliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.CuentaBancariaCliente.ToListAsync());
        }

        // GET: CuentaBancariaCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaBancariaCliente = await _context.CuentaBancariaCliente
                .FirstOrDefaultAsync(m => m.IdBancoP_ClienteE == id);
            if (cuentaBancariaCliente == null)
            {
                return NotFound();
            }

            return View(cuentaBancariaCliente);
        }

        // GET: CuentaBancariaCliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuentaBancariaCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBancoP_ClienteE,Cuenta,Moneda,Swift,Estado,IdCliente,IdBanco")] CuentaBancariaCliente cuentaBancariaCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentaBancariaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuentaBancariaCliente);
        }

        // GET: CuentaBancariaCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaBancariaCliente = await _context.CuentaBancariaCliente.FindAsync(id);
            if (cuentaBancariaCliente == null)
            {
                return NotFound();
            }
            return View(cuentaBancariaCliente);
        }

        // POST: CuentaBancariaCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBancoP_ClienteE,Cuenta,Moneda,Swift,Estado,IdCliente,IdBanco")] CuentaBancariaCliente cuentaBancariaCliente)
        {
            if (id != cuentaBancariaCliente.IdBancoP_ClienteE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentaBancariaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaBancariaClienteExists(cuentaBancariaCliente.IdBancoP_ClienteE))
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
            return View(cuentaBancariaCliente);
        }

        // GET: CuentaBancariaCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaBancariaCliente = await _context.CuentaBancariaCliente
                .FirstOrDefaultAsync(m => m.IdBancoP_ClienteE == id);
            if (cuentaBancariaCliente == null)
            {
                return NotFound();
            }

            return View(cuentaBancariaCliente);
        }

        // POST: CuentaBancariaCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuentaBancariaCliente = await _context.CuentaBancariaCliente.FindAsync(id);
            _context.CuentaBancariaCliente.Remove(cuentaBancariaCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaBancariaClienteExists(int id)
        {
            return _context.CuentaBancariaCliente.Any(e => e.IdBancoP_ClienteE == id);
        }
    }
}
