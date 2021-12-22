using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public class clsSQL
    {
        static DataTable _dtTable = new DataTable();
        static DataTable dt = new DataTable();
        public static int intPersonID = 0;
        static public bool bolManagerOrder = false;
        public static NewManager newManager;

        public class NewManager
        {
            public bool bolIsNewManager = false;
            public string strNewManagerSalary = "";
            public NewManager(bool bolIsNewManager, string strNewManagerSalary)
            {
                this.bolIsNewManager = bolIsNewManager;
                this.strNewManagerSalary = strNewManagerSalary;
            }
        }

        public class Discount {
            public bool bolHasRows = false;
            public int intItemID = 0;
            public int intDiscountID = 0;
            public decimal decDiscountAmount = 0;
            public string strDescription = "";
            public string strExpDate = "";

            public Discount(bool bolHasRows, int intItemID, int intDiscountID, decimal decDiscountAmount)
            {
                this.bolHasRows = bolHasRows;
                this.intItemID = intItemID;
                this.intDiscountID = intDiscountID;
                this.decDiscountAmount = decDiscountAmount;
            }
        }

        public class AvailableItem
        {
            public string strItemName = "";
            public int intInventoryID = 0;
            public decimal decRetailPrice = 0;
            public int intDiscountID = 0;

            public AvailableItem(string strItemName, int intInventoryID, decimal decRetailPrice, int intDiscountID)
            {
                this.strItemName = strItemName;
                this.intInventoryID = intInventoryID;
                this.decRetailPrice = decRetailPrice;
                this.intDiscountID = intDiscountID;
            }
        }


        //Get Setters
        public static DataTable DTTable
        {
            get { return _dtTable; }
            set { _dtTable = value; }
        }

        public static DataTable loginTable
        {
            get { return _dtTable; }
            set { _dtTable = value; }
        }

        private const string strConn = @"Server=cstnt.tstc.edu;Database=inew2332fa21;
            User Id=StilesE21Fa2332;password=1715126;";
        static SqlConnection cnn = new SqlConnection(strConn);

        //Open SQL Connection to Database
        public static SqlConnection OpenDatabase()
        {
            cnn = new SqlConnection(strConn);
            //method to open database
            try
            {
                //open the connection to database
                cnn.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return cnn;
        }
        //Close SQL Connection & Dispose 
        public static void CloseDatabase(SqlConnection cnn)
        {
            try
            {
                //open the connection to database
                cnn.Close();
                cnn.Dispose();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Check If User Exists Command
        public static bool CheckIfUserExists(TextBox tbxUserName, Label lblLoginError, SqlConnection cnn, bool bolIsNewUser)
        {
            SqlCommand _sqlNewUserCommand;
            bool bolIsValid = false;
            SqlDataReader rdr = null;
            //Run SQL Command to check to see if the user input exists inside the database or not, if it does store inside datareader
            try
            {
                _sqlNewUserCommand = new SqlCommand("SELECT LogonID, LogonName, Password," +
                    "FirstChallengeQuestion, FirstChallengeAnswer, SecondChallengeQuestion, SecondChallengeAnswer," +
                    "ThirdChallengeQuestion, ThirdChallengeAnswer From StilesE21Fa2332.Logon WHERE LogonName = '" + tbxUserName.Text + "'", cnn);
                rdr = _sqlNewUserCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*Check if the DataReader has any rows & depending on the boolean which was passed in upon function call it will
             determine if the user is a New User or one who is resetting their password
            
             If the user is an existing user & the dataReader has existing rows, use the get DataReader function
             to set it inside the clsLogon class to allow the ForgotPassword function to access it.

             If the user is a new user and the DataReader has existing rows, inform the user the UserName already exists within
             the database

             If the returning user enters a UserName that does not exist inside the database, inform the user

             If the user is a new user and the DataReader finds no rows, set the boolean value bolIsValid as Valid             
            */
            try
            {
                if (rdr.HasRows && !bolIsNewUser)
                {
                    lblLoginError.Visible = false;
                    bolIsValid = false;
                    rdr.Read();
                    clsLogon.getDataReader(rdr);
                }
                else if (rdr.HasRows && bolIsNewUser)
                {
                    lblLoginError.Visible = true;
                    bolIsValid = false;
                    clsValidation.getErrorMessage("*Username already exists");
                    rdr.Close();
                }
                else if (!bolIsNewUser)
                {
                    lblLoginError.Visible = true;
                    clsValidation.getErrorMessage("*Username does not exist");
                    bolIsValid = true;
                }
                else if (!rdr.HasRows && bolIsNewUser)
                {
                    lblLoginError.Visible = false;
                    bolIsValid = true;
                    rdr.Close();
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error for finding an existing user", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bolIsValid;
        }

        //New User Command
        public static int NewUser(TextBox[] arrTbxes, string strZip, ComboBox[] arrCbxes, SqlConnection cnn, MaskedTextBox[] arrMaskedTextBoxes)
        {
            /*Create SQL Command for Person
             Use SCOPE_IDENTITY() to retrieve inserted row's PersonID and store it inside an Integer Variable
            
             Create SQL Command for Logon
             Use intID to set the PersonID in the Logon Table to tie the rows together
            
             Depending on if a user is a manager or not, set different data*/
            SqlCommand _sqlNewUserCommand;
            int intRow = 0;
            try
            {
                _sqlNewUserCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.Person " +
                "(Title, NameFirst, NameMiddle, NameLast, Suffix, Address1, Address2, Address3,City,Zipcode,State,Email,PhonePrimary,PhoneSecondary)" +
                "Values (@Title, @FirstName, @MiddleName, @LastName, @Suffix, @Address1, @Address2, @Address3, @City, @Zip, " +
                "@State, @Email, @PhoneOne, @PhoneTwo) SELECT SCOPE_IDENTITY()", cnn);
                _sqlNewUserCommand.Parameters.AddWithValue("@Title", arrCbxes[3].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@FirstName", arrTbxes[0].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@MiddleName", arrTbxes[1].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@LastName", arrTbxes[2].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@Suffix", arrCbxes[4].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@Address1", arrTbxes[3].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@Address2", arrTbxes[4].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@Address3", arrTbxes[5].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@City", arrTbxes[6].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@State", arrCbxes[5].Text);

                if (!String.IsNullOrEmpty(strZip))
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@Zip", strZip);
                }
                else
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@Zip", arrMaskedTextBoxes[0].Text);
                }

                if (arrMaskedTextBoxes[1].Text == "(   )    -")
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@PhoneOne", "");
                }
                else
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@PhoneOne", arrMaskedTextBoxes[1].Text);
                }

                if (arrMaskedTextBoxes[2].Text == "(   )    -")
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@PhoneTwo", "");
                }
                else
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@PhoneTwo", arrMaskedTextBoxes[2].Text);
                }
                _sqlNewUserCommand.Parameters.AddWithValue("@Email", arrTbxes[7].Text);
                int intID = Convert.ToInt32(_sqlNewUserCommand.ExecuteScalar());

                _sqlNewUserCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.Logon " +
                "(PersonID, LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer, SecondChallengeQuestion, SecondChallengeAnswer," +
                " ThirdChallengeQuestion, ThirdChallengeAnswer, PositionTitle)" +
                "Values (@PersonID, @LogonName, @Password, @FirstChallengeQuestion, @FirstChallengeAnswer, @SecondChallengeQuestion, @SecondChallengeAnswer," +
                " @ThirdChallengeQuestion, @ThirdChallengeAnswer, @PositionTitle)", cnn);
                _sqlNewUserCommand.Parameters.AddWithValue("@PersonID", intID);
                _sqlNewUserCommand.Parameters.AddWithValue("@LogonName", arrTbxes[8].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@Password", arrTbxes[9].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@FirstChallengeQuestion", arrCbxes[0].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@FirstChallengeAnswer", arrTbxes[10].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@SecondChallengeQuestion", arrCbxes[1].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@SecondChallengeAnswer", arrTbxes[11].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@ThirdChallengeQuestion", arrCbxes[2].Text);
                _sqlNewUserCommand.Parameters.AddWithValue("@ThirdChallengeAnswer", arrTbxes[12].Text);
                if (newManager != null && newManager.bolIsNewManager)
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@PositionTitle", "Manager");
                }
                else
                {
                    _sqlNewUserCommand.Parameters.AddWithValue("@PositionTitle", "Customer");
                }
                intRow += _sqlNewUserCommand.ExecuteNonQuery();

                if (newManager != null && newManager.bolIsNewManager)
                {
                    _sqlNewUserCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.Employees (PersonID, Active,Manager,Salary) " +
                    "Values(@PersonID, @Active, @Manager, @Salary)", cnn);
                    _sqlNewUserCommand.Parameters.AddWithValue("@PersonID", intID);
                    _sqlNewUserCommand.Parameters.AddWithValue("@Active", true);
                    _sqlNewUserCommand.Parameters.AddWithValue("@Manager", true);
                    _sqlNewUserCommand.Parameters.AddWithValue("@Salary", newManager.strNewManagerSalary);
                    _sqlNewUserCommand.ExecuteNonQuery();
                }
            }
            catch(NullReferenceException e)
            {
                MessageBox.Show(e.Message, "Null Reference Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return intRow;
        }

        //Set New Password
        public static bool setNewPassword(TextBox tbxConfirmPassword, SqlConnection cnn, int intID)
        {
            /*Update SQL statement to update the person's password based off LogonID*/
            try
            {
                SqlCommand _sqlForgotPasswordCommand = new SqlCommand("UPDATE StilesE21Fa2332.Logon SET Password=" + "'" + tbxConfirmPassword.Text + "'" +
                    "WHERE LogonID =" + "'" + intID + "'", cnn);
                _sqlForgotPasswordCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in processing Login SQL Statement.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        /*LOGIN COMMAND*/
        public static DataTable Login(TextBox tbxUserName, TextBox tbxPassword, SqlConnection cnn)
        {
            SqlDataReader rdr = null;
            SqlCommand _sqlLoginCommand = new SqlCommand();
            SqlDataAdapter _daTable = new SqlDataAdapter();
            /*Selects Logon Rows that are associated with the UserName & Password
             If Rows are equal to 1 then store the position Title associated with the account and display it as well as set the logon success boolean to true
            Else if there are no rows, clear the login textboxes, focus on the username textbox, and set the logon success boolean to false
            dispose of tables, commands, etc & return success boolean*/
            try
            {
                string strQuery = "Select PersonID, LogonName, Password, PositionTitle" +
                    " From StilesE21Fa2332.Logon Where LogonName = '" + tbxUserName.Text + "'";
                _sqlLoginCommand = new SqlCommand(strQuery, cnn);
                rdr = _sqlLoginCommand.ExecuteReader();


                while (rdr.Read())
                {
                    string strPassword = rdr.GetString(2);
                    if (tbxPassword.Text.Equals(strPassword))
                    {
                        rdr.Close();
                        _daTable.SelectCommand = _sqlLoginCommand;
                        _daTable.Fill(_dtTable);
                        break;
                    }
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in processing Login SQL Statement.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _sqlLoginCommand.Dispose();
            loginTable = _dtTable;

            try
            {
                foreach (DataRow row in loginTable.Rows)
                {
                    int.TryParse(row["PersonID"].ToString(), out intPersonID);
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _daTable.Dispose();
            return _dtTable;
        }

        //ADD IMAGE FUNCTION
        public static byte[] AddImage()
        {
            OpenFileDialog ofdFile = new OpenFileDialog(); //New instance
            ofdFile.ValidateNames = true; //Prevent illegal characters
            ofdFile.AddExtension = false; //Auto fixes file extension problems
            ofdFile.Filter = "Image File|*.png|Image File|*.jpg|Image File|*.jfif"; //Allow types
            ofdFile.Title = "File to Upload"; //Title of dialog box
            byte[] bytImage = null;
            try
            {

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    bytImage = File.ReadAllBytes(ofdFile.FileName);
                }
                else
                {
                    bytImage = null;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString(), "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bytImage;
        }

        //Load inventory to DataGridView
        public static void LoadGridView(DataGridView dgvStore, SqlConnection cnn)
        {
            /*Create SQL Statement in string
            Create DataAdapter
            Create DataSet
            Fill the DataSet
            Fill the DataTable
            Create BindingSource for DataGridView
            Bind the binding source to the DataGridView
            Set unneeded columns visibility to false, change column headers to appropriate text*/
            try
            {
                string strCommand = "Select InventoryID, ItemName, ItemDescription, RetailPrice, Quantity, ItemImage From StilesE21Fa2332.Inventory" +
                    " WHERE Discontinued = 0";
                SqlDataAdapter da = new SqlDataAdapter(strCommand, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvStore.DataSource = bi;
                dgvStore.Columns["InventoryID"].Visible = false;
                dgvStore.Columns["ItemImage"].Visible = false;
                dgvStore.Columns["ItemName"].HeaderText = "Book Name";
                dgvStore.Columns["Quantity"].HeaderText = "Quantity Available";
                dgvStore.Columns["ItemDescription"].HeaderText = "Description";
                dgvStore.Columns["RetailPrice"].HeaderText = "Price";
                dgvStore.Columns["RetailPrice"].DefaultCellStyle.Format = "c";
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void LoadDiscounts(DataGridView dgvDiscounts, bool bolIsManager, SqlConnection cnn)
        {
            //Load Discounts depending on if the form opening the data is Managers Form or not
            try
            {
                string strCommand = "Select InventoryID, Description, DiscountPercentage, DiscountCode, ExpDate, DiscountID From StilesE21Fa2332.Discounts ";
                if (!bolIsManager)
                {
                    strCommand += "WHERE convert(date,ExpDate) >= getdate()";
                }
                SqlDataAdapter da = new SqlDataAdapter(strCommand, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvDiscounts.DataSource = bi;
                dgvDiscounts.Sort(dgvDiscounts.Columns["ExpDate"], ListSortDirection.Ascending);
                if (!bolIsManager)
                {
                    dgvDiscounts.Columns["InventoryID"].Visible = false;
                    dgvDiscounts.Columns["DiscountPercentage"].HeaderText = "Discount Percentage";
                    dgvDiscounts.Columns["DiscountCode"].HeaderText = "Discount Code";
                }
            }

            catch(Exception e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadInventory(DataGridView dgvInventory, SqlConnection cnn)
        {

            //Load all inventory into the datagridview
            try
            {
                string strCommand = "Select * From StilesE21Fa2332.Inventory";
                SqlDataAdapter da = new SqlDataAdapter(strCommand, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvInventory.DataSource = bi;

                dgvInventory.Sort(dgvInventory.Columns["Quantity"], ListSortDirection.Ascending);
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message, "Load Inventory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    int.TryParse(row.Cells[5].Value.ToString(), out int intQuantity);
                    if(intQuantity == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Parse Error in Load Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadCustomers(DataGridView dgvCustomers, SqlConnection cnn)
        {
            //Load all customers into datagridview
            try
            {
                string strCommand = "SELECT LogonName, Password, FirstChallengeQuestion, FirstChallengeAnswer, SecondChallengeQuestion, SecondChallengeAnswer," +
                    "ThirdChallengeQuestion, ThirdChallengeAnswer, Title, NameFirst, NameMiddle, NameLast, Suffix, Address1, Address2, Address3," +
                    "City, State, Zipcode, Email, PhonePrimary, PhoneSecondary, PersonDeleted, AccountDisabled, AccountDeleted, P.PersonID" +
                " FROM[StilesE21Fa2332].[Person] as P" +
                " INNER JOIN[StilesE21Fa2332].Logon as L ON P.PersonID = L.PersonID" +
                " WHERE L.PositionTitle = 'Customer'";
                SqlDataAdapter da = new SqlDataAdapter(strCommand, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvCustomers.DataSource = bi;
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadManagers(DataGridView dgvManagers, SqlConnection cnn)
        {
            //Load all managers into datagridview
            try
            {
                string strCommand = "SELECT L.LogonName, L.Password, L.FirstChallengeQuestion, L.FirstChallengeAnswer, L.SecondChallengeQuestion, L.SecondChallengeAnswer, " +
                    "L.ThirdChallengeQuestion, L.ThirdChallengeAnswer," +
                    "P.Title, P.NameFirst, P.NameMiddle, P.NameLast, P.Suffix, P.Address1, P.Address2, " +
                    "P.Address3, P.City,  P.State, P.Zipcode, P.Email, P.PhonePrimary, P.PhoneSecondary, P.PersonDeleted, " +
                    "L.PositionTitle, L.AccountDeleted,  E.PersonID, L.AccountDisabled, E.Active, " +
                    "E.Manager, E.Salary" +
                " FROM[StilesE21Fa2332].[Person] as P" +
                " INNER JOIN[StilesE21Fa2332].Logon as L ON P.PersonID = L.PersonID" +
                " INNER JOIN StilesE21Fa2332.Employees as E ON L.PersonID = E.PersonID" +
                " WHERE L.PositionTitle = 'Manager'";
                SqlDataAdapter da = new SqlDataAdapter(strCommand, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvManagers.DataSource = bi;
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadOrders(DataGridView dgvOrders, SqlConnection cnn)
        {
            //Load all orders into datagridview
            try
            {
                string strQuery = "SELECT I.ItemName, I.RetailPrice, OD.DiscountID, O.OrderDate " +
                                  "From StilesE21Fa2332.Inventory as I " +
                                  "Left Join StilesE21Fa2332.OrderDetails as OD on I.InventoryID = OD.InventoryID " +
                                  "Right Join StilesE21Fa2332.Orders as O on O.OrderID = OD.OrderID  " +
                                  "ORDER By O.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvOrders.DataSource = bi;
            }
            catch (Exception e)
            {
                clsManager.ErrorMessageBox(e, "Loading DataGridView Orders Error", "", true);
            }
        }

        public static Discount FindDiscount(TextBox tbxDiscount, Label lblDiscountError)
        {

            SqlConnection cnn = OpenDatabase();
            SqlCommand _sqlNewUserCommand;
            SqlDataReader rdr = null;
            Discount newDiscount = new Discount(false, 0, 0, 0);

            //Run SQL Command to check to see if the user input exists inside the database or not, if it does store inside datareader
            try
            {
                _sqlNewUserCommand = new SqlCommand("SELECT * From StilesE21Fa2332.Discounts WHERE DiscountCode = '" + tbxDiscount.Text + "'", cnn);
                rdr = _sqlNewUserCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            rdr.Read();
            //If rdr has rows, store the discount information then create the discount object, else throw discount error
            if (rdr.HasRows)
            {
                try
                {
                    int intItemID = rdr.GetInt32(1);
                    int intDiscountID = rdr.GetInt32(0);
                    decimal decDiscountAmount = rdr.GetDecimal(3);
                    decDiscountAmount = decDiscountAmount / 100;

                    newDiscount = new Discount(rdr.HasRows, intItemID, intDiscountID, decDiscountAmount);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Reader Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                rdr.Close();
            }
            else
            {
                lblDiscountError.Visible = true;
                lblDiscountError.Text = "*Discount Not Found";
            }
            return newDiscount;
        }

        public static int CreateOrder(MaskedTextBox mskCCNumber, DateTimePicker dtpExpDate, MaskedTextBox mskCCV, DataGridView dgvCart)
        {
            SqlConnection cnn = OpenDatabase();
            //Depending on if a new order is with a Manager or not, set different SQL paramaters
            string strCurrentDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            string strCCNumber = mskCCNumber.Text.Trim();
            string strExpDate = dtpExpDate.Text.Trim();
            int intOrderID = 0;
            string[] arrManagerInfo = GetManagerName();

            SqlCommand _sqlNewOrderCommand;
            try
            {
                if (clsFinishOrder.bolManagerOrder)
                {
                    _sqlNewOrderCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.Orders " +
                    "(PersonID, EmployeeID, OrderDate, CC_Number, ExpDate, CCV)" +
                    "Values (@PersonID, @EmployeeID, @OrderDate, @CC_Number, @ExpDate, @CCV) SELECT SCOPE_IDENTITY()", cnn);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@PersonID", intPersonID);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@EmployeeID", arrManagerInfo[2]);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@OrderDate", strCurrentDate);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@CC_Number", strCCNumber);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@ExpDate", strExpDate);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@CCV", mskCCV.Text);
                    intOrderID = Convert.ToInt32(_sqlNewOrderCommand.ExecuteScalar());
                }
                else
                {
                    _sqlNewOrderCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.Orders " +
                    "(PersonID, OrderDate, CC_Number, ExpDate, CCV)" +
                    "Values (@PersonID, @OrderDate, @CC_Number, @ExpDate, @CCV) SELECT SCOPE_IDENTITY()", cnn);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@PersonID", intPersonID);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@OrderDate", strCurrentDate);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@CC_Number", strCCNumber);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@ExpDate", strExpDate);
                    _sqlNewOrderCommand.Parameters.AddWithValue("@CCV", mskCCV.Text);
                    intOrderID = Convert.ToInt32(_sqlNewOrderCommand.ExecuteScalar());
                }

                foreach(DataGridViewRow row in dgvCart.Rows)
                {
                    int.TryParse(row.Cells[0].Value.ToString(), out int intInventoryID);
                    int.TryParse(row.Cells[9].Value.ToString(), out int intDiscountID);

                    string strQuantity = row.Cells[6].Value.ToString();
                    strQuantity = strQuantity.Replace("x", "");
                    int.TryParse(strQuantity, out int intQuantity);

                    if (intDiscountID != 0)
                    {
                        _sqlNewOrderCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.OrderDetails " +
                        "(OrderID, InventoryID, DiscountID, Quantity)" +
                        "Values (@OrderID, @InventoryID, @DiscountID, @Quantity)", cnn);
                        _sqlNewOrderCommand.Parameters.AddWithValue("@OrderID", intOrderID);
                        _sqlNewOrderCommand.Parameters.AddWithValue("@InventoryID", intInventoryID);
                        _sqlNewOrderCommand.Parameters.AddWithValue("@DiscountID", intDiscountID);
                        _sqlNewOrderCommand.Parameters.AddWithValue("@Quantity", intQuantity);
                    }
                    else
                    {
                        _sqlNewOrderCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.OrderDetails " +
                        "(OrderID, InventoryID, Quantity)" +
                        "Values (@OrderID, @InventoryID, @Quantity)", cnn);
                        _sqlNewOrderCommand.Parameters.AddWithValue("@OrderID", intOrderID);
                        _sqlNewOrderCommand.Parameters.AddWithValue("@InventoryID", intInventoryID);
                        _sqlNewOrderCommand.Parameters.AddWithValue("@Quantity", intQuantity);
                    }
                    _sqlNewOrderCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(FormatException e)
            {
                MessageBox.Show(e.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseDatabase(cnn);

            return intOrderID;
        }

        public static string[] GetCustomerName()
        {
            string strFirstName = "";
            string strLastName = "";
            string strPhoneNumber = "";
            SqlDataReader rdr;
            string strQuery = "SELECT NameFirst, NameLast, PhonePrimary FROM StilesE21Fa2332.Person WHERE PersonID = @PersonID";
            //Find Customer name with intPerson ID, store their information then return it through an array
            try 
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand _GetCustomerNameCommand = new SqlCommand(strQuery, cnn);
                _GetCustomerNameCommand.Parameters.AddWithValue("@PersonID", intPersonID);
                rdr = _GetCustomerNameCommand.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    strFirstName = rdr.GetString(0);
                    strLastName = rdr.GetString(1);
                    strPhoneNumber = rdr.GetString(2);
                }
                rdr.Close();
            } catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch(Exception a)
            {
                MessageBox.Show(a.Message, "DataReader error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseDatabase(cnn);
            string[] arrCustomerName = new string[] { strFirstName, strLastName, strPhoneNumber };
            return arrCustomerName;
        }

        public static string[] GetManagerName()
        {
            string strFirstName = "";
            string strLastName = "";
            int intEmployeeID = 0;
            string strEmployeeID = "";
            SqlDataReader rdr;
            string strQuery = "SELECT NameFirst, NameLast, E.EmployeeID" +
                " FROM StilesE21Fa2332.Person as P" +
                " INNER JOIN[StilesE21Fa2332].Employees as E ON P.PersonID = E.PersonID" +
                " WHERE P.PersonID = @PersonID";
            //Find Customer name with intPerson ID, store their information then return it through an array
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand _GetCustomerNameCommand = new SqlCommand(strQuery, cnn);
                _GetCustomerNameCommand.Parameters.AddWithValue("@PersonID", clsFinishOrder.intManagerID);
                rdr = _GetCustomerNameCommand.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                    strFirstName = rdr.GetString(0);
                    strLastName = rdr.GetString(1);
                    intEmployeeID = rdr.GetInt32(2);
                    strEmployeeID = intEmployeeID.ToString();
                }
                rdr.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "DataReader error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseDatabase(cnn);
            string[] arrCustomerName = new string[] { strFirstName, strLastName, strEmployeeID };
            return arrCustomerName;
        }

        public static void UpdateQuantity(DataGridView dgvCart)
        {
            int intRows = dgvCart.Rows.Count;
            //Find the quantity of each item inside the cart then remove it from the database
            foreach(DataGridViewRow row in dgvCart.Rows)
            {
                try
                {
                    int.TryParse(row.Cells[4].Value.ToString(), out int intAvailableQuantity);

                    string strQuantity = row.Cells[6].Value.ToString();
                    strQuantity = strQuantity.Replace("x", "");
                    int.TryParse(strQuantity, out int intSelectedQuantity);

                    int intNewQuantity = intAvailableQuantity - intSelectedQuantity;

                    int.TryParse(row.Cells[0].Value.ToString(), out int intInventoryID);

                    SqlConnection cnn = OpenDatabase();

                   SqlCommand _sqlUpdateQuantityCommand = new SqlCommand("UPDATE StilesE21Fa2332.Inventory " +
                        "SET Quantity = @Quantity WHERE InventoryID = @InventoryID", cnn);
                    _sqlUpdateQuantityCommand.Parameters.AddWithValue("@Quantity", intNewQuantity);
                    _sqlUpdateQuantityCommand.Parameters.AddWithValue("@InventoryID", intInventoryID);
                    _sqlUpdateQuantityCommand.ExecuteNonQuery();
                    CloseDatabase(cnn);
                }
                catch(FormatException e)
                {
                    MessageBox.Show(e.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }catch(SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void UpdateItem(int intID, byte[] bytImg, TextBox[] arrTbxes, CheckBox cbxDiscon)
        {
            //Update a selected item
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand cmd = new SqlCommand("UPDATE StilesE21Fa2332.Inventory SET ItemName=@Name, ItemDescription=@Description," +
                " RetailPrice=@Price, Cost=@Cost, Quantity=@Quantity, ItemImage = @Image," +
                "Discontinued = @Discontinued, Genre=@Genre WHERE InventoryID=@ItemID", cnn);
                cmd.Parameters.AddWithValue("@ItemID", (intID));
                cmd.Parameters.AddWithValue("@Name", arrTbxes[0].Text);
                cmd.Parameters.AddWithValue("@Description", (arrTbxes[1].Text));
                cmd.Parameters.AddWithValue("@Price", arrTbxes[2].Text);
                cmd.Parameters.AddWithValue("@Cost", arrTbxes[3].Text);
                cmd.Parameters.AddWithValue("@Quantity", arrTbxes[4].Text);
                cmd.Parameters.AddWithValue("@Discontinued", cbxDiscon.Checked);
                cmd.Parameters.AddWithValue("@Genre", arrTbxes[5].Text);
                SqlParameter sqlParams = cmd.Parameters.AddWithValue("@Image", bytImg); // The parameter will be the image as a byte array
                sqlParams.DbType = System.Data.DbType.Binary;
                cmd.ExecuteNonQuery();
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception with Updating an Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseDatabase(cnn);
        }

        public static bool UpdateCustomer(clsManager.Person person)
        {
            //Update a selected customer
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand cmd = new SqlCommand("UPDATE StilesE21Fa2332.Person SET Title=@Title, NameFirst=@FirstName, NameMiddle=@MiddleName," +
                " NameLast=@LastName, Suffix=@Suffix, Address1=@Address1, Address2=@Address2, Address3=@Address3, City=@City," +
                "Zipcode=@Zip, State=@State, Email=@Email, PhonePrimary=@PhonePrimary, PhoneSecondary=@PhoneSecondary" +
                " WHERE PersonID=@PersonID", cnn);
                cmd.Parameters.AddWithValue("@PersonID", (person.intPersonID));
                cmd.Parameters.AddWithValue("@Title", person.strTitle);
                cmd.Parameters.AddWithValue("@FirstName", (person.strFirstName));
                cmd.Parameters.AddWithValue("@MiddleName", person.strMiddleName);
                cmd.Parameters.AddWithValue("@LastName", person.strLastName);
                cmd.Parameters.AddWithValue("@Suffix", person.strSuffix);
                cmd.Parameters.AddWithValue("@Address1", person.strAddress1);
                cmd.Parameters.AddWithValue("@Address2", person.strAddress2);
                cmd.Parameters.AddWithValue("@Address3", person.strAddress3);
                cmd.Parameters.AddWithValue("@City", person.strCity);
                cmd.Parameters.AddWithValue("@Zip", person.strZip);
                cmd.Parameters.AddWithValue("@State", person.strStates);
                cmd.Parameters.AddWithValue("@Email", person.strEmail);

                if (person.strPhonePrimary == "(   )    -")
                {
                    cmd.Parameters.AddWithValue("@PhonePrimary", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PhonePrimary", person.strPhonePrimary);
                }

                if (person.strPhoneSecondary == "(   )    -")
                {
                    cmd.Parameters.AddWithValue("@PhoneSecondary", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PhoneSecondary", person.strPhoneSecondary);
                }
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE StilesE21Fa2332.Logon SET Password=@Password, FirstChallengeQuestion=@FirstQuestion, FirstChallengeAnswer=@FirstAnswer," +
                " SecondChallengeQuestion=@SecondQuestion, SecondChallengeAnswer=@SecondAnswer, ThirdChallengeQuestion=@ThirdQuestion, ThirdChallengeAnswer=@ThirdAnswer " +
                "WHERE PersonID=@PersonID", cnn);
                cmd.Parameters.AddWithValue("@PersonID", (person.intPersonID));
                cmd.Parameters.AddWithValue("@Password", (person.strPassword));
                cmd.Parameters.AddWithValue("@FirstQuestion", (person.strFirstChallengeQuestion));
                cmd.Parameters.AddWithValue("@FirstAnswer", (person.strFirstChallengeAnswer));
                cmd.Parameters.AddWithValue("@SecondQuestion", (person.strSecondChallengeQuestion));
                cmd.Parameters.AddWithValue("@SecondAnswer", (person.strSecondChallengeAnswer));
                cmd.Parameters.AddWithValue("@ThirdQuestion", (person.strThirdChallengeQuestion));
                cmd.Parameters.AddWithValue("@ThirdAnswer", (person.strThirdChallengeAnswer));
                cmd.ExecuteNonQuery();
                CloseDatabase(cnn);
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception with Updating a Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void AddItem(TextBox[] arrTbxes, CheckBox cbxDiscon, byte[] bytImg)
        {
            //Add a new item to the database
            try
            {
                SqlConnection cnn = OpenDatabase();
                string query = "INSERT INTO StilesE21Fa2332.Inventory (ItemName, ItemDescription, RetailPrice," +
                    " Cost, Quantity, ItemImage, Discontinued, Genre)" +
                    " Values (@ItemName, @ItemDescription, @RetailPrice, @Cost, @Quantity, @Image, @Discontinued,@Genre)";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@ItemName", arrTbxes[0].Text);
                cmd.Parameters.AddWithValue("@ItemDescription", arrTbxes[1].Text);
                cmd.Parameters.AddWithValue("@RetailPrice", arrTbxes[2].Text);
                cmd.Parameters.AddWithValue("@Cost", arrTbxes[3].Text);
                cmd.Parameters.AddWithValue("@Quantity", arrTbxes[4].Text);
                SqlParameter sqlParams = cmd.Parameters.AddWithValue("@Image", bytImg); // The parameter will be the image as a byte array
                sqlParams.DbType = System.Data.DbType.Binary;
                cmd.Parameters.AddWithValue("@Discontinued", cbxDiscon.Checked);
                cmd.Parameters.AddWithValue("@Genre", arrTbxes[5].Text);
                cmd.ExecuteNonQuery();
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception in Item Addition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseDatabase(cnn);
        }

        public static void GetCustomerOrders(int intCustomerID, DataGridView dgvOrders)
        {
            //Find a customer's orders
            try
            {
                SqlConnection cnn = OpenDatabase();
                string strQuery = "SELECT * FROM StilesE21Fa2332.Orders WHERE PersonID = " + intCustomerID;
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvOrders.DataSource = bi;
                CloseDatabase(cnn);
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message, "Error Customer Order Lookup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch(Exception a)
            {
                MessageBox.Show(a.Message, "Error Customer Order Lookup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateCustomerAccount(int intPersonID, bool bolIsEnabled, bool bolIsDeleted)
        {
            //Update a customer account 
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand cmd = new SqlCommand("UPDATE StilesE21Fa2332.Person SET PersonDeleted=@Deleted WHERE PersonID=@PersonID", cnn);
                cmd.Parameters.AddWithValue("@PersonID", (intPersonID));
                cmd.Parameters.AddWithValue("@Deleted", bolIsDeleted);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE StilesE21Fa2332.Logon SET AccountDisabled=@Disabled, AccountDeleted=@Deleted" +
                    " WHERE PersonID=@PersonID", cnn);
                cmd.Parameters.AddWithValue("@PersonID", (intPersonID));
                cmd.Parameters.AddWithValue("@Disabled", bolIsEnabled);
                cmd.Parameters.AddWithValue("@Deleted", bolIsDeleted);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception with Account Activation/Deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseDatabase(cnn);
        }

        public static void UpdateManagerAccount(int intPersonID, bool bolIsEnabled, bool bolIsDeleted, bool bolIsActive, bool bolIsManager)
        {
            //Update a manager account depending on if it's selected active, enabled or allowed to be a manager
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand cmd = new SqlCommand("UPDATE StilesE21Fa2332.Person SET PersonDeleted=@Deleted WHERE PersonID=@PersonID", cnn);
                cmd.Parameters.AddWithValue("@PersonID", (intPersonID));
                cmd.Parameters.AddWithValue("@Deleted", bolIsDeleted);
                cmd.ExecuteNonQuery();

                if (!bolIsManager)
                {
                    cmd = new SqlCommand("UPDATE StilesE21Fa2332.Logon SET AccountDisabled=@Disabled, AccountDeleted=@Deleted, PositionTitle=@PositionTitle" +
                    " WHERE PersonID=@PersonID", cnn);
                    cmd.Parameters.AddWithValue("@PersonID", (intPersonID));
                    cmd.Parameters.AddWithValue("@Disabled", bolIsEnabled);
                    cmd.Parameters.AddWithValue("@Deleted", bolIsDeleted);
                    cmd.Parameters.AddWithValue("@PositionTitle", "Employee");
                }
                else
                {
                    cmd = new SqlCommand("UPDATE StilesE21Fa2332.Logon SET AccountDisabled=@Disabled, AccountDeleted=@Deleted" +
                    " WHERE PersonID=@PersonID", cnn);
                    cmd.Parameters.AddWithValue("@PersonID", (intPersonID));
                    cmd.Parameters.AddWithValue("@Disabled", bolIsEnabled);
                    cmd.Parameters.AddWithValue("@Deleted", bolIsDeleted);
                }
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE StilesE21Fa2332.Employees SET Active=@Active, Manager=@Manager" +
                    " WHERE PersonID=@PersonID", cnn);
                cmd.Parameters.AddWithValue("@PersonID", (intPersonID));
                cmd.Parameters.AddWithValue("@Active", bolIsActive);
                cmd.Parameters.AddWithValue("@Manager", bolIsManager);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "SQL Exception with Account Activation/Deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseDatabase(cnn);
        }

        public static void UpdateManagerSalary(int intPersonID, string strSalary)
        {
            //Update a selected manager's salary
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand cmd = new SqlCommand("UPDATE StilesE21Fa2332.Employees SET Salary=@Salary WHERE PersonID=@PersonID", cnn);
                cmd.Parameters.AddWithValue("@PersonID", (intPersonID));
                cmd.Parameters.AddWithValue("@Salary", strSalary);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                clsManager.ErrorMessageBox(e, "", "SQL Exception with Account Activation/Deletion", true);
            }
            CloseDatabase(cnn);
        }

        public static List<AvailableItem> LoadNonDiscountedItems()
        {
            //Get the list of all Available Items that don't have discounts tied to them
            List<AvailableItem> lstAvailableItems = new List<AvailableItem>();
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand cmd = new SqlCommand("SELECT ItemName, I.InventoryID, I.RetailPrice " +
                 "FROM StilesE21Fa2332.Inventory as I " +
                 " LEFT JOIN StilesE21Fa2332.Discounts as D ON I.InventoryID = D.InventoryID" +
                 "  WHERE D.DiscountID IS NULL", cnn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AvailableItem availableItem = new AvailableItem(rdr.GetString(0), rdr.GetInt32(1), rdr.GetDecimal(2), 0);
                    lstAvailableItems.Add(availableItem);
                }
            }catch(Exception e)
            {
                clsManager.ErrorMessageBox(e, "", "SQL Exception", true);
            }
            return lstAvailableItems;
        }

        public static List<AvailableItem> LoadItems()
        {
            //Load all items 
            List<AvailableItem> lstAllItems = new List<AvailableItem>();
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand cmd = new SqlCommand("SELECT ItemName, I.InventoryID, I.RetailPrice " +
                 "FROM StilesE21Fa2332.Inventory as I", cnn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AvailableItem item = new AvailableItem(rdr.GetString(0), rdr.GetInt32(1), rdr.GetDecimal(2), 0);
                    lstAllItems.Add(item);
                }
            }
            catch (Exception e)
            {
                clsManager.ErrorMessageBox(e, "", "SQL Exception", true);
            }
            return lstAllItems;
        }

        public static void CreateNewDiscount(int intInventoryID, string strDescription, string strDiscount, DateTime dtpExpDate)
        {
            //Create a new discount, generate a random discount code and insert it into Discounts
            try
            {
                SqlConnection cnn = OpenDatabase();
                Random random = new Random();
                string strDiscountCode = "";
                for (int x = 0; x < 10; x++)
                {
                    int a = random.Next(0, 9);
                    string strLetter = a.ToString();
                    strDiscountCode += strLetter;
                }
                SqlCommand _sqlNewDiscountCommand = new SqlCommand("INSERT INTO StilesE21Fa2332.Discounts " +
                "(InventoryID, Description, DiscountPercentage, DiscountCode, ExpDate)" +
                "Values (@InventoryID, @Description, @DiscountPercentage, @DiscountCode, @ExpDate)", cnn);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@InventoryID", intInventoryID);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@Description", strDescription);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@DiscountPercentage", strDiscount);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@DiscountCode", strDiscountCode);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@ExpDate", dtpExpDate);
                _sqlNewDiscountCommand.ExecuteNonQuery();
                CloseDatabase(cnn);
            }catch(Exception e)
            {
                clsManager.ErrorMessageBox(e, "", "SQL Exception", true);
            }
        }

        public static void UpdateDiscount(int intDiscountID, int intInventoryID, string strDescription, string strDiscount, DateTime dateExpDate)
        {
            //Update a selected discount in the database
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlCommand _sqlNewDiscountCommand = new SqlCommand("UPDATE StilesE21Fa2332.Discounts " +
                "SET InventoryID=@InventoryID, Description=@Description, DiscountPercentage=@DiscountPercentage, ExpDate=@ExpDate" +
                " WHERE DiscountID=@DiscountID", cnn);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@DiscountID", intDiscountID);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@InventoryID", intInventoryID);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@Description", strDescription);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@DiscountPercentage", strDiscount);
                _sqlNewDiscountCommand.Parameters.AddWithValue("@ExpDate", dateExpDate);
                _sqlNewDiscountCommand.ExecuteNonQuery();
                CloseDatabase(cnn);
            }
            catch (Exception e)
            {
                clsManager.ErrorMessageBox(e, "", "SQL Exception", true);
            }
        }

        public static void FindDailyOrders(string strDate, DataGridView dgvOrders)
        {
            //Select daily orders depending on the date selected
            try
            {
                SqlConnection cnn = OpenDatabase();
                string strQuery = "SELECT I.ItemName, I.RetailPrice, OD.DiscountID, O.OrderDate " +
                                  "From StilesE21Fa2332.Inventory as I " +
                                  "Left Join StilesE21Fa2332.OrderDetails as OD on I.InventoryID = OD.InventoryID " +
                                  "Right Join StilesE21Fa2332.Orders as O on O.OrderID = OD.OrderID  " +
                                  "WHERE O.OrderDate = '"+ strDate + "' " +
                                  "ORDER By O.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvOrders.DataSource = bi;
                CloseDatabase(cnn);
            }
            catch (Exception e)
            {
                clsManager.ErrorMessageBox(e, "Loading DataGridView Orders Error", "", true);
            }
        }

        public static void FindWeeklyOrders(string strDate, DataGridView dgvOrders)
        {
            //Select weekly orders depending on what date is selected
            try
            {
                SqlConnection cnn = OpenDatabase();
                string strQuery = "SELECT I.ItemName, I.RetailPrice, OD.DiscountID, O.OrderDate " +
                                  "From StilesE21Fa2332.Inventory as I " +
                                  "Left Join StilesE21Fa2332.OrderDetails as OD on I.InventoryID = OD.InventoryID " +
                                  "Right Join StilesE21Fa2332.Orders as O on O.OrderID = OD.OrderID  " +
                                  "WHERE OrderDate >= DATEADD(day,-7, '" + strDate + "')   AND OrderDate <= '" + strDate + "' " +
                                  "ORDER By O.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvOrders.DataSource = bi;
                CloseDatabase(cnn);
            }
            catch (Exception e)
            {
                clsManager.ErrorMessageBox(e, "Loading DataGridView Orders Error", "", true);
            }
        }

        public static void FindMonthlyOrders(int intMonth, int intYear, DataGridView dgvOrders)
        {
            //Select monthly orders depending on what date is selected
            try
            {
                SqlConnection cnn = OpenDatabase();
                string strQuery = "SELECT I.ItemName, I.RetailPrice, OD.DiscountID, O.OrderDate " +
                                  "From StilesE21Fa2332.Inventory as I " +
                                  "Left Join StilesE21Fa2332.OrderDetails as OD on I.InventoryID = OD.InventoryID " +
                                  "Right Join StilesE21Fa2332.Orders as O on O.OrderID = OD.OrderID  " +
                                  " WHERE MONTH(O.OrderDate) = "+ intMonth +" AND YEAR(O.OrderDate) = " + intYear +
                                  "ORDER By O.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                BindingSource bi = new BindingSource();
                bi.DataSource = dt;
                dgvOrders.DataSource = bi;
                CloseDatabase(cnn);
            }
            catch (Exception e)
            {
                clsManager.ErrorMessageBox(e, "Loading DataGridView Orders Error", "", true);
            }
        }

        public static decimal FindDiscount(int intDiscountID)
        {
            //Find a discount depending on what discountID is selected
            decimal decDiscountAmount = 0;
            try
            {
                SqlConnection cnn = OpenDatabase();
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand("Select DiscountPercentage FROM StilesE21Fa2332.Discounts WHERE DiscountID =" + intDiscountID, cnn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    decDiscountAmount = rdr.GetDecimal(0);
                }
                decDiscountAmount = decDiscountAmount / 100;
                rdr.Close();
            }catch(Exception e)
            {
                clsManager.ErrorMessageBox(e, "Error Finding Discount", "", true);
            }
            return decDiscountAmount;
        }
    }
}
