using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfClubWebsite.Domain;
using Microsoft.AspNetCore.Http;

namespace GolfClubWebsite.Pages
{

    public class WelcomeModel : PageModel
    {

        public string playername;
        public string playerNumber;
        public string membershipLevel;
        public string Role;
        public void OnGet()
        {
            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = HttpContext.Session.GetString("Player Number");
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role= HttpContext.Session.GetString("Role");
        }

        public void OnPost()
        {
            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = HttpContext.Session.GetString("Player Number");
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");
        }
    }

}