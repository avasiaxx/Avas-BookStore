using SU21_Final_Project;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmHelp : Form
    {
        string strFrmState = "";
        bool bolManagerAddition = false;
        DataGridView dgvCart = new DataGridView();
        clsManager.Person person = new clsManager.Person();
        string strManagerState = "";
        public frmHelp(string strFrmState)
        {
            //Pass in Form State string into constructor and set it to the global string inside the class
            InitializeComponent();
            this.strFrmState = strFrmState;
        }
        public frmHelp(string strFrmState, bool bolManagerAddition, string strManagerState, clsManager.Person person)
        {
            //Pass in Form State string into constructor and set it to the global string inside the class
            InitializeComponent();
            this.strFrmState = strFrmState;
            this.bolManagerAddition = bolManagerAddition;
            this.person = person;
            this.strManagerState = strManagerState;
        }

        public frmHelp(string strFrmState, DataGridView dgvCart)
        {
            //Pass in Form State string into constructor and set it to the global string inside the class
            InitializeComponent();
            this.strFrmState = strFrmState;
            this.dgvCart.AllowUserToAddRows = false;
            clsShoppingCart.SaveCurrentCart(dgvCart, this.dgvCart);
        }

        private void frmHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Depending on the Form State string when the Help Form is closing reopens to the previous form the user was on.
            switch (strFrmState)
            {
                case "Navigation":
                    new frmNavigation().Show();
                    break;
                case "Logon":
                    new frmLogin().Show();
                    break;
                case "Forgot Password": new frmForgotPassword().Show();
                    break;
                case "New User": new frmNewUser(bolManagerAddition, strManagerState, person).Show();
                    break;
                case "Main":
                    new frmMain(dgvCart).Show();
                    break;
                case "Discounts":
                    new frmDiscounts(dgvCart).Show();
                    break;
                case "Finish Order":
                    new frmFinishOrder(dgvCart).Show();
                    break;
                case "Manager":
                    new frmManager().Show();
                    break;
            }
            strFrmState = "";
        }
    }
}
