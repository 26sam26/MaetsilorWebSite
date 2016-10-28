using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models.ForumViewModels
{
    public class Message
    {
        public int ID { get; set; }
        public string Auteur { get; set; }
        public string Texte { get; set; }
    }
}
