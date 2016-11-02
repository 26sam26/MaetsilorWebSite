using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models
{
    public class MembreViewModels
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public MembreViewModels(ApplicationUser appUser)
        {
            ID = appUser.Id;
            Email = appUser.Email;
            Role = appUser.Claims.ToList().FirstOrDefault().ClaimValue;
        }
        public MembreViewModels()
        {
                
        }
    }
}
