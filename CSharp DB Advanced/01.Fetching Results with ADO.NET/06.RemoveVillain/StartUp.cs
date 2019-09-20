using _01.InitialSetUp;
using System;
using System.Data.SqlClient;

namespace _06.RemoveVillain
{
    public class StartUp
    {
        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainQuery = "Select Name From Villains Where Id = @villainId";

                string villainName;

                using (SqlCommand command = new SqlCommand(villainQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);

                    villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                int deletedMinions = DeleteMinionsVillainsById(connection, villainId);
                DeleteVillainsById(connection, villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{deletedMinions} minions were released.");
            }
        }

        private static void DeleteVillainsById(SqlConnection connection, int villainId)
        {
            string deleteVillainQuery = "DELETE FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                command.ExecuteNonQuery();
            }
        }

        private static int DeleteMinionsVillainsById(SqlConnection connection, int villainId)
        {
            string deleteVillainQuery = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return command.ExecuteNonQuery();
            }
        }
    }
}
