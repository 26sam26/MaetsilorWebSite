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
            foreach (UserGroup ug in _context.UserGroups)
            {
                if (ug.UserID == user.Id)
                {
                    Group g = _context.Groups.FirstOrDefault(gr => gr.ID == ug.GroupID);
                    groups.Add(g);
                }
            }
            return View(groups);
        }

        // GET: MatchMaking/Details/5
        public ActionResult Details(int id)
        {
            Group g = _context.Groups.Where(gr => gr.ID == id).Single();
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
        // GET: MatchMaking/IndexMembre/5
        public ActionResult IndexMembre(int id)
        {
            Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
            List<Membre> lm = new List<Membre>();
            foreach (UserGroup ug in _context.UserGroups)
            {
                if (ug.GroupID == g.ID && ug.IsMember)
                {
                    ApplicationUser user = _context.Users.FirstOrDefault(u => u.Id == ug.UserID);
                    Membre m = new Membre(user);
                    lm.Add(m);
                }
            }
            ViewData["GroupID"] = id;
            ViewData["GroupMaster"] = g.MaitreDuJeu;
            return View(lm);
        }
        // GET: MatchMaking/IndexDemandes
        public ActionResult IndexDemandes(int id)
        {
            Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
            List<Membre> lm = new List<Membre>();
            foreach (UserGroup ug in _context.UserGroups)
            {
                if (ug.GroupID == g.ID && !ug.IsMember)
                {
                    ApplicationUser user = _context.Users.FirstOrDefault(u => u.Id == ug.UserID);
                    Membre m = new Membre(user);
                    lm.Add(m);
                }
            }
            ViewData["GroupID"] = id;
            ViewData["GroupMaster"] = g.MaitreDuJeu;
            return View(lm);
        }

        // GET: MatchMaking/Chat
        public ActionResult Chat(int id)
        {
            Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
            List<ChatMessage> lm = new List<ChatMessage>();
            foreach (ChatMessage c in _context.ChatMessages.ToList())
            {
                if (c.GroupID == g.ID)
                {
                    lm.Add(c);
                }
            }
            ViewData["GroupID"] = id;
            ViewData["GroupMaster"] = g.MaitreDuJeu;
            return View(lm);
        }

        // GET: MatchMaking/ChatReply
        public ActionResult ChatReply(int id)
        {
            Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
            ViewData["GroupID"] = id;
            ViewData["GroupMaster"] = g.MaitreDuJeu;
            return View();
        }

        // POST: MatchMaking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChatReply(int id, ChatMessage reply)
        {
            try
            {
                ApplicationUser user = _context.Users.First(u => u.UserName == HttpContext.User.Identity.Name);
                if (user == null)
                {
                    return View("Error");
                }
                Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
                if (g == null)
                {
                    return View("Error");
                }
                ChatMessage m = reply;

                m.Auteur = user.ToString();
                m.Date = DateTime.UtcNow;
                m.Message = m.Auteur + ": " + m.Message;
                m.GroupID = g.ID;
                _context.Add(m);
                _context.SaveChanges();
                return RedirectToAction("Chat", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Details", new { id = g.ID });
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

                Group g = _context.Groups.Where(gr => gr.ID == id).Single();
                _context.Groups.Remove(g);
                _context.SaveChangesAsync();
                return RedirectToAction("IndexUserGroups");
            }
            catch
            {
                return RedirectToAction("Index");
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
                UserGroup ug = new UserGroup();
                ug.GroupID = g.ID;
                ug.UserID = user.Id;
                ug.IsMember = false;
                _context.Add(ug);
                _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KickMember(int id, string memberId)
        {
            try
            {
                UserGroup ug = _context.UserGroups.FirstOrDefault(u => u.GroupID == id && u.UserID == memberId);
                _context.Remove(ug);
                _context.SaveChangesAsync();
                return RedirectToAction("IndexMembre", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        // GET: MatchMaking/IndexCalendrier
        public ActionResult IndexCalendrier(int id)
        {
            Group g = _context.Groups.FirstOrDefault(gr => gr.ID == id);
            ViewData["GroupID"] = id;
            ViewData["GroupMaster"] = g.MaitreDuJeu;
            List<Partie> lp = new List<Partie>();
            foreach (Partie p in _context.Parties)
            {
                if (p.GroupID == g.ID)
                {
                    lp.Add(p);
                }
            }
            return View(lp);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelPartie(int id, int partieId)
        {
            Partie partie = _context.Parties.FirstOrDefault(p => p.ID == partieId);
            try
            {
                _context.Remove(partie);
                _context.SaveChangesAsync();
                return RedirectToAction("IndexCalendrier", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeclineMember(int id, string memberId)
        {
            try
            {
                UserGroup ug = _context.UserGroups.FirstOrDefault(u => u.GroupID == id && u.UserID == memberId);
                _context.Remove(ug);
                _context.SaveChangesAsync();
                return RedirectToAction("IndexDemandes", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptMember(int id, string memberId)
        {
            try
            {
                UserGroup ug = _context.UserGroups.FirstOrDefault(u => u.GroupID == id && u.UserID == memberId);
                ug.IsMember = true;
                _context.Update(ug);
                _context.SaveChangesAsync();
                return RedirectToAction("IndexDemandes", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CreatePartie(int id)
        {
            ViewData["GroupID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePartie(int id, Partie partie)
        {
            try
            {
                Partie p = new Partie();
                p.Date = partie.Date;
                p.Description = partie.Description;
                p.GroupID = id;
                _context.Parties.Add(p);
                _context.SaveChangesAsync();
                return RedirectToAction("IndexCalendrier", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}