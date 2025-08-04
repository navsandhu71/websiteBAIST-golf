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
    public class MemberLogin
    {
        public Player AuthenticateLogin(string UserName, string Password)
        {

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();



            SqlConnection ClubBAIST = new();
            ClubBAIST.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("ClubBAIST");



            ClubBAIST.Open();

            string ErrorMessage;


            SqlCommand AnAddCommand = new SqlCommand
            {
                Connection = ClubBAIST,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AuthenticateLogin"
            };


            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@UserName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = UserName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Password",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Password
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            Player AuthenticatedPlayer = new();

            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();
            try
            {
                if (exampleReader.HasRows)
                {


                    while (exampleReader.Read())
                    {

                        for (int i = 0; i < exampleReader.FieldCount; ++i)
                        {
                            AuthenticatedPlayer.MemberNumber = exampleReader["MemberNumber"].ToString();
                            AuthenticatedPlayer.MemberName = exampleReader["MemberName"].ToString();
                            AuthenticatedPlayer.MembershipLevel = exampleReader["MembershipLevel"].ToString();
                            AuthenticatedPlayer.PhoneNumber = exampleReader["PhoneNumber"].ToString();
                            AuthenticatedPlayer.UserName = exampleReader["UserName"].ToString();
                            AuthenticatedPlayer.Role = exampleReader["MemberRole"].ToString();

                        }

                    }

                }

                exampleReader.Close();
            }
            catch (SqlException ex)
            {
                ErrorMessage = ex.Message;
                if (ErrorMessage != null)
                {
                   AuthenticatedPlayer  = null;
                }

            }

            ClubBAIST.Close();

            return AuthenticatedPlayer;
        }

        public bool NewMemberSignUp(string MemberName, int MemberNumber, string Username, string Password)
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
                CommandText = "SignUpOnline"
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
                ParameterName = "@UserName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Username
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Password",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Password
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommand.ExecuteNonQuery();
            ClubBAIST.Close();
            success = true;

            return success;

        }
    }
}
