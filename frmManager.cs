using FA21_Final_Project.Properties;
using SU21_Final_Project;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public partial class frmManager : Form
    {
        byte[] bytImg;
        Image image;
        bool bolNavAway = false;

        enum EditItemState { Edit, Save }
        EditItemState EditItem = EditItemState.Edit;

        enum AddItemState { Add, Save }
        AddItemState AddItem = AddItemState.Add;

        enum AddDiscountState { Add, Save }
        AddDiscountState DiscountAdd = AddDiscountState.Add;

        enum EditDiscountState { Edit, Save }
        EditDiscountState DiscountEdit = EditDiscountState.Edit;

        //Final Push
        public frmManager()
        {
            InitializeComponent();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            DataGridView[] arrDgvs = new DataGridView[]
            {
                dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
            };
            try
            {
                //Set Min/Max dates for allowed dates
                DateTime dateMin = DateTime.Now;
                dtpExpDate.MinDate = dateMin;
                dtpExpDate.MaxDate = DateTime.Now.AddYears(5);

                //Load datagridviews, set autosizemode to displayedcells, load comboboxes, set dtp date format
                clsManager.LoadDataGridViews(arrDgvs);
                dgvInventory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvInventory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvInventory.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvInventory.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Argument out of range exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clsManager.LoadAvailableItemsForDiscounts(cbxAvailableItems, cbxAvailableItemEdit);
            dtpExpDate.CustomFormat = "MM / yy";
            dtpExpDateEdit.CustomFormat = "MM / yy";


            //Set all column headers to appropriate names & hide unnecessary columns
            try
            {
                dgvInventory.Columns["InventoryID"].HeaderText = "Inventory ID";
                dgvInventory.Columns["ItemName"].HeaderText = "Item Name";
                dgvInventory.Columns["ItemDescription"].HeaderText = "Description";
                dgvInventory.Columns["RetailPrice"].HeaderText = "Retail Price";
                dgvInventory.Columns["ItemImage"].HeaderText = "Image";

                dgvCustomers.Columns["LogonName"].HeaderText = "Username";
                dgvCustomers.Columns["Password"].Visible = false;
                dgvCustomers.Columns["FirstChallengeQuestion"].Visible = false;
                dgvCustomers.Columns["SecondChallengeQuestion"].Visible = false;
                dgvCustomers.Columns["ThirdChallengeQuestion"].Visible = false;
                dgvCustomers.Columns["FirstChallengeAnswer"].Visible = false;
                dgvCustomers.Columns["SecondChallengeAnswer"].Visible = false;
                dgvCustomers.Columns["ThirdChallengeAnswer"].Visible = false;
                dgvCustomers.Columns["NameFirst"].HeaderText = "First Name";
                dgvCustomers.Columns["NameMiddle"].HeaderText = "Middle Name";
                dgvCustomers.Columns["NameLast"].HeaderText = "Last Name";
                dgvCustomers.Columns["Zipcode"].HeaderText = "Zip";
                dgvCustomers.Columns["PersonDeleted"].HeaderText = "Person Deleted";
                dgvCustomers.Columns["AccountDisabled"].HeaderText = "Account Disabled";
                dgvCustomers.Columns["AccountDeleted"].HeaderText = "Account Deleted";
                dgvCustomers.Columns["PersonID"].HeaderText = "Person ID";
                dgvCustomers.Columns["PhonePrimary"].HeaderText = "Phone Primary";
                dgvCustomers.Columns["PhoneSecondary"].Visible = false;

                dgvManagers.Columns["LogonName"].HeaderText = "Username";
                dgvManagers.Columns["Password"].Visible = false;
                dgvManagers.Columns["FirstChallengeQuestion"].Visible = false;
                dgvManagers.Columns["SecondChallengeQuestion"].Visible = false;
                dgvManagers.Columns["ThirdChallengeQuestion"].Visible = false;
                dgvManagers.Columns["FirstChallengeAnswer"].Visible = false;
                dgvManagers.Columns["SecondChallengeAnswer"].Visible = false;
                dgvManagers.Columns["ThirdChallengeAnswer"].Visible = false;
                dgvManagers.Columns["NameFirst"].HeaderText = "First Name";
                dgvManagers.Columns["NameMiddle"].HeaderText = "Middle Name";
                dgvManagers.Columns["NameLast"].HeaderText = "Last Name";
                dgvManagers.Columns["Zipcode"].HeaderText = "Zip";
                dgvManagers.Columns["PersonDeleted"].HeaderText = "Person Deleted";
                dgvManagers.Columns["AccountDisabled"].HeaderText = "Account Disabled";
                dgvManagers.Columns["AccountDeleted"].HeaderText = "Account Deleted";
                dgvManagers.Columns["PersonID"].HeaderText = "Person ID";
                dgvManagers.Columns["PhonePrimary"].HeaderText = "Phone Primary";
                dgvManagers.Columns["PhoneSecondary"].Visible = false;

                dgvDiscounts.Columns["InventoryID"].HeaderText = "Inventory ID";
                dgvDiscounts.Columns["DiscountPercentage"].HeaderText = "Discount Percentage";
                dgvDiscounts.Columns["DiscountCode"].HeaderText = "Discount Code";
                dgvDiscounts.Columns["ExpDate"].HeaderText = "Expiration Date";
                dgvDiscounts.Columns["DiscountID"].HeaderText = "Discount ID";

                dgvOrdersForReports.Columns["ItemName"].HeaderText = "Item Name";
                dgvOrdersForReports.Columns["RetailPrice"].HeaderText = "Retail Price";
                dgvOrdersForReports.Columns["DiscountID"].HeaderText = "Discount ID";
                dgvOrdersForReports.Columns["OrderDate"].HeaderText = "Order Date";
            }
            catch(Exception a)
            {
                clsManager.ErrorMessageBox(a, "Setting Column Headers/Visibility Error", "", true);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            TextBox[] arrTbxes = new TextBox[] {
            tbxAddItemName,tbxAddItemDesc,tbxAddItemPrice,tbxAddItemCost,tbxAddItemQuantity, tbxAddItemGenre};
            //If AddItem state is Add, set text, state & enable the group of tools to allow adding a new item
            switch (AddItem)
            {
                case AddItemState.Add:
                    btnAddItem.Text = "Save";
                    grpAddItem.Enabled = true;
                    AddItem = AddItemState.Save;
                    break;
                case AddItemState.Save:
                    //If AddState is Save, check if the textboxes are empty, check if money format is allowed, if validation is all correct
                    //Add the new item, reload datagridviews, reload comboboxes and clear textboxes
                    bool bolIsInvalid = false;
                    bool[] arrBolValid = new bool[] {
                clsValidation.CheckIfEmpty(arrTbxes),
                clsValidation.CheckIfMoney(tbxAddItemCost),
                clsValidation.CheckIfMoney(tbxAddItemPrice),
                        };
                    foreach(bool bol in arrBolValid)
                    {
                        if (!bol)
                        {
                            bolIsInvalid = true;
                        }
                    }
                    if (!bolIsInvalid)
                    {
                        grpAddItem.Enabled = false;
                        if (clsManager.AddNewItem(arrTbxes, bytImg, cbxAddDiscontinued))
                        {
                            btnAddItem.Text = "Add";
                            AddItem = AddItemState.Add;
                            DataGridView[] arrDgvs = new DataGridView[]
                            {
                            dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
                            };
                            clsManager.LoadDataGridViews(arrDgvs);
                            clsManager.LoadAvailableItemsForDiscounts(cbxAvailableItems, cbxAvailableItemEdit);
                            foreach (TextBox tbx in arrTbxes)
                            {
                                tbx.Clear();
                            }
                            pbxAddItemImage.Image = null;
                        }
                        else
                        {
                            grpAddItem.Enabled = true;
                        }
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Turn off the group of tools on cancel, change addItem state and set the button text back to Add Item
            grpAddItem.Enabled = false;
            btnAddItem.Text = "Add Item";
            AddItem = AddItemState.Add;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TextBox[] arrTbxes = new TextBox[] {
            tbxEditItemName,tbxEditItemDesc,tbxEditRetailPrice,tbxEditItemCost,tbxEditItemQuantity, tbxEditGenre};
            clsManager.Selection selection;

            
            switch (EditItem)
            {
                case EditItemState.Edit:
                    //Turn on Edit Tools, turn off datagridview, change the editItemState
                    btnEdit.Text = "Save";
                    grpEditItem.Enabled = true;
                    dgvInventory.Enabled = false;
                    EditItem = EditItemState.Save;
                    break;
                case EditItemState.Save:
                    /*Check if textboxes are empty or if acceptable money format,
                     Ask if they really want to update the selected item
                    If they change an item's image, save the new image otherwise save previous image*/
                    bool bolIsInvalid = false;
                    bool[] arrBolValid = new bool[] {
                clsValidation.CheckIfEmpty(arrTbxes),
                clsValidation.CheckIfMoney(tbxEditItemCost),
                clsValidation.CheckIfMoney(tbxEditRetailPrice),
                        };
                    foreach (bool bol in arrBolValid)
                    {
                        if (!bol)
                        {
                            bolIsInvalid = true;
                        }
                    }

                    if (!bolIsInvalid)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want update this item?", "Updating/Editting Item",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            if (bytImg != null)
                            {
                                selection = new clsManager.Selection(dgvInventory, "Inventory", arrTbxes, bytImg, cbxEditDisc);
                                DataGridView[] arrDgvs = new DataGridView[]
                                {
                            dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
                                };
                                clsManager.UpdateSelection(selection);
                                clsManager.LoadDataGridViews(arrDgvs);
                                clsManager.LoadAvailableItemsForDiscounts(cbxAvailableItems, cbxAvailableItemEdit);
                                bytImg = null;
                            }
                            else
                            {
                                selection = new clsManager.Selection(dgvInventory, "Inventory", arrTbxes, clsManager.byteImg, cbxEditDisc);
                                DataGridView[] arrDgvs = new DataGridView[]
                                {
                            dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
                                };
                                clsManager.UpdateSelection(selection);
                                clsManager.LoadDataGridViews(arrDgvs);
                                clsManager.LoadAvailableItemsForDiscounts(cbxAvailableItems, cbxAvailableItemEdit);
                            }
                            btnEdit.Text = "Edit";
                            grpEditItem.Enabled = false;
                            dgvInventory.Enabled = true;
                            EditItem = EditItemState.Edit;
                        }
                    }
                    break;
            }
        }

        private void btnCancelItemEdit_Click(object sender, EventArgs e)
        {
            //Turn off edit tools, enable datagridview, reset EditItemState, empty the item image variable
            btnEdit.Text = "Edit Item";
            grpEditItem.Enabled = false;
            dgvInventory.Enabled = true;
            EditItem = EditItemState.Edit;
            bytImg = null;
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            //Load the inventory selection into the tools depending on what is selected
            TextBox[] arrTbxes = new TextBox[] {
            tbxEditItemName,tbxEditItemDesc,tbxEditRetailPrice,tbxEditItemCost,tbxEditItemQuantity, tbxEditGenre};
            if (tabView.SelectedTab == tabInventory)
            {
                clsManager.LoadInventorySelection(dgvInventory, arrTbxes, pbxEditItemImage, cbxEditDisc);
            }
        }

        private void btnEditImage_Click(object sender, EventArgs e)
        {
            //Get the new added image and save it into a bytImg variable
            //Display the image in a picturebox
            bytImg = clsSQL.AddImage();
            try
            {
                if (bytImg != null)
                {
                    using (MemoryStream mStream = new MemoryStream(bytImg))
                    {
                        image = Image.FromStream(mStream);
                    }
                    pbxEditItemImage.Image = image;
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Argument Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            //Get the new added image and save it into a bytImg variable
            //Display the image in a picturebox
            bytImg = clsSQL.AddImage();
            try
            {
                if (bytImg != null)
                {
                    using (MemoryStream mStream = new MemoryStream(bytImg))
                    {
                        image = Image.FromStream(mStream);
                    }
                    pbxAddItemImage.Image = image;
                }
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Argument null exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInventory_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //If the item is out of stock, display the row in red
            try
            {
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    int.TryParse(row.Cells[5].Value.ToString(), out int intQuantity);
                    if (intQuantity == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Parse Error in Column Header Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintInventory_Click(object sender, EventArgs e)
        {
            //Print the inventory report
            clsManager.PrintInventoryReport(clsManager.GenerateReport(dgvInventory));
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!bolNavAway)
            {
                //Create Person Object
                //Pass Person object into New User Constructor and set the New User state to Add
                clsManager.Person person = new clsManager.Person();
                bolNavAway = true;
                new frmNewUser(true, "Add", person).Show();
                this.Close();
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                //Create new Person Object
                //Pass Person object into New User Constructor and set the New User state to Edit
                clsManager.Person person = new clsManager.Person(dgvCustomers.SelectedCells);
                new frmNewUser(true, "Edit", person).Show();
                bolNavAway = true;
                this.Close();
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Edit Customer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            //Set the Manager ID to the PersonID
            //Create Person Object
            //Set Manager Order to true
            //Open frmMain
            clsFinishOrder.intManagerID = clsSQL.intPersonID;
            bolNavAway = true;
            clsManager.Person person = new clsManager.Person(dgvCustomers.SelectedCells);
            clsSQL.intPersonID = person.intPersonID;
            clsFinishOrder.bolManagerOrder = true;
            new frmMain().Show();
            this.Close();
        }
        private void tbxCustomerSearchEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Search for an email based on what is typed
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvCustomers.DataSource;
                bs.Filter = "Email like '%" + tbxCustomerSearchEmail.Text + "%'";
                dgvInventory.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Email Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxSearchLastName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Search for last name depending on what is typed
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvCustomers.DataSource;
                bs.Filter = "NameLast like '%" + tbxSearchLastName.Text + "%'";
                dgvInventory.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Last Name Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxSearchFirstName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Search for a first name based on what is typed
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvCustomers.DataSource;
                bs.Filter = "NameFirst like '%" + tbxSearchFirstName.Text + "%'";
                dgvInventory.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "First Name Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxMemberID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Search for a PersonID based on what is typed
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvCustomers.DataSource;
                bs.Filter = "Convert(PersonID, 'System.String') LIKE '" + tbxMemberID.Text + "%'";
                dgvInventory.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "MemberID Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            //Load Customer Orders depending on what row is selected
            clsManager.LoadCustomerOrders(dgvCustomers, dgvOrders);

            //Set Column Headers
            dgvOrders.Columns["OrderID"].HeaderText = "Order ID";
            dgvOrders.Columns["PersonID"].HeaderText = "Person ID";
            dgvOrders.Columns["OrderDate"].HeaderText = "Order Date";
            dgvOrders.Columns["EmployeeID"].HeaderText = "Employee ID";
            dgvOrders.Columns["CC_Number"].HeaderText = "CC Number";
            dgvOrders.Columns["ExpDate"].HeaderText = "Expiration Date";
            dgvOrders.Columns["CCV"].HeaderText = "CCV";

            try
            {
                foreach(DataGridViewRow row in dgvCustomers.SelectedRows)
                {
                    bool.TryParse(row.Cells[24].Value.ToString(), out bool bolAccDeleted);
                    chkCustDeleted.Checked = bolAccDeleted;
                    bool.TryParse(row.Cells[23].Value.ToString(), out bool bolAccDisabled);
                    chkCustEnabledDisabled.Checked = bolAccDisabled;
                }
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Error loading Customer Enabled/Disabled Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save the customer's new status depending on if they click yes
            DialogResult result = MessageBox.Show("Are you sure you want update this customer's account?", "Account Activation/Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DataGridView[] arrDgvs = new DataGridView[]
                {
                dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
                };
                CheckBox[] arrCbxes = new CheckBox[]
                {
                    chkCustEnabledDisabled, chkCustDeleted
                };
                //Update the account status and load dgvViews
                clsManager.UpdateAccountStatus(arrCbxes, dgvCustomers, false);
                clsManager.LoadDataGridViews(arrDgvs);
            }
        }

        private void btnAddNewManager_Click(object sender, EventArgs e)
        {
            Exception s = new Exception();
            //Make sure that the manager entered a new salary before adding a new customer
            //Only allow salaries between 34,000-50,000
            //Create new person object
            //Pass person object into New User Constructor and set New User state to Add
            if (!String.IsNullOrEmpty(tbxSalary.Text))
            {
                try
                {
                    int.TryParse(tbxSalary.Text, out int intSalary);
                    if(intSalary < 34000)
                    {
                        clsManager.ErrorMessageBox(s, "Minimum Salary Rate is $34,000 ($17 an hour for Managers)", "Improper Salary", false);
                        return;
                    }
                    else if(intSalary > 50000)
                    {
                        clsManager.ErrorMessageBox(s, "Maximum Salary Rate is $50,000 ($24.51 an hour for Managers)", "Improper Salary", false);
                        return;
                    }
                }catch(Exception a)
                {
                    clsManager.ErrorMessageBox(a, "Parse Exception", "", true);
                }
                bolNavAway = true;
                clsManager.Person person = new clsManager.Person(true, tbxSalary.Text);
                new frmNewUser(true, "Add", person).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a Manager's Salary before continuing", "Manager Creation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEditManager_Click(object sender, EventArgs e)
        {
            try
            {
                //Create new person Object
                //Pass into New User Constructor
                //Set New User state to edit
                clsManager.Person person = new clsManager.Person(dgvManagers.SelectedCells);
                bolNavAway = true;
                new frmNewUser(true, "Edit", person).Show();
                this.Close();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Edit Manager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplayInfo_Click(object sender, EventArgs e)
        {
            //Print selected manager information
            clsManager.PrintManagerInformation(clsManager.GenerateManagerReport(dgvManagers), dgvManagers);
        }

        private void btnSaveManager_Click(object sender, EventArgs e)
        {
            //Ask if the changes want to be saved to selected manager then update the user account status and reload datagridviews
            DialogResult result = MessageBox.Show("Are you sure you want to update this selected Manager's Account?", "Manager Account Activation/Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DataGridView[] arrDgvs = new DataGridView[]
                {
                    dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
                };
                CheckBox[] arrCbxes = new CheckBox[]
                {
                    chkManagerEnabled, chkManagerDeleted, chkManagerActive,chkIsManager
                };
                clsManager.UpdateAccountStatus(arrCbxes, dgvManagers, true);
                clsManager.LoadDataGridViews(arrDgvs);
            }
        }

        private void ApplyManagerSalary_Click(object sender, EventArgs e)
        {
            //Make sure that the manager entered a new salary before adding a new customer
            //Only allow salaries between 34,000-50,000
            //Reload datagridviews
            Exception s = new Exception();
            DialogResult result = MessageBox.Show("Are you sure you want update this selected Manager's Salary?", "Manager Salary Update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                {
                    if (!String.IsNullOrEmpty(tbxSalary.Text))
                    {
                        tbxSalary.Enabled = false;
                        try
                        {
                            int.TryParse(tbxSalary.Text, out int intSalary);
                            if (intSalary < 34000)
                            {
                                clsManager.ErrorMessageBox(s, "Minimum Salary Rate is $34,000 ($17 an hour for Managers)", "Improper Salary", false);
                                tbxSalary.Enabled = true;
                                return;
                            }
                            else if (intSalary > 50000)
                            {
                                clsManager.ErrorMessageBox(s, "Maximum Salary Rate is $50,000 ($24.51 an hour for Managers)", "Improper Salary", false);
                                tbxSalary.Enabled = true;
                                return;
                            }
                        }
                        catch (Exception a)
                        {
                            clsManager.ErrorMessageBox(a, "Parse Exception", "", true);
                        }
                        clsManager.UpdateManagerSalary(dgvManagers, tbxSalary);
                        tbxSalary.Enabled = true;
                        DataGridView[] arrDgvs = new DataGridView[]
                        {
                            dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
                        };
                        clsManager.LoadDataGridViews(arrDgvs);
                    }
                    else
                    {
                        MessageBox.Show("Please select a Manager's Salary to update", "Manager Update Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvManagers_SelectionChanged(object sender, EventArgs e)
        {
            int intRows = dgvManagers.SelectedCells.Count;
            //Display account status in CheckBoxes
            try
            {
                foreach (DataGridViewRow row in dgvManagers.SelectedRows)
                {
                    bool.TryParse(row.Cells[22].Value.ToString(), out bool bolAccDeleted);
                    chkManagerDeleted.Checked = bolAccDeleted;
                    bool.TryParse(row.Cells[26].Value.ToString(), out bool bolAccDisabled);
                    chkManagerEnabled.Checked = bolAccDisabled;
                    bool.TryParse(row.Cells[27].Value.ToString(), out bool bolIsActive);
                    chkManagerActive.Checked = bolIsActive;
                    bool.TryParse(row.Cells[28].Value.ToString(), out bool bolIsManager);
                    chkIsManager.Checked = bolIsManager;
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Error loading Manager Enabled/Disabled Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveDiscount_Click(object sender, EventArgs e)
        {
            DataGridView[] arrDgvs = new DataGridView[]
            {
                dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
            };
            TextBox[] arrTbxes = new TextBox[] { tbxNewDiscountDescription };
            /*Discount Add State: Enable Discount Creation tools, set Discount state to Save
             Discount Save State: Make sure combo boxes are selected, check if textboxes are empty,
            Create new discount, and if successful, disable tools temporarily for update, load datagridviews
            */
            switch (DiscountAdd)
            {
                case AddDiscountState.Add:
                    grpCreateDiscount.Enabled = true;
                    btnSaveDiscount.Text = "Save";
                    DiscountAdd = AddDiscountState.Save;
                    break;
                case AddDiscountState.Save:
                    bool bolIsInvalid = false;
                    grpCreateDiscount.Enabled = false;
                    if (cbxAvailableItems.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please select an item for Discount Creation", "Item Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        grpCreateDiscount.Enabled = true;
                        bolIsInvalid = true;
                    }
                    if (cbxDiscAmount.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please select a percentage for Discount Creation", "Discount Percentage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        grpCreateDiscount.Enabled = true;
                        bolIsInvalid = true;
                    }
                    if (!bolIsInvalid)
                    {
                        if (clsValidation.CheckIfEmpty(arrTbxes))
                        {
                            if (clsManager.DiscountCreation(cbxAvailableItems, tbxNewDiscountDescription, cbxDiscAmount, dtpExpDate))
                            {
                                grpCreateDiscount.Enabled = false;
                                DiscountAdd = AddDiscountState.Add;
                                btnSaveDiscount.Text = "Create Discount";
                                clsManager.LoadDataGridViews(arrDgvs);
                                cbxAvailableItems.Text = "";
                                tbxNewDiscountDescription.Text = "";
                                cbxDiscAmount.Text = "";
                            }
                            else
                            {
                                grpCreateDiscount.Enabled = true;
                            }
                        }
                    }
                    break;
            }

        }

        private void btnCancelDiscountCreation_Click(object sender, EventArgs e)
        {
            //Renable discount creation tools
            grpCreateDiscount.Enabled = false;
            DiscountAdd = AddDiscountState.Add;
            btnSaveDiscount.Text = "Create Discount";
        }

        private void btnEditDiscount_Click(object sender, EventArgs e)
        {
            switch (DiscountEdit) {
                case EditDiscountState.Edit:
                    //Disable discount creation tools, set discount edit state to Edit
                    grpEditDiscount.Enabled = true;
                    dgvDiscounts.Enabled = false;
                    btnEditDiscount.Text = "Save Discount";
                    DiscountEdit = EditDiscountState.Save;
                    break;
                case EditDiscountState.Save:
                    DialogResult result = MessageBox.Show("Are you sure you want update this selected discount?", "Discount Update",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //Disable edit tools temporarily, edit discount, renable tools, load datagridview, load items into comboboxes for discounts
                        grpEditDiscount.Enabled = false;
                        if (clsManager.EditDiscount(dgvDiscounts, cbxAvailableItemEdit, tbxDiscountDescriptionEdit, cbxDiscAmountEdit, dtpExpDateEdit))
                        {
                            btnEditDiscount.Text = "Edit Discount";
                            DataGridView[] arrDgvs = new DataGridView[]
                            {
                            dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
                            };
                            grpEditDiscount.Enabled = false;
                            dgvDiscounts.Enabled = true;
                            clsManager.LoadDataGridViews(arrDgvs);
                            DiscountEdit = EditDiscountState.Edit;
                            clsManager.LoadAvailableItemsForDiscounts(cbxAvailableItems, cbxAvailableItemEdit);
                        }
                        else
                        {
                            grpEditDiscount.Enabled = true;
                        }
                    }
                    break;
            }
        }

        private void btnCancelDiscountEdit_Click(object sender, EventArgs e)
        {
            //Renable discount edit tools
            grpEditDiscount.Enabled = false;
            dgvDiscounts.Enabled = true;
            btnEditDiscount.Text = "Edit Discount";
            DiscountEdit = EditDiscountState.Edit;
        }

        private void cbxAvailableItems_SelectedValueChanged(object sender, EventArgs e)
        {
            //Display the Item Name inside the textbox Description
            try
            {
                string strItemTitle = cbxAvailableItems.Text;
                tbxNewDiscountDescription.Text = " " + cbxAvailableItems.Text;
                string strDescription = tbxNewDiscountDescription.Text;
                string strRemoveCost = strDescription.Substring(strDescription.IndexOf("$") + 1);
                tbxNewDiscountDescription.Text = tbxNewDiscountDescription.Text.Replace("$" + strRemoveCost, "");
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Argument Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!String.IsNullOrEmpty(cbxDiscAmount.Text))
            {
                string strPercent = cbxDiscAmount.Text + " Off";
                tbxNewDiscountDescription.Text = tbxNewDiscountDescription.Text.Insert(0, strPercent) + " ";
            }
        }

        private void cbxDiscAmount_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Display the discount amount in the item description
                if (tbxNewDiscountDescription.Text.Contains("% Off"))
                {
                    string strDescription = tbxNewDiscountDescription.Text;
                    string strOutput = strDescription.Substring(strDescription.IndexOf("%") + 1);
                    string strPercent = cbxDiscAmount.Text;
                    tbxNewDiscountDescription.Text = strOutput.Insert(0, strPercent) + " ";
                }
                else
                {
                    string strPercent = cbxDiscAmount.Text + " Off";
                    tbxNewDiscountDescription.Text = tbxNewDiscountDescription.Text.Insert(0, strPercent);
                }
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Argumennt null exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDiscounts_SelectionChanged(object sender, EventArgs e)
        {
            //Display Discount Information into the textbox, combobox and datetimepicker depending on what's selected
            try
            {
                foreach (DataGridViewRow row in dgvDiscounts.SelectedRows)
                {
                    int.TryParse(row.Cells[0].Value.ToString(), out int intInventoryID);
                    foreach(clsSQL.AvailableItem item in clsManager.lstItems)
                    {
                        if(intInventoryID == item.intInventoryID)
                        {
                            cbxAvailableItemEdit.SelectedIndex = cbxAvailableItemEdit.FindString(item.strItemName);
                            break;
                        }
                    }
                    tbxDiscountDescriptionEdit.Text = row.Cells[1].Value.ToString();
                    string strPercentage = row.Cells[2].Value.ToString() + "%";
                    cbxDiscAmountEdit.SelectedItem = strPercentage;
                    dtpExpDateEdit.Value = (DateTime)row.Cells[4].Value;
                }                    
            }catch(Exception s)
            {
                clsManager.ErrorMessageBox(s, "", "Discount Selection Error", true);
            }
        }

        private void cbxDiscAmountEdit_SelectedValueChanged(object sender, EventArgs e)
        {
            //Display the Discounted Amount in the Discount Description
            try {
                foreach (DataGridViewRow row in dgvDiscounts.SelectedRows) {
                    if (tbxDiscountDescriptionEdit.Text.Contains("% Off"))
                    {
                        string strDescription = tbxDiscountDescriptionEdit.Text;
                        string strOutput = strDescription.Substring(strDescription.IndexOf("%") + 1);
                        string strPercent = cbxDiscAmountEdit.Text;
                        tbxDiscountDescriptionEdit.Text = strOutput.Insert(0, strPercent) + " ";
                    }
                    else if (row.Cells[1].Value.ToString().Contains("% Off"))
                    {
                        string strPercent = cbxDiscAmountEdit.Text + " Off ";
                        tbxDiscountDescriptionEdit.Text = tbxDiscountDescriptionEdit.Text.Insert(0, strPercent) + " ";
                    }
                }
            }catch(Exception a)
            {
                clsManager.ErrorMessageBox(a, "Error Selecting a discount amount", "", true);
            }
        }

        private void cbxAvailableItemEdit_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Display the available item in the discount description
                string strItemTitle = cbxAvailableItemEdit.Text;
                tbxDiscountDescriptionEdit.Text = " " + cbxAvailableItemEdit.Text;
                string strDescription = tbxDiscountDescriptionEdit.Text;
                string strRemoveCost = strDescription.Substring(strDescription.IndexOf("$") + 1);
                tbxDiscountDescriptionEdit.Text = tbxDiscountDescriptionEdit.Text.Replace("$" + strRemoveCost, "");

                if (!String.IsNullOrEmpty(cbxDiscAmountEdit.Text))
                {
                    string strPercent = cbxDiscAmountEdit.Text + " Off";
                    tbxDiscountDescriptionEdit.Text = tbxDiscountDescriptionEdit.Text.Insert(0, strPercent) + " ";
                }
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Argument null exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            //If there are more than 0 rows in the datagridview, print the report
            if (dgvOrdersForReports.Rows.Count > 0)
            {
                clsManager.PrintSalesReport(clsManager.GenerateSalesReport(dgvOrdersForReports));
            }
            else
            {
                MessageBox.Show("No orders have been selected to view a Sales Report", "No orders selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDaily_Click(object sender, EventArgs e)
        {
            //Set the report type and load the daily reports
            clsManager.strReportType = "Daily";
            clsManager.LoadDailySalesReports(dgvOrdersForReports, dtpReports);
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            //Set the report type and load the weekly reports
            clsManager.strReportType = "Weekly";
            clsManager.LoadWeeklySalesReports(dgvOrdersForReports, dtpReports);
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            //Set the report type and load the monthly reports
            clsManager.strReportType = "Monthly";
            clsManager.LoadMonthlySalesReports(dgvOrdersForReports, dtpReports);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //Reload datagridviews
            DataGridView[] arrDgvs = new DataGridView[]
            {
                dgvInventory,dgvCustomers,dgvManagers,dgvDiscounts,dgvOrdersForReports
            };
            clsManager.LoadDataGridViews(arrDgvs);
        }

        private void tbxAddItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only digits into the item quantity
            clsValidation.OnlyAllowDigits(sender, e);
        }

        private void tbxAddItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only digits and a decimal in the Item Price
            clsValidation.OnlyAllowDigitsAndDecimal(sender, e);
        }

        private void tbxAddItemCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only digits and a decimal in the Item Cost
            clsValidation.OnlyAllowDigitsAndDecimal(sender, e);
        }

        private void tbxEditRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only digits and a decimal in the Item Price
            clsValidation.OnlyAllowDigitsAndDecimal(sender, e);
        }

        private void tbxEditItemCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only digits and a decimal in the Item Cost
            clsValidation.OnlyAllowDigitsAndDecimal(sender, e);
        }

        private void tbxEditItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only digits in the Item Quantity
            clsValidation.OnlyAllowDigits(sender, e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if(tabView.SelectedTab == tabInventory)
            {
                //Upon Clicking, pulls up help Diagram and displays it in Help Form as well as passes in the Form State String to constructor
                frmHelp help = new frmHelp("Manager");
                help.BackgroundImage = Resources.frmInventoryHelp;
                help.Width = Resources.frmInventoryHelp.Width;
                help.Height = Resources.frmInventoryHelp.Height;
                bolNavAway = true;
                help.Show();
                this.Close();
            }
            else if (tabView.SelectedTab == tabCustomers)
            {
                //Upon Clicking, pulls up help Diagram and displays it in Help Form as well as passes in the Form State String to constructor
                frmHelp help = new frmHelp("Manager");
                help.BackgroundImage = Resources.frmCustomersHelp;
                help.Width = Resources.frmCustomersHelp.Width;
                help.Height = Resources.frmCustomersHelp.Height;
                bolNavAway = true;
                help.Show();
                this.Close();
            }
            else if (tabView.SelectedTab == tabManagers)
            {
                //Upon Clicking, pulls up help Diagram and displays it in Help Form as well as passes in the Form State String to constructor
                frmHelp help = new frmHelp("Manager");
                help.BackgroundImage = Resources.frmManagerHelp;
                help.Width = Resources.frmManagerHelp.Width;
                help.Height = Resources.frmManagerHelp.Height;
                bolNavAway = true;
                help.Show();
                this.Close();
            }
            else if (tabView.SelectedTab == tabDiscounts)
            {
                //Upon Clicking, pulls up help Diagram and displays it in Help Form as well as passes in the Form State String to constructor
                frmHelp help = new frmHelp("Manager");
                help.BackgroundImage = Resources.frmDiscountsHelp;
                help.Width = Resources.frmDiscountsHelp.Width;
                help.Height = Resources.frmDiscountsHelp.Height;
                bolNavAway = true;
                help.Show();
                this.Close();
            }
            else if (tabView.SelectedTab == tabReports)
            {
                //Upon Clicking, pulls up help Diagram and displays it in Help Form as well as passes in the Form State String to constructor
                frmHelp help = new frmHelp("Manager");
                help.BackgroundImage = Resources.frmOrdersHelp;
                help.Width = Resources.frmOrdersHelp.Width;
                help.Height = Resources.frmOrdersHelp.Height;
                bolNavAway = true;
                help.Show();
                this.Close();
            }
        }

        private void tbxSearchItemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Search for an Item Name depending on what is entered
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvInventory.DataSource;
                bs.Filter = "ItemName like '%" + tbxSearchItemName.Text + "%'";
                dgvInventory.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Item Name Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxSearchInventoryID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Search for an inventory ID depending on what is entered
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvInventory.DataSource;
                bs.Filter = "Convert(InventoryID, 'System.String') LIKE '" + tbxSearchInventoryID.Text + "%'";
                dgvInventory.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "MemberID Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxSearchGenre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Search for an item genre depending on what is entered
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvInventory.DataSource;
                bs.Filter = "Genre like '%" + tbxSearchGenre.Text + "%'";
                dgvInventory.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Item Genre Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only digits for the Manager Salary
            clsValidation.OnlyAllowDigits(sender, e);
        }

        private void frmManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If the user is wanting to leave frmManagers, go back to frmLogin if they hit yes
            if (!bolNavAway)
            {
                DialogResult result = MessageBox.Show("Returning to the login screen will log you out. Continue?", "Logging out",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    new frmLogin().Show();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
