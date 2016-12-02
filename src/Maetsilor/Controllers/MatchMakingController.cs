using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Maetsilor.Data;
using Maetsilor.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Maetsilor.Models.MatchMakingViewModel;
using Microsoft.EntityFrameworkCore;

namespace Maetsilor.Controllers
{
    public class MatchMakingController : Controller
    {
        private ApplicationDbContext _context = null;
        private readonly UserManager<ApplicationUser> _userManager;

        public MatchMakingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: MatchMaking
        public ActionResult Index()
        {
            List<Group> groups = _context.Groups.ToList();
            return View(groups);
        }

        // GET: MatchMaking
        public ActionResult IndexUserGroups()
        {
            ApplicationUser user = _context.Users.First(u => u.UserName == HttpContext.User.Identity.Name);

            if (user == null)
            {
                return View("Error");
            }
            List<Group> groups = new List<Group>();
            foreach (Group g in _context.Groups)
            {
                if (g.Membres.Contains(user)) { groups.Add(g); }
            }
            return View(groups);
        }

        // GET: MatchMaking/Details/5
        public ActionResult Details(int id)
        {
            Group g = _context.Groups.Where(gr => gr.ID == id).Single();
            if(g.MaitreDuJeu == null)
            {
                return RedirectToAction("IndexUserGroups");
            }
            return View(g);
        }

        // GET: MatchMaking/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: MatchMaking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ApplicationUser user = _context.Users.First(u => u.UserName == HttpContext.User.Identity.Name);
                if (user == null)
                {
                    return View("Error");
                }
                Group g = new Group();
                TryUpdateModelAsync(g);
                g.MaitreDuJeu = user.UserName;
                g.ID = 0;
                g.Membres = new List<ApplicationUser>();
                g.Chat = new List<ChatMessage>();
                g.Membres.Add(user);
                _context.Add(g);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MatchMaking/Edit/5
        public ActionResult Edit(int id)
        {
            Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
            return View(g);
        }

        // POST: MatchMaking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
                TryUpdateModelAsync(g);
                _context.SaveChanges();
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: MatchMaking/Delete/5
        public ActionResult Delete(int id)
        {
            Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
            return View(g);
        }

        // POST: MatchMaking/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
                _context.Groups.Remove(g);
                _context.SaveChanges();
                return RedirectToAction("IndexUserGroups");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Join(int id, IFormCollection collection)
        {
            try
            {
                ApplicationUser user = _context.Users.First(u => u.UserName == HttpContext.User.Identity.Name);
                if (user == null)
                {
                    return View("Error");
                }
                Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
                if (!g.RequeteEnAttente.Contains(user) && !g.Membres.Contains(user))
                {
                    g.RequeteEnAttente.Add(user);
                    _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}