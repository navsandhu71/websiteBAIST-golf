using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubWebsite.Domain
{
    public class DailyTeeSheet
    {
        private List<TeeTime> _golfTeeTimes = new List<TeeTime>();

        
        public string Date { get; set; }
        public string DayOfWeek { get; set; }

        public List<TeeTime> GolfTeeTimes
        {
            get
            {
                return _golfTeeTimes;
            }
            set
            {
                _golfTeeTimes = value;
            }
        }

    }
}
