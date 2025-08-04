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
    public class Clerk
    {
        public Player FindPlayer(int MemberNumber)
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
                CommandText = "FindMember"
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

            Player FoundPlayer = new();

            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();

            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {

                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        FoundPlayer.MemberNumber = exampleReader["MemberNumber"].ToString();
                        FoundPlayer.MemberName = exampleReader["MemberName"].ToString();
                        FoundPlayer.MembershipLevel = exampleReader["MembershipLevel"].ToString();
                        FoundPlayer.PhoneNumber = exampleReader["PhoneNumber"].ToString();
                        FoundPlayer.UserName = exampleReader["UserName"].ToString();
                        FoundPlayer.Role = exampleReader["MemberRole"].ToString();

                    }

                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return FoundPlayer;



        }
    }
}
