
namespace FA21_Final_Project
{
    partial class frmForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForgotPassword));
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cbxFirstChallengeQuestion = new System.Windows.Forms.ComboBox();
            this.lblFirstChallengeQuestion = new System.Windows.Forms.Label();
            this.cbxSecondChallengeQuestion = new System.Windows.Forms.ComboBox();
            this.lblSecondChallengeQuestion = new System.Windows.Forms.Label();
            this.cbxThirdChallengeQuestion = new System.Windows.Forms.ComboBox();
            this.lblThirdChallengeQuestion = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbxNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbxConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblFirstChallengeAnswer = new System.Windows.Forms.Label();
            this.tbxFirstChallengeAnswer = new System.Windows.Forms.TextBox();
            this.lblSecondChallengeAnswer = new System.Windows.Forms.Label();
            this.tbxSecondChallengeAnswer = new System.Windows.Forms.TextBox();
            this.lblThirdChallengeAnswer = new System.Windows.Forms.Label();
            this.tbxThirdChallengeAnswer = new System.Windows.Forms.TextBox();
            this.lblErrorFirstAnswer = new System.Windows.Forms.Label();
            this.lblErrorUserName = new System.Windows.Forms.Label();
            this.lblErrorSecondAnswer = new System.Windows.Forms.Label();
            this.lblErrorThirdAnswer = new System.Windows.Forms.Label();
            this.lblErrorNewPassword = new System.Windows.Forms.Label();
            this.lblErrorConfirmPassword = new System.Windows.Forms.Label();
            this.lblChangePassError = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pbxShowNewPassword = new System.Windows.Forms.PictureBox();
            this.pbxShowConfirmPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowConfirmPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(306, 40);
            this.tbxUsername.MaxLength = 20;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(160, 29);
            this.tbxUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(198, 40);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(102, 22);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // cbxFirstChallengeQuestion
            // 
            this.cbxFirstChallengeQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFirstChallengeQuestion.Enabled = false;
            this.cbxFirstChallengeQuestion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFirstChallengeQuestion.FormattingEnabled = true;
            this.cbxFirstChallengeQuestion.Items.AddRange(new object[] {
            "Where were you born?",
            "What was your first school?",
            "What\'s your favorite food?",
            "What is your first pets name?",
            "What is your mother\'s name?"});
            this.cbxFirstChallengeQuestion.Location = new System.Drawing.Point(306, 79);
            this.cbxFirstChallengeQuestion.Name = "cbxFirstChallengeQuestion";
            this.cbxFirstChallengeQuestion.Size = new System.Drawing.Size(275, 26);
            this.cbxFirstChallengeQuestion.TabIndex = 1;
            // 
            // lblFirstChallengeQuestion
            // 
            this.lblFirstChallengeQuestion.AutoSize = true;
            this.lblFirstChallengeQuestion.Enabled = false;
            this.lblFirstChallengeQuestion.Location = new System.Drawing.Point(77, 78);
            this.lblFirstChallengeQuestion.Name = "lblFirstChallengeQuestion";
            this.lblFirstChallengeQuestion.Size = new System.Drawing.Size(223, 22);
            this.lblFirstChallengeQuestion.TabIndex = 5;
            this.lblFirstChallengeQuestion.Text = "First Challenge Question:";
            // 
            // cbxSecondChallengeQuestion
            // 
            this.cbxSecondChallengeQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecondChallengeQuestion.Enabled = false;
            this.cbxSecondChallengeQuestion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSecondChallengeQuestion.FormattingEnabled = true;
            this.cbxSecondChallengeQuestion.Items.AddRange(new object[] {
            "Where were you born?",
            "What was your first school?",
            "What\'s your favorite food?",
            "What is your first pets name?",
            "What is your mother\'s name?"});
            this.cbxSecondChallengeQuestion.Location = new System.Drawing.Point(306, 154);
            this.cbxSecondChallengeQuestion.Name = "cbxSecondChallengeQuestion";
            this.cbxSecondChallengeQuestion.Size = new System.Drawing.Size(275, 26);
            this.cbxSecondChallengeQuestion.TabIndex = 3;
            // 
            // lblSecondChallengeQuestion
            // 
            this.lblSecondChallengeQuestion.AutoSize = true;
            this.lblSecondChallengeQuestion.Enabled = false;
            this.lblSecondChallengeQuestion.Location = new System.Drawing.Point(48, 154);
            this.lblSecondChallengeQuestion.Name = "lblSecondChallengeQuestion";
            this.lblSecondChallengeQuestion.Size = new System.Drawing.Size(252, 22);
            this.lblSecondChallengeQuestion.TabIndex = 14;
            this.lblSecondChallengeQuestion.Text = "Second Challenge Question:";
            // 
            // cbxThirdChallengeQuestion
            // 
            this.cbxThirdChallengeQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThirdChallengeQuestion.Enabled = false;
            this.cbxThirdChallengeQuestion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxThirdChallengeQuestion.FormattingEnabled = true;
            this.cbxThirdChallengeQuestion.Items.AddRange(new object[] {
            "Where were you born?",
            "What was your first school?",
            "What\'s your favorite food?",
            "What is your first pets name?",
            "What is your mother\'s name?"});
            this.cbxThirdChallengeQuestion.Location = new System.Drawing.Point(306, 229);
            this.cbxThirdChallengeQuestion.Name = "cbxThirdChallengeQuestion";
            this.cbxThirdChallengeQuestion.Size = new System.Drawing.Size(275, 26);
            this.cbxThirdChallengeQuestion.TabIndex = 5;
            // 
            // lblThirdChallengeQuestion
            // 
            this.lblThirdChallengeQuestion.AutoSize = true;
            this.lblThirdChallengeQuestion.Enabled = false;
            this.lblThirdChallengeQuestion.Location = new System.Drawing.Point(71, 230);
            this.lblThirdChallengeQuestion.Name = "lblThirdChallengeQuestion";
            this.lblThirdChallengeQuestion.Size = new System.Drawing.Size(229, 22);
            this.lblThirdChallengeQuestion.TabIndex = 18;
            this.lblThirdChallengeQuestion.Text = "Third Challenge Question:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Enabled = false;
            this.lblNewPassword.Location = new System.Drawing.Point(159, 306);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(141, 22);
            this.lblNewPassword.TabIndex = 20;
            this.lblNewPassword.Text = "New Password:";
            // 
            // tbxNewPassword
            // 
            this.tbxNewPassword.Enabled = false;
            this.tbxNewPassword.Location = new System.Drawing.Point(306, 304);
            this.tbxNewPassword.MaxLength = 20;
            this.tbxNewPassword.Name = "tbxNewPassword";
            this.tbxNewPassword.Size = new System.Drawing.Size(160, 29);
            this.tbxNewPassword.TabIndex = 7;
            this.tbxNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Enabled = false;
            this.lblConfirmPassword.Location = new System.Drawing.Point(129, 344);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(171, 22);
            this.lblConfirmPassword.TabIndex = 22;
            this.lblConfirmPassword.Text = "Confirm Password:";
            // 
            // tbxConfirmPassword
            // 
            this.tbxConfirmPassword.Enabled = false;
            this.tbxConfirmPassword.Location = new System.Drawing.Point(306, 343);
            this.tbxConfirmPassword.MaxLength = 20;
            this.tbxConfirmPassword.Name = "tbxConfirmPassword";
            this.tbxConfirmPassword.Size = new System.Drawing.Size(160, 29);
            this.tbxConfirmPassword.TabIndex = 8;
            this.tbxConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(337, 432);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmit.Location = new System.Drawing.Point(121, 432);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(161, 33);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Next";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblFirstChallengeAnswer
            // 
            this.lblFirstChallengeAnswer.AutoSize = true;
            this.lblFirstChallengeAnswer.Enabled = false;
            this.lblFirstChallengeAnswer.Location = new System.Drawing.Point(91, 116);
            this.lblFirstChallengeAnswer.Name = "lblFirstChallengeAnswer";
            this.lblFirstChallengeAnswer.Size = new System.Drawing.Size(209, 22);
            this.lblFirstChallengeAnswer.TabIndex = 29;
            this.lblFirstChallengeAnswer.Text = "First Challenge Answer:";
            // 
            // tbxFirstChallengeAnswer
            // 
            this.tbxFirstChallengeAnswer.Enabled = false;
            this.tbxFirstChallengeAnswer.Location = new System.Drawing.Point(306, 115);
            this.tbxFirstChallengeAnswer.MaxLength = 20;
            this.tbxFirstChallengeAnswer.Name = "tbxFirstChallengeAnswer";
            this.tbxFirstChallengeAnswer.Size = new System.Drawing.Size(181, 29);
            this.tbxFirstChallengeAnswer.TabIndex = 2;
            // 
            // lblSecondChallengeAnswer
            // 
            this.lblSecondChallengeAnswer.AutoSize = true;
            this.lblSecondChallengeAnswer.Enabled = false;
            this.lblSecondChallengeAnswer.Location = new System.Drawing.Point(62, 192);
            this.lblSecondChallengeAnswer.Name = "lblSecondChallengeAnswer";
            this.lblSecondChallengeAnswer.Size = new System.Drawing.Size(238, 22);
            this.lblSecondChallengeAnswer.TabIndex = 32;
            this.lblSecondChallengeAnswer.Text = "Second Challenge Answer:";
            // 
            // tbxSecondChallengeAnswer
            // 
            this.tbxSecondChallengeAnswer.Enabled = false;
            this.tbxSecondChallengeAnswer.Location = new System.Drawing.Point(306, 190);
            this.tbxSecondChallengeAnswer.MaxLength = 20;
            this.tbxSecondChallengeAnswer.Name = "tbxSecondChallengeAnswer";
            this.tbxSecondChallengeAnswer.Size = new System.Drawing.Size(181, 29);
            this.tbxSecondChallengeAnswer.TabIndex = 4;
            // 
            // lblThirdChallengeAnswer
            // 
            this.lblThirdChallengeAnswer.AutoSize = true;
            this.lblThirdChallengeAnswer.Enabled = false;
            this.lblThirdChallengeAnswer.Location = new System.Drawing.Point(85, 268);
            this.lblThirdChallengeAnswer.Name = "lblThirdChallengeAnswer";
            this.lblThirdChallengeAnswer.Size = new System.Drawing.Size(215, 22);
            this.lblThirdChallengeAnswer.TabIndex = 34;
            this.lblThirdChallengeAnswer.Text = "Third Challenge Answer:";
            // 
            // tbxThirdChallengeAnswer
            // 
            this.tbxThirdChallengeAnswer.Enabled = false;
            this.tbxThirdChallengeAnswer.Location = new System.Drawing.Point(306, 265);
            this.tbxThirdChallengeAnswer.MaxLength = 20;
            this.tbxThirdChallengeAnswer.Name = "tbxThirdChallengeAnswer";
            this.tbxThirdChallengeAnswer.Size = new System.Drawing.Size(181, 29);
            this.tbxThirdChallengeAnswer.TabIndex = 6;
            // 
            // lblErrorFirstAnswer
            // 
            this.lblErrorFirstAnswer.AutoSize = true;
            this.lblErrorFirstAnswer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFirstAnswer.ForeColor = System.Drawing.Color.Red;
            this.lblErrorFirstAnswer.Location = new System.Drawing.Point(78, 116);
            this.lblErrorFirstAnswer.Name = "lblErrorFirstAnswer";
            this.lblErrorFirstAnswer.Size = new System.Drawing.Size(14, 18);
            this.lblErrorFirstAnswer.TabIndex = 30;
            this.lblErrorFirstAnswer.Text = "*";
            this.lblErrorFirstAnswer.Visible = false;
            // 
            // lblErrorUserName
            // 
            this.lblErrorUserName.AutoSize = true;
            this.lblErrorUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUserName.ForeColor = System.Drawing.Color.Red;
            this.lblErrorUserName.Location = new System.Drawing.Point(178, 40);
            this.lblErrorUserName.Name = "lblErrorUserName";
            this.lblErrorUserName.Size = new System.Drawing.Size(14, 18);
            this.lblErrorUserName.TabIndex = 35;
            this.lblErrorUserName.Text = "*";
            this.lblErrorUserName.Visible = false;
            // 
            // lblErrorSecondAnswer
            // 
            this.lblErrorSecondAnswer.AutoSize = true;
            this.lblErrorSecondAnswer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorSecondAnswer.ForeColor = System.Drawing.Color.Red;
            this.lblErrorSecondAnswer.Location = new System.Drawing.Point(49, 192);
            this.lblErrorSecondAnswer.Name = "lblErrorSecondAnswer";
            this.lblErrorSecondAnswer.Size = new System.Drawing.Size(14, 18);
            this.lblErrorSecondAnswer.TabIndex = 38;
            this.lblErrorSecondAnswer.Text = "*";
            this.lblErrorSecondAnswer.Visible = false;
            // 
            // lblErrorThirdAnswer
            // 
            this.lblErrorThirdAnswer.AutoSize = true;
            this.lblErrorThirdAnswer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorThirdAnswer.ForeColor = System.Drawing.Color.Red;
            this.lblErrorThirdAnswer.Location = new System.Drawing.Point(72, 268);
            this.lblErrorThirdAnswer.Name = "lblErrorThirdAnswer";
            this.lblErrorThirdAnswer.Size = new System.Drawing.Size(14, 18);
            this.lblErrorThirdAnswer.TabIndex = 40;
            this.lblErrorThirdAnswer.Text = "*";
            this.lblErrorThirdAnswer.Visible = false;
            // 
            // lblErrorNewPassword
            // 
            this.lblErrorNewPassword.AutoSize = true;
            this.lblErrorNewPassword.Enabled = false;
            this.lblErrorNewPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNewPassword.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNewPassword.Location = new System.Drawing.Point(148, 304);
            this.lblErrorNewPassword.Name = "lblErrorNewPassword";
            this.lblErrorNewPassword.Size = new System.Drawing.Size(14, 18);
            this.lblErrorNewPassword.TabIndex = 41;
            this.lblErrorNewPassword.Text = "*";
            this.lblErrorNewPassword.Visible = false;
            // 
            // lblErrorConfirmPassword
            // 
            this.lblErrorConfirmPassword.AutoSize = true;
            this.lblErrorConfirmPassword.Enabled = false;
            this.lblErrorConfirmPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorConfirmPassword.ForeColor = System.Drawing.Color.Red;
            this.lblErrorConfirmPassword.Location = new System.Drawing.Point(117, 343);
            this.lblErrorConfirmPassword.Name = "lblErrorConfirmPassword";
            this.lblErrorConfirmPassword.Size = new System.Drawing.Size(14, 18);
            this.lblErrorConfirmPassword.TabIndex = 42;
            this.lblErrorConfirmPassword.Text = "*";
            this.lblErrorConfirmPassword.Visible = false;
            // 
            // lblChangePassError
            // 
            this.lblChangePassError.AutoSize = true;
            this.lblChangePassError.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePassError.ForeColor = System.Drawing.Color.Red;
            this.lblChangePassError.Location = new System.Drawing.Point(92, 378);
            this.lblChangePassError.Name = "lblChangePassError";
            this.lblChangePassError.Size = new System.Drawing.Size(118, 18);
            this.lblChangePassError.TabIndex = 43;
            this.lblChangePassError.Text = "*Error Message";
            this.lblChangePassError.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.Red;
            this.btnHelp.Location = new System.Drawing.Point(547, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(59, 30);
            this.btnHelp.TabIndex = 44;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pbxShowNewPassword
            // 
            this.pbxShowNewPassword.Image = ((System.Drawing.Image)(resources.GetObject("pbxShowNewPassword.Image")));
            this.pbxShowNewPassword.Location = new System.Drawing.Point(472, 306);
            this.pbxShowNewPassword.Name = "pbxShowNewPassword";
            this.pbxShowNewPassword.Size = new System.Drawing.Size(39, 27);
            this.pbxShowNewPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxShowNewPassword.TabIndex = 45;
            this.pbxShowNewPassword.TabStop = false;
            this.pbxShowNewPassword.Click += new System.EventHandler(this.pbxShowNewPassword_Click);
            // 
            // pbxShowConfirmPassword
            // 
            this.pbxShowConfirmPassword.Image = ((System.Drawing.Image)(resources.GetObject("pbxShowConfirmPassword.Image")));
            this.pbxShowConfirmPassword.Location = new System.Drawing.Point(472, 345);
            this.pbxShowConfirmPassword.Name = "pbxShowConfirmPassword";
            this.pbxShowConfirmPassword.Size = new System.Drawing.Size(39, 27);
            this.pbxShowConfirmPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxShowConfirmPassword.TabIndex = 46;
            this.pbxShowConfirmPassword.TabStop = false;
            this.pbxShowConfirmPassword.Click += new System.EventHandler(this.pbxShowConfirmPassword_Click);
            // 
            // frmForgotPassword
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(206)))), ((int)(((byte)(208)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(618, 505);
            this.Controls.Add(this.pbxShowConfirmPassword);
            this.Controls.Add(this.pbxShowNewPassword);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblChangePassError);
            this.Controls.Add(this.lblErrorConfirmPassword);
            this.Controls.Add(this.lblErrorNewPassword);
            this.Controls.Add(this.lblErrorThirdAnswer);
            this.Controls.Add(this.lblErrorSecondAnswer);
            this.Controls.Add(this.lblErrorUserName);
            this.Controls.Add(this.lblThirdChallengeAnswer);
            this.Controls.Add(this.tbxThirdChallengeAnswer);
            this.Controls.Add(this.lblSecondChallengeAnswer);
            this.Controls.Add(this.tbxSecondChallengeAnswer);
            this.Controls.Add(this.lblErrorFirstAnswer);
            this.Controls.Add(this.lblFirstChallengeAnswer);
            this.Controls.Add(this.tbxFirstChallengeAnswer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.tbxConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.tbxNewPassword);
            this.Controls.Add(this.cbxThirdChallengeQuestion);
            this.Controls.Add(this.lblThirdChallengeQuestion);
            this.Controls.Add(this.cbxSecondChallengeQuestion);
            this.Controls.Add(this.lblSecondChallengeQuestion);
            this.Controls.Add(this.cbxFirstChallengeQuestion);
            this.Controls.Add(this.lblFirstChallengeQuestion);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.tbxUsername);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "frmForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot Password";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmForgotPassword_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShowConfirmPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox cbxFirstChallengeQuestion;
        private System.Windows.Forms.Label lblFirstChallengeQuestion;
        private System.Windows.Forms.ComboBox cbxSecondChallengeQuestion;
        private System.Windows.Forms.Label lblSecondChallengeQuestion;
        private System.Windows.Forms.ComboBox cbxThirdChallengeQuestion;
        private System.Windows.Forms.Label lblThirdChallengeQuestion;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbxNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbxConfirmPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblFirstChallengeAnswer;
        private System.Windows.Forms.TextBox tbxFirstChallengeAnswer;
        private System.Windows.Forms.Label lblSecondChallengeAnswer;
        private System.Windows.Forms.TextBox tbxSecondChallengeAnswer;
        private System.Windows.Forms.Label lblThirdChallengeAnswer;
        private System.Windows.Forms.TextBox tbxThirdChallengeAnswer;
        private System.Windows.Forms.Label lblErrorFirstAnswer;
        private System.Windows.Forms.Label lblErrorUserName;
        private System.Windows.Forms.Label lblErrorSecondAnswer;
        private System.Windows.Forms.Label lblErrorThirdAnswer;
        private System.Windows.Forms.Label lblErrorNewPassword;
        private System.Windows.Forms.Label lblErrorConfirmPassword;
        private System.Windows.Forms.Label lblChangePassError;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.PictureBox pbxShowNewPassword;
        private System.Windows.Forms.PictureBox pbxShowConfirmPassword;
    }
}