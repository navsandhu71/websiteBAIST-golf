using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubWebsite.Domain
{
    public class MemberAccount
    {
        public int AccountNumber { get; set; }
        public string MemberName { get; set; }
        public string TransactionDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime WhenBooked { get; set; }
        public DateTime WhenCharged { get; set; }
    }
}
