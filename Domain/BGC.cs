using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfClubWebsite.TechnicalServices;

namespace GolfClubWebsite.Domain
{
    public class BGC
    {
        public Player RequestLogin(string UserName, string Password)
        {
            Player RequestedPlayer = new();
            MemberLogin LoginManager = new MemberLogin();

            RequestedPlayer = LoginManager.AuthenticateLogin(UserName, Password);

            return RequestedPlayer;
        }

        public bool NewMemberSignUp(string MemberName, int MemberNumber, string Username, string Password)
        {
            bool Confirmation;
            MemberLogin LoginManager = new MemberLogin();
            Confirmation = LoginManager.NewMemberSignUp(MemberName, MemberNumber, Username, Password);
            return Confirmation;

        }
        public DailyTeeSheet GetDailyTeeSheet(string Date)
        {
            DailyTeeSheet RequestedTeeSheet = new();
            ManageTeeSheets TeeSheetManager = new ManageTeeSheets();
            RequestedTeeSheet = TeeSheetManager.FindDailyTeeSheet(Date);

            return RequestedTeeSheet;
        }

        public string BookTeeTime(TeeTime ModifiedTeeTime)
        {
            string confirmation ;
            ManageTeeSheets TeeSheetManager = new ManageTeeSheets();
            confirmation = TeeSheetManager.FinalizeTeeTime(ModifiedTeeTime);

            return confirmation;
        }
        public List<string> ShowAvailableTeeTimesRequest(string RequestedDay)
        {
            List<string> timeList = new List<string>();

            SubmitStandingTeeTimeRequest StandingRequestManager = new SubmitStandingTeeTimeRequest();
            timeList = StandingRequestManager.FetchAvailableTeeTimesRequest(RequestedDay);

            return timeList;
        }


        public bool SubmitStandingTeeTimeRequest(StandingTeeTimeRequestForm FilledForm)
        {
            bool confirmation;
            SubmitStandingTeeTimeRequest StandingRequestManager = new SubmitStandingTeeTimeRequest();
            confirmation = StandingRequestManager.SubmitStandingTeeTimeApplication(FilledForm);

            return confirmation;
        }

        public Player GetPlayer(int MemberNumber)
        {
            Player RequestedPlayer = new();
            Clerk ClerkTaskManger = new Clerk();
            RequestedPlayer = ClerkTaskManger.FindPlayer(MemberNumber);

            return RequestedPlayer;
        }

        public List<TeeTime> GetBookedTimes(int MemberNumber)
        {
            List<TeeTime> teeTimes= new();
            ManageTeeSheets TeeSheetManager = new ManageTeeSheets();
            teeTimes = TeeSheetManager.ShowBookedTimes(MemberNumber);

            return teeTimes;
        }

        public bool CancelTeeTime(string MemberNumber, string GolfDate, string GolfTime)
        {
            bool confirmation;
            ManageTeeSheets TeeSheetManager = new ManageTeeSheets();
            confirmation = TeeSheetManager.CancelTeeTime(MemberNumber, GolfDate, GolfTime);

            return confirmation;
        }


        public bool CancelTeeTimeClerkAndMembers(string MemberNumber, string GolfDate, string GolfTime)
        {
            bool confirmation;
            ManageTeeSheets TeeSheetManager = new ManageTeeSheets();
            confirmation = TeeSheetManager.CancelTeeTimeClerkAndMembers(MemberNumber, GolfDate, GolfTime);

            return confirmation;
        }


        public StandingTeeTimeRequestForm ShowRequestedTeeTimes(int MemberNumber)
        {
            StandingTeeTimeRequestForm standingTeeTimeRequest = new StandingTeeTimeRequestForm();
            SubmitStandingTeeTimeRequest StandingRequestManager = new SubmitStandingTeeTimeRequest();
            standingTeeTimeRequest = StandingRequestManager.ShowRequestedTeeTimes(MemberNumber);

            return standingTeeTimeRequest;
        }
        public bool CancelStandingTeeTimeRequest(int RequestNumber)
        {
            bool confirmation;
            SubmitStandingTeeTimeRequest StandingRequestManager = new SubmitStandingTeeTimeRequest();
            confirmation = StandingRequestManager.CancelStandingTeeTimeRequest(RequestNumber);

            return confirmation;
        }

