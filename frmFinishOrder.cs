using FA21_Final_Project.Properties;
using SU21_Final_Project;
using System;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    //Test Push x4
    public partial class frmFinishOrder : Form
    {
        DataGridView dgvCart = new DataGridView();
        bool bolOrderFinished, bolIsHelp = false;
        public frmFinishOrder(DataGridView dgvCart)
        {
            InitializeComponent();
            //Set min/max date for the date time picker
            try
            {
                DateTime dateMin = DateTime.Now;
                dtpExpDate.MinDate = dateMin;
                dtpExpDate.MaxDate = DateTime.Now.AddYears(5);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Out of range exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };

            //Save current cart so it can be passed to dgvCart
            clsShoppingCart.SaveCurrentCart(dgvCart, this.dgvCart);
            this.dgvCart.AllowUserToAddRows = false;
            clsFinishOrder.DisplayOrder(arrBillingLabels);
            dtpExpDate.CustomFormat = "MM / yy";
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            MaskedTextBox[] arrMaskedTextboxes = new MaskedTextBox[]
            {
                mskCC,mskCCV
            };
            Label[] arrErrorLabels = new Label[]
            {
                lblErrorCC,lblErrorCCV
            };
            Label[] arrTextBoxes = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };
            foreach(Label lbl in arrErrorLabels)
            {
                lbl.Visible = false;
            }
            /*Check if textboxes aren't empty, and check if the date is acceptable,
             if both meet the requirements then finish order*/

            if(clsValidation.CheckIfPaymentInfoEmpty(arrMaskedTextboxes, arrErrorLabels, dtpExpDate, lblExpDate, lblFinishOrderError) &&
                !clsValidation.CheckIfAcceptableDate(dtpExpDate, lblErrorExpDate, lblFinishOrderError))
            {
                mskCC.Text = mskCC.Text.Replace(" ", "");
                clsFinishOrder.FinishOrder(mskCC, dtpExpDate, mskCCV, this.dgvCart, arrTextBoxes);
                bolOrderFinished = true;
                DialogResult result = MessageBox.Show("Thank you for shopping at Ava's BookStore! Return to store?", "Thank you for your order",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bolOrderFinished = false;
                    try
                    {
                        this.dgvCart.Rows.Clear();
                    }catch(Exception a)
                    {
                        clsManager.ErrorMessageBox(a, "Error Deleting Rows from DataGridView Cart", "", true);
                    }
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close the form
            this.Close();
        }

        private void frmFinishOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //If the order isn't finished or they aren't accessing the help screen, return to frmMain, otherwise close the application
                if (!bolOrderFinished && !bolIsHelp)
                {
                    new frmMain(this.dgvCart).Show();
                }
                else if (bolOrderFinished && !clsFinishOrder.bolManagerOrder)
                {
                    Application.Exit();
                }else if(clsFinishOrder.bolManagerOrder)
                {
                    new frmManager().Show();
                }
            }catch(Exception a)
            {
                clsManager.ErrorMessageBox(a, "Error exiting application", "", true);
            }
        }

        private void mskCC_Click(object sender, EventArgs e)
        {
            //Reset caret position depending on last input
            PositionCursorInMaskedTextBox(mskCC);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            bolIsHelp = true;
            //Upon Clicking, pulls up help Diagram and displays it in Help Form
            frmHelp help = new frmHelp("Finish Order", dgvCart);
            help.BackgroundImage = Resources.frmFinishOrderHelp;
            help.Width = Resources.frmFinishOrderHelp.Width;
            help.Height = Resources.frmFinishOrderHelp.Height;
            help.Show();
            this.Close();
        }

        private void mskCCV_Click(object sender, EventArgs e)
        {
            PositionCursorInMaskedTextBox(mskCCV);
        }


        //Moves cursor back to the previous position of what they've entered
        private void PositionCursorInMaskedTextBox(MaskedTextBox mskTbx)
        {
            try
            {
                if (mskTbx == null) return;

                int pos = mskTbx.SelectionStart;

                if (pos > mskTbx.Text.Length)
                    this.BeginInvoke((MethodInvoker)delegate () { mskTbx.Select(mskTbx.Text.Length, 0); });
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Invalid Operation Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
