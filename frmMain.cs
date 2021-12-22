//ToDo: Change the entries below indicated by {} to your values
//*******************************************
//*******************************************
// Programmer: Elizabeth Stiles
// Course: INEW 2332.{7Z#} (Final Project)
// Program Description: A simple bookstore application where you can purchase books/magazines.
//*******************************************
// Form Purpose: The main view to navigate which forms you wish to go to
//*******************************************
//*******************************************

using FA21_Final_Project;
using FA21_Final_Project.Properties;
using System;
using System.Data;
using System.Windows.Forms;

namespace SU21_Final_Project
{
    public partial class frmMain : Form
    {
        int intRows = 0;
        int intCount = 1;
        int intSelectedQuantity, intItemQuantity;
        bool bolIsHelp, bolIsDiscounts, bolIsLogin, bolIsOrder = false;
        enum ItemQuantityEdit { Edit, Save}
        ItemQuantityEdit editState = ItemQuantityEdit.Edit;
        DataTable dt = new DataTable();
        public frmMain()
        {
            //Set ToolTip for Back Button
            InitializeComponent();
            tipDoubleClickInfo.SetToolTip(btnBack, "Click to return to the Main Menu");
        }
        public frmMain(DataGridView dgvCart)
        {
            //If the previous carts rows are existing then reload the cart
            InitializeComponent();
            int intRows2 = dgvCart.Rows.Count;
            if (intRows2 > 0)
            {
                clsShoppingCart.SaveCurrentCart(dgvCart, this.dgvCart);
                int intRows = this.dgvCart.Rows.Count;
            }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            bolIsHelp = true;
            //Upon Clicking, pulls up help Diagram and displays it in Help Form
            frmHelp help = new frmHelp("Main", dgvCart);
            help.BackgroundImage = Resources.CartHelp;
            help.Width = Resources.CartHelp.Width;
            help.Height = Resources.CartHelp.Height;
            help.Show();
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Open SQL Connection, Load DGVStore with Inventory and Close
            clsShoppingCart.LoadShoppingCart(dgvStore);

            //Create Columns in Cart DataGridView
            if (dgvCart.DataSource == null)
            {
                try
                {
                    dgvCart.ColumnCount = 10;
                    dgvCart.Columns[0].Name = "InventoryID";
                    dgvCart.Columns[1].Name = "Items";
                    dgvCart.Columns[2].Name = "ItemDescription";
                    dgvCart.Columns[3].Name = "Retail Price";
                    dgvCart.Columns[4].Name = "Available Quantity";
                    dgvCart.Columns[5].Name = "ItemImage";
                    dgvCart.Columns[6].Name = "Quantity";
                    dgvCart.Columns[7].Name = "Item Cost";
                    dgvCart.Columns[8].Name = "Discount Applied";
                    dgvCart.Columns[9].Name = "DiscountID";

                    //Set unneeded columns invisible in cart
                    dgvCart.Columns["InventoryID"].Visible = false;
                    dgvCart.Columns["ItemImage"].Visible = false;
                    dgvCart.Columns["ItemDescription"].Visible = false;
                    dgvCart.Columns["Available Quantity"].Visible = false;
                    dgvCart.Columns["Discount Applied"].Visible = false;
                    dgvCart.Columns["DiscountID"].Visible = false;

                    dgvCart.Columns["Retail Price"].DefaultCellStyle.Format = "c";
                }catch(Exception s)
                {
                    MessageBox.Show(s.Message, "DataGridView Column Names error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };

            try
            {
                //Find if the items inside the dgvCart contain a discount or not and calculate depending on which is which
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells[8].Value.ToString() == "No")
                    {
                        clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, false);
                    }
                    else if (row.Cells[8].Value.ToString() == "Yes")
                    {
                        clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);
                    }
                }
            }catch(Exception a)
            {
                MessageBox.Show(a.Message, "Finding discounts error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*On click of a selection in the DataGridView store, auto set the quantity selection to 1 for the user & display
            the selection of the item in labels & picturebox*/

            tbxQuantity.Text = "1";
            intCount = 1;
            clsShoppingCart.DisplaySelection(dgvStore, lblBookName, lblBookDescription, lblBookPrice, pbxItemImage);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*Find if item is not added and if not, allow addition if it has then display of error
            Find selected quantity, then parse the input from the user,
            find if the entered quantity is acceptable and not above current available stock
            If above available stock, throw an error informing the user that inputted quantity is not acceptable
            If acceptable, add item to DataGridView Cart*/

            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };

            int intItemQuantity = clsShoppingCart.GetSelectedRowQuantity(dgvStore);

            int intQuantity = 0;
            //Check if Item exists in cart already
            if (!clsShoppingCart.CheckIfItemAdded(dgvStore, dgvCart, lblItemError))
            {
                try
                {
                    //Parse selected quantity
                    Int32.TryParse(tbxQuantity.Text, out intQuantity);
                }
                catch (FormatException s)
                {
                    MessageBox.Show(s.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //If the selected quantity is above what is available, throw an error
                if (intQuantity > intItemQuantity)
                {
                    MessageBox.Show("Cannot order above available quantity \n\n" +
                        "(Selection Currently Available: " + intItemQuantity.ToString() + ")", "Unavailable Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbxQuantity.Clear();
                    tbxQuantity.Focus();
                    //If they type in 0, throw an error
                }else if(intQuantity == 0)
                {
                    MessageBox.Show("Invalid Quantity Selection \n\n" +
                        "(Selection Currently Available: " + intItemQuantity.ToString() + ")", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbxQuantity.Clear();
                    tbxQuantity.Focus();
                }
                else
                {
                    //Calculate the cost by selected quantity & add to cart then calculate the billing summary depending on if it's a discount or not
                    clsShoppingCart.CalculateCostByQuantity(dgvStore, dgvCart, intRows = clsShoppingCart.AddToCart(dgvStore, dgvCart, dt), intQuantity);
                    try
                    {
                        foreach (DataGridViewRow row in dgvCart.SelectedRows)
                        {
                            if (row.Cells[8].Value.ToString() == "No")
                            {
                                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, false);
                            }
                            else if (row.Cells[8].Value.ToString() == "Yes")
                            {
                                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);
                            }
                        }
                    }catch(Exception s)
                    {
                        MessageBox.Show(s.Message, "Error updating billing summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    lblItemError.Visible = false;
                    intCount = 1;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lblDiscountError.Visible = false;

            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };
            //Remove selected item from cart
            clsShoppingCart.RemoveFromCart(dgvStore, dgvCart);
            bool bolIsApplied = false;
            lblItemError.Visible = false;

            try
            {
                //Find if there is a discount applied in the cart
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells[8].Value.ToString() == "Yes")
                    {
                        bolIsApplied = true;
                    }
                }
            }catch(Exception s)
            {
                MessageBox.Show(s.Message, "Error finding a coupon applied to an item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Calculate the billing summary based off if there is a discount or not
            if (bolIsApplied)
            {
                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);
            }
            else
            {
                lblDiscountedSubtotal.Text = "Discounted SubTotal: $0";
                lblDiscountPercentage.Text = "Discount Percentage: 0%";
                lblActualDiscountAmount.Text = "Amount Removed: $0";
                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, false);
            }
        }

        private void pbxIncrease_Click(object sender, EventArgs e)
        {
            /*Find selected item quantity, if the current number inside the textbox is not above the current available stock,
            allow the user to increase their choice until they reach their available limit then throw an error informing them that 
            they have hit their limit in selection*/
            int intItemQuantity = clsShoppingCart.GetSelectedRowQuantity(dgvStore);
            intCount = IncreaseCount(intCount, intItemQuantity, tbxQuantity);
        }

        private void pbxDecrease_Click(object sender, EventArgs e)
        {
            intCount = DecreaseCount(intCount, tbxQuantity);
        }

        //Only allow digits in quantity textbox
        private void tbxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only allows digits in TextBox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }            
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            //Sets the boolean for help to false and runs closing event
            bolIsHelp = false;
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If bool is false and isn't recognized as help, opens frmLogin
            if (!bolIsHelp && !bolIsDiscounts && !bolIsLogin && !bolIsOrder)
            {
                new frmNavigation().Show();
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            /*To Edit Selected Cart Item, show necessary controls to be able to edit,
             Then retrieve the current Quantity & Available quantity for the item and set the Edit State to Save
            Once the Edit State is at save, and the user clicks the button to save after adjusting quantity 
            then save the new quantity & cost to the dgvCart row and hide editing tools*/

            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };

            if (dgvCart.SelectedRows.Count >= 1) {
                switch (editState)
                {
                    case ItemQuantityEdit.Edit:
                        pbxDecrease2.Visible = true;
                        tbxQuantity2.Visible = true;
                        pbxIncrease2.Visible = true;
                        btnAdd.Enabled = false;
                        btnRemove.Enabled = false;
                        dgvCart.Enabled = false;
                        dgvStore.Enabled = false;
                        btnCancel.Visible = true;
                        intSelectedQuantity = clsShoppingCart.GetCartItemQuantity(dgvCart, tbxQuantity2);
                        intItemQuantity = clsShoppingCart.GetSelectedRowQuantity(dgvCart);
                        editState = ItemQuantityEdit.Save;
                        btnEditItem.Text = "Save";
                        break;
                    case ItemQuantityEdit.Save:
                        try
                        {
                            Int32.TryParse(tbxQuantity2.Text, out intSelectedQuantity);
                        }
                        catch (FormatException s)
                        {
                            MessageBox.Show(s.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (intSelectedQuantity > intItemQuantity)
                        {
                            MessageBox.Show("Cannot order above available quantity \n\n" +
                                "(Selection Currently Available: " + intItemQuantity.ToString() + ")", "Unavailable Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbxQuantity2.Clear();
                            tbxQuantity2.Focus();
                        }
                        else if (intSelectedQuantity == 0)
                        {
                            MessageBox.Show("Invalid Quantity Selection \n\n" +
                                "(Selection Currently Available: " + intItemQuantity.ToString() + ")", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbxQuantity2.Clear();
                            tbxQuantity2.Focus();
                        }
                        else
                        {
                            pbxDecrease2.Visible = false;
                            tbxQuantity2.Visible = false;
                            pbxIncrease2.Visible = false;
                            btnAdd.Enabled = true;
                            btnRemove.Enabled = true;
                            dgvCart.Enabled = true;
                            dgvStore.Enabled = true;
                            btnCancel.Visible = false;
                            editState = ItemQuantityEdit.Edit;
                            btnEditItem.Text = "Edit Item";
                            decimal decItemCost = 0;
                            decimal decTotalItemCost = 0;
                            try
                            {
                                foreach (DataGridViewRow row in dgvCart.SelectedRows)
                                {
                                    if (row.Cells[8].Value.ToString() != "Yes")
                                    {
                                        row.Cells[6].Value = "x" + intSelectedQuantity;
                                        try
                                        {
                                            decimal.TryParse(row.Cells[3].Value.ToString(), out decItemCost);
                                        }
                                        catch (Exception c)
                                        {
                                            MessageBox.Show(c.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        decTotalItemCost = decItemCost * intSelectedQuantity;

                                        row.Cells[7].Value = decTotalItemCost.ToString("C");

                                        clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, false);
                                    }
                                    else
                                    {
                                        string strCurrentQuantity = row.Cells[6].Value.ToString();
                                        strCurrentQuantity = strCurrentQuantity.Replace("x", "");
                                        int intCurrentQuantity = 0;
                                        decimal decDiscountedPrice = 0;
                                        decimal decAmountOfItemsTotal = 0;
                                        try
                                        {
                                            int.TryParse(strCurrentQuantity, out intCurrentQuantity);

                                            //Find if the current quantity is greater than 1
                                            if (intCurrentQuantity > 1)
                                            {
                                                //Get Item Cost
                                                decimal.TryParse(row.Cells[3].Value.ToString(), out decItemCost);
                                                //Store Total Items Cost
                                                string strAmountOfItemsTotal = row.Cells[7].Value.ToString();
                                                //Remove $
                                                strAmountOfItemsTotal = strAmountOfItemsTotal.Replace("$", "");
                                                //Parse Total Items Cost
                                                decimal.TryParse(strAmountOfItemsTotal, out decAmountOfItemsTotal);

                                                //Get the amount of items that can equally go into the Total Items Cost
                                                decimal decTemp = decAmountOfItemsTotal / decItemCost;
                                                //Round the amount of items down 
                                                decimal decRoundedQuantity = Math.Floor(decTemp);
                                                //Multiply the item cost by the rounded quantity
                                                decimal decTemp2 = decItemCost * decRoundedQuantity;
                                                //Get the discount amount by subtracting the rounded items amount from the original total item cost
                                                decimal decDiscountAmount = decAmountOfItemsTotal - decTemp2;

                                                //Calculate the Total Item Cost with all the items with normal price
                                                decTotalItemCost = decItemCost * (intSelectedQuantity - 1);
                                                //Add the discount amount ontop of the total item
                                                decTotalItemCost += decDiscountAmount;
                                                //Display as new cost
                                                row.Cells[7].Value = decTotalItemCost.ToString("C");
                                                //Display new quantity
                                                row.Cells[6].Value = "x" + intSelectedQuantity;


                                                //This is wrong. I need the percent not the amount removed.
                                                decimal decRemovedAmount = decItemCost - decDiscountAmount;

                                                decimal[] arrDiscountAmounts = new decimal[] {
                                                                decDiscountAmount, decRemovedAmount
                                                            };
                                                clsShoppingCart.DiscountInfo[1] = decRemovedAmount;

                                                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);
                                            }
                                            else
                                            {
                                                //Get Single Discounted Price

                                                string strDiscountedPrice = row.Cells[7].Value.ToString();
                                                strDiscountedPrice = strDiscountedPrice.Replace("$", "");
                                                decimal.TryParse(strDiscountedPrice, out decDiscountedPrice);

                                                //Get Actual Item Price
                                                decimal.TryParse(row.Cells[3].Value.ToString(), out decItemCost);

                                                //Determine the total minus one item
                                                decTotalItemCost = decItemCost * (intSelectedQuantity - 1);
                                                //Add the discounted item to the total
                                                decTotalItemCost += decDiscountedPrice;
                                                //Display new item total
                                                row.Cells[7].Value = decTotalItemCost.ToString("C");

                                                row.Cells[6].Value = "x" + intSelectedQuantity;

                                                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);

                                            }
                                        }
                                        catch (Exception c)
                                        {
                                            MessageBox.Show(c.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            catch (Exception a)
                            {
                                MessageBox.Show(a.Message, "DataGridView Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;           
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Hide editing tools and set editing state to Edit
            pbxDecrease2.Visible = false;
            tbxQuantity2.Visible = false;
            pbxIncrease2.Visible = false;
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            dgvCart.Enabled = true;
            dgvStore.Enabled = true;
            btnCancel.Visible = false;
            editState = ItemQuantityEdit.Edit;
            btnEditItem.Text = "Edit Item";
        }

        private void pbxDecrease2_Click(object sender, EventArgs e)
        {
            //Increase quantity count upon click
            intSelectedQuantity = DecreaseCount(intSelectedQuantity, tbxQuantity2);
        }

        private void pbxIncrease2_Click(object sender, EventArgs e)
        {
            //Decrease quantity count upon click
            intSelectedQuantity = IncreaseCount(intSelectedQuantity, intItemQuantity, tbxQuantity2);
        }

        //Function to increment quantity but not allow the user to go past what is available
        private int IncreaseCount(int intCount, int intItemQuantity, TextBox tbxQuantity)
        {
            if (intCount < intItemQuantity)
            {
                intCount++;
            }
            tbxQuantity.Text = intCount.ToString();

            return intCount;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            bool bolIsAdded = false;
            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };
            try
            {
                //Find if a discount is applied
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells[8].Value.ToString() == "Yes")
                    {
                        bolIsAdded = true;
                        break;
                    }
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Error finding discounted item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //If discount is applied, do not let them add it and display the error
            if (bolIsAdded)
            {
                lblDiscountError.Text = "*Discount already applied.";
                lblDiscountError.Visible = true;
            }
            //Add discount if there isn't one added
            else
            {
                bool bolIsApplied = clsShoppingCart.ApplyDiscount(tbxDiscount, lblDiscountError, dgvStore, dgvCart);

                if (bolIsApplied)
                {
                    clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);
                }
            }
        }

        //Function to decrement quantity but not allow past 0
        private int DecreaseCount(int intCount, TextBox tbxQuantity)
        {
            //If the number is not equal to zero and is above 0, allow the user to decrease their selection
            if (intCount != 0 && intCount > 0)
            {
                intCount--;
            }
            tbxQuantity.Text = intCount.ToString();

            return intCount;
        }

        private void tbxQuantity2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only allows digits in TextBox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };
            //Clear all items from cart
            clsShoppingCart.ClearCart(dgvCart, arrBillingLabels);
            lblItemError.Visible = false;
        }

        private void tbxSearchItemName_TextChanged(object sender, EventArgs e)
        {
            //Find an item name depending on the string entered
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvStore.DataSource;
                bs.Filter = "ItemName like '%" + tbxSearchItemName.Text + "%'";
                dgvStore.DataSource = bs;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Item Name Search Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Sets the boolean for help to false and runs closing event
            bolIsHelp = false;
            this.Close();
        }

        private void dgvStore_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Find if item is not added and if not, allow addition if it has then display of error
            Find selected quantity, then parse the input from the user,
            find if the entered quantity is acceptable and not above current available stock
            If above available stock, throw an error informing the user that inputted quantity is not acceptable
            If acceptable, add item to DataGridView Cart*/

            if (e.RowIndex == -1)
                return;

                Label[] arrBillingLabels = new Label[]
                {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
                };

            int intItemQuantity = clsShoppingCart.GetSelectedRowQuantity(dgvStore);

            int intQuantity = 0;

            if (!clsShoppingCart.CheckIfItemAdded(dgvStore, dgvCart, lblItemError))
            {
                try
                {
                    Int32.TryParse(tbxQuantity.Text, out intQuantity);
                }
                catch (FormatException s)
                {
                    MessageBox.Show(s.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (intQuantity > intItemQuantity)
                {
                    MessageBox.Show("Cannot order above available quantity \n\n" +
                        "(Selection Currently Available: " + intItemQuantity.ToString() + ")", "Unavailable Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbxQuantity.Clear();
                    tbxQuantity.Focus();
                }
                else if (intQuantity == 0)
                {
                    MessageBox.Show("Invalid Quantity Selection \n\n" +
                        "(Selection Currently Available: " + intItemQuantity.ToString() + ")", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbxQuantity.Clear();
                    tbxQuantity.Focus();
                }
                else
                {
                    clsShoppingCart.CalculateCostByQuantity(dgvStore, dgvCart, intRows = clsShoppingCart.AddToCart(dgvStore, dgvCart, dt), intQuantity);
                    try
                    {
                        foreach (DataGridViewRow row in dgvCart.SelectedRows)
                        {
                            if (row.Cells[8].Value.ToString() == "No")
                            {
                                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, false);
                            }
                            else if (row.Cells[8].Value.ToString() == "Yes")
                            {
                                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);
                            }
                        }
                    }catch(Exception s)
                    {
                        MessageBox.Show(s.Message, "Error processing calculating and billing summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    lblItemError.Visible = false;
                    intCount = 1;
                }
            }
        }

        private void dgvCart_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            lblDiscountError.Visible = false;

            Label[] arrBillingLabels = new Label[]
            {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
            };
            //Remove selected item from cart
            clsShoppingCart.RemoveFromCart(dgvStore, dgvCart);
            bool bolIsApplied = false;

            //If discount is applied, BolisApplied = true
            try
            {
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells[8].Value.ToString() == "Yes")
                    {
                        bolIsApplied = true;
                    }
                }
            }
            catch (Exception s) { MessageBox.Show(s.Message, "Error finding discounted item", MessageBoxButtons.OK, MessageBoxIcon.Error); } 

            //Calculate billing summary depending on if a discount is applied or not
            if (bolIsApplied)
            {
                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, true);
            }
            else
            {
                lblDiscountedSubtotal.Text = "Discounted SubTotal: $0.00";
                lblDiscountPercentage.Text = "Discount Percentage: 0%";
                lblActualDiscountAmount.Text = "Amount Removed: $0.00";
                clsShoppingCart.CalculateAndUpdateBillingSummary(dgvCart, arrBillingLabels, false);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            /*Check If Cart is Empty, if not then find if the user wants to login, is logged in or doesn't want to login
             Login: Opens login form
             NoLogin: does nothing
             isLoggedIn: allows the user to start the order process*/
            if (dgvCart.Rows.Count > 0)
            {
                clsFinishOrder.state = clsFinishOrder.StartOrderProcess();

                switch (clsFinishOrder.state)
                {
                    case clsFinishOrder.LoginState.LogIn:
                        bolIsLogin = true;
                        new frmLogin(dgvCart).Show();
                        this.Close();
                        break;

                    case clsFinishOrder.LoginState.NoLogin:
                        break;

                    case clsFinishOrder.LoginState.isLoggedIn:

                        Label[] arrBillingLabels = new Label[]
                        {
                lblSubTotal, lblDiscountPercentage, lblActualDiscountAmount, lblDiscountedSubtotal, lblTax, lblTotal
                        };

                        clsFinishOrder.Summary = new clsFinishOrder.BillingSummary(arrBillingLabels);
                        bolIsOrder = true;
                        new frmFinishOrder(dgvCart).Show();
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select item(s) in your cart to start an order.", "No items in cart",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDiscounts_Click(object sender, EventArgs e)
        {
            //Set Discount Boolean to true then show frmDiscounts
            bolIsDiscounts = true;
            new frmDiscounts(dgvCart).Show();
            this.Close();
        }
    }
}