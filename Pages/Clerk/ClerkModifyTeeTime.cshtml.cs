using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfClubWebsite.Domain;
using Microsoft.AspNetCore.Http;

namespace GolfClubWebsite.Pages.Clerk
{
    public class ClerkModifyTeeTimeModel : PageModel
    {
        [BindProperty]
        public string MemberNumber { get; set; }

        public string MemberName { get; set; }

        public string PlayerNumber { get; set; }

        public string MembershipLevel { get; set; }

        public string MemberRole { get; set; }

        [BindProperty]
        public string Submit { get; set; }

        public Player RequestedPlayer = new();

        public string Message { get; set; }

        public bool Confirmation;

      
        [BindProperty]
        public string InputFieldDate { get; set; }
        [BindProperty]
        public string InputFieldTime { get; set; }

        BGC RequestDirector = new BGC();
        public List<TeeTime> BookedTimes = new List<TeeTime>();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Submit == "Find Member")
            {
                if (MemberNumber == null || MemberNumber.Length <= 0)
                {
                    ModelState.AddModelError("MemberNumber", "Enter a valid MemberNumber!");
                }
                else
                {
                    BGC RequestDirector = new BGC();

                    RequestedPlayer = RequestDirector.GetPlayer(int.Parse(MemberNumber));

                    if (ModelState.IsValid)
                    {
                        MemberName = RequestedPlayer.MemberName;
                        PlayerNumber = RequestedPlayer.MemberNumber;
                        MembershipLevel = RequestedPlayer.MembershipLevel;
                        MemberRole = RequestedPlayer.Role;
                        HttpContext.Session.SetString("Player Name", MemberName);
                        HttpContext.Session.SetString("Player Number", PlayerNumber);
                        HttpContext.Session.SetString("Membership Level", MembershipLevel);
                        HttpContext.Session.SetString("Role", MemberRole);


                    }
                }
            }

            if (Submit == "ShowBookedTeeTimes")
            {
                MemberName = HttpContext.Session.GetString("Player Name");
                PlayerNumber = HttpContext.Session.GetString("Player Number");
                MembershipLevel = HttpContext.Session.GetString("Membership Level");
                MemberRole = HttpContext.Session.GetString("Role");
                BookedTimes = RequestDirector.GetBookedTimes(int.Parse(PlayerNumber));
            }
            if (Submit == "CancelTeeTime")
            {


                MemberName = HttpContext.Session.GetString("Player Name");
                PlayerNumber = HttpContext.Session.GetString("Player Number");
                MembershipLevel = HttpContext.Session.GetString("Membership Level");
                MemberRole = HttpContext.Session.GetString("Role");
               
                if (InputFieldTime == null || InputFieldTime.Length <= 0)
                {
                    ModelState.AddModelError("InputFieldTime", "Select a time from the tee sheet!");
                }
                if (InputFieldDate == null || InputFieldDate.Length <= 0)
                {
                    ModelState.AddModelError("InputFieldDate", "Select a date to get the tee sheet!");
                }
                else
                {
                    Confirmation = RequestDirector.CancelTeeTimeClerkAndMembers(PlayerNumber.ToString(), InputFieldDate, InputFieldTime);
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
