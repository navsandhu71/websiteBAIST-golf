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
  
    public class SubmitPlayerScoresModel : PageModel
    {
        public string playername;
        public int playerNumber;
        public string membershipLevel;
        public string Role;

        [BindProperty]
        public string GolfCourse { get; set; }
        [BindProperty]
        public decimal CourseRating { get; set; }
        [BindProperty]
        public decimal SlopeRating { get; set; }
        [BindProperty]
        public DateTime GolfDate { get; set; }
        [BindProperty]
        public int Hole1Par { get; set; }
        [BindProperty]
        public int Hole1Scores { get; set; }
       
        [BindProperty]
        public int Hole2Par { get; set; }
        [BindProperty]
        public int Hole2Scores { get; set; }
       

        [BindProperty]
        public int Hole3Par { get; set; }
        [BindProperty]
        public int Hole3Scores { get; set; }
       

        [BindProperty]
        public int Hole4Par { get; set; }
        [BindProperty]
        public int Hole4Scores { get; set; }
     
        [BindProperty]
        public int Hole5Par { get; set; }
        [BindProperty]
        public int Hole5Scores { get; set; }
       
        [BindProperty]
        public int Hole6Par { get; set; }
        [BindProperty]
        public int Hole6Scores { get; set; }
      

        [BindProperty]
        public int Hole7Par { get; set; }
        [BindProperty]
        public int Hole7Scores { get; set; }
       

        [BindProperty]
        public int Hole8Par { get; set; }
        [BindProperty]
        public int Hole8Scores { get; set; }
       
        [BindProperty]
        public int Hole9Par { get; set; }
        [BindProperty]
        public int Hole9Scores { get; set; }
       


        [BindProperty]
        public int Hole10Par { get; set; }
        [BindProperty]
        public int Hole10Scores { get; set; }
      

        [BindProperty]
        public int Hole11Par { get; set; }
        [BindProperty]
        public int Hole11Scores { get; set; }
        

        [BindProperty]
        public int Hole12Par { get; set; }
        [BindProperty]
        public int Hole12Scores { get; set; }
       

        [BindProperty]
        public int Hole13Par { get; set; }
        [BindProperty]
        public int Hole13Scores { get; set; }
       

        [BindProperty]
        public int Hole14Par { get; set; }
        [BindProperty]
        public int Hole14Scores { get; set; }
        

        [BindProperty]
        public int Hole15Par { get; set; }
        [BindProperty]
        public int Hole15Scores { get; set; }
      

        [BindProperty]
        public int Hole16Par { get; set; }
        [BindProperty]
        public int Hole16Scores { get; set; }
        

        [BindProperty]
        public int Hole17Par { get; set; }
        [BindProperty]
        public int Hole17Scores { get; set; }
        

        [BindProperty]
        public int Hole18Par { get; set; }
        [BindProperty]
        public int Hole18Scores { get; set; }
        


        public List<HoleScore> ScoresList = new List<HoleScore>();

        BGC RequestDirector = new BGC();

        public int GolfNumber;

        public bool Confirmation;

        public bool Confirmation1;

        public int TotalScores;

        [BindProperty]
        public string Message { get; set; }
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


            if (CourseRating <= 0)
            {
                ModelState.AddModelError("CourseRating", "Enter Course Rating!");
            }
            if (SlopeRating <= 0)
            {
                ModelState.AddModelError("SlopeRating", "Enter Slope Rating!");
            }

            if(GolfDate.ToString()==null)
            {
                ModelState.AddModelError("GolfDate", "Select Golf Date!");
            }
            if(Hole1Scores<=0)
            {
                ModelState.AddModelError("Hole1Scores", "Enter Hole 1 Scores!");
            }
            if (Hole2Scores <= 0)
            {
                ModelState.AddModelError("Hole2Scores", "Enter Hole 2 Scores!");
            }
            if (Hole3Scores <= 0)
            {
                ModelState.AddModelError("Hole3Scores", "Enter Hole 3 Scores!");
            }
            if (Hole4Scores <= 0)
            {
                ModelState.AddModelError("Hole4Scores", "Enter Hole 4 Scores!");
            }
            if (Hole5Scores <= 0)
            {
                ModelState.AddModelError("Hole5Scores", "Enter Hole 5 Scores!");
            }
            if (Hole6Scores <= 0)
            {
                ModelState.AddModelError("Hole6Scores", "Enter Hole 6 Scores!");
            }
            if (Hole7Scores <= 0)
            {
                ModelState.AddModelError("Hole7Scores", "Enter Hole 7 Scores!");
            }
            if (Hole8Scores <= 0)
            {
                ModelState.AddModelError("Hole8Scores", "Enter Hole 8 Scores!");
            }
            if (Hole9Scores <= 0)
            {
                ModelState.AddModelError("Hole9Scores", "Enter Hole 9 Scores!");
            }
            if (Hole10Scores <= 0)
            {
                ModelState.AddModelError("Hole10Scores", "Enter Hole 10 Scores!");
            }
            if (Hole11Scores <= 0)
            {
                ModelState.AddModelError("Hole11Scores", "Enter Hole 11 Scores!");
            }
            if (Hole12Scores <= 0)
            {
                ModelState.AddModelError("Hole12Scores", "Enter Hole 12 Scores!");
            }
            if (Hole13Scores <= 0)
            {
                ModelState.AddModelError("Hole13Scores", "Enter Hole 13 Scores!");
            }
            if (Hole14Scores <= 0)
            {
                ModelState.AddModelError("Hole14Scores", "Enter Hole 14 Scores!");
            }
            if (Hole15Scores <= 0)
            {
                ModelState.AddModelError("Hole15Scores", "Enter Hole 15 Scores!");
            }
            if (Hole16Scores <= 0)
            {
                ModelState.AddModelError("Hole16Scores", "Enter Hole 16 Scores!");
            }
            if (Hole17Scores <= 0)
            {
                ModelState.AddModelError("Hole17Scores", "Enter Hole 17 Scores!");
            }
            if (Hole18Scores <= 0)
            {
                ModelState.AddModelError("Hole18Scores", "Enter Hole 18 Scores!");
            }
            else
            {
                HoleScore Hole1 = new HoleScore
                {
                    HoleNumber = 1,
                    HoleByHoleScore = Hole1Scores,
                    Par = Hole1Par

                };
                ScoresList.Add(Hole1);
                HoleScore Hole2 = new HoleScore
                {
                    HoleNumber = 2,
                    HoleByHoleScore = Hole2Scores,
                    Par = Hole2Par
                };
                ScoresList.Add(Hole2);
                HoleScore Hole3 = new HoleScore
                {
                    HoleNumber = 3,
                    HoleByHoleScore = Hole3Scores,
                    Par = Hole3Par
                };
                ScoresList.Add(Hole3);
                HoleScore Hole4 = new HoleScore
                {
                    HoleNumber = 4,
                    HoleByHoleScore = Hole4Scores,
                    Par = Hole4Par
                };
                ScoresList.Add(Hole4);

                HoleScore Hole5 = new HoleScore
                {
                    HoleNumber = 5,
                    HoleByHoleScore = Hole5Scores,
                    Par = Hole5Par
                };
                ScoresList.Add(Hole5);

                HoleScore Hole6 = new HoleScore
                {
                    HoleNumber = 6,
                    HoleByHoleScore = Hole6Scores,
                    Par = Hole6Par
                };
                ScoresList.Add(Hole6);

                HoleScore Hole7 = new HoleScore
                {
                    HoleNumber = 7,
                    HoleByHoleScore = Hole7Scores,
                    Par = Hole7Par
                };
                ScoresList.Add(Hole7);

                HoleScore Hole8 = new HoleScore
                {
                    HoleNumber = 8,
                    HoleByHoleScore = Hole8Scores,
                    Par = Hole8Par
                };
                ScoresList.Add(Hole8);

                HoleScore Hole9 = new HoleScore
                {
                    HoleNumber = 9,
                    HoleByHoleScore = Hole9Scores,
                    Par = Hole9Par
                };
                ScoresList.Add(Hole9);

                HoleScore Hole10 = new HoleScore
                {
                    HoleNumber = 10,
                    HoleByHoleScore = Hole10Scores,
                    Par = Hole10Par
                };
                ScoresList.Add(Hole10);

                HoleScore Hole11 = new HoleScore
                {
                    HoleNumber = 11,
                    HoleByHoleScore = Hole11Scores,
                    Par = Hole11Par
                };
                ScoresList.Add(Hole11);

                HoleScore Hole12 = new HoleScore
                {
                    HoleNumber = 12,
                    HoleByHoleScore = Hole12Scores,
                    Par = Hole12Par
                };
                ScoresList.Add(Hole12);

                HoleScore Hole13 = new HoleScore
                {
                    HoleNumber = 13,
                    HoleByHoleScore = Hole13Scores,
                    Par = Hole13Par
                };
                ScoresList.Add(Hole13);

                HoleScore Hole14 = new HoleScore
                {
                    HoleNumber = 14,
                    HoleByHoleScore = Hole14Scores,
                    Par = Hole14Par
                };
                ScoresList.Add(Hole14);

                HoleScore Hole15 = new HoleScore
                {
                    HoleNumber = 15,
                    HoleByHoleScore = Hole15Scores,
                    Par = Hole15Par
                };
                ScoresList.Add(Hole15);

                HoleScore Hole16 = new HoleScore
                {
                    HoleNumber = 16,
                    HoleByHoleScore = Hole16Scores,
                    Par = Hole16Par
                };
                ScoresList.Add(Hole16);

                HoleScore Hole17 = new HoleScore
                {
                    HoleNumber = 17,
                    HoleByHoleScore = Hole17Scores,
                    Par = Hole17Par
                };
                ScoresList.Add(Hole17);

                HoleScore Hole18 = new HoleScore
                {
                    HoleNumber = 18,
                    HoleByHoleScore = Hole18Scores,
                    Par = Hole18Par
                };
                ScoresList.Add(Hole18);


                GolfNumber = RequestDirector.SubmitGolfGameScores(playerNumber, GolfCourse, CourseRating, SlopeRating, GolfDate);

                for (int i = 0; i < ScoresList.Count; ++i)
                {
                    Confirmation = RequestDirector.AddHoleScores(GolfNumber, ScoresList[i].HoleNumber, ScoresList[i].HoleByHoleScore, ScoresList[i].Par);
                    TotalScores += ScoresList[i].HoleByHoleScore;
                }

                Confirmation1 = RequestDirector.UpdateTotalScores(GolfNumber, TotalScores, playerNumber);


                if (Confirmation1 == true)
                {
                    Message = "Scores added successfully!";
                }
                else
                {
                    Message = "Failed to add scores!";
                }
            }
        }
    }
}
