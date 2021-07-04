using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClassesFromSqlServer.Classes
{
    public class FileOperations
    {
        public static (bool, Exception) RemoveFolder(string folder)
        {
            try
            {
                Directory.Delete(folder, true);
                return (true, null);
            }
            catch (Exception exception)
            {
                return (false, exception);
            }
        }
    }
}
