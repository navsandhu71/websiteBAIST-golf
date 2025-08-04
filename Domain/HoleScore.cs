using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubWebsite.Domain
{
    public class HoleScore
    {
        public int HoleNumber { get; set; }

        public int HoleByHoleScore { get; set; }

        public int Par { get; set; }

        public int TotalShots { get; set; }
      
    }
}
