using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfClubWebsite.Domain
{
    public class MembershipApplication
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string AlternatePhone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Occupation { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyPostalCode { get; set; }

        public string CompanyPhone { get; set; }

        public string FirstShareholderName { get; set; }

        public string SecondShareholderName { get; set; }

        
        public string ApplicationStatus { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string RequestedRole { get; set; }

        public int ApplicationNumber { get; set; }

        public DateTime OnlineSubmissionDate { get; set; }
    }
}
