using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfClubWebsite.Domain;

namespace GolfClubWebsite.Pages.MembershipCommittee
{
    public class ReviewMembershipApplicationsModel : PageModel
    {
        [BindProperty]
        public int ApplicationNumber { get; set; }

        [BindProperty]
        public string UpdatedStatus { get; set; }

        public BGC RequestDirector = new BGC();

        public List<MembershipApplication> MembershipApplications = new List<MembershipApplication>();

        public List<MembershipApplication> WaitlistedMembershipApplications = new List<MembershipApplication>();

        [BindProperty]
        public string Submit { get; set; }

        public  bool Confirmation;

        [BindProperty]
        public string Message { get; set; }

        public Player newPlayer = new Player();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Submit == "ViewOnHoldMembershipApplications")
            {
               MembershipApplications = RequestDirector.ViewMemberApplications();
                   
            }
            if(Submit == "ViewWaitlistedMembershipApplications")
            {
               WaitlistedMembershipApplications = RequestDirector.ViewWaitlistedMembershipApplications();
               
            }
            if(Submit== "SubmitDecision")
            {
                if (ApplicationNumber.ToString() == null || ApplicationNumber.ToString().Length <=0 ||  ApplicationNumber <= 0 )
                {
                    ModelState.AddModelError("ApplicationNumber", "Enter Application Number");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        newPlayer = RequestDirector.ReviewMembershipApplication(ApplicationNumber, UpdatedStatus);

                      
                    }
                }
            }

        }
    }
}
