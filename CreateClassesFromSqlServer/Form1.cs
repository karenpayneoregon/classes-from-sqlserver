using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateClassesFromSqlServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            DataOperations.Server = ".\\SQLEXPRESS";
            DataOperations.Database = "NorthWind2020";
            DataOperations.OutputFolder = "Classes";
            
            DataOperations.Create();
        }
    }
}
