using _01.InitialSetUp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    public class StartUp
    {
        public static void Main()
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateTownsSqlQuery = @"UPDATE Towns
                                           SET Name = UPPER(Name)
                                         WHERE CountryCode = 
                                        (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(updateTownsSqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    int rowsAffected = (int)command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"No town names were affected.");
                        return;
                    }

                    Console.WriteLine($"{rowsAffected} town names were affected. ");
                }


                string townNamesSqlQuery = @"SELECT t.Name 
                                               FROM Towns as t
                                               JOIN Countries AS c ON c.Id = t.CountryCode
                                              WHERE c.Name = @countryName";

                List<string> towns = new List<string>();

                using (SqlCommand command = new SqlCommand(townNamesSqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
        }
    }
}
