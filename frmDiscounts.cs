using FA21_Final_Project.Properties;
using SU21_Final_Project;
using System;
using System.Data;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmDiscounts : Form
    {
        bool bolIsHelp = false;
        string strSelected = "";
        DataTable dt = new DataTable();
        DataGridView dgvCart = new DataGridView();
        public frmDiscounts(DataGridView dgvCart)
        {
            InitializeComponent();
            clsShoppingCart.SaveCurrentCart(dgvCart, this.dgvCart);
            int intRows = dgvCart.Rows.Count;
            this.dgvCart.AllowUserToAddRows = false;
        }

        private void frmDiscounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            int intRows = dgvCart.Rows.Count;
            //Open FrmMain when frmDiscounts is closing
            if (!bolIsHelp)
            {
                new frmMain(dgvCart).Show();
            }
        }

        private void frmDiscounts_Load(object sender, EventArgs e)
        {
            clsShoppingCart.LoadDiscounts(dgvDiscounts);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close form
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //Label to inform the user that the cell that is clicked is copied to clipboard
            Clipboard.SetText(strSelected);
            lblCopied.Visible = true;
        }

        private void dgvDiscounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Store string when a cell is clicked
            try
            {
                strSelected = dgvDiscounts.SelectedCells[3].Value.ToString();
            }catch(Exception a)
            {
                MessageBox.Show(a.Message, "Error selecting discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            bolIsHelp = true;
            //Upon Clicking, pulls up help Diagram and displays it in Help Form
            frmHelp help = new frmHelp("Discounts", dgvCart);
            help.BackgroundImage = Resources.frmDiscountHelp;
            help.Width = Resources.frmDiscountHelp.Width;
            help.Height = Resources.frmDiscountHelp.Height;
            help.Show();
            this.Close();
        }

        private void dgvDiscounts_SelectionChanged(object sender, EventArgs e)
        {
            //Depending on what row is selected, save the discount code
            try
            {
                foreach (DataGridViewRow row in dgvDiscounts.SelectedRows)
                {
                    strSelected = row.Cells[3].Value.ToString();
                }
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Data Grid View Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
