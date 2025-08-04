using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfClubWebsite.Domain;

namespace GolfClubWebsite.Pages.FinanceCommittee
{
    public class ViewMemberAccountModel : PageModel
    {
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public string MemberName { get; set; }

        public BGC RequestDirector = new BGC();

        public List<MemberAccount> AccountInfo = new List<MemberAccount>();

        [BindProperty]
        public decimal TotalTransactionAmount { get; set; }

        [BindProperty]
        public string Submit { get; set; }
        
        public List<Player> RequestedPlayer = new List<Player>();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Submit == "GetMemberDetails")
            {
                if (MemberName == null || MemberName.Length <= 0)
                {
                    ModelState.AddModelError("MemberName", "Enter Member Name");
                }
                else
                {
                    RequestedPlayer = RequestDirector.GetMemberDetailsUsingName(MemberName);
                }
            }
            if (Submit == "ViewMemberAccount")
            {
                if (MemberNumber <= 0)
                {
                    ModelState.AddModelError("MemberNumber", "ENter Member Number!");
                }
                else
                {
                    AccountInfo = RequestDirector.ViewMemberAccount(MemberNumber);
                }
            }

        }
    }
}
