﻿
namespace CreateClassesFromSqlServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CreateButton = new System.Windows.Forms.Button();
            this.DatabaseNamesListBox = new System.Windows.Forms.ListBox();
            this.CreatedListBox = new System.Windows.Forms.ListBox();
            this.RemoveClassesFolderButton = new System.Windows.Forms.Button();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateButton.Image")));
            this.CreateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateButton.Location = new System.Drawing.Point(329, 12);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(132, 23);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Run/Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DatabaseNamesListBox
            // 
            this.DatabaseNamesListBox.FormattingEnabled = true;
            this.DatabaseNamesListBox.ItemHeight = 15;
            this.DatabaseNamesListBox.Location = new System.Drawing.Point(12, 12);
            this.DatabaseNamesListBox.Name = "DatabaseNamesListBox";
            this.DatabaseNamesListBox.Size = new System.Drawing.Size(302, 229);
            this.DatabaseNamesListBox.TabIndex = 1;
            // 
            // CreatedListBox
            // 
            this.CreatedListBox.FormattingEnabled = true;
            this.CreatedListBox.ItemHeight = 15;
            this.CreatedListBox.Location = new System.Drawing.Point(329, 70);
            this.CreatedListBox.Name = "CreatedListBox";
            this.CreatedListBox.Size = new System.Drawing.Size(322, 154);
            this.CreatedListBox.TabIndex = 2;
            // 
            // RemoveClassesFolderButton
            // 
            this.RemoveClassesFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveClassesFolderButton.Image")));
            this.RemoveClassesFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveClassesFolderButton.Location = new System.Drawing.Point(519, 12);
            this.RemoveClassesFolderButton.Name = "RemoveClassesFolderButton";
            this.RemoveClassesFolderButton.Size = new System.Drawing.Size(132, 23);
            this.RemoveClassesFolderButton.TabIndex = 3;
            this.RemoveClassesFolderButton.Text = "Remove classes";
            this.RemoveClassesFolderButton.UseVisualStyleBackColor = true;
            this.RemoveClassesFolderButton.Click += new System.EventHandler(this.RemoveClassFolderButton_Click_1);
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(329, 41);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(132, 23);
            this.LanguageComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Double click name above to open in folder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 252);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.RemoveClassesFolderButton);
            this.Controls.Add(this.CreatedListBox);
            this.Controls.Add(this.DatabaseNamesListBox);
            this.Controls.Add(this.CreateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.ListBox DatabaseNamesListBox;
        private System.Windows.Forms.ListBox CreatedListBox;
        private System.Windows.Forms.Button RemoveClassesFolderButton;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label label1;
    }
}

