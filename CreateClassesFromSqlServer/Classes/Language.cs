using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClassesFromSqlServer.Classes
{
    public enum Language
    {
        Sharp,
        Basic
    }

    public class ComboLanguage
    {
        public string Display { get; set; }
        public Language Language { get; set; }
        public override string ToString() => Display;

    }

    public class Helpers
    {
        public static List<ComboLanguage> Languages => new List<ComboLanguage>()
        {
            new ComboLanguage() {Display = "C#", Language = Language.Sharp},
            new ComboLanguage() {Display = "VB.NET", Language = Language.Basic}

        };
    }
}
