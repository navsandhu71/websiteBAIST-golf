using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfClubWebsite.Domain;
using GolfClubWebsite.TechnicalServices;
using Microsoft.AspNetCore.Http;

namespace GolfClubWebsite.Pages
{
    public class CancelStandingTeeTimeRequestModel : PageModel
    {
        BGC RequestDirector = new BGC();
        
        public string playername;
        public int playerNumber;
        public string membershipLevel;
        public string Role;

        public string Message { get; set; }

        public bool Confirmation;

        [BindProperty]
        public string Submit { get; set; }

        public StandingTeeTimeRequestForm standingTeeTimeRequest = new();


        [BindProperty]
        public int RequestNumber { get; set; }
        public void OnGet()
        {
            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = int.Parse(HttpContext.Session.GetString("Player Number"));
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");
        }

        public void OnPost()
        {
            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = int.Parse(HttpContext.Session.GetString("Player Number"));
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");

            if(Submit == "ShowStandingTeeTimeRequest")
            {
                standingTeeTimeRequest = RequestDirector.ShowRequestedTeeTimes(playerNumber);
                if(standingTeeTimeRequest.RequestNumber < 1)
                {
                    Message = "No Standing Tee Time Request Submitted!";
                }
            }

            if(Submit == "CancelStandingTeeTimeRequest")
            {
                if (RequestNumber <= 0 || RequestNumber.ToString() == null)
                {
                    ModelState.AddModelError("RequestNumber", "Select a request from the list or Enter request Number");

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Confirmation = RequestDirector.CancelStandingTeeTimeRequest(RequestNumber);

                        if (Confirmation == true)
                        {
                            Message = "Request Cancelled Successfully";
                        }
                        else
                        {
                            Message = "Failed to Cancel Request";
                        }
                    }
                }
            }
        }
    }
}
