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
    public class ModifyTeeTimeModel : PageModel
    {
        BGC RequestDirector = new BGC();
        public List<TeeTime> BookedTimes = new List<TeeTime>();
        public string playername;
        public int playerNumber;
        public string membershipLevel;
        public string Role;

        public string Message { get; set; }

        public bool Confirmation;

        [BindProperty]
        public string Submit { get; set; }

        [BindProperty]
        public string InputFieldDate { get; set; }
        [BindProperty]
        public string InputFieldTime { get; set; }
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

            if (Submit == "ShowBookedTeeTimes")
            {
                BookedTimes = RequestDirector.GetBookedTimes(playerNumber);
            }
            if(Submit == "CancelTeeTime")
            {
                if (InputFieldDate == null || InputFieldDate.Length<=0)
                {
                    ModelState.AddModelError("InputFieldDate", "Select a date to get the tee sheet!");
                }

                if (InputFieldTime == null || InputFieldTime.Length <= 0)
                {
                    ModelState.AddModelError("InputFieldTime", "Select a time from the tee sheet!");
                }

                else
                {
                    Confirmation = RequestDirector.CancelTeeTimeClerkAndMembers(playerNumber.ToString(), InputFieldDate, InputFieldTime);

                    if (Confirmation == true)
                    {
                        Message = "TeeTime Cancelled Successfully";
                    }
                    else
                    {
                        Message = "Failed to cancel Tee Time";
                    }
                }
            }

        }
    }
}
