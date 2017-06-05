using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingData
{
    class Program
    {
        static void Main(string[] args)
        {

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = @"(LocalDb)\MSSQLLocalDB"; sqlConnectionStringBuilder.InitialCatalog ="ProgrammingInCSharp";

            string connectionString = sqlConnectionStringBuilder.ToString();

            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("Insert into People(FirstName, MiddleName,LastName) values('Bob','John','Zack')", conn);

            conn.Open();

            var result = command.ExecuteNonQuery();

            Console.WriteLine("Rows affected " + result.ToString());

            SqlCommand command2 = new SqlCommand("SELECT * FROM People", conn); 

            SqlDataReader reader = command2.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine(reader["firstname"] + " " + reader["middlename"] + " " + reader["lastname"]);
            }

            Console.ReadLine();

        }


        public static async Task SelectDataFromTable()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM People", connection); await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync(); while (await dataReader.ReadAsync())
                {
                    string formatStringWithMiddleName = "Person({ 0}) is named{ 1} { 2} { 3}";
                    string formatStringWithoutMiddleName = "Person({ 0}) is named{ 1} { 3}";

                    if ((dataReader["middlename"] == null))
                    {
                        Console.WriteLine(formatStringWithoutMiddleName, dataReader["id"], dataReader["firstname"], dataReader["lastname"]);
                    }
                    else
                    {
                        Console.WriteLine(formatStringWithMiddleName, dataReader["id"], dataReader["firstname"], dataReader["middlename"], dataReader["lastname"]);
                    }
                }
                dataReader.Close();
            }
        }
    }
}
