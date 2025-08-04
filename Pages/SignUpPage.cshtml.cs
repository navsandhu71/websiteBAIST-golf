using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfClubWebsite.Domain;

namespace GolfClubWebsite.Pages
{
    public class SignUpPageModel : PageModel
    {
        [BindProperty]
        public string MemberName { get; set; }
        [BindProperty]
        public int MemberNumber { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }

        bool Confirmation;

        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (UserName == null || UserName.Length <= 0)
            {
                ModelState.AddModelError("UserName", "Enter UserName");
            }
            if (Password == null || Password.Length <= 0)
            {
                ModelState.AddModelError("Password", "Enter Password");
            }
            if(MemberNumber.ToString() == null || MemberNumber<=0)
            {
                ModelState.AddModelError("MemberNumber", "Enter Member Number");
            }
            if(MemberName == null || MemberName.Length<=0)
            {
                ModelState.AddModelError("MemberName", "Enter Member Name");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    BGC RequestDirector = new BGC();
                    Confirmation = RequestDirector.NewMemberSignUp(MemberName, MemberNumber, UserName, Password);

                    if (Confirmation == true)
                    {
                        Message = "Signed up successfully, You can now login into the member portal!";
                    }
                    else
                    {
                        Message = "Failed to Sign Up!";
                    }
                }
            }
            
        }
    }
}
