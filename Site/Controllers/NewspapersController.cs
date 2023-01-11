#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Controllers
{
    public class NewspapersController : Controller
    {
        private readonly INewspaperService _newspaperService;

        public NewspapersController(INewspaperService newspaperService)
        {
            _newspaperService = newspaperService;
        }

        // GET: Newspapers
        public async Task<IActionResult> Index()
        {
            return View(await _newspaperService.GetAllQueryable().ToListAsync());
        }

        // GET: Newspapers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaper = await _newspaperService.GetAllQueryable()
                .FirstOrDefaultAsync(m => m.NewspaperID == id);
            if (newspaper == null)
            {
                return NotFound();
            }

            return View(newspaper);
        }

        // GET: Newspapers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Newspapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewspaperID,NewspaperName,NewspaperCountry")] Newspaper newspaper)
        {
            if (ModelState.IsValid)
            {
                _newspaperService.CreateFromEntity(newspaper);
                await _newspaperService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newspaper);
        }

        // GET: Newspapers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaper = await _newspaperService.GetAllQueryable().FirstAsync(m => m.NewspaperID == id);
            if (newspaper == null)
            {
                return NotFound();
            }
            return View(newspaper);
        }

        // POST: Newspapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewspaperID,NewspaperName,NewspaperCountry")] Newspaper newspaper)
        {
            if (id != newspaper.NewspaperID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _newspaperService.UpdateFromEntity(newspaper);
                    await _newspaperService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewspaperExists(newspaper.NewspaperID))
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
            return View(newspaper);
        }

        // GET: Newspapers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newspaper = await _newspaperService.GetAllQueryable()
                .FirstOrDefaultAsync(m => m.NewspaperID == id);
            if (newspaper == null)
            {
                return NotFound();
            }

            return View(newspaper);
        }

        // POST: Newspapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newspaper = await _newspaperService.GetAllQueryable().FirstOrDefaultAsync(m => m.NewspaperID == id);
            _newspaperService.DeleteFromEntity(newspaper);
            await _newspaperService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewspaperExists(int id)
        {
            return _newspaperService.GetAllQueryable().Any(e => e.NewspaperID == id);
        }
    }
}
