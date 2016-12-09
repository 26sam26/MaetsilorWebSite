using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maetsilor.Models.MatchMakingViewModel
{
    public class ChatMessage
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Auteur { get; set; }
        public string Message { get; set; }
        public int GroupID { get; set; }
    }
}
