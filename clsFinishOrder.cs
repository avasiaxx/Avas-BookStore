using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    class clsFinishOrder
    {
        public enum LoginState { isLoggedIn, LogIn, NoLogin }
        public static LoginState state;
        public static bool bolManagerOrder = false;
        public static int intManagerID = 0;
        public static int intRows
        {
            get; set;
        }
        public static Label[] arrBillingSummaryLabels
        {
            get; set;
        }

        public static BillingSummary Summary
        {
            get; set;
        }

        public class BillingSummary
        {
            public string strSubTotal = "";
            public string strDiscPerc = "";
            public string strAmountDisc = "";
            public string strDiscountedSub = "";
            public string strTax = "";
            public string strTotal = "";
            public BillingSummary(Label[] arrBillingLabels)
            {
                try
                {
                    strSubTotal = arrBillingLabels[0].Text;
                    strDiscPerc = arrBillingLabels[1].Text;
                    strAmountDisc = arrBillingLabels[2].Text;
                    strDiscountedSub = arrBillingLabels[3].Text;
                    strTax = arrBillingLabels[4].Text;
                    strTotal = arrBillingLabels[5].Text;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error loading Billing Labels", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static LoginState StartOrderProcess()
        { 
            /*If no existing rows, it means the user isn't logged in so they're prompted that they should login,
             Yes = set loginState to Login
             No = set loginState to NoLogin
             If there are existing rows, set loginState to isLoggedIn
             Return loginState*/
            if (intRows == 0)
            {
                DialogResult result =
                MessageBox.Show("Please sign in to start an order. \n\n Would you like to sign in?", "You are not logged in.", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    //if yes
                    state = LoginState.LogIn;
                }
                else
                {
                    //is no
                    state = LoginState.NoLogin;
                }
            }
            else
            {
                //has rows
                state = LoginState.isLoggedIn;
            }
            return state;
        }

        public static void DisplayOrder(Label[] arrBillingLabels)
        {
            try {
                //Displays previous billing labels from frmCart
                arrBillingLabels[0].Text = Summary.strSubTotal;
                arrBillingLabels[1].Text = Summary.strDiscPerc;
                arrBillingLabels[2].Text = Summary.strAmountDisc;
                arrBillingLabels[3].Text = Summary.strDiscountedSub;
                arrBillingLabels[4].Text = Summary.strTax;
                arrBillingLabels[5].Text = Summary.strTotal;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error loading billing labels", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FinishOrder(MaskedTextBox mskCCNumber, DateTimePicker dtpExpDate, MaskedTextBox mskCCV, DataGridView dgvCart, Label[] arrTextBoxes)
        {
            //Get Order ID after creating an order
            int intOrderID = clsSQL.CreateOrder(mskCCNumber, dtpExpDate, mskCCV, dgvCart);

            //Call Print/Generate Report Method
            PrintReport(GenerateReport(dgvCart, arrTextBoxes, intOrderID), intOrderID);

            //Update Item Quantities in Database
            clsSQL.UpdateQuantity(dgvCart);
        }

        static public void PrintReport(StringBuilder html, int intOrderID)
        {
            //Get MyDocs Path
            string strDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Combine MyDocs with new Folder Name
            string strPathString = Path.Combine(strDocumentsPath, "AvasBookStore Receipts");

            //Get Current Date
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            //Create path to store new file
            string strPath = Path.Combine("\\Receipt " + date + " RefNum " + intOrderID.ToString() + ".html");
            try
            { 
                //Find if the file exists, if it doesn't then create the folder & write the file to the folder
                if (!Directory.Exists(strPathString))
                {
                    Directory.CreateDirectory(strPathString);
                    WriteToFile(strPathString, strPath, html);
                }
                else
                {   //Since the folder does exist, write the file to the folder
                    WriteToFile(strPathString, strPath, html);
                }
                System.Diagnostics.Process.Start(strPathString + strPath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error System Permissions", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void WriteToFile(string strPathString, string strPath, StringBuilder html)
        {
            //Write the HTML using the StreamWriter 
            using (StreamWriter wr = new StreamWriter(strPathString + strPath))
            {
                wr.WriteLine(html);
            }
        }

        public static StringBuilder GenerateReport(DataGridView dgvCart, Label[] arrTextBoxes, int intOrderID)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            string[] arrCustomerInfo = clsSQL.GetCustomerName();
            string[] arrManagerInfo = clsSQL.GetManagerName();

            //Create CSS
            css.Append("<style>");
            css.Append("td {font-family: Arial;padding:5px;text-align:center;font-weight:bold;text-align:center;}");
            css.Append("h1{font-family: Arial;color: green;text-align:center;}");
            css.Append("h2{font-family: Arial;color: black;text-align:center;}");
            css.Append("h3{font-family: Arial;color: black;text-align:center;}");
            css.Append("h4{font-family: Arial;color: black;text-align:center;}");
            css.Append("th{text-decoration:underline;text-align:center;}");
            css.Append("</style>");

            //Begin the headers for HTML
            html.Append("<html>");
            html.Append($"<head>{css}<title>{"Receipt"}</title></head>");
            html.Append("<body>");
            html.Append($"<h1>Ava's BookStore</h1>");
            html.Append($"<h2>Receipt</h2>");
            try
            {
                html.Append($"<h3>Customer Name: {arrCustomerInfo[0]} {arrCustomerInfo[1]}</h3>");
                html.Append($"<h4>Customer Phone: {arrCustomerInfo[2]}</h4>");
                if (clsFinishOrder.bolManagerOrder)
                {
                    html.Append($"<h3>Manager Name: {arrManagerInfo[0]} {arrManagerInfo[1]}</h3>");
                    html.Append($"<h4>Employee ID: {arrManagerInfo[2]}</h4>");
                }
                html.Append($"<h4>Reference Number: {intOrderID} </h3>");
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error loading HTML report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            html.Append("<table align=\"center\" style=\"margin: 0px auto; \">");
            html.Append("<th>Item Name </th>");
            html.Append("<th>Quantity </th>");
            html.Append("<th>Item Cost </th>");
            html.Append("<tr><td colspan=7><hr/></td></tr>");

            bool bolHasDiscount = false;

            //Display items and find if a discount is stored
            try
            {
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{row.Cells[1].Value.ToString()}</td>"); //Name
                    html.Append($"<td>{row.Cells[6].Value.ToString()}</td>"); //Quantity
                    html.Append($"<td>{row.Cells[7].Value.ToString()}</td>"); //Item Cost
                    html.Append("</tr>");

                    if(row.Cells[8].Value.ToString() == "Yes")
                    {
                        bolHasDiscount = true;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                //Depending on if a discount is added, display the receipt differently
                if (bolHasDiscount)
                {
                    html.Append("<tr><td colspan=7><hr/></td></tr>");
                    html.Append("</table>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[0].Text}</b></p>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[1].Text}</b></p>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[2].Text}</b></p>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[3].Text}</b></p>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[4].Text}</b></p>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[5].Text}</b></p>");
                    html.Append("</body></html>");
                }
                else
                {
                    html.Append("<tr><td colspan=7><hr/></td></tr>");
                    html.Append("</table>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[0].Text}</b></p>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[4].Text}</b></p>");
                    html.Append($"<p align=\"center\"><b>{arrTextBoxes[5].Text}</b></p>");
                    html.Append("</body></html>");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error loading HTML report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return html;
        }
    }
}
