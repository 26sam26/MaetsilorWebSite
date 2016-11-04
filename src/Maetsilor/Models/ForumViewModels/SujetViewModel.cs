using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models.ForumViewModels
{
    public class Sujet
    {
        public int ID { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public DateTime DateCréation { get; set; }
        public DateTime DernièreRéponse { get; set; }
        public string DernierRépondant { get; set; }
        public List<Message> Messages { get; set; }
        public int NbRéponse { get; set; }
            
    }
}
