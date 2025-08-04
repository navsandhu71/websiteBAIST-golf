using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubWebsite.Domain
{
    public class StandingTeeTimeRequestForm
    {
        public string FirstMemberName { get; set; }
        public string SecondMemberName { get; set; }
        public string ThirdMemberName { get; set; }
        public string ForthMemberName { get; set; }
        public int FirstMemberNumber { get; set; }
        public int SecondMemberNumber { get; set; }
        public int ThirdMemberNumber { get; set; }
        public int ForthMemberNumber { get; set; }
        public string RequestedDayOfWeek { get; set; }
        public string RequestedTime { get; set; }
        public DateTime RequestedStartDate { get; set; }
        public DateTime RequestedEndDate { get; set; }

        public int RequestNumber { get; set; }

    }
}
