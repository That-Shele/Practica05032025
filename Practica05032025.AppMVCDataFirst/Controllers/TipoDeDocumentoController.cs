using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica05032025.AppMVCDataFirst.Models;

namespace Practica05032025.AppMVCDataFirst.Controllers
{
    public class TipoDeDocumentoController : Controller
    {
        private readonly CatalogosDbContext _context;

        public TipoDeDocumentoController(CatalogosDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeDocumento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDeDocumentos.ToListAsync());
        }

        // GET: TipoDeDocumento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDeDocumento = await _context.TiposDeDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposDeDocumento == null)
            {
                return NotFound();
            }

            return View(tiposDeDocumento);
        }

        // GET: TipoDeDocumento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeDocumento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] TiposDeDocumento tiposDeDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposDeDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDeDocumento);
        }

        // GET: TipoDeDocumento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDeDocumento = await _context.TiposDeDocumentos.FindAsync(id);
            if (tiposDeDocumento == null)
            {
                return NotFound();
            }
            return View(tiposDeDocumento);
        }

        // POST: TipoDeDocumento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] TiposDeDocumento tiposDeDocumento)
        {
            if (id != tiposDeDocumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposDeDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposDeDocumentoExists(tiposDeDocumento.Id))
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
            return View(tiposDeDocumento);
        }

        // GET: TipoDeDocumento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDeDocumento = await _context.TiposDeDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposDeDocumento == null)
            {
                return NotFound();
            }

            return View(tiposDeDocumento);
        }

        // POST: TipoDeDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposDeDocumento = await _context.TiposDeDocumentos.FindAsync(id);
            if (tiposDeDocumento != null)
            {
                _context.TiposDeDocumentos.Remove(tiposDeDocumento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposDeDocumentoExists(int id)
        {
            return _context.TiposDeDocumentos.Any(e => e.Id == id);
        }
    }
}
