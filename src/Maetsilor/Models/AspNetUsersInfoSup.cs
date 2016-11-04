using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models
{
    public class AspNetUsersInfoSup
    {
        public int ID { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }

        public string DisplayName { get; set; }

    }
}
