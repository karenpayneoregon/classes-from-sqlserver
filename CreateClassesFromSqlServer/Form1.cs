using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateClassesFromSqlServer.Classes;
using static CreateClassesFromSqlServer.Classes.Dialogs;

namespace CreateClassesFromSqlServer
{
    public partial class Form1 : Form
    {
        private BindingSource _databaseBindingSource = new ();
        public Form1()
        {
            InitializeComponent();

            DataOperations.Server = ".\\SQLEXPRESS";
            DataOperations.OutputFolder = "Classes";

            Shown += OnShown;
        }

        private async void OnShown(object? sender, EventArgs e)
        {
            _databaseBindingSource.DataSource = await DataOperations.DatabaseNameList();
            DatabaseNamesListBox.DataSource = _databaseBindingSource;
        }

        /// <summary>
        /// Database script (modified version of Microsoft's Northwind database)
        /// https://gist.github.com/karenpayneoregon/40a6e1158ff29819286a39b7f1ed1ae8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            DataOperations.Database = DatabaseNamesListBox.Text;
            

            if (CreatedListBox.Items.Contains(DatabaseNamesListBox.Text))
            {
                return;
            }
            
            
            var (success, exception) = DataOperations.Create();
            if (success)
            {
                CreatedListBox.Items.Add(DatabaseNamesListBox.Text);
                CreatedListBox.SelectedIndex = CreatedListBox.Items.Count -1;
            }
            else
            {
                MessageBox.Show($"Encountered issues\n{exception.Message}");
            }
        }


        /// <summary>
        /// Remove all class folders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveClassFolderButton_Click_1(object sender, EventArgs e)
        {
            if (Directory.Exists(DataOperations.OutputFolder))
            {
                if (Question("Confirm, remove all class folders"))
                {
                    var (success, exception) = FileOperations.RemoveFolder(DataOperations.OutputFolder);
                    if (!success)
                    {
                        MessageBox.Show($"Encountered issues\n{exception.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Folder does not exists");
            }

        }
    }
}
