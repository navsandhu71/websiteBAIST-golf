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
    public class PlayerScores
    {
        public int SubmitGolfGameScores(int MemberNumber, string GolfCourse, decimal CourseRating, decimal SlopeRating, DateTime GolfDate)
        {
            int GolfID = 0;

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
                CommandText = "SubmitGolfGame"
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
                ParameterName = "@GolfCourse",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = GolfCourse
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@CourseRating",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = CourseRating
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@SlopeRating",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = SlopeRating
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
                ParameterName = "@GolfID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
                
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommand.ExecuteNonQuery();

            GolfID = (int)AnAddCommand.Parameters["@GolfID"].Value;

            ClubBAIST.Close();
           
            return GolfID;

        }

        public bool AddHoleScores(int GolfID, int HoleNumber, int HoleByHoleScore, int HolePar)
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
                CommandText = "AddHoleScores"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = GolfID
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@HoleNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = HoleNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@HoleByHoleScore",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = HoleByHoleScore
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Par",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = HolePar
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

           

            AnAddCommand.ExecuteNonQuery();


            ClubBAIST.Close();

            success = true;

            return success;
        }

        public bool UpdateTotalScores(int GolfID, int TotalScores, int MemberNumber)
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
                CommandText = "UpdateTotalScores"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@GolfID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = GolfID
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@TotalScores",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = TotalScores
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = MemberNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommand.ExecuteNonQuery();

            ClubBAIST.Close();

            success = true;

            return success;
        }

        public List<decimal> GetLast20Scores(int MemberNumber)
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
                CommandText = "GetLast20Scores"
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

            List<decimal> Last20Scores = new List<decimal>();
            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();


            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {
                    decimal _score = 0;
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        _score =decimal.Parse( exampleReader[0].ToString());
                    }

                    Last20Scores.Add(_score);
                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return Last20Scores;
        }

        public decimal AverageLast20Scores(int MemberNumber)
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
                CommandText = "Last20ScoresAverage"
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

            decimal average = 0;
            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {
                    
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        average =decimal.Parse(exampleReader[0].ToString());
                    }

                    
                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return average;
        }

        public decimal Best8Average(int MemberNumber)
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
                CommandText = "Best8Average"
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

            decimal average = 0;
            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {

                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        average = decimal.Parse(exampleReader[0].ToString());
                    }


                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return average;
        }


        public Player ViewHandicapIndex(int MemberNumber)
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
                CommandText = "ViewPlayerHandicap"
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
            Player player = new Player();

            if (exampleReader.HasRows)
            {

                while (exampleReader.Read())
                {

                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        player.HandicapCalculationDate = DateTime.Parse(exampleReader[1].ToString());
                        player.PlayerHandicapIndex = decimal.Parse(exampleReader[2].ToString());
                    }


                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return player;
        }
    }
}
