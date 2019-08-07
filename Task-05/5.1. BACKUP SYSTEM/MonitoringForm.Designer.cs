namespace _5._1.BACKUP_SYSTEM
{
    partial class MonitoringForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.saveBackupLabel = new System.Windows.Forms.Label();
            this.openFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // newText
            // 
            this.newText.Enabled = false;
            this.newText.Location = new System.Drawing.Point(12, 32);
            this.newText.Multiline = true;
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(532, 272);
            this.newText.TabIndex = 0;
            // 
            // SaveMeAs
            // 
            this.SaveMeAs.Enabled = false;
            this.SaveMeAs.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveMeAs.Location = new System.Drawing.Point(161, 331);
            this.SaveMeAs.Name = "SaveMeAs";
            this.SaveMeAs.Size = new System.Drawing.Size(132, 50);
            this.SaveMeAs.TabIndex = 1;
            this.SaveMeAs.Text = "Save As File";
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
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1_Deleted);
            // 
            // createFolder
            // 
            this.createFolder.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createFolder.Location = new System.Drawing.Point(12, 331);
            this.createFolder.Name = "createFolder";
            this.createFolder.Size = new System.Drawing.Size(132, 50);
            this.createFolder.TabIndex = 2;
            this.createFolder.Text = "Create/Check Folders";
            this.createFolder.UseVisualStyleBackColor = true;
            this.createFolder.Click += new System.EventHandler(this.CreateFolder_Click);
            // 
            // SaveBackupChanges
            // 
            this.SaveBackupChanges.Enabled = false;
            this.SaveBackupChanges.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBackupChanges.Location = new System.Drawing.Point(312, 331);
            this.SaveBackupChanges.Name = "SaveBackupChanges";
            this.SaveBackupChanges.Size = new System.Drawing.Size(132, 50);
            this.SaveBackupChanges.TabIndex = 3;
            this.SaveBackupChanges.Text = "Save Text File Backup";
            this.SaveBackupChanges.UseVisualStyleBackColor = true;
            this.SaveBackupChanges.Click += new System.EventHandler(this.SaveBackupChanges_Click);
            // 
            // goToMenuButton
            // 
            this.goToMenuButton.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goToMenuButton.Location = new System.Drawing.Point(412, 388);
            this.goToMenuButton.Name = "goToMenuButton";
            this.goToMenuButton.Size = new System.Drawing.Size(132, 50);
            this.goToMenuButton.TabIndex = 4;
            this.goToMenuButton.Text = "Back to Main Menu";
            this.goToMenuButton.UseVisualStyleBackColor = true;
            this.goToMenuButton.Click += new System.EventHandler(this.GoToMenuButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter your text here";
            // 
            // saveBackupLabel
            // 
            this.saveBackupLabel.AutoSize = true;
            this.saveBackupLabel.Enabled = false;
            this.saveBackupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveBackupLabel.Location = new System.Drawing.Point(250, 313);
            this.saveBackupLabel.Name = "saveBackupLabel";
            this.saveBackupLabel.Size = new System.Drawing.Size(270, 15);
            this.saveBackupLabel.TabIndex = 7;
            this.saveBackupLabel.Text = "YOUR BACKUP FILES SUCCESSFULLY SAVED!";
            // 
            // openFolder
            // 
            this.openFolder.Enabled = false;
            this.openFolder.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openFolder.Location = new System.Drawing.Point(12, 388);
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(132, 50);
            this.openFolder.TabIndex = 8;
            this.openFolder.Text = "Open Main Folder";
            this.openFolder.UseVisualStyleBackColor = true;
            this.openFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // MonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.openFolder);
            this.Controls.Add(this.saveBackupLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goToMenuButton);
            this.Controls.Add(this.SaveBackupChanges);
            this.Controls.Add(this.createFolder);
            this.Controls.Add(this.SaveMeAs);
            this.Controls.Add(this.newText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitoringForm";
            this.Text = "Monitoring mode";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label saveBackupLabel;
        private System.Windows.Forms.Button openFolder;
    }
}