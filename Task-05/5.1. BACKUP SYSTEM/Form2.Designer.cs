﻿namespace _5._1.BACKUP_SYSTEM
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newText = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SaveMeAs = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.createFolder = new System.Windows.Forms.Button();
            this.SaveBackupChanges = new System.Windows.Forms.Button();
            this.goToMenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // newText
            // 
            this.newText.Location = new System.Drawing.Point(12, 12);
            this.newText.Multiline = true;
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(532, 266);
            this.newText.TabIndex = 0;
            // 
            // SaveMeAs
            // 
            this.SaveMeAs.Location = new System.Drawing.Point(143, 304);
            this.SaveMeAs.Name = "SaveMeAs";
            this.SaveMeAs.Size = new System.Drawing.Size(94, 34);
            this.SaveMeAs.TabIndex = 1;
            this.SaveMeAs.Text = "Save As";
            this.SaveMeAs.UseVisualStyleBackColor = true;
            this.SaveMeAs.Click += new System.EventHandler(this.SaveMeAs_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1_Created);
            // 
            // createFolder
            // 
            this.createFolder.Location = new System.Drawing.Point(12, 304);
            this.createFolder.Name = "createFolder";
            this.createFolder.Size = new System.Drawing.Size(94, 34);
            this.createFolder.TabIndex = 2;
            this.createFolder.Text = "Create Folder";
            this.createFolder.UseVisualStyleBackColor = true;
            this.createFolder.Click += new System.EventHandler(this.CreateFolder_Click);
            // 
            // SaveBackupChanges
            // 
            this.SaveBackupChanges.Location = new System.Drawing.Point(430, 304);
            this.SaveBackupChanges.Name = "SaveBackupChanges";
            this.SaveBackupChanges.Size = new System.Drawing.Size(96, 33);
            this.SaveBackupChanges.TabIndex = 3;
            this.SaveBackupChanges.Text = "Save Backup";
            this.SaveBackupChanges.UseVisualStyleBackColor = true;
            this.SaveBackupChanges.Click += new System.EventHandler(this.SaveBackupChanges_Click);
            // 
            // goToMenuButton
            // 
            this.goToMenuButton.Location = new System.Drawing.Point(221, 394);
            this.goToMenuButton.Name = "goToMenuButton";
            this.goToMenuButton.Size = new System.Drawing.Size(100, 44);
            this.goToMenuButton.TabIndex = 4;
            this.goToMenuButton.Text = "Back to main menu";
            this.goToMenuButton.UseVisualStyleBackColor = true;
            this.goToMenuButton.Click += new System.EventHandler(this.GoToMenuButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.goToMenuButton);
            this.Controls.Add(this.SaveBackupChanges);
            this.Controls.Add(this.createFolder);
            this.Controls.Add(this.SaveMeAs);
            this.Controls.Add(this.newText);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newText;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button SaveMeAs;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button createFolder;
        private System.Windows.Forms.Button SaveBackupChanges;
        private System.Windows.Forms.Button goToMenuButton;
    }
}