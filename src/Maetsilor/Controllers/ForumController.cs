using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Maetsilor.Data;
using Maetsilor.Models.ForumViewModels;

namespace Maetsilor.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext _context = null;
        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Forum
        public ActionResult Index()
        {
            List<Sujet> ls = new List<Sujet>();
            foreach(Sujet s in _context.Sujets)
            {
                ls.Add(s);
            }
            return View(ls);
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            Sujet s = _context.Sujets.FirstOrDefault(su => su.ID == id);
            return View(s);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Sujet sujet = new Sujet();
                TryUpdateModelAsync(sujet);
                sujet.NbRéponse = 0;
                sujet.DateCréation = DateTime.Now;
                sujet.Auteur = HttpContext.User.Identity.Name.ToString(); 
                _context.Sujets.Add(sujet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Home");
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            Sujet s = _context.Sujets.FirstOrDefault(su=>su.ID == id);
            return View(s);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Sujet sujet = _context.Sujets.FirstOrDefault(su => su.ID == id);
                TryUpdateModelAsync(sujet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Sujet s = _context.Sujets.FirstOrDefault(su => su.ID == id);
                _context.Sujets.Remove(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Sujet s = _context.Sujets.FirstOrDefault(su => su.ID == id);
                _context.Sujets.Remove(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}