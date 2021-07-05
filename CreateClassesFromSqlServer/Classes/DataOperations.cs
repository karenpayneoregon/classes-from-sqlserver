using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace CreateClassesFromSqlServer.Classes
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

        public static Language Language { get; set; }

        /// <summary>
        /// Iterate <see cref="Database"/> tables, create classes from
        /// SQL in the file ClassQuery.txt or ClassQueryPlain.txt
        ///
        /// ClassQuery.txt          Will show how to add an attribute to each property
        /// ClassQueryPlain.txt     Will create a plain vanilla class
        /// </summary>
        public static (bool, Exception) Create()
        {
            try
            {
                var classQuery = Language == Language.Sharp ? 
                    File.ReadAllText("ClassQueryPlain.txt") : 
                    File.ReadAllText("ClassQueryPlainVb.txt");
                
                var fileExtension = Language == Language.Sharp ? ".cs" : ".vb";
                

                using var cn = new SqlConnection($"Server={Server};Database={Database};Integrated Security=true");

                cn.Open();

                var adapter = new SqlDataAdapter(
                    "SELECT TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE " +
                    $"FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_TYPE = 'BASE TABLE') AND (TABLE_CATALOG = '{Database}') AND (TABLE_NAME != N'sysdiagrams') " +
                    "ORDER BY TABLE_NAME", cn);

                var table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    var tableName = "";
                    
                    if (row["TABLE_SCHEMA"].ToString() == "dbo")
                    {
                        tableName = row["TABLE_NAME"].ToString();
                    }
                    else
                    {
                        tableName = row["TABLE_SCHEMA"] + "." + row["TABLE_NAME"];
                    }

                    var fileName = tableName + fileExtension;

                    var baseFileName = Path.GetFileNameWithoutExtension(fileName);
                    baseFileName = baseFileName.Replace(".", "");

                    fileName = baseFileName + fileExtension;

                    string sqlStatement = $"declare @TableName sysname = '{tableName}'{classQuery}";

                    using var cmd = new SqlCommand(sqlStatement, cn);

                    string code = (string)cmd.ExecuteScalar();

                    var directoryName = Path.Combine(OutputFolder, Database);

                    if (!Directory.Exists(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    var path = Path.Combine(directoryName, fileName);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    File.WriteAllText(path, code);

                }

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex);
            }
        }

        /// <summary>
        /// Get all database names for <see cref="Server"/>
        /// </summary>
        /// <returns>List of database names a-z order excluding system tables</returns>
        public static async Task<List<string>> DatabaseNameList()
        {
            var tableNameList = new List<string>();
            var sqlStatement = await File.ReadAllTextAsync("DatabaseNames.txt");


            return await Task.Run(async () =>
            {
                await using var cn = new SqlConnection($"Server={Server};Database=master;Integrated Security=true");
                await using var cmd = new SqlCommand(sqlStatement, cn);

                cn.Open();

                var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    tableNameList.Add(reader.GetString(0));
                }


                return tableNameList;

            });

        }

        /// <summary>
        /// Get table names under <see cref="Server"/> for <see cref="Database"/>
        /// </summary>
        /// <returns>List of table names</returns>
        public static async Task<List<string>> TableNamesList()
        {
            var tableNameList = new List<string>();
            
            var sqlStatement = $"SELECT TABLE_NAME FROM [{Database}].INFORMATION_SCHEMA.TABLES " + 
                                     "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> 'sysdiagrams' " + 
                                     "ORDER BY TABLE_NAME";


            return await Task.Run(async () =>
            {
                
                await using var cn = new SqlConnection($"Server={Server};Database=master;Integrated Security=true");
                await using var cmd = new SqlCommand(sqlStatement, cn);

                cn.Open();

                var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    tableNameList.Add(reader.GetString(0));
                }
                
                return tableNameList;

            });

        }
    }
}