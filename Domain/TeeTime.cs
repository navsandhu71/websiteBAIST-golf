using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubWebsite.Domain
{
    public class TeeTime
    {
        public string Date { get; set; }

        public string Time { get; set; }


        public string MemberName { get; set; }

        public int MemberNumber { get; set; }
        public string Member1Name { get; set; }

        public string Member2Name { get; set; }
        public string Member3Name { get; set; }
        public string Member4Name { get; set; }

        public string NoOfCarts { get; set; }

        public string Day { get; set; }

        public int Member1Number { get; set; }
        public int Member2Number { get; set; }
        public int Member3Number { get; set; }
        public int Member4Number { get; set; }

        public string BookingDate1 { get; set; }
        public string BookingDate2 { get; set; }
        public string BookingDate3 { get; set; }
        public string BookingDate4 { get; set; }

        public string status { get; set; }
    }
}
