namespace _5._1.BACKUP_SYSTEM
{
    partial class Form3
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
            this.dateBackupList = new System.Windows.Forms.ListBox();
            this.backupText = new System.Windows.Forms.TextBox();
            this.showBackupDates = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.backupFolders = new System.Windows.Forms.Button();
            this.filesBackupList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // dateBackupList
            // 
            this.dateBackupList.FormattingEnabled = true;
            this.dateBackupList.Location = new System.Drawing.Point(12, 12);
            this.dateBackupList.Name = "dateBackupList";
            this.dateBackupList.Size = new System.Drawing.Size(132, 329);
            this.dateBackupList.TabIndex = 0;
            this.dateBackupList.SelectedIndexChanged += new System.EventHandler(this.DateList_SelectedIndexChanged);
            // 
            // backupText
            // 
            this.backupText.Location = new System.Drawing.Point(346, 12);
            this.backupText.Multiline = true;
            this.backupText.Name = "backupText";
            this.backupText.Size = new System.Drawing.Size(198, 328);
            this.backupText.TabIndex = 1;
            // 
            // showBackupDates
            // 
            this.showBackupDates.Location = new System.Drawing.Point(24, 347);
            this.showBackupDates.Name = "showBackupDates";
            this.showBackupDates.Size = new System.Drawing.Size(102, 38);
            this.showBackupDates.TabIndex = 2;
            this.showBackupDates.Text = "Show Backup variants";
            this.showBackupDates.UseVisualStyleBackColor = true;
            this.showBackupDates.Click += new System.EventHandler(this.ShowBackupDates_Click);
            // 
            // menuButton
            // 
            this.menuButton.Location = new System.Drawing.Point(229, 396);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(100, 42);
            this.menuButton.TabIndex = 3;
            this.menuButton.Text = "Go back to Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // backupFolders
            // 
            this.backupFolders.Location = new System.Drawing.Point(299, 351);
            this.backupFolders.Name = "backupFolders";
            this.backupFolders.Size = new System.Drawing.Size(103, 34);
            this.backupFolders.TabIndex = 4;
            this.backupFolders.Text = "Show Backup Folders";
            this.backupFolders.UseVisualStyleBackColor = true;
            this.backupFolders.Click += new System.EventHandler(this.BackupFolders_Click);
            // 
            // filesBackupList
            // 
            this.filesBackupList.FormattingEnabled = true;
            this.filesBackupList.Location = new System.Drawing.Point(150, 11);
            this.filesBackupList.Name = "filesBackupList";
            this.filesBackupList.Size = new System.Drawing.Size(190, 329);
            this.filesBackupList.TabIndex = 5;
            this.filesBackupList.SelectedIndexChanged += new System.EventHandler(this.FilesBackupList_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.filesBackupList);
            this.Controls.Add(this.backupFolders);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.showBackupDates);
            this.Controls.Add(this.backupText);
            this.Controls.Add(this.dateBackupList);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox dateBackupList;
        private System.Windows.Forms.TextBox backupText;
        private System.Windows.Forms.Button showBackupDates;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button backupFolders;
        private System.Windows.Forms.ListBox filesBackupList;
    }
}