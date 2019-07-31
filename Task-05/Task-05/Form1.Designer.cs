namespace Task_05
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.folder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.newText = new System.Windows.Forms.TextBox();
            this.saveNewText = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveChanges = new System.Windows.Forms.Button();
            this.backupDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.Path = "D:\\Users\\cam\\mydocs\\Files for Task-05\\Working Files";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1_Created);
            // 
            // folder
            // 
            this.folder.Location = new System.Drawing.Point(39, 340);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(75, 23);
            this.folder.TabIndex = 0;
            this.folder.Text = "Folder";
            this.folder.UseVisualStyleBackColor = true;
            this.folder.Click += new System.EventHandler(this.Folder_Click);
            // 
            // newText
            // 
            this.newText.Location = new System.Drawing.Point(30, 37);
            this.newText.Multiline = true;
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(193, 209);
            this.newText.TabIndex = 2;
            // 
            // saveNewText
            // 
            this.saveNewText.Location = new System.Drawing.Point(160, 340);
            this.saveNewText.Name = "saveNewText";
            this.saveNewText.Size = new System.Drawing.Size(75, 23);
            this.saveNewText.TabIndex = 3;
            this.saveNewText.Text = "Save As";
            this.saveNewText.UseVisualStyleBackColor = true;
            this.saveNewText.Click += new System.EventHandler(this.SaveNewText_Click);
            // 
            // saveChanges
            // 
            this.saveChanges.Location = new System.Drawing.Point(271, 340);
            this.saveChanges.Name = "saveChanges";
            this.saveChanges.Size = new System.Drawing.Size(75, 23);
            this.saveChanges.TabIndex = 4;
            this.saveChanges.Text = "Save";
            this.saveChanges.UseVisualStyleBackColor = true;
            this.saveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // backupDate
            // 
            this.backupDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backupDate.FormattingEnabled = true;
            this.backupDate.Location = new System.Drawing.Point(289, 51);
            this.backupDate.Name = "backupDate";
            this.backupDate.Size = new System.Drawing.Size(121, 21);
            this.backupDate.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 450);
            this.Controls.Add(this.backupDate);
            this.Controls.Add(this.saveChanges);
            this.Controls.Add(this.saveNewText);
            this.Controls.Add(this.newText);
            this.Controls.Add(this.folder);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button folder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox newText;
        private System.Windows.Forms.Button saveNewText;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button saveChanges;
        private System.Windows.Forms.ComboBox backupDate;
    }
}

