using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GolfClubWebsite.Domain;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GolfClubWebsite.TechnicalServices
{
    public class SubmitStandingTeeTimeRequest
    { 

        public List<string> FetchAvailableTeeTimesRequest(string RequestedDay)
        {

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();



            SqlConnection ClubBAIST = new();
            ClubBAIST.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("ClubBAIST");



            ClubBAIST.Open();

            SqlCommand AnAddCommand = new SqlCommand
            {
                Connection = ClubBAIST,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetAvailableStandingTeeTimes"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Day",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = RequestedDay
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();


            List<string> _availableRequests = new List<string>();

            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {
                    string value="";
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        value=exampleReader[0].ToString();

                    }
                    _availableRequests.Add(value);

                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return _availableRequests;


        }



        public bool SubmitStandingTeeTimeApplication(StandingTeeTimeRequestForm FilledForm)
        {
            bool success = false;
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();



            SqlConnection ClubBAIST = new();
            ClubBAIST.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("ClubBAIST");



            ClubBAIST.Open();

            SqlCommand AnAddCommand = new SqlCommand
            {
                Connection = ClubBAIST,
                CommandType = CommandType.StoredProcedure,
                CommandText = "SubmitStandingTeeTimeRequest"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@FirstMemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.FirstMemberName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@SecondMemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.SecondMemberName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@ThirdMemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.ThirdMemberName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@ForthMemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.ForthMemberName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@FirstMemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.FirstMemberNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@SecondMemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.SecondMemberNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@ThirdMemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.ThirdMemberNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@ForthMemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.ForthMemberNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@RequestedDay",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.RequestedDayOfWeek
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@RequestedTeeTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.RequestedTime
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@StartDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.RequestedStartDate
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@EndDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = FilledForm.RequestedEndDate
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            
            AnAddCommand.ExecuteNonQuery();
            ClubBAIST.Close();
            success = true;

            return success;



        }

        public StandingTeeTimeRequestForm ShowRequestedTeeTimes(int MemberNumber)
        {

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();



            SqlConnection ClubBAIST = new();
            ClubBAIST.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("ClubBAIST");



            ClubBAIST.Open();

            SqlCommand AnAddCommand = new SqlCommand
            {
                Connection = ClubBAIST,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ShowStandingTeeTimeRequest"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = MemberNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();

            StandingTeeTimeRequestForm standingTeeTimeRequest = new StandingTeeTimeRequestForm();

            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {

                    standingTeeTimeRequest.RequestNumber = int.Parse(exampleReader[0].ToString());
                    standingTeeTimeRequest.FirstMemberName = exampleReader[1].ToString();
                    standingTeeTimeRequest.SecondMemberName = exampleReader[2].ToString();
                    standingTeeTimeRequest.ThirdMemberName = exampleReader[3].ToString();
                    standingTeeTimeRequest.ForthMemberName = exampleReader[4].ToString();
                    standingTeeTimeRequest.RequestedDayOfWeek = exampleReader[5].ToString();
                    standingTeeTimeRequest.RequestedTime = exampleReader[6].ToString();



                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return standingTeeTimeRequest;

        }
        public bool CancelStandingTeeTimeRequest(int RequestNumber)
        {
            bool success = false;

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();



            SqlConnection ClubBAIST = new();
            ClubBAIST.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("ClubBAIST");



            ClubBAIST.Open();

            SqlCommand AnAddCommand = new SqlCommand
            {
                Connection = ClubBAIST,
                CommandType = CommandType.StoredProcedure,
                CommandText = "CancelStandingTeeTimeRequest"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@RequestNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = RequestNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

                      
            AnAddCommand.ExecuteNonQuery();
            ClubBAIST.Close();
            success = true;

            return success;
        }

        public List<Player> GetMemberDetailsUsingName(string MemberName)
        {
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();



            SqlConnection ClubBAIST = new();
            ClubBAIST.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("ClubBAIST");



            ClubBAIST.Open();

            SqlCommand AnAddCommand = new SqlCommand
            {
                Connection = ClubBAIST,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetMemberDetailsUsingName"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = MemberName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();

            List<Player> RequestedMembers = new List<Player>();

            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {
                    Player player = new Player();
                    for(int i=0;i<exampleReader.FieldCount;++i)
                    {
                        player.MemberNumber = exampleReader[0].ToString();
                        player.MemberName = exampleReader[1].ToString();
                        player.MembershipLevel = exampleReader[2].ToString();
                        player.PhoneNumber = exampleReader[3].ToString();
                        
                    }

                    RequestedMembers.Add(player);

                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return RequestedMembers;

        }
    }
}
