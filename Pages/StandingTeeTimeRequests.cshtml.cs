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
    public class StandingTeeTimeRequestsModel : PageModel
    {
        [BindProperty]
        public string MemberName { get; set; }

        [BindProperty]
        public string FirstMemberName { get; set; }
        [BindProperty]
        public string SecondMemberName { get; set; }
        [BindProperty]
        public string ThirdMemberName { get; set; }
        [BindProperty]
        public string ForthMemberName { get; set; }

        [BindProperty]
        public int FirstMemberNumber { get; set; }
        [BindProperty]
        public int SecondMemberNumber { get; set; }
        [BindProperty]
        public int ThirdMemberNumber { get; set; }
        [BindProperty]
        public int ForthMemberNumber { get; set; }
        [BindProperty]
        public string RequestedDayOfWeek { get; set; }
        [BindProperty]
        public TimeSpan RequestedTeeTime { get; set; }
        [BindProperty]
        public DateTime RequestedStartDate { get; set; }
        [BindProperty]
        public DateTime RequestedEndDate { get; set; }

        public bool Confirmation { get; set; }
        public string Message { get; set; }

        public StandingTeeTimeRequestForm FormRequested = new();

        [BindProperty]
        public string Submit { get; set; }
        public List<string> timesavailable = new List<string>();


        public string playername;
        public string playerNumber;
        public string membershipLevel;
        public string Role;


        public List<Player> RequestedPlayer = new List<Player>();

        public void OnGet()
        {
            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = HttpContext.Session.GetString("Player Number");
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");
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
                    BGC RequestDirector = new BGC();
                    RequestedPlayer = RequestDirector.GetMemberDetailsUsingName(MemberName);
                }
            }

            if (Submit == "ShowAvailableTimes")
            {
             
                BGC RequestDirector = new BGC();
                timesavailable = RequestDirector.ShowAvailableTeeTimesRequest(RequestedDayOfWeek);
            }

            if (Submit == "SubmitRequest")
            {
                if (FirstMemberName == null || FirstMemberName.Length <= 0)
                {
                    ModelState.AddModelError("FirstMemberName", "Enter First Member Name");
                }
                if (FirstMemberNumber <= 0)
                {
                    ModelState.AddModelError("FirstMemberNumber", "Enter a valid First Member Number");
                }
                if (SecondMemberName == null || SecondMemberName.Length <= 0)
                {
                    ModelState.AddModelError("SecondMemberName", "Enter Second Member Name");
                }
                if (SecondMemberNumber <= 0)
                {
                    ModelState.AddModelError("SecondMemberNumber", "Enter a valid Second Member Number");
                }
                if (ThirdMemberName == null || ThirdMemberName.Length <= 0)
                {
                    ModelState.AddModelError("ThirdMemberName", "Enter Third Member Name");
                }
                if (ThirdMemberNumber <= 0)
                {
                    ModelState.AddModelError("ThirdMemberNumber", "Enter a valid Third Member Number");
                }
                if (ForthMemberName == null || ForthMemberName.Length <= 0)
                {
                    ModelState.AddModelError("ForthMemberName", "Enter Forth Member Name");
                }
                if (ForthMemberNumber <= 0)
                {
                    ModelState.AddModelError("ForthMemberNumber", "Enter a valid Forth Member Number");
                }
                if (RequestedTeeTime.ToString() == null || RequestedTeeTime.ToString().Length <= 0)
                {
                    ModelState.AddModelError("RequestedTeeTime", "Select a time to request!");
                }
                if (RequestedStartDate.ToString() == null || RequestedStartDate.ToString().Length < 0)
                {
                    ModelState.AddModelError("RequestedStartDate", "Select a start date!");
                }
                if (RequestedEndDate.ToString() == null || RequestedEndDate.ToString().Length < 0)
                {
                    ModelState.AddModelError("RequestedEndDate", "Select a end date!");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        playername = HttpContext.Session.GetString("Player Name");
                        playerNumber = HttpContext.Session.GetString("Player Number");
                        membershipLevel = HttpContext.Session.GetString("Membership Level");
                        Role = HttpContext.Session.GetString("Role");
                        FormRequested.FirstMemberName = FirstMemberName;
                        FormRequested.SecondMemberName = SecondMemberName;
                        FormRequested.ThirdMemberName = ThirdMemberName;
                        FormRequested.ForthMemberName = ForthMemberName;
                        FormRequested.FirstMemberNumber = FirstMemberNumber;
                        FormRequested.SecondMemberNumber = SecondMemberNumber;
                        FormRequested.ThirdMemberNumber = ThirdMemberNumber;
                        FormRequested.ForthMemberNumber = ForthMemberNumber;
                        FormRequested.RequestedDayOfWeek = RequestedDayOfWeek;
                        FormRequested.RequestedTime = RequestedTeeTime.ToString();
                        FormRequested.RequestedStartDate = RequestedStartDate.Date;
                        FormRequested.RequestedEndDate = RequestedEndDate.Date;

                        BGC RequestDirector = new BGC();
                        Confirmation = RequestDirector.SubmitStandingTeeTimeRequest(FormRequested);
                        if (Confirmation == true)
                        {
                            Message = "Request for Standing Tee Time has been submitted successfully";
                        }
                    }
                }
            }
            
        }
    }
}
