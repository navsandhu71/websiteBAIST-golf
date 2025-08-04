using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfClubWebsite.Domain;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GolfClubWebsite.TechnicalServices
{
    public class ManageTeeSheets
    {
        public DailyTeeSheet FindDailyTeeSheet(string Date)
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
                CommandText = "FetchDailySheet"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = Date
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            DailyTeeSheet RequestedTeeSheet = new();

            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();

            List<TeeTime> golfteetimes = new List<TeeTime>();

            if (exampleReader.HasRows)
            {

                while (exampleReader.Read())
                {
                    TeeTime teeTime = new TeeTime();
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        RequestedTeeSheet.Date = exampleReader["GolfDate"].ToString();
                        RequestedTeeSheet.DayOfWeek = exampleReader["GolfDay"].ToString();
                        teeTime.Time = exampleReader["GolfTime"].ToString();
                        teeTime.Date =exampleReader["GolfDate"].ToString();
                        teeTime.Member1Name = exampleReader["Member1Name"].ToString();
                        teeTime.Member2Name = exampleReader["Member2Name"].ToString();
                        teeTime.Member3Name = exampleReader["Member3Name"].ToString();
                        teeTime.Member4Name = exampleReader["Member4Name"].ToString();
                       
                        teeTime.NoOfCarts = exampleReader["NoOfCarts"].ToString();
                 
                        teeTime.BookingDate1 = exampleReader["BookingDate1"].ToString();
                        teeTime.BookingDate2 = exampleReader["BookingDate2"].ToString();
                        teeTime.BookingDate3 = exampleReader["BookingDate3"].ToString();
                        teeTime.BookingDate4 = exampleReader["BookingDate4"].ToString();

                    }
                    RequestedTeeSheet.GolfTeeTimes.Add(teeTime);


                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return RequestedTeeSheet;
        }

        public string FinalizeTeeTime(TeeTime ModifiedTeeTime)
        {
            bool success = false;
            string message;

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
                CommandText = "FinalizeTeeTime"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = ModifiedTeeTime.Date
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

           
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfTime",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ModifiedTeeTime.Time
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ModifiedTeeTime.MemberName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = ModifiedTeeTime.MemberNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@NoOfCarts",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = ModifiedTeeTime.NoOfCarts
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            try
            {

                AnAddCommand.ExecuteNonQuery();
                message = "Tee Time Booked Successfully";
               // success = true;
            }

            catch(SqlException ex)
            {
                message = ex.Message;
            //    success = false;
            }
            ClubBAIST.Close();
            return message;


        }


        public List<TeeTime> ShowBookedTimes(int MemberNumber)
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
                CommandText = "ShowBookedTeeTimes"
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


            List<TeeTime> _bookedTimes = new List<TeeTime>();

            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {
                    TeeTime booked = new TeeTime();
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        booked.Date = exampleReader[0].ToString();
                        booked.Day  = exampleReader[1].ToString();
                        booked.Time = exampleReader[2].ToString();
                        booked.status = exampleReader[3].ToString();
                    }
                    _bookedTimes.Add(booked);

                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return _bookedTimes;
        }


        public bool CancelTeeTime(string MemberNumber, string GolfDate, string GolfTime)
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
                CommandText = "CancelTeeTime"
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

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = GolfDate
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                SqlValue = GolfTime
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommand.ExecuteNonQuery();
            ClubBAIST.Close();
            success = true;

            return success;

        }


        public bool CancelTeeTimeClerkAndMembers(string MemberNumber, string GolfDate, string GolfTime)
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
                CommandText = "CancelTeeTimeClerkAndMembers"
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

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = GolfDate
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                SqlValue = GolfTime
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommand.ExecuteNonQuery();
            ClubBAIST.Close();
            success = true;

            return success;

        }

        public bool MemberCheckIn(int MemberNumber, string GolfDate, string GolfTime)
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
                CommandText = "CheckInMember"
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

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = GolfDate
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfTime",
                SqlDbType = SqlDbType.Time,
                Direction = ParameterDirection.Input,
                SqlValue = GolfTime
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommand.ExecuteNonQuery();
            ClubBAIST.Close();
            success = true;

            return success;

        }
    }
}