        public bool SubmitMembershipApplications(MembershipApplication newApplication)
        {
            bool confirmation;
            MembershipApplications MembershipManager = new MembershipApplications();
            confirmation = MembershipManager.AddMembershipApplications(newApplication);

            return confirmation;

        }

        public List<MembershipApplication> ViewMemberApplications()
        {
            List<MembershipApplication> _mylist = new List<MembershipApplication>();
            MembershipApplications MembershipManager = new MembershipApplications();
            _mylist = MembershipManager.ViewMemberApplications();

            return _mylist;

        }

        public List<MembershipApplication> ViewWaitlistedMembershipApplications()
        {
            List<MembershipApplication> _mylist = new List<MembershipApplication>();
            MembershipApplications MembershipManager = new MembershipApplications();
            _mylist = MembershipManager.ViewWaitlistedMembershipApplications();

            return _mylist;
        }

        public Player ReviewMembershipApplication(int ApplicationNumber, string UpdatedStatus)
        {
            Player newPlayer = new Player();
            MembershipApplications MembershipManager = new MembershipApplications();
            newPlayer = MembershipManager.ReviewMembershipApplication(ApplicationNumber, UpdatedStatus);

            return newPlayer;
        }

        public int SubmitGolfGameScores(int MemberNumber, string GolfCourse, decimal CourseRating, decimal SlopeRating, DateTime GolfDate)
        {
            int GolfID;
            PlayerScores ScoreManager = new PlayerScores();
            GolfID = ScoreManager.SubmitGolfGameScores(MemberNumber, GolfCourse, CourseRating, SlopeRating, GolfDate);

            return GolfID;
        }

        public bool AddHoleScores(int GolfID, int HoleNumber, int HoleByHoleScore, int HolePar)
        {
            bool confirmation;
            PlayerScores ScoreManager = new PlayerScores();
            confirmation = ScoreManager.AddHoleScores(GolfID, HoleNumber, HoleByHoleScore, HolePar);

            return confirmation;
        }

        public bool UpdateTotalScores(int GolfID, int TotalScores, int MemberNumber)
        {
            bool confirmation;
            PlayerScores ScoreManager = new PlayerScores();
            confirmation = ScoreManager.UpdateTotalScores(GolfID, TotalScores, MemberNumber);

            return confirmation;
        }

        public List<decimal> GetLast20Scores(int MemberNumber)
        {
            List<decimal> _mylist = new List<decimal>();
            PlayerScores ScoreManager = new PlayerScores();
            _mylist = ScoreManager.GetLast20Scores(MemberNumber);

            return _mylist;
        }
        public decimal AverageLast20Scores(int MemberNumber)
        {
            decimal average;
            PlayerScores ScoreManager = new PlayerScores();
            average = ScoreManager.AverageLast20Scores(MemberNumber);

            return average;
        }

        public decimal Best8Average(int MemberNumber)
        {
            decimal average;
            PlayerScores ScoreManager = new PlayerScores();
            average = ScoreManager.AverageLast20Scores(MemberNumber);

            return average;
        }

        public Player ViewHandicapIndex(int MemberNumber)
        {
            Player player;
            PlayerScores ScoreManager = new PlayerScores();
            player = ScoreManager.ViewHandicapIndex(MemberNumber);

            return player;
        }

        public List<MemberAccount> ViewMemberAccount(int MemberNumber)
        {
            List<MemberAccount> _mylist = new List<MemberAccount>();
            MemberAccounts FinanceManager = new MemberAccounts();
            _mylist = FinanceManager.ViewMemberAccount(MemberNumber);

            return _mylist;
        }
        public List<Player> GetMemberDetailsUsingName(string MemberName)
        {
            List<Player> RequestedMembers = new List<Player>();
            SubmitStandingTeeTimeRequest StandingRequestManager = new SubmitStandingTeeTimeRequest();
            RequestedMembers = StandingRequestManager.GetMemberDetailsUsingName(MemberName);

            return RequestedMembers;
        }


        public bool MemberCheckIn(int MemberNumber, string GolfDate, string GolfTime)
        {
            bool confirmation;
            ManageTeeSheets TeeSheetManager = new ManageTeeSheets();
            confirmation = TeeSheetManager.MemberCheckIn(MemberNumber, GolfDate, GolfTime);

            return confirmation;
        }


    }
}
