using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using GolfClubWebsite.Domain;
using Microsoft.AspNetCore.Http;

namespace GolfClubWebsite.Pages
{
    public class RequestLoginModel : PageModel
    {

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public Player ExistingPlayer = new();


        public string playernumber { get; set; }

        public string playerName { get; set; }

        public string membershipLevel { get; set; }

        public string Role { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {

            if (UserName == null || UserName.Length <= 0)
            {
                ModelState.AddModelError("UserName", "Enter UserName");
            }
            if (Password == null || Password.Length <= 0)
            {
                ModelState.AddModelError("Password", "Enter Password");
            }
            if (ModelState.IsValid)
            {
                BGC RequestDirector = new BGC();
                ExistingPlayer = RequestDirector.RequestLogin(UserName, Password);


                if (ExistingPlayer == null)
                {
                    Message = "Invalid Username or Password!";
               //     return RedirectToPage("SignUpPage");
                }
                else
                {
                    playernumber = ExistingPlayer.MemberNumber;
                    playerName = ExistingPlayer.MemberName;
                    membershipLevel = ExistingPlayer.MembershipLevel;
                    Role = ExistingPlayer.Role;

                    HttpContext.Session.SetString("Player Name", playerName);
                    HttpContext.Session.SetString("Player Number", playernumber);
                    HttpContext.Session.SetString("Membership Level", membershipLevel);
                    HttpContext.Session.SetString("Role", Role);
                    return RedirectToPage("Welcome");
                }
            }
       
            
                return RedirectToPage("RequestLogin");
            
            
        }
    }
}
