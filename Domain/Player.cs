using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubWebsite.Domain
{
    public class Player
    {
        private List<TeeTime> _bookedTeeTimes = new List<TeeTime>();
        public string MembershipLevel { get; set; }
        public string MemberNumber { get; set; }
        public string MemberName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public string Role { get; set; }
        public List<TeeTime> BookedTeeTimes
        {
            get
            {
                return _bookedTeeTimes;
            }
            set
            {
                _bookedTeeTimes = value;
            }
        }

        public decimal PlayerHandicapIndex { get; set; }
        public DateTime HandicapCalculationDate { get; set; }
    }
}
