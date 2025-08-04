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
    public class MemberAccounts
    {
       public List<MemberAccount> ViewMemberAccount(int MemberNumber)
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
                CommandText = "ViewMemberAccount"
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

            
            List<MemberAccount> AccountInfo = new List<MemberAccount>();
            SqlDataReader exampleReader;
            exampleReader = AnAddCommand.ExecuteReader();


            if (exampleReader.HasRows)
            {

                while (exampleReader.Read())
                {
                    MemberAccount transaction = new MemberAccount();
                    for (int i = 0; i < exampleReader.FieldCount; ++i)
                    {
                        transaction.AccountNumber = int.Parse(exampleReader[0].ToString());
                        transaction.MemberName = exampleReader[1].ToString();
                        transaction.TransactionDescription = exampleReader[2].ToString();
                        transaction.TransactionAmount = decimal.Parse(exampleReader[3].ToString());
                        transaction.WhenBooked = DateTime.Parse(exampleReader[4].ToString());
                        transaction.WhenCharged = DateTime.Parse(exampleReader[5].ToString());
                        transaction.AccountBalance = decimal.Parse(exampleReader[6].ToString());
                    }
                    AccountInfo.Add(transaction);
                }

            }

            exampleReader.Close();

            ClubBAIST.Close();

            return AccountInfo;
        }
    }
}
