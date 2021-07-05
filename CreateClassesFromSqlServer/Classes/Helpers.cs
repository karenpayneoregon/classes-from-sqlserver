using System.Collections.Generic;

namespace CreateClassesFromSqlServer.Classes
{
    public class Helpers
    {
        /// <summary>
        /// For ComboBox language selection
        /// </summary>
        public static List<ComboLanguage> Languages => new()
        {
            new() {Display = "C#", Language = Language.Sharp},
            new() {Display = "VB.NET", Language = Language.Basic}
        };
    }
}