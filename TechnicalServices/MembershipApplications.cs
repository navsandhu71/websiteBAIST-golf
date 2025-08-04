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
    public class MembershipApplications
    {
        public bool AddMembershipApplications(MembershipApplication newApplication)
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
                CommandText = "SubmitMembershipApplication"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.LastName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.FirstName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.Address
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.PostalCode
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.Phone
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@AlternatePhone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.AlternatePhone
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.Email
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@DateOfBirth",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.DateOfBirth
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Occupation",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue =  newApplication.Occupation
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@CompanyName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.CompanyName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@CompanyAddress",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.CompanyAddress
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@CompanyPostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.CompanyPostalCode
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@CompanyPhone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.CompanyPhone
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@ApplicationDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.ApplicationDate
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Shareholder1Name",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.FirstShareholderName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Shareholder2Name",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.SecondShareholderName
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@RequestedRole",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newApplication.RequestedRole
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommand.ExecuteNonQuery();
            ClubBAIST.Close();
            success = true;

            return success;


        }

        public List<MembershipApplication> ViewMemberApplications()
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
                CommandText = "FetchAllMembershipApplications"
            };


            List<MembershipApplication> applications = new List<MembershipApplication>();
            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();


            if (exampleReader.HasRows)
            {

              
                while (exampleReader.Read())
                {
                    MembershipApplication _application1 = new MembershipApplication();
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        _application1.ApplicationNumber = int.Parse(exampleReader[0].ToString());
                        _application1.LastName = exampleReader[1].ToString();
                        _application1.FirstName = exampleReader[2].ToString();
                        _application1.Address = exampleReader[3].ToString();
                        _application1.PostalCode = exampleReader[4].ToString();
                        _application1.Phone = exampleReader[5].ToString();
                        _application1.AlternatePhone = exampleReader[6].ToString();
                        _application1.Email = exampleReader[7].ToString();
                        _application1.DateOfBirth = DateTime.Parse(exampleReader[8].ToString());
                        _application1.Occupation = exampleReader[9].ToString();
                        _application1.CompanyName = exampleReader[10].ToString();
                        _application1.CompanyAddress = exampleReader[11].ToString();
                        _application1.CompanyPostalCode = exampleReader[12].ToString();
                        _application1.CompanyPhone = exampleReader[13].ToString();
                        _application1.ApplicationDate = DateTime.Parse(exampleReader[14].ToString());
                        _application1.OnlineSubmissionDate = DateTime.Parse(exampleReader[15].ToString());
                        _application1.FirstShareholderName = exampleReader[16].ToString();
                        _application1.SecondShareholderName = exampleReader[17].ToString();
                        _application1.RequestedRole = exampleReader[18].ToString();
                        _application1.ApplicationStatus = exampleReader[19].ToString();
                    }
                    applications.Add(_application1);
                }
                
            }

            exampleReader.Close();

            ClubBAIST.Close();

            return applications;


        }

        public List<MembershipApplication> ViewWaitlistedMembershipApplications()
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
                CommandText = "ViewWaitlistedMembershipApplications"
            };


            List<MembershipApplication> applications = new List<MembershipApplication>();
            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();


            if (exampleReader.HasRows)
            {


                while (exampleReader.Read())
                {
                    MembershipApplication _application1 = new MembershipApplication();
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        _application1.ApplicationNumber = int.Parse(exampleReader[0].ToString());
                        _application1.LastName = exampleReader[1].ToString();
                        _application1.FirstName = exampleReader[2].ToString();
                        _application1.Address = exampleReader[3].ToString();
                        _application1.PostalCode = exampleReader[4].ToString();
                        _application1.Phone = exampleReader[5].ToString();
                        _application1.AlternatePhone = exampleReader[6].ToString();
                        _application1.Email = exampleReader[7].ToString();
                        _application1.DateOfBirth = DateTime.Parse(exampleReader[8].ToString());
                        _application1.Occupation = exampleReader[9].ToString();
                        _application1.CompanyName = exampleReader[10].ToString();
                        _application1.CompanyAddress = exampleReader[11].ToString();
                        _application1.CompanyPostalCode = exampleReader[12].ToString();
                        _application1.CompanyPhone = exampleReader[13].ToString();
                        _application1.ApplicationDate = DateTime.Parse(exampleReader[14].ToString());
                        _application1.OnlineSubmissionDate = DateTime.Parse(exampleReader[15].ToString());
                        _application1.FirstShareholderName = exampleReader[16].ToString();
                        _application1.SecondShareholderName = exampleReader[17].ToString();
                        _application1.RequestedRole = exampleReader[18].ToString();
                        _application1.ApplicationStatus = exampleReader[19].ToString();
                    }
                    applications.Add(_application1);
                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return applications;


        }
        public Player ReviewMembershipApplication(int ApplicationNumber, string UpdatedStatus)
        {
            Player newPlayer = new Player();
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
                CommandText = "ReviewMembershipApplication"
            };

            SqlParameter AnAddCommandParameter;
            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@ApplicationNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = ApplicationNumber
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@UpdatedStatus",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = UpdatedStatus
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@Username",
                SqlDbType = SqlDbType.VarChar,
                Size=10,
                Direction = ParameterDirection.Output                
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);

            AnAddCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            AnAddCommand.Parameters.Add(AnAddCommandParameter);


            AnAddCommand.ExecuteNonQuery();

            newPlayer.MemberNumber = (AnAddCommand.Parameters["@MemberNumber"].Value).ToString();
            newPlayer.UserName = (AnAddCommand.Parameters["@Username"].Value).ToString();

            ClubBAIST.Close();
           
            return newPlayer;

        }
    }
}
