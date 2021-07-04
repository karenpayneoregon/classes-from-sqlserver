using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Classes
{
    public class SqlOperations
    {
        /// <summary>
        /// SQL-Server name
        /// </summary>
        public static string Server { get; set; }
        /// <summary>
        /// Database in Server
        /// </summary>
        public static string Database { get; set; }

        /// <summary>
        /// Read top 10 countries 
        /// </summary>
        /// <returns></returns>
        public static (bool, Exception, List<Countries>) GetCountriesList()
        {
            try
            {
                List<Countries> countriesList = new List<Countries>();
                using var cn = new SqlConnection($"Server={Server};Database={Database};Integrated Security=true");
                using var cmd = new SqlCommand("SELECT TOP 10 CountryIdentifier, Name FROM dbo.Countries;", cn);

                cn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    countriesList.Add(new Countries() { CountryIdentifier = reader.GetInt32(0), Name = reader.GetString(1) });
                }

                return (true, null, countriesList);
            }
            catch (Exception exception)
            {
                return (false, exception, null);
            }
        }
    }
}
