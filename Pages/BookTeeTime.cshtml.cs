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
    public class BookTeeTimeModel : PageModel
    {

        public string playername;
        public int playerNumber;
        public string membershipLevel;
        public string Role;

        [BindProperty]
        public DateTime InputFieldDate { get; set; }

        public DailyTeeSheet RequestedTeeSheet = new();
        [BindProperty]
        public string Submit { get; set; }

        public string Confirmation { get; set; }
        public string Message { get; set; }


        [BindProperty]
        public string TotalPlayers { get; set; }
        [BindProperty]
        public string TotalCarts { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }


        [BindProperty]
        public string InputFieldTime { get; set; }
        public BGC RequestDirector = new BGC();

        public TeeTime ModifiedTeeTime = new();
        public string dayofweek;
        [BindProperty]
        public DateTime GolfDate { get; set; }


        public TeeTime TeeTimeToBook = new();

        public bool Booking;
        public void OnGet()
        {
            playername = HttpContext.Session.GetString("Player Name");
            playerNumber =int.Parse( HttpContext.Session.GetString("Player Number"));
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");
        }

        public void OnPost()
        {

            playername = HttpContext.Session.GetString("Player Name");
            playerNumber = int.Parse(HttpContext.Session.GetString("Player Number"));
            membershipLevel = HttpContext.Session.GetString("Membership Level");
            Role = HttpContext.Session.GetString("Role");

            if (Submit == "GetDailyTeeSheet")
            {
                if(GolfDate.ToString() == null)
                {
                    ModelState.AddModelError("InputFieldDate", "Select a date to get the tee sheet!");
                }
                RequestedTeeSheet = RequestDirector.GetDailyTeeSheet(InputFieldDate.ToString());
                RequestedTeeSheet.Date = InputFieldDate.Date.ToString("yyyy/M/d");
                RequestedTeeSheet.DayOfWeek = InputFieldDate.DayOfWeek.ToString();
                GolfDate = InputFieldDate;
            }

            if (Submit == "BookTeeTime")
            {

                if (InputFieldTime == null || InputFieldTime.Length <= 0)
                {
                    ModelState.AddModelError("InputFieldTime", "Select a time from the tee sheet!");
                }
               
                    TeeTimeToBook.Date = GolfDate.ToString();
                    TeeTimeToBook.Time = InputFieldTime;
                    TeeTimeToBook.MemberName = playername;
                    TeeTimeToBook.NoOfCarts = TotalCarts;
                    TeeTimeToBook.MemberNumber = playerNumber;
                    dayofweek = GolfDate.DayOfWeek.ToString();

                    Booking = AllowedToBook(membershipLevel, InputFieldTime, dayofweek);
                    BGC RequestDirector = new BGC();
                    if (Booking == true)
                    {
                        Confirmation = RequestDirector.BookTeeTime(TeeTimeToBook);

                        // Message = Confirmation;

                    }
                    else
                    {
                        Message = "Failed to book TeeTime due to time restrictions!";
                    }
                
            }
       
        }
        public bool AllowedToBook(string membershipLevel, string time, string day)
        {
            if (membershipLevel == "Gold")
            {
                return true;
            }
            if (membershipLevel == "Silver")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {

                    TimeSpan BreakStartTime = new TimeSpan(15, 0, 0);
                    TimeSpan BreakEndTime = new TimeSpan(17, 30, 0);

                    TimeSpan TimeToBook = Convert.ToDateTime(time).TimeOfDay;

                    if (TimeToBook < BreakStartTime || TimeToBook > BreakEndTime)
                    {
                        return true;
                    }
                    else
                        return false;

                
                }
                else
                {

                    TimeSpan startTime = new TimeSpan(11, 0, 0);
                    TimeSpan TimeToBook = Convert.ToDateTime(time).TimeOfDay;

                    if (TimeToBook > startTime)
                        return true;
                    else
                        return false;


                }
            }
            if (membershipLevel == "Bronze")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {

                    TimeSpan BreakStartTime = new TimeSpan(15, 0, 0);
                    TimeSpan BreakEndTime = new TimeSpan(18, 0, 0);

                    TimeSpan TimeToBook = Convert.ToDateTime(time).TimeOfDay;

                    if (TimeToBook < BreakStartTime || TimeToBook > BreakEndTime)
                    {
                        return true;
                    }
                    else
                        return false;

                   
                }
                else
                {

                    TimeSpan startTime = new TimeSpan(13, 0, 0);
                    TimeSpan TimeToBook = Convert.ToDateTime(time).TimeOfDay;

                    if (TimeToBook > startTime)
                        return true;
                    else
                        return false;

                
                    }
                }
            else
            {
                return false;
            }

        }

    }
}

