namespace _5._1.BACKUP_SYSTEM
{
    partial class BackupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateBackupList
            // 
            this.dateBackupList.FormattingEnabled = true;
            this.dateBackupList.Location = new System.Drawing.Point(12, 38);
            this.dateBackupList.Name = "dateBackupList";
            this.dateBackupList.Size = new System.Drawing.Size(132, 303);
            this.dateBackupList.TabIndex = 0;
            this.dateBackupList.SelectedIndexChanged += new System.EventHandler(this.DateList_SelectedIndexChanged);
            // 
            // backupText
            // 
            this.backupText.Location = new System.Drawing.Point(335, 38);
            this.backupText.Multiline = true;
            this.backupText.Name = "backupText";
            this.backupText.Size = new System.Drawing.Size(209, 302);
            this.backupText.TabIndex = 1;
            // 
            // showBackupDates
            // 
            this.showBackupDates.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showBackupDates.Location = new System.Drawing.Point(12, 347);
            this.showBackupDates.Name = "showBackupDates";
            this.showBackupDates.Size = new System.Drawing.Size(132, 50);
            this.showBackupDates.TabIndex = 2;
            this.showBackupDates.Text = "Show Backup Folders Variants";
            this.showBackupDates.UseVisualStyleBackColor = true;
            this.showBackupDates.Click += new System.EventHandler(this.ShowBackupDates_Click);
            // 
            // menuButton
            // 
            this.menuButton.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuButton.Location = new System.Drawing.Point(412, 388);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(132, 50);
            this.menuButton.TabIndex = 3;
            this.menuButton.Text = "Back to Main Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // backupFolders
            // 
            this.backupFolders.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backupFolders.Location = new System.Drawing.Point(170, 347);
            this.backupFolders.Name = "backupFolders";
            this.backupFolders.Size = new System.Drawing.Size(132, 50);
            this.backupFolders.TabIndex = 4;
            this.backupFolders.Text = "Show Backup Folders";
            this.backupFolders.UseVisualStyleBackColor = true;
            this.backupFolders.Click += new System.EventHandler(this.BackupFolders_Click);
            // 
            // filesBackupList
            // 
            this.filesBackupList.FormattingEnabled = true;
            this.filesBackupList.Location = new System.Drawing.Point(150, 38);
            this.filesBackupList.Name = "filesBackupList";
            this.filesBackupList.Size = new System.Drawing.Size(179, 303);
            this.filesBackupList.TabIndex = 5;
            this.filesBackupList.SelectedIndexChanged += new System.EventHandler(this.FilesBackupList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Backup folders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(137, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Backup .txt files in selected folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(369, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Text in selected .txt file";
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filesBackupList);
            this.Controls.Add(this.backupFolders);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.showBackupDates);
            this.Controls.Add(this.backupText);
            this.Controls.Add(this.dateBackupList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupForm";
            this.Text = "Backup mode";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}