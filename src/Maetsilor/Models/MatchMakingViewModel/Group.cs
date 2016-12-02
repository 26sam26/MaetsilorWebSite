using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Maetsilor.Models.MatchMakingViewModel
{
    public class Group
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string TypeDePartie { get; set; }
        public int MaxDeJoueur { get; set; }
        public int MinDeJoueur { get; set; }
        public string MaitreDuJeu { get; set; }
        public List<ApplicationUser> Membres { get; set; }
        public List<ApplicationUser> RequeteEnAttente { get; set; }
        public List<Partie> Calendrier { get; set; }
        public List<ChatMessage> Chat { get; set; }
    }
}
