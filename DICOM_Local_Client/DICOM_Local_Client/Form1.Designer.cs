namespace DICOM_Local_Client
{
    partial class Form1
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
            this.SendFileButton = new System.Windows.Forms.Button();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.PatienName = new System.Windows.Forms.TextBox();
            this.PatientName_Label = new System.Windows.Forms.Label();
            this.PatineSurname_Label = new System.Windows.Forms.Label();
            this.PatinetSurname = new System.Windows.Forms.TextBox();
            this.PatinetUsername_Label = new System.Windows.Forms.Label();
            this.PatientUsername = new System.Windows.Forms.TextBox();
            this.PatientDoB = new System.Windows.Forms.DateTimePicker();
            this.DoB_Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FilePath_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendFileButton
            // 
            this.SendFileButton.Location = new System.Drawing.Point(247, 149);
            this.SendFileButton.Name = "SendFileButton";
            this.SendFileButton.Size = new System.Drawing.Size(75, 23);
            this.SendFileButton.TabIndex = 0;
            this.SendFileButton.Text = "Send file";
            this.SendFileButton.UseVisualStyleBackColor = true;
            this.SendFileButton.Click += new System.EventHandler(this.SendFileButton_Click);
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(12, 149);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFileButton.TabIndex = 1;
            this.SelectFileButton.Text = "Select file";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // PatienName
            // 
            this.PatienName.Location = new System.Drawing.Point(101, 18);
            this.PatienName.Name = "PatienName";
            this.PatienName.Size = new System.Drawing.Size(200, 20);
            this.PatienName.TabIndex = 2;
            // 
            // PatientName_Label
            // 
            this.PatientName_Label.AutoSize = true;
            this.PatientName_Label.Location = new System.Drawing.Point(14, 28);
            this.PatientName_Label.Name = "PatientName_Label";
            this.PatientName_Label.Size = new System.Drawing.Size(35, 13);
            this.PatientName_Label.TabIndex = 3;
            this.PatientName_Label.Text = "Name";
            // 
            // PatineSurname_Label
            // 
            this.PatineSurname_Label.AutoSize = true;
            this.PatineSurname_Label.Location = new System.Drawing.Point(14, 54);
            this.PatineSurname_Label.Name = "PatineSurname_Label";
            this.PatineSurname_Label.Size = new System.Drawing.Size(49, 13);
            this.PatineSurname_Label.TabIndex = 5;
            this.PatineSurname_Label.Text = "Surname";
            // 
            // PatinetSurname
            // 
            this.PatinetSurname.Location = new System.Drawing.Point(101, 44);
            this.PatinetSurname.Name = "PatinetSurname";
            this.PatinetSurname.Size = new System.Drawing.Size(200, 20);
            this.PatinetSurname.TabIndex = 4;
            // 
            // PatinetUsername_Label
            // 
            this.PatinetUsername_Label.AutoSize = true;
            this.PatinetUsername_Label.Location = new System.Drawing.Point(14, 80);
            this.PatinetUsername_Label.Name = "PatinetUsername_Label";
            this.PatinetUsername_Label.Size = new System.Drawing.Size(55, 13);
            this.PatinetUsername_Label.TabIndex = 7;
            this.PatinetUsername_Label.Text = "Username";
            // 
            // PatientUsername
            // 
            this.PatientUsername.Location = new System.Drawing.Point(101, 70);
            this.PatientUsername.Name = "PatientUsername";
            this.PatientUsername.Size = new System.Drawing.Size(200, 20);
            this.PatientUsername.TabIndex = 6;
            // 
            // PatientDoB
            // 
            this.PatientDoB.Location = new System.Drawing.Point(101, 97);
            this.PatientDoB.Name = "PatientDoB";
            this.PatientDoB.Size = new System.Drawing.Size(200, 20);
            this.PatientDoB.TabIndex = 8;
            // 
            // DoB_Label
            // 
            this.DoB_Label.AutoSize = true;
            this.DoB_Label.Location = new System.Drawing.Point(14, 104);
            this.DoB_Label.Name = "DoB_Label";
            this.DoB_Label.Size = new System.Drawing.Size(66, 13);
            this.DoB_Label.TabIndex = 9;
            this.DoB_Label.Text = "Date of Birth";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PatinetSurname);
            this.groupBox1.Controls.Add(this.DoB_Label);
            this.groupBox1.Controls.Add(this.PatienName);
            this.groupBox1.Controls.Add(this.PatientDoB);
            this.groupBox1.Controls.Add(this.PatientName_Label);
            this.groupBox1.Controls.Add(this.PatinetUsername_Label);
            this.groupBox1.Controls.Add(this.PatineSurname_Label);
            this.groupBox1.Controls.Add(this.PatientUsername);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 131);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Info";
            // 
            // FilePath_textBox
            // 
            this.FilePath_textBox.Location = new System.Drawing.Point(13, 204);
            this.FilePath_textBox.Name = "FilePath_textBox";
            this.FilePath_textBox.Size = new System.Drawing.Size(100, 20);
            this.FilePath_textBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 249);
            this.Controls.Add(this.FilePath_textBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.SendFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendFileButton;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.TextBox PatienName;
        private System.Windows.Forms.Label PatientName_Label;
        private System.Windows.Forms.Label PatineSurname_Label;
        private System.Windows.Forms.TextBox PatinetSurname;
        private System.Windows.Forms.Label PatinetUsername_Label;
        private System.Windows.Forms.TextBox PatientUsername;
        private System.Windows.Forms.DateTimePicker PatientDoB;
        private System.Windows.Forms.Label DoB_Label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox FilePath_textBox;
    }
}

