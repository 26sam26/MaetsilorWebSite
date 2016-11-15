using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Maetsilor.Data;
using Maetsilor.Models;

namespace Maetsilor.Controllers
{
    public class MembreController : Controller
    {
        private ApplicationDbContext _context = null;
        public MembreController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Membre
        public ActionResult Index(string OrdreTri = null, string searchTerm = null, string searchField = null, int page = 1)
        {
            List<Membre> lmvm = new List<Membre>();
            foreach(ApplicationUser appUser in _context.Users)
            {
               lmvm.Add(new Membre(appUser));
            }

            if (HttpContext.Request.IsAjaxRequest())
                return PartialView("_IndexPartial", lmvm);
            else
                return View(lmvm);
        }

        // GET: Membre/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Membre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Membre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Membre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {

                ApplicationUser allo = _context.Users.Where(m => m.Id == id).Single();
               //No fucking clue. Sory
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Membre/Delete/5
        public ActionResult Delete(string id)
        {
            _context.Remove(_context.Users.Where(m => m.Id == id).Single());
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // POST: Membre/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}