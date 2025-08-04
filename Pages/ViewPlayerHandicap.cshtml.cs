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
    public class ViewPlayerHandicapModel : PageModel
    {
        public string playername;
        public int playerNumber;
        public string membershipLevel;
        public string Role;

        public BGC RequestDirector = new BGC();
        [BindProperty]
        public int MemberNumber { get; set; }
        public decimal Last20Average { get; set; }
        public decimal Best8Average { get; set; }
        public Player _Player = new Player();

        public List<decimal> Last20ScoresList = new List<decimal>();

        public void OnGet()
        {
            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = int.Parse(HttpContext.Session.GetString("Player Number"));
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");

            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = int.Parse(HttpContext.Session.GetString("Player Number"));
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");

            Last20ScoresList = RequestDirector.GetLast20Scores(playerNumber);

            if (Last20ScoresList.Count >= 20)
            {
                Last20Average = RequestDirector.AverageLast20Scores(playerNumber);
                Best8Average = RequestDirector.Best8Average(playerNumber);
                _Player = RequestDirector.ViewHandicapIndex(playerNumber);
            }
        }

        public void OnPost()
        {
          
        }
    }
}
