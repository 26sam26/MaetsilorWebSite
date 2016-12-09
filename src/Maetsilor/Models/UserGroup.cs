using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models
{
    public class UserGroup
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int GroupID { get; set; }
        public bool IsMember { get; set; }
    }
}
