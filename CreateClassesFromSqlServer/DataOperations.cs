using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CreateClassesFromSqlServer
{
    public class DataOperations
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
        /// Location to create classes
        /// </summary>
        public static string OutputFolder { get; set; }
        
        /// <summary>
        /// Iterate <see cref="Database"/> tables, create classes from
        /// SQL in the file ClassQuery.txt
        /// </summary>
        public static void Create()
        {
            var classQuery = File.ReadAllText("ClassQuery.txt");
            using var connection = new SqlConnection($"Server={Server};Database={Database};Integrated Security=true");
            
            connection.Open();
            
            var adapter = new SqlDataAdapter(
                "SELECT TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE " +
                $"FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_TYPE = 'BASE TABLE') AND (TABLE_CATALOG = '{Database}') AND (TABLE_NAME != N'sysdiagrams') " + 
                "ORDER BY TABLE_NAME", connection);
            
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                var tableName = row["TABLE_NAME"].ToString();
                var fileName = tableName + ".cs";

                string sql = $"declare @TableName sysname = '{tableName}'{classQuery}";

                using var cmd = new SqlCommand(sql, connection);
                string code = (string)cmd.ExecuteScalar();

                if (File.Exists(Path.Combine(OutputFolder, fileName)))
                {
                    File.Delete(Path.Combine(OutputFolder, fileName));
                }
                
                File.WriteAllText(Path.Combine(OutputFolder, fileName), code);

            }
        }


    }
}