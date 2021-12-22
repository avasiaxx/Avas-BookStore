using FA21_Final_Project.Properties;
using SU21_Final_Project;
using System;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmNavigation : Form
    {
        bool bolNavAway = false;
        public frmNavigation()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Set login boolean to true, run the close event and show frmLogin
            if(clsFinishOrder.intRows > 0)
            {
                    DialogResult result = MessageBox.Show("Returning to the login screen will log you out. Continue?", "Logging out",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bolNavAway = true;
                    this.Close();
                    new frmLogin().Show();
                }
            }
            else
            {
                bolNavAway = true;
                this.Close();
                new frmLogin().Show();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //Set view boolean to true, run the close event and show frmMain
            bolNavAway = true;
            this.Close();
            new frmMain().Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Upon Clicking, pulls up help Diagram and displays it in Help Form as well as passes in the Form State String to constructor
            frmHelp help = new frmHelp("Navigation");
            help.BackgroundImage = Resources.frmMainHelp2;
            help.Width = Resources.frmMainHelp2.Width;
            help.Height = Resources.frmMainHelp2.Height;
            bolNavAway = true;
            help.Show();
            this.Close();
        }

        private void frmNavigation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If User is not wanting to view the cart or login, close the program
            if(!bolNavAway)
            {
                Application.Exit();
            }
        }
    }
}
