using _01.InitialSetUp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    class StartUp
    {
        public static void Main()
        {
            List<string> minionNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string nameSqlQuery = "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(nameSqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minionNames.Add((string)reader[0]);
                        }
                    }
                }
            }

            for (int i = 0; i < minionNames.Count / 2; i++)
            {

                Console.WriteLine(minionNames[i]);
                Console.WriteLine(minionNames[minionNames.Count - 1 - i]);
            }
            if (minionNames.Count % 2 != 0)
            {
                Console.WriteLine(minionNames[minionNames.Count / 2]);
            }
        }
    }
}
