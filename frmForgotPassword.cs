using FA21_Final_Project.Properties;
using System;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmForgotPassword : Form
    {
        public enum LoginState { EnterUserName, EnterAnswers, Finish }
        LoginState loginState = LoginState.EnterUserName;
        bool bolIsClicked, bolIsClicked2, bolIsHelp = true;
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bolIsHelp = false;
            //Declare all control arrays
            TextBox[] arrTbx = new TextBox[]
            {
            tbxUsername, tbxFirstChallengeAnswer,tbxSecondChallengeAnswer,tbxThirdChallengeAnswer
            };
            ComboBox[] arrCbx = new ComboBox[]
            {
                cbxFirstChallengeQuestion,cbxSecondChallengeQuestion,cbxThirdChallengeQuestion
            };
            Label[] arrLbl = new Label[]
            {
                lblFirstChallengeQuestion, lblFirstChallengeAnswer, lblSecondChallengeQuestion, lblSecondChallengeAnswer,
                lblThirdChallengeQuestion,lblThirdChallengeAnswer
            };
            Label[] arrErrors = new Label[] {
                lblErrorFirstAnswer, lblErrorSecondAnswer, lblErrorThirdAnswer
            };

            //Clear then set all error labels not visible to the user on start
            lblChangePassError.Visible = false;
            lblChangePassError.Text = "";

            foreach (Label lbl in arrErrors)
            {
                lbl.Visible = false;
            }
            //Check if user entered an input after clicking a button, if they did not then throw an error message
            if (String.IsNullOrEmpty(tbxUsername.Text))
            {
                lblChangePassError.Text = "*Please enter a UserName";
                lblChangePassError.Visible = true;
                lblErrorUserName.Visible = true;
            }
            else
            {
             /*
              Starting State: EnterUsername - 
              Run ForgotPassword Function & show needed input TextBoxes & ComboBoxes
             
              State: Enter Answers - 
              Show all needed input TextBoxes, change Button Text to Submit and set State to Finish
             
              State: Finish - 
              Inform user of successful password change, close form & show frmLogin*/  
                lblErrorUserName.Visible = false;

                switch (loginState)
                {
                    case LoginState.EnterUserName:
                        tbxUsername.ReadOnly = true;
                        if(clsLogon.ForgotPassword(arrTbx, arrCbx, loginState, tbxNewPassword, tbxConfirmPassword, lblChangePassError, arrErrors)){
                            for (int i = 0; i < arrTbx.Length; i++)
                            {
                                arrTbx[i].Enabled = true;
                            }
                            for (int i = 0; i < arrLbl.Length; i++)
                            {
                                arrLbl[i].Enabled = true;
                            }
                            loginState = LoginState.EnterAnswers;
                        }
                        else
                        {
                            tbxUsername.ReadOnly = false;
                        }
                        break;
                    case LoginState.EnterAnswers:
                        for (int i = 0; i < arrTbx.Length; i++)
                        {
                            arrTbx[i].ReadOnly = true;
                        }
                        if (clsLogon.ForgotPassword(arrTbx, arrCbx, loginState, tbxNewPassword, tbxConfirmPassword, lblChangePassError, arrErrors))
                        {
                            tbxConfirmPassword.Enabled = true;
                            tbxNewPassword.Enabled = true;
                            lblNewPassword.Enabled = true;
                            lblConfirmPassword.Enabled = true;
                            btnSubmit.Text = "Submit";
                            loginState = LoginState.Finish;
                        }
                        else
                        {
                            for (int i = 0; i < arrTbx.Length; i++)
                            {
                                arrTbx[i].ReadOnly = false;
                            }
                        }
                        break;
                    case LoginState.Finish:
                        if (clsLogon.ForgotPassword(arrTbx, arrCbx, loginState, tbxNewPassword, tbxConfirmPassword, lblChangePassError, arrErrors))
                        {
                            if (MessageBox.Show("Password saved and changed successfully", "Password changed.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                Close();
                            }
                        }
                        break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Set Help Boolean to false and call closing event
            bolIsHelp = false;
            clsLogon.dataReader = null;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Set Help Boolean to true, create HelpObject, Pass in Form State, set FrmHelp Background to appropriate image, width & height
            //Show FrmHelp & close currrent form
            bolIsHelp = true;
            frmHelp frmHelpObj = new frmHelp("Forgot Password");
            frmHelpObj.BackgroundImage = Resources.frmForgotPassHelp;
            frmHelpObj.Width = Resources.frmForgotPassHelp.Width + 20;
            frmHelpObj.Height = Resources.frmForgotPassHelp.Height;
            frmHelpObj.Show();
            this.Close();
        }

        private void pbxShowNewPassword_Click(object sender, EventArgs e)
        {
            /*If the button is first clicked, unhide password text and change the color of the image
             If button is clicked once more, hide password text & change the PictureBox back to the previous image*/
            if (!bolIsClicked)
            {
                pbxShowNewPassword.Image = Resources.HidePasswordBtn;
                bolIsClicked = true;
                tbxNewPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pbxShowNewPassword.Image = Resources.ShowPasswordBtn;
                bolIsClicked = false;
                tbxNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void pbxShowConfirmPassword_Click(object sender, EventArgs e)
        {
            /*If the button is first clicked, unhide password text and change to appropriate image
             If button is clicked once more, hide password text & revert the PictureBox back to the previous image*/
            if (!bolIsClicked2)
            {
                pbxShowConfirmPassword.Image = Resources.HidePasswordBtn;
                bolIsClicked2 = true;
                tbxConfirmPassword.UseSystemPasswordChar = true;
            }
            else
            {
                pbxShowConfirmPassword.Image = Resources.ShowPasswordBtn;
                bolIsClicked2 = false;
                tbxConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void frmForgotPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If Help Button is not clicked, display frmLogin
            if (!bolIsHelp)
            {
                new frmLogin().Show();
            }
        }
    }
}
