using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models
{
    public class Membre
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public Membre(ApplicationUser appUser)
        {
            ID = appUser.Id;
            Email = appUser.Email;
            Role = "That shit is fucked" ;//appUser.Claims.ToList().FirstOrDefault().ClaimValue;
        }
        public Membre()
        {
                
        }
    }
}
