using FA21_Final_Project.Properties;
using SU21_Final_Project;
using System;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmLogin : Form
    {
        bool bolIsNewUser, bolIsReturningUser, bolIsClicked, bolIsHelp, bolIsSuccessfulLogin = false;
        DataGridView dgvCart = new DataGridView();
        public frmLogin(DataGridView dgvCart)
        {
            //Saves the previous cart if left the screen
            //Resets login
            InitializeComponent();
            clsShoppingCart.SaveCurrentCart(dgvCart, this.dgvCart);
            this.dgvCart.AllowUserToAddRows = false;
            clsLogon.ResetLogin();
        }
        public frmLogin()
        {
            //Resets login
            InitializeComponent();
            clsLogon.ResetLogin();
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            //Click Event for Forgot Password Button that shows the Forgot Password Form
            bolIsReturningUser = true;
            new frmForgotPassword().Show();
            this.Close();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            //Click Event for New User Button that shows the New User Form
            bolIsNewUser = true;
            this.Close();
            new frmNewUser().Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bolIsHelp = false;
            //Click Event For Login Button that Opens the database, verifies if the login information exists then closes the database
            if (!clsLogon.Login(tbxUsername, tbxPassword))
            {
                lblLoginError.Visible = true;
            }
            else
            {
                bolIsSuccessfulLogin = true;

                if (clsLogon.strPositionType == "Customer")
                {
                    clsFinishOrder.bolManagerOrder = false;
                    new frmMain(dgvCart).Show();
                    this.Close();
                }
                else
                {
                    new frmManager().Show();
                    this.Close();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Sets Boolean to recognize user is not wanting to create a new user & use the forget password feature and returns them to
            //previous form
            bolIsNewUser = false;
            bolIsReturningUser = false;
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Set Help Boolean to true, create HelpObject, Pass in Form State, set FrmHelp Background to appropriate image, width & height
            //Show FrmHelp & close currrent form
            bolIsHelp = true;
            frmHelp frmHelpObj = new frmHelp("Logon");
            frmHelpObj.BackgroundImage = Resources.frmLoginHelp_png;
            frmHelpObj.Width = Resources.frmLoginHelp_png.Width + 20;
            frmHelpObj.Height = Resources.frmLoginHelp_png.Height;
            frmHelpObj.Show();
            this.Close();
        }

        private void pbxShowPassword_Click(object sender, EventArgs e)
        {
            /*If the button is first clicked, unhide password text and change the color of the image
             If button is clicked once more, hide password text & change the PictureBox back to the previous image*/
            if (!bolIsClicked)
            {
                pbxShowPassword.Image = Resources.HidePasswordBtn;
                bolIsClicked = true;
                tbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pbxShowPassword.Image = Resources.ShowPasswordBtn;
                bolIsClicked = false;
                tbxPassword.UseSystemPasswordChar = true;
            }
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            //Sets Boolean to recognize user is not wanting to create a new user & use the forget password feature and returns them to
            //previous form
            bolIsNewUser = false;
            bolIsReturningUser = false;
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If the user is not wanting to access help, new user form or forgot password then show frmNavigation
            if(!bolIsReturningUser && !bolIsNewUser && !bolIsHelp && !bolIsSuccessfulLogin)
            {
                new frmNavigation().Show();
            }
        }
    }
}
