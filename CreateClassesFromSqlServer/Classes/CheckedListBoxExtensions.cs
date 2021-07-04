using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CreateClassesFromSqlServer.Classes
{
    public static class CheckedListBoxExtensions
    {
        public static List<string> SelectedTableNames(this CheckedListBox sender)
        {
            return sender.Items.Cast<string>().Where((cat, index) => sender.GetItemChecked(index)).Select(item => item).ToList();
        }
    }
}