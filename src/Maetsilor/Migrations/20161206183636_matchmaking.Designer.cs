using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Maetsilor.Data;

namespace Maetsilor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161206183636_matchmaking")]
    partial class matchmaking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Maetsilor.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("GroupID");

                    b.Property<int?>("GroupID1");

                    b.Property<int?>("InfoSupID");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("GroupID");

                    b.HasIndex("GroupID1");

                    b.HasIndex("InfoSupID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Maetsilor.Models.AspNetUsersInfoSup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<byte[]>("Image");

                    b.Property<string>("ImageType");

                    b.HasKey("ID");

                    b.ToTable("InfoSups");
                });

            modelBuilder.Entity("Maetsilor.Models.ForumViewModels.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Auteur");

                    b.Property<int?>("SujetID");

                    b.Property<string>("Texte");

                    b.HasKey("ID");

                    b.HasIndex("SujetID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Maetsilor.Models.ForumViewModels.Sujet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Auteur");

                    b.Property<DateTime>("DateCreation");

                    b.Property<string>("DernierRepondant");

                    b.Property<DateTime>("DerniereReponse");

                    b.Property<string>("Description");

                    b.Property<int>("NbReponse");

                    b.Property<string>("Titre");

                    b.HasKey("ID");

                    b.ToTable("Sujets");
                });

            modelBuilder.Entity("Maetsilor.Models.MatchMakingViewModel.ChatMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Auteur");

                    b.Property<DateTime>("Date");

                    b.Property<int>("GroupID");

                    b.Property<string>("Message");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Maetsilor.Models.MatchMakingViewModel.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("MaitreDuJeu");

                    b.Property<int>("MaxDeJoueur");

                    b.Property<int>("MinDeJoueur");

                    b.Property<string>("Nom");

                    b.Property<string>("TypeDePartie");

                    b.HasKey("ID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Maetsilor.Models.MatchMakingViewModel.Partie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("GroupID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Maetsilor.Models.ApplicationUser", b =>
                {
                    b.HasOne("Maetsilor.Models.MatchMakingViewModel.Group")
                        .WithMany("Membres")
                        .HasForeignKey("GroupID");

                    b.HasOne("Maetsilor.Models.MatchMakingViewModel.Group")
                        .WithMany("RequeteEnAttente")
                        .HasForeignKey("GroupID1");

                    b.HasOne("Maetsilor.Models.AspNetUsersInfoSup", "InfoSup")
                        .WithMany()
                        .HasForeignKey("InfoSupID");
                });

            modelBuilder.Entity("Maetsilor.Models.ForumViewModels.Message", b =>
                {
                    b.HasOne("Maetsilor.Models.ForumViewModels.Sujet")
                        .WithMany("Messages")
                        .HasForeignKey("SujetID");
                });

            modelBuilder.Entity("Maetsilor.Models.MatchMakingViewModel.ChatMessage", b =>
                {
                    b.HasOne("Maetsilor.Models.MatchMakingViewModel.Group")
                        .WithMany("Chat")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Maetsilor.Models.MatchMakingViewModel.Partie", b =>
                {
                    b.HasOne("Maetsilor.Models.MatchMakingViewModel.Group")
                        .WithMany("Calendrier")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Maetsilor.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Maetsilor.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Maetsilor.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
