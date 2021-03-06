﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Maetsilor.Models;
using Maetsilor.Models.ForumViewModels;
using Maetsilor.Models.MatchMakingViewModel;

namespace Maetsilor.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Sujet> Sujets { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AspNetUsersInfoSup> InfoSups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Partie> Parties { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
