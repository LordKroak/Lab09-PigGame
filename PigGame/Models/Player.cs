using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PigGame.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public int TotalScore { get; set; }
        public bool IsTurn { get; set; }
    }
}
