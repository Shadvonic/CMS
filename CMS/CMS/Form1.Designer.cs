namespace CMS
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
            this.btnCaseIndexForm = new System.Windows.Forms.Button();
            this.btnAddCase = new System.Windows.Forms.Button();
            this.btnEditCase = new System.Windows.Forms.Button();
            this.btnRosterForm = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnConfigurationSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.AddPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCaseIndexForm
            // 
            this.btnCaseIndexForm.Location = new System.Drawing.Point(140, 1);
            this.btnCaseIndexForm.Name = "btnCaseIndexForm";
            this.btnCaseIndexForm.Size = new System.Drawing.Size(66, 33);
            this.btnCaseIndexForm.TabIndex = 1;
            this.btnCaseIndexForm.Text = "Case";
            this.btnCaseIndexForm.UseVisualStyleBackColor = true;
            this.btnCaseIndexForm.Click += new System.EventHandler(this.btnCaseIndexForm_Click);
            // 
            // btnAddCase
            // 
            this.btnAddCase.Location = new System.Drawing.Point(73, 1);
            this.btnAddCase.Name = "btnAddCase";
            this.btnAddCase.Size = new System.Drawing.Size(70, 33);
            this.btnAddCase.TabIndex = 2;
            this.btnAddCase.Text = "Persons";
            this.btnAddCase.UseVisualStyleBackColor = true;
            this.btnAddCase.Click += new System.EventHandler(this.btnAddCase_Click);
            // 
            // btnEditCase
            // 
            this.btnEditCase.Location = new System.Drawing.Point(475, 406);
            this.btnEditCase.Name = "btnEditCase";
            this.btnEditCase.Size = new System.Drawing.Size(82, 25);
            this.btnEditCase.TabIndex = 3;
            this.btnEditCase.Text = "Case Index";
            this.btnEditCase.UseVisualStyleBackColor = true;
            this.btnEditCase.Click += new System.EventHandler(this.btnEditCase_Click);
            // 
            // btnRosterForm
            // 
            this.btnRosterForm.Location = new System.Drawing.Point(12, 403);
            this.btnRosterForm.Name = "btnRosterForm";
            this.btnRosterForm.Size = new System.Drawing.Size(99, 28);
            this.btnRosterForm.TabIndex = 4;
            this.btnRosterForm.Text = "Person Index";
            this.btnRosterForm.UseVisualStyleBackColor = true;
            this.btnRosterForm.Click += new System.EventHandler(this.btnRosterForm_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(720, 406);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(68, 25);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnConfigurationSettings
            // 
            this.btnConfigurationSettings.Location = new System.Drawing.Point(2, 2);
            this.btnConfigurationSettings.Name = "btnConfigurationSettings";
            this.btnConfigurationSettings.Size = new System.Drawing.Size(75, 32);
            this.btnConfigurationSettings.TabIndex = 7;
            this.btnConfigurationSettings.Text = "File";
            this.btnConfigurationSettings.UseVisualStyleBackColor = true;
            this.btnConfigurationSettings.Click += new System.EventHandler(this.btnConfigurationSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Menu System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(554, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "Add Case";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddPerson
            // 
            this.AddPerson.Location = new System.Drawing.Point(107, 403);
            this.AddPerson.Name = "AddPerson";
            this.AddPerson.Size = new System.Drawing.Size(99, 28);
            this.AddPerson.TabIndex = 12;
            this.AddPerson.Text = "Add Person";
            this.AddPerson.UseVisualStyleBackColor = true;
            this.AddPerson.Click += new System.EventHandler(this.AddPerson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 446);
            this.Controls.Add(this.AddPerson);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfigurationSettings);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnRosterForm);
            this.Controls.Add(this.btnEditCase);
            this.Controls.Add(this.btnAddCase);
            this.Controls.Add(this.btnCaseIndexForm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCaseIndexForm;
        private System.Windows.Forms.Button btnAddCase;
        private System.Windows.Forms.Button btnEditCase;
        private System.Windows.Forms.Button btnRosterForm;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnConfigurationSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddPerson;
    }
}

