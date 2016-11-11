using Maetsilor.Models;
using Maetsilor.Models.ForumViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Data
{
    public class SeedData
    {

        #region Champs
        static PasswordHasher<ApplicationUser> _pass = new PasswordHasher<ApplicationUser>();
        #endregion

        #region Propriété
        public static ApplicationDbContext Context;
        #endregion

        public static void InitialiserRoles()
        {
            IdentityRole[] ir = new IdentityRole[]
            {
                new IdentityRole {Name = "Administrateur"},
                new IdentityRole {Name = "Utilisateur"},
                new IdentityRole {Name = "Moderateur"},
                new IdentityRole {Name = "ExclusionForum"},
                new IdentityRole {Name = "Autre"}
            };
            foreach (IdentityRole i in ir)
            {
                i.NormalizedName = i.Name.ToUpper();
                i.ConcurrencyStamp = Guid.NewGuid().ToString();
            }
            foreach (IdentityRole i in ir)
            {
                if (!Context.Roles.Any(d => d.NormalizedName == i.NormalizedName))
                {
                    Context.Add(i);
                }
            }
            Context.SaveChanges();

        }
        public static void InitialiserUsers()
        {
            ApplicationUser[] appUsers = new ApplicationUser[]
            {
                 new ApplicationUser {Email = "admin@test.ca", PasswordHash = "Test123!" },
                 new ApplicationUser {Email = "usager@test.ca", PasswordHash = "Test123!" },
                 new ApplicationUser {Email = "moderateur@test.ca", PasswordHash = "Test123!" }
            };

            foreach (ApplicationUser u in appUsers)
            {
                u.ConcurrencyStamp = Guid.NewGuid().ToString();
                u.LockoutEnabled = true;
                u.UserName = u.Email;
                u.NormalizedEmail = u.Email.ToUpper();
                u.NormalizedUserName = u.UserName.ToUpper();
                u.SecurityStamp = Guid.NewGuid().ToString();
                u.PasswordHash = _pass.HashPassword(u, u.PasswordHash);
            }
            foreach (ApplicationUser u in appUsers)
            {
                if (!Context.Users.Any(d => d.NormalizedEmail == u.NormalizedEmail))
                {
                    Context.Add(u);
                }
            }
            Context.SaveChanges();
        }

        public static void AssossiateUsersRole()
        {
            IdentityUserRole<string>[] usersRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.FirstOrDefault(u=> u.Email == "admin@test.ca").Id,
                    RoleId = Context.Roles.FirstOrDefault(r=>r.Name == "Administrateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.FirstOrDefault(u=> u.Email == "moderateur@test.ca").Id,
                    RoleId = Context.Roles.FirstOrDefault(r=>r.Name == "Moderateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.FirstOrDefault(u=> u.Email == "usager@test.ca").Id,
                    RoleId = Context.Roles.FirstOrDefault(r=>r.Name == "Utilisateur").Id
                }
            };

            foreach (IdentityUserRole<string> ur in usersRoles)
            {
                if (!Context.UserRoles.Any(d => d.UserId == ur.UserId && d.RoleId == ur.RoleId))
                {
                    Context.UserRoles.Add(ur);
                }
            }
            Context.SaveChanges();
        }
        public static void InitialiserForum()
        {
            Sujet s = new Sujet() { NbReponse = 0, Titre = "Bienvenu!", DateCreation = DateTime.Now, Description = "Bienvenu au nouveaux Membres!" };
            Context.Sujets.Add(s);
            Context.SaveChanges();
        }
    }
}
