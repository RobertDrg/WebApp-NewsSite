#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Models;
using Site.Repositories.Interfaces;
using Site.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Site.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: News
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string searchString = null)
        {
            //var news = _newsService.GetAllQueryable();

            //if (searchString is not null)
            //{
            //    news = _newsService.GetByCondition(news => news.NewsTitle.Contains(searchString));
            //}
            //return View(await news.ToListAsync());
            var authors = _newsService.GetAllQueryable().Include(c => c.Author).Include(c => c.Newspaper);


            return View(await authors.ToListAsync());
        }

        // GET: News/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsService.GetAllQueryable()
                .Include(n => n.Author)
                .Include(n => n.Newspaper)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_newsService.GetAuthors(), "AuthorID", "AuthorID");
            ViewData["NewspaperID"] = new SelectList(_newsService.GetNewspapers(), "NewspaperID", "NewspaperID");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsID,NewsTitle,Category,Content,URL,NewsCreated,AuthorID,NewspaperID")] News news)
        {
            if (ModelState.IsValid)
            {
                _newsService.CreateFromEntity(news);
                await _newsService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_newsService.GetAuthors(), "AuthorID", "AuthorID", news.AuthorID);
            ViewData["NewspaperID"] = new SelectList(_newsService.GetNewspapers(), "NewspaperID", "NewspaperID", news.NewspaperID);
            return View(news);
        }

        // GET: News/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsService.GetAllQueryable().FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_newsService.GetAuthors(), "AuthorID", "AuthorID", news.AuthorID);
            ViewData["NewspaperID"] = new SelectList(_newsService.GetNewspapers(), "NewspaperID", "NewspaperID", news.NewspaperID);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsID,NewsTitle,Category,Content,URL,NewsCreated,AuthorID,NewspaperID")] News news)
        {
            if (id != news.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _newsService.UpdateFromEntity(news);
                    await _newsService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsID))
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
            ViewData["AuthorID"] = new SelectList(_newsService.GetAuthors(), "AuthorID", "AuthorID", news.AuthorID);
            ViewData["NewspaperID"] = new SelectList(_newsService.GetNewspapers(), "NewspaperID", "NewspaperID", news.NewspaperID);
            return View(news);
        }

        // GET: News/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsService.GetAllQueryable()
                .Include(n => n.Author)
                .Include(n => n.Newspaper)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _newsService.GetAllQueryable().FirstOrDefaultAsync(m => m.NewsID == id);
            _newsService.DeleteFromEntity(news);
            await _newsService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _newsService.GetAllQueryable().Any(e => e.NewsID == id);
        }

        [HttpGet]
        public IActionResult SearchNews(string newsTitle, [Bind("NewsID,NewsTitle,Category,URL,Content,NewsCreated,AuthorFirstName,NewspaperID")] News news)
        {
            var newss = _newsService.GetNewsByTitle(newsTitle).Include(c => c.Author).Include(c => c.Newspaper); ;
            ViewData["AuthorID"] = new SelectList(_newsService.GetAuthors(), "AuthorID", "AuthorID");
            ViewData["PublisherID"] = new SelectList(_newsService.GetNewspapers(), "NewspaperID", "NewspaperID");
            return View(newss);
        }

        [HttpGet]
        public IActionResult NewsPage(int id, [Bind("NewsID,NewsTitle,Category,URL,Content,NewsCreated,AuthorFirstName,NewspaperID")] News news)
        {
            var newss = _newsService.GetNewsById(id).Include(c => c.Author).Include(c => c.Newspaper);
            ViewData["AuthorID"] = new SelectList(_newsService.GetAuthors(), "AuthorID", "AuthorID", "AuthorFirstname");
            ViewData["PublisherID"] = new SelectList(_newsService.GetNewspapers(), "NewspaperID", "NewspaperID");
            return View(newss);
        }
    }
}
