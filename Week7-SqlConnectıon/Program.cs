using Npgsql;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Connection string = Specifies the database connection details
        string connectionString = "Host=myServerAddress; Port=5432; Database=myDataBase; Username=myUsername; Password=myPassword;";

        // Create a connection object
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            // Open the connection
            connection.Open();

            string query = "SELECT * FROM myTable";

            // Use NpgsqlCommand to execute the SQL query
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                // Execute the query and get the data reader
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    // Read the data
                    while (reader.Read())
                    {
                        // Output the value of a specific column
                        // Make sure the column name matches the actual database column name
                        Console.WriteLine(reader["ColumnName"]);
                    }
                }
            }

            // The connection will automatically be closed when the `using` block ends
        }
    }
}
