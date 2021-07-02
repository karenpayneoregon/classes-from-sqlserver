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

        /// <summary>
        /// Database script (modified version of Microsoft's Northwind database)
        /// https://gist.github.com/karenpayneoregon/40a6e1158ff29819286a39b7f1ed1ae8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            DataOperations.Server = ".\\SQLEXPRESS";
            DataOperations.Database = "NorthWind2020";
            DataOperations.OutputFolder = "Classes";
            
            DataOperations.Create();
        }
    }
}
