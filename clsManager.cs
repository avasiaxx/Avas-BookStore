using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public class clsManager
    {
        public static List<string> lstPersonInfo = new List<string>();
        public static List<clsSQL.AvailableItem> lstNonDiscountedItems = new List<clsSQL.AvailableItem>();
        public static List<clsSQL.AvailableItem> lstItems = new List<clsSQL.AvailableItem>();
        public static string strReportType = "";
        public class Person {
            public string strLogonName, strPassword, strFirstChallengeQuestion, strFirstChallengeAnswer, strSecondChallengeQuestion, strSecondChallengeAnswer,
                strThirdChallengeQuestion, strThirdChallengeAnswer, strTitle, strFirstName, strMiddleName, strLastName, strSuffix, strAddress1,
                strAddress2, strAddress3, strCity, strStates, strZip, strEmail, strPhonePrimary, strPhoneSecondary, strSalary;
            public int intPersonID = 0;
            public bool bolIsNewManager = false;

            public Person()
            {
                //Intended to generate a blank user
            }

            public Person(bool bolIsNewManager, string strSalary)
            {
                this.strSalary = strSalary;
                this.bolIsNewManager = bolIsNewManager;
            }
            public Person(DataGridViewSelectedCellCollection colCells)
            {
                try
                {
                    strLogonName = colCells[0].Value.ToString();
                    strPassword = colCells[1].Value.ToString();
                    strFirstChallengeQuestion = colCells[2].Value.ToString();
                    strFirstChallengeAnswer = colCells[3].Value.ToString();
                    strSecondChallengeQuestion = colCells[4].Value.ToString();
                    strSecondChallengeAnswer = colCells[5].Value.ToString();
                    strThirdChallengeQuestion = colCells[6].Value.ToString();
                    strThirdChallengeAnswer = colCells[7].Value.ToString();
                    strTitle = colCells[8].Value.ToString();
                    strFirstName = colCells[9].Value.ToString();
                    strMiddleName = colCells[10].Value.ToString();
                    strLastName = colCells[11].Value.ToString();
                    strSuffix = colCells[12].Value.ToString();
                    strAddress1 = colCells[13].Value.ToString();
                    strAddress2 = colCells[14].Value.ToString();
                    strAddress3 = colCells[15].Value.ToString();
                    strCity = colCells[16].Value.ToString();
                    strStates = colCells[17].Value.ToString();
                    strZip = colCells[18].Value.ToString();
                    strEmail = colCells[19].Value.ToString();
                    strPhonePrimary = colCells[20].Value.ToString();
                    strPhoneSecondary = colCells[21].Value.ToString();
                    int.TryParse(colCells[25].Value.ToString(), out intPersonID);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message, "Error Editing Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public class Selection
        {
            public DataGridView dgvDataGridView;
            public string strSelectionState;
            public TextBox[] arrTbxes;
            public byte[] bytImg;
            public CheckBox cbxDiscon;
            public Selection(DataGridView dgvDataGridView, string strSelectionState, TextBox[] arrTbxes, byte[] bytImg, CheckBox cbxDiscon)
            {
                this.dgvDataGridView = dgvDataGridView;
                this.strSelectionState = strSelectionState;
                this.arrTbxes = arrTbxes;
                this.bytImg = bytImg;
                this.cbxDiscon = cbxDiscon;
            }

            public Selection (DataGridView dgvDataGridView, string strSelectionState, TextBox [] arrTbxes)
            {
                this.dgvDataGridView = dgvDataGridView;
                this.strSelectionState = strSelectionState;
                this.arrTbxes = arrTbxes;
            }
        }
        static public byte[] byteImg
        {
            get; set;
        }
        static public void LoadDataGridViews(DataGridView[] arrDgvs)
        {
            try
            {
                //Open SQL connection, load all data grid views & close
                SqlConnection cnn = clsSQL.OpenDatabase();
                clsSQL.LoadInventory(arrDgvs[0], cnn);
                clsSQL.LoadCustomers(arrDgvs[1], cnn);
                clsSQL.LoadManagers(arrDgvs[2], cnn);
                clsSQL.LoadDiscounts(arrDgvs[3], true, cnn);
                clsSQL.LoadOrders(arrDgvs[4], cnn);
                clsSQL.CloseDatabase(cnn);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error opening SQL Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void LoadInventorySelection(DataGridView dgvInventory, TextBox[] arrTbxes,
            PictureBox pbxItem, CheckBox cbxEditDisc)
        {
            //Dpending on the item selected, load all tools on selection
            try
            {
                foreach (DataGridViewRow row in dgvInventory.SelectedRows)
                {
                    arrTbxes[0].Text = row.Cells[1].Value.ToString(); //Name
                    arrTbxes[1].Text = row.Cells[2].Value.ToString(); //Item Desc

                    arrTbxes[2].Text = row.Cells[3].Value.ToString(); //Retail Price
                    arrTbxes[3].Text = row.Cells[4].Value.ToString(); //Cost
                    arrTbxes[4].Text = row.Cells[5].Value.ToString(); //Quantity

                    if (row.Cells[6].Value != System.DBNull.Value)
                    {
                        MemoryStream ms = new MemoryStream((byte[])row.Cells[6].Value); //Image
                        byteImg = (byte[])row.Cells[6].Value;
                        pbxItem.Image = Image.FromStream(ms);
                    }

                    bool.TryParse(row.Cells[7].Value.ToString(), out bool bolDiscontinued); //Discontinued

                    arrTbxes[5].Text = row.Cells[8].Value.ToString(); //Genre

                    if (bolDiscontinued)
                    {
                        cbxEditDisc.Checked = true;
                    }
                    else
                    {
                        cbxEditDisc.Checked = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void UpdateSelection(Selection selection)
        {
            //Depending on selection, update an item
            int intID = 0;
            switch (selection.strSelectionState) {

                case "Inventory":
                    try
                    {
                        foreach (DataGridViewRow row in selection.dgvDataGridView.SelectedRows)
                        {
                            int.TryParse(row.Cells[0].Value.ToString(), out intID);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Parse exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    clsSQL.UpdateItem(intID, selection.bytImg, selection.arrTbxes, selection.cbxDiscon);
                    break;
            }
        }

        static public bool AddNewItem(TextBox[] arrTbxes, byte[] bytImg, CheckBox cbxDisc)
        {
            //If the user attempts to create a new item without an image, throw an error otherwise create item
            if(bytImg != null)
            {
                clsSQL.AddItem(arrTbxes, cbxDisc, bytImg);
                return true;
            }
            else
            {
                MessageBox.Show("Please add an image to your new item", "Item Addition Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public void PrintInventoryReport(StringBuilder html)
        {
            //Get MyDocs Path
            string strDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Combine MyDocs with new Folder Name
            string strPathString = Path.Combine(strDocumentsPath, "Avas BookStore Inventory Reports");

            //Get Current Date
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            //Create path to store new file
            string strPath = Path.Combine("\\Inventory Report " + date + ".html");
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
            try
            {
                using (StreamWriter wr = new StreamWriter(strPathString + strPath))
                {
                    wr.WriteLine(html);
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error using StreamWriter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static StringBuilder GenerateReport(DataGridView dgvInventory)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            //Create CSS
            css.Append("<style>");
            //css.Append("td {font-family: Arial;padding:5px;text-align:center;font-weight:bold;text-align:center;}");
            css.Append("h1{font-family: Arial;color: green;text-align:center;}");
            css.Append("h2{font-family: Arial;color: black;text-align:center;}");
            css.Append("h3{font-family: Arial;color: black;text-align:center;}");
            css.Append("h4{font-family: Arial;color: black;text-align:center;}");

            css.Append(".header1{text-decoration:underline;text-align:center; font-size: 20px;}");
            css.Append(".header2{text-decoration:underline;text-align:center; font-size: 25px;}");

            css.Append(".Items{font-family: Arial, Helvetica, border-collapse: collapse; width:100%;}");
            css.Append(".Items td, .Items th {border: 1px solid #ddd; padding: 8px;}");
            css.Append(".Items tr:nth-child(even){background-color: #f2f2f2;");
            css.Append(".Items tr:hover {background-color: #ddd;}");
            css.Append(".Items th {padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #04AA6D;color: white;}");
            css.Append("</style>");

            //Begin the headers for HTML
            html.Append("<html>");
            html.Append($"<head>{css}<title>{"Inventory Report"}</title></head>");
            html.Append("<body>");
            html.Append($"<h1>Ava's BookStore</h1>");
            html.Append($"<h2>Inventory Report</h2>");

            html.Append("<table align=\"center\" style=\"margin: 10px auto; \">");
            html.Append("<th class=\"header2\">Item's In Need Of Restock</th>");
            html.Append("<table class=\"Items\"><tr>");
            html.Append("<th>Item ID </th>");
            html.Append("<th>Item Name </th>");
            html.Append("<th>Retail Price </th>");
            html.Append("<th>Item Cost </th>");
            html.Append("<th>Quantity </th>");
            html.Append("<th>Discontinued </th></tr>");

            try
            {
                //Quantity is 0
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    int.TryParse(row.Cells[5].Value.ToString(), out int intQuantity);
                    if (intQuantity == 0)
                    {
                        html.Append("<tr>");
                        html.Append($"<td>{row.Cells[0].Value.ToString()}</td>"); //Item ID
                        html.Append($"<td>{row.Cells[1].Value.ToString()}</td>"); //Item Name
                        html.Append($"<td>{row.Cells[3].Value.ToString()}</td>"); //Retail Price
                        html.Append($"<td>{row.Cells[4].Value.ToString()}</td>"); //Item Cost
                        html.Append($"<td>{row.Cells[5].Value.ToString()}</td>"); //Quantity
                        html.Append($"<td>{row.Cells[7].Value.ToString()}</td>"); //Availability
                        html.Append("</tr>");
                    }
                }
                html.Append("<table align=\"center\" style=\"margin: 10px auto; \">");
                html.Append("<th class=\"header2\">Item's Available</th>");

                html.Append("<table class=\"Items\"><tr>");
                html.Append("<th>Item ID </th>");
                html.Append("<th>Item Name </th>");
                html.Append("<th>Retail Price </th>");
                html.Append("<th>Item Cost </th>");
                html.Append("<th>Quantity </th>");
                html.Append("<th>Discontinued </th></tr>");

                //Quantity is greater than 0
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    int.TryParse(row.Cells[5].Value.ToString(), out int intQuantity);
                    if (intQuantity > 0)
                    {
                        html.Append("<tr>");
                        html.Append($"<td>{row.Cells[0].Value.ToString()}</td>"); //Item ID
                        html.Append($"<td>{row.Cells[1].Value.ToString()}</td>"); //Item Name
                        html.Append($"<td>{row.Cells[3].Value.ToString()}</td>"); //Retail Price
                        html.Append($"<td>{row.Cells[4].Value.ToString()}</td>"); //Item Cost
                        html.Append($"<td>{row.Cells[5].Value.ToString()}</td>"); //Quantity
                        html.Append($"<td>{row.Cells[7].Value.ToString()}</td>"); //Availability
                        html.Append("</tr>");
                    }
                }
                
                html.Append("<table align=\"center\" style=\"margin: 10px auto; \">");
                html.Append("<th class=\"header2\">All Items</th>");

                html.Append("<table class=\"Items\"><tr>");
                html.Append("<th>Item ID </th>");
                html.Append("<th>Item Name </th>");
                html.Append("<th>Retail Price </th>");
                html.Append("<th>Item Cost </th>");
                html.Append("<th>Quantity </th>");
                html.Append("<th>Discontinued </th></tr>");

                //All Items
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                        html.Append("<tr>");
                        html.Append($"<td>{row.Cells[0].Value.ToString()}</td>"); //Item ID
                        html.Append($"<td>{row.Cells[1].Value.ToString()}</td>"); //Item Name
                        html.Append($"<td>{row.Cells[3].Value.ToString()}</td>"); //Retail Price
                        html.Append($"<td>{row.Cells[4].Value.ToString()}</td>"); //Item Cost
                        html.Append($"<td>{row.Cells[5].Value.ToString()}</td>"); //Quantity
                        html.Append($"<td>{row.Cells[7].Value.ToString()}</td>"); //Availability
                        html.Append("</tr>");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return html;
        }

        public static void LoadCustomerOrders(DataGridView dgvCustomers, DataGridView dgvOrders)
        {
            //When a selected row is clicked, load the customer orders into the datagridview for customer orders
            int intCustomerID = 0;
            try
            {
                foreach(DataGridViewRow row in dgvCustomers.SelectedRows)
                {
                    int.TryParse(row.Cells[25].Value.ToString(), out intCustomerID);
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Parse Error in Load Customer Orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsSQL.GetCustomerOrders(intCustomerID, dgvOrders);
        }

        public static bool EditCustomer(Person person)
        {
            //Pass the person object into update customer & return if the creation worked or not
            return clsSQL.UpdateCustomer(person);
        }

        public static void UpdateAccountStatus(CheckBox[] arrCbxes, DataGridView dgvDataGridView, bool bolManagerUpdate)
        {
            int intPersonID = 0;
            //Update account status based on what is checked and what kind of account is being updated
            try
            {
                foreach (DataGridViewRow row in dgvDataGridView.SelectedRows)
                {
                    int.TryParse(row.Cells[25].Value.ToString(), out intPersonID);
                }

                if (!bolManagerUpdate)
                {
                    bool bolIsEnabled = arrCbxes[0].Checked;
                    bool bolIsDeleted = arrCbxes[1].Checked;
                    clsSQL.UpdateCustomerAccount(intPersonID, bolIsEnabled, bolIsDeleted);
                }
                else
                {
                    bool bolIsEnabled = arrCbxes[0].Checked;
                    bool bolIsDeleted = arrCbxes[1].Checked;
                    bool bolIsActive = arrCbxes[2].Checked;
                    bool bolIsManager = arrCbxes[3].Checked;
                    clsSQL.UpdateManagerAccount(intPersonID, bolIsEnabled, bolIsDeleted, bolIsActive, bolIsManager);
                }
            }
            catch (Exception s)
            {
                ErrorMessageBox(s, "","DataGridView Error - Activating/Disabling an Account", true);
            }
        }

        public static void ErrorMessageBox(Exception e,string strTitle, string strText, bool bolIsException)
        {
            //Format a messagebox depending on what kind of messagebox is needed
            if(bolIsException) {
                MessageBox.Show(e.Message, strText, MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            else
            {
                MessageBox.Show(strTitle, strText, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateManagerSalary(DataGridView dgvManagers, TextBox tbxSalary)
        {
            //Update a selected manager's salary
            int intPersonID = 0;
            string strSalary = tbxSalary.Text;
            try
            {
                foreach (DataGridViewRow row in dgvManagers.SelectedRows)
                {
                    int.TryParse(row.Cells[25].Value.ToString(), out intPersonID);
                }
            }catch(Exception e)
            {
                ErrorMessageBox(e, "DataGrid Exception", "DataGridException", true);
            }

            clsSQL.UpdateManagerSalary(intPersonID, strSalary);
        }

        static public void PrintManagerInformation(StringBuilder html, DataGridView dgvManagers)
        {
            string strFullName = "";
            try
            {
                foreach (DataGridViewRow row in dgvManagers.SelectedRows)
                {
                    strFullName = row.Cells[9].Value.ToString() + " " + row.Cells[11].Value.ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Get MyDocs Path
            string strDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Combine MyDocs with new Folder Name
            string strPathString = Path.Combine(strDocumentsPath, "Avas BookStore Manager Information");

            //Get Current Date
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            //Create path to store new file
            string strPath = Path.Combine("\\Manager Information " + date + ".html");
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

        public static StringBuilder GenerateManagerReport(DataGridView dgvManagers)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            //Create CSS
            css.Append("<style>");
            //css.Append("td {font-family: Arial;padding:5px;text-align:center;font-weight:bold;text-align:center;}");
            css.Append("h1{font-family: Arial;color: green;text-align:center;}");
            css.Append("h2{font-family: Arial;color: black;text-align:center;}");
            css.Append("h3{font-family: Arial;color: black;text-align:center;}");
            css.Append("h4{font-family: Arial;color: black;text-align:center;}");

            css.Append(".header1{text-decoration:underline;text-align:center; font-size: 20px;}");
            css.Append(".header2{text-decoration:underline;text-align:center; font-size: 25px;}");

            css.Append(".Items{font-family: Arial, Helvetica, border-collapse: collapse; width:100%;}");
            css.Append(".Items td, .Items th {border: 1px solid #ddd; padding: 8px;}");
            css.Append(".Items tr:nth-child(even){background-color: #f2f2f2;");
            css.Append(".Items tr:hover {background-color: #ddd;}");
            css.Append(".Items th {padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #04AA6D;color: white;}");
            css.Append("</style>");

            //Begin the headers for HTML
            html.Append("<html>");
            html.Append($"<head>{css}<title>{"Manager Information"}</title></head>");
            html.Append("<body>");
            html.Append($"<h1>Ava's BookStore</h1>");

            html.Append("<table align=\"center\" style=\"margin: 10px auto; \">");
            html.Append("<th class=\"header2\">Manager Information</th>");
            html.Append("<table class=\"Items\"><tr>");
            html.Append("<th>Name </th>");
            html.Append("<th>Phone </th>");
            html.Append("<th>Email </th>");
            html.Append("<th>Position </th>");
            html.Append("<th>Salary </th>");

            //Displays selected manager's information in HTML Report
            try
            {
                foreach (DataGridViewRow row in dgvManagers.SelectedRows)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{row.Cells[9].Value.ToString()} {row.Cells[11].Value.ToString()}</td>"); //Name
                    html.Append($"<td>{row.Cells[20].Value.ToString()}</td>"); //Phone
                    html.Append($"<td>{row.Cells[19].Value.ToString()}</td>"); //Email
                    html.Append($"<td>Manager</td>"); //Position
                    decimal.TryParse(row.Cells[29].Value.ToString(), out decimal decSalary);
                    html.Append($"<td>{decSalary.ToString("C")}</td>"); //Salary
                    html.Append("</tr>");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return html;
        }

        public static void LoadAvailableItemsForDiscounts(ComboBox cbxAvailableItems, ComboBox cbxAvailableItemsEdit)
        {
            //Load all Available Items with no Discounts Tied and All Existing items into a list then add them to the comboboxes
            List<clsSQL.AvailableItem> lstAvailableItems = new List<clsSQL.AvailableItem>();
            List<clsSQL.AvailableItem> lstAllItems = new List<clsSQL.AvailableItem>();
            lstAvailableItems = clsSQL.LoadNonDiscountedItems();
            lstAllItems = clsSQL.LoadItems();
            lstNonDiscountedItems.AddRange(lstAvailableItems);
            lstItems.AddRange(lstAllItems);
            try
            {
                foreach (clsSQL.AvailableItem item in lstAvailableItems)
                {
                    cbxAvailableItems.Items.Add(item.strItemName + " " + item.decRetailPrice.ToString("C"));
                }

                foreach (clsSQL.AvailableItem item in lstAllItems)
                {
                    cbxAvailableItemsEdit.Items.Add(item.strItemName + " " + item.decRetailPrice.ToString("C"));
                }
            }catch(Exception e)
            {
                clsManager.ErrorMessageBox(e, "Error loading Available Items in Comboboxes", "", true);
            }
        }

        public static bool DiscountCreation(ComboBox cbxSelectedItem, TextBox tbxDescription, ComboBox cbxDiscountPercentage, DateTimePicker dtpExpDate)
        {
            //Find the nondiscounted item depending on what is selected in the combobox, check if the date they selected is appropriate, then create a new discount\
            try
            {
                int intSelectedIndex = cbxSelectedItem.SelectedIndex;
                int intInventoryID = lstNonDiscountedItems[intSelectedIndex].intInventoryID;
                Label lbl = new Label();
                Label lbl2 = new Label();
                Exception e = new Exception();

                string strDescription = tbxDescription.Text;
                string strDiscount = cbxDiscountPercentage.Text.Replace("%", "");
                DateTime dateExpDate = dtpExpDate.Value;

                if (!clsValidation.CheckIfAcceptableDate(dtpExpDate, lbl, lbl2))
                {
                    clsSQL.CreateNewDiscount(intInventoryID, strDescription, strDiscount, dateExpDate);
                    return true;
                }
                else
                {
                    ErrorMessageBox(e,"Expiration Date is not accepted. Please select a current day or one later", "Exp Date Error", false);
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error lwith Discount Creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool EditDiscount(DataGridView dgvDiscounts, ComboBox cbxSelectedItem, TextBox tbxDescription, ComboBox cbxDiscountPercentage, DateTimePicker dtpExpDate)
        {
            //Depending on what item is selected for discount edit, find the item and edit it
            int intSelectedIndex = 0;
            int intInventoryID = 0;
            int intSelectedInventoryID = 0;
            Label lbl = new Label();
            Label lbl2 = new Label();
            Exception e = new Exception();

            string strDescription = "";
            string strDiscount = "";
            int intDiscountID = 0;
            DateTime dateExpDate = dtpExpDate.Value;
            try
            {
                foreach (DataGridViewRow row in dgvDiscounts.SelectedRows)
                {
                    int.TryParse(row.Cells[5].Value.ToString(), out intDiscountID);
                    int.TryParse(row.Cells[0].Value.ToString(), out intSelectedInventoryID);
                }

                intSelectedIndex = cbxSelectedItem.SelectedIndex;
                intInventoryID = lstItems[intSelectedIndex].intInventoryID;

                strDescription = tbxDescription.Text;
                strDiscount = cbxDiscountPercentage.Text.Replace("%", "");

                foreach (DataGridViewRow row in dgvDiscounts.Rows)
                {
                    int.TryParse(row.Cells[0].Value.ToString(), out int intCheckInventoryID);
                    if (intInventoryID == intCheckInventoryID)
                    {
                        if (intSelectedInventoryID != intInventoryID)
                        {
                            clsManager.ErrorMessageBox(e, "Discount already exists with this item. Please select another item.", "Discount exists with this item.", false);
                            return false;
                        }
                    }
                }
            }
            catch(Exception s)
            {
                clsManager.ErrorMessageBox(s, "Error Loading Items for Edit Items", "", true);
            }

            if (!clsValidation.CheckIfAcceptableDate(dtpExpDate, lbl, lbl2))
            {
                clsSQL.UpdateDiscount(intDiscountID, intInventoryID, strDescription, strDiscount, dateExpDate);
                return true;
            }
            else
            {
                ErrorMessageBox(e, "Expiration Date is not accepted. Please select a current day or one later", "Exp Date Error", false);
                return false;
            }
        }

        public static void LoadDailySalesReports(DataGridView dgvOrders, DateTimePicker dtpDate)
        {
            //Get the date selected, and find the daily orders
            try
            {
                DateTime dateSelected = dtpDate.Value;
                dateSelected = dateSelected.Date;
                string strDate = dateSelected.ToString("yyy-MM-dd");

                clsSQL.FindDailyOrders(strDate, dgvOrders);

            }catch(Exception e)
            {
                ErrorMessageBox(e, "Error Loading Daily Reports", "", true);
            }
        }

        public static void LoadMonthlySalesReports(DataGridView dgvOrders, DateTimePicker dtpDate)
        {
            //Get the date selected and find the monthly orders
            try
            {
                DateTime dateSelected = dtpDate.Value;
                dateSelected = dateSelected.Date;
                int intMonth = dateSelected.Month;
                int intYear = dateSelected.Year;

                clsSQL.FindMonthlyOrders(intMonth, intYear, dgvOrders);

            }
            catch (Exception e)
            {
                ErrorMessageBox(e, "Error Loading Daily Reports", "", true);
            }
        }

        public static void LoadWeeklySalesReports(DataGridView dgvOrders, DateTimePicker dtpDate)
        {
            //Get the date selected and find the weekly orders
            try
            {
                DateTime dateSelected = dtpDate.Value;
                dateSelected = dateSelected.Date;
                string strDate = dateSelected.ToString("yyy-MM-dd");

                clsSQL.FindWeeklyOrders(strDate, dgvOrders);

            }
            catch (Exception e)
            {
                ErrorMessageBox(e, "Error Loading Daily Reports", "", true);
            }
        }

        static public void PrintSalesReport(StringBuilder html)
        {
            //Get MyDocs Path
            string strDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Combine MyDocs with new Folder Name
            string strPathString = Path.Combine(strDocumentsPath, "Avas BookStore Sales Reports");

            //Get Current Date
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            //Create path to store new file
            string strPath = Path.Combine("\\" + strReportType + " Sales Report " + date + ".html");
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

        public static StringBuilder GenerateSalesReport(DataGridView dgvSalesReports)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            //Create CSS
            css.Append("<style>");
            //css.Append("td {font-family: Arial;padding:5px;text-align:center;font-weight:bold;text-align:center;}");
            css.Append("h1{font-family: Arial;color: green;text-align:center;}");
            css.Append("h2{font-family: Arial;color: black;text-align:center;}");
            css.Append("h3{font-family: Arial;color: black;text-align:center;}");
            css.Append("h4{font-family: Arial;color: black;text-align:center;}");

            css.Append(".header1{text-decoration:underline;text-align:center; font-size: 20px;}");
            css.Append(".header2{text-decoration:underline;text-align:center; font-size: 25px;}");

            css.Append(".Items{font-family: Arial, Helvetica, border-collapse: collapse; width:100%;}");
            css.Append(".Items td, .Items th {border: 1px solid #ddd; padding: 8px;}");
            css.Append(".Items tr:nth-child(even){background-color: #f2f2f2;");
            css.Append(".Items tr:hover {background-color: #ddd;}");
            css.Append(".Items th {padding-top: 12px;padding-bottom: 12px;text-align: left;background-color: #04AA6D;color: white;}");
            css.Append("</style>");

            //Begin the headers for HTML
            html.Append("<html>");
            html.Append($"<head>{css}<title>Ava's Bookstore {strReportType} Sales Report</title></head>");
            html.Append("<body>");
            html.Append($"<h1>Ava's BookStore</h1>");
            html.Append($"<h2>{strReportType} Sales Report</h2>");

            html.Append("<table align=\"center\" style=\"margin: 10px auto; \">");
            html.Append("<table class=\"Items\"><tr>");
            html.Append("<th>Item Name </th>");
            html.Append("<th>Retail Price </th>");
            html.Append("<th>Discount ID </th>");
            html.Append("<th>Amount Paid </th>");
            html.Append("<th>Order Date </th>");
            decimal decTotalSales = 0;
            int intAmountOfSales = 0;

            //For each item that exists in the salesReports datagridview, print it
            try
            {
                foreach (DataGridViewRow row in dgvSalesReports.Rows)
                {
                    html.Append("<tr>");
                    html.Append($"<td>{row.Cells[0].Value.ToString()}</td>"); //Item Name
                    int.TryParse(row.Cells[2].Value.ToString(), out int intDiscountID);
                    decimal decDiscountPerc = 0;
                    decimal decAmountPaid = 0;
                    decimal decRetailPrice = 0;
                    decimal.TryParse(row.Cells[1].Value.ToString(), out decRetailPrice);
                    if (intDiscountID != 0)
                    {
                        decDiscountPerc = clsSQL.FindDiscount(intDiscountID);
                        decimal decDiscountedAmount = decRetailPrice * decDiscountPerc;
                        decAmountPaid = decRetailPrice - decDiscountedAmount;
                    }
                    else
                    {
                        decAmountPaid = decRetailPrice;
                    }
                    html.Append($"<td>{row.Cells[1].Value.ToString()}</td>"); //Retail Price
                    html.Append($"<td>{row.Cells[2].Value.ToString()}</td>"); //DiscountID
                    html.Append($"<td>{decAmountPaid.ToString("C")}</td>"); //Amount Paid
                    DateTime dateOrderDate = (DateTime)row.Cells[3].Value;
                    html.Append($"<td>{dateOrderDate.ToString("MM/dd/yyyy")}</td>"); //Order Date
                    decTotalSales += decAmountPaid;
                    html.Append("</tr>");
                    intAmountOfSales++;
                }

                html.Append("<tr><td colspan=7><hr/></td></tr>");
                html.Append("</table>");
                html.Append($"<p align=\"center\"><b>Amount Of Sales: {intAmountOfSales}</b></p>");
                html.Append($"<p align=\"center\"><b>Total Revenue: { decTotalSales.ToString("C")}</b></p>");
                html.Append("</body></html>");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return html;
        }
    }
}
