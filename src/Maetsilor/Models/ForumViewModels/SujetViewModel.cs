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
        public DateTime DateCreation { get; set; }
        public DateTime DerniereReponse { get; set; }
        public string DernierRepondant { get; set; }
        public List<Message> Messages { get; set; }
        public int NbReponse { get; set; }
            
    }
}
