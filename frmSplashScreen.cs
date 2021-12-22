using System;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            //Set Time Left and run the timer
            TimeLeft = 30;
            tmrSplash.Start();
        }

        public int TimeLeft { get; set; }
        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            //If Time left is greater than 0, decrement
            if (TimeLeft > 0)
            {
                TimeLeft--;
            }
            else
            {
                //Other stop, show frmNavigation and hide the splash screen
                tmrSplash.Stop();
                new frmNavigation().Show();
                this.Hide();
            }
        }
    }
}
