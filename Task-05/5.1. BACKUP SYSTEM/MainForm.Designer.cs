namespace _5._1.BACKUP_SYSTEM
{
    partial class MainForm
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
            this.observerButton = new System.Windows.Forms.Button();
            this.backupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // observerButton
            // 
            this.observerButton.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.observerButton.Location = new System.Drawing.Point(109, 109);
            this.observerButton.Name = "observerButton";
            this.observerButton.Size = new System.Drawing.Size(234, 74);
            this.observerButton.TabIndex = 0;
            this.observerButton.Text = "Enable monitoring mode";
            this.observerButton.UseVisualStyleBackColor = true;
            this.observerButton.Click += new System.EventHandler(this.ObserverButton_Click);
            // 
            // backupButton
            // 
            this.backupButton.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backupButton.Location = new System.Drawing.Point(109, 243);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(234, 74);
            this.backupButton.TabIndex = 1;
            this.backupButton.Text = "Enable backup mode";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 450);
            this.Controls.Add(this.backupButton);
            this.Controls.Add(this.observerButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "BACKUP SYSTEM";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button observerButton;
        private System.Windows.Forms.Button backupButton;
    }
}