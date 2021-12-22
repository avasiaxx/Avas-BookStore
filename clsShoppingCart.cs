using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FA21_Final_Project
{
    public class clsShoppingCart
    {
        public static void LoadShoppingCart(DataGridView dgvStore)
        {
            SqlConnection cnn = clsSQL.OpenDatabase();
            clsSQL.LoadGridView(dgvStore,cnn);
            clsSQL.CloseDatabase(cnn);
        }

        public static void LoadDiscounts(DataGridView dgvDiscounts)
        {
            try
            {
                //Open Database, Load and Display Discounts in DataGridView, Close Connection
                SqlConnection cnn = clsSQL.OpenDatabase();
                clsSQL.LoadDiscounts(dgvDiscounts, false, cnn);
                clsSQL.CloseDatabase(cnn);

            }catch(Exception e) {
            MessageBox.Show(e.Message, "Error with SQL Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Displays Image, Name, Description and Price associated with item when clicked on in DataGridView
        public static void DisplaySelection(DataGridView dgvStore, Label lblItemName, Label lblDescription, Label lblPrice, PictureBox pbxItemImage)
        {
            decimal decRetailPrice = 0;
            DateTime time = DateTime.Now;
            try
            {
                foreach (DataGridViewRow row in dgvStore.SelectedRows)
                {
                    try
                    {
                        decimal.TryParse(row.Cells[3].Value.ToString(), out decRetailPrice);
                        if (row.Cells[4].Value != System.DBNull.Value)
                        {
                            MemoryStream ms = new MemoryStream((byte[])row.Cells[5].Value);
                            byte[] bytImg = (byte[])row.Cells[5].Value;
                            pbxItemImage.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    lblItemName.Text = row.Cells[1].Value.ToString(); //NAME
                    lblDescription.Text = row.Cells[2].Value.ToString(); //Item Description
                    lblPrice.Text = decRetailPrice.ToString("C"); //Price
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error with Display Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Add Items to Cart Function
        public static int AddToCart(DataGridView dgvStore, DataGridView dgvCart, DataTable dt)
        {
            //Finds the selected row in the DataGridStoreView & clones/adds the row to the DataGridCartView
            int intRows = 0;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            try
            {
                foreach (DataGridViewRow dgvr in dgvStore.SelectedRows)
                {
                    DataGridViewRow r = dgvr.Clone() as DataGridViewRow;
                    foreach (DataGridViewCell cell in dgvr.Cells)
                    {
                        r.Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                    if (dgvCart.DataSource == null)
                    {
                        dgvCart.Rows.Add(r);
                        int intRows2 = dgvCart.RowCount;
                        dgvCart.Rows[intRows2 - 1].Cells[8].Value = "No";
                        dgvCart.Rows[intRows2 - 1].Cells[9].Value = "0";
                    }
                    else
                    {
                        dt.Rows.Add(r);
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return intRows = dgvCart.RowCount;
        }

        //Remove Items From Cart Function
        public static void RemoveFromCart(DataGridView dgvStore, DataGridView dgvCart)
        {
            try
            {
                //Removes the select row from cart
                foreach (DataGridViewRow dgvr in dgvCart.SelectedRows)
                {
                    DataGridViewRow r = dgvr.Clone() as DataGridViewRow;
                    foreach (DataGridViewCell cell in dgvr.Cells)
                    {
                        r.Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                    dgvCart.Rows.Remove(dgvr);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ClearCart(DataGridView dgvCart, Label[] arrLabels)
        {
            //Clear cart if they hit yes
            DialogResult result = MessageBox.Show("Are you sure you want to clear your cart?", "Clear Cart",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                try
                {
                    //Removes all rows from cart & resets labels
                    dgvCart.Rows.Clear();
                    arrLabels[0].Text = "SubTotal: $0.00";
                    arrLabels[1].Text = "Discount Percentage: 0%";
                    arrLabels[2].Text = "Amount Discounted: $0.00";
                    arrLabels[3].Text = "Discounted SubTotal: $0.00";
                    arrLabels[4].Text = "Tax: $0.00";
                    arrLabels[5].Text = "Total: $0.00";
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "DataGridView Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        public static void AddDiscountedItem(DataGridView dgvStore, DataGridView dgvCart, int intItemID2, int intDiscountID, decimal decDiscountAmount)
        {
            int intItemID = 0;
            int intRows = 0;
            decimal decItemCost = 0;
            decimal decRemovedAmount = 0;
            //Find the ID of the item, clone the row and add it to the dgvCart
            try
            {
                foreach (DataGridViewRow row in dgvStore.Rows)
                {
                    int.TryParse(row.Cells[0].Value.ToString(), out intItemID);

                    if(intItemID2 == intItemID)
                    {
                            DataGridViewRow r = row.Clone() as DataGridViewRow;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                r.Cells[cell.ColumnIndex].Value = cell.Value;
                            }
                            dgvCart.Rows.Add(r);
                            intRows = dgvCart.RowCount;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error with finding a discounted item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

            try
            {
                //Display quantity for item, set DiscountApplied to Yes, calculate the amount of the item and display it 
                dgvCart.Rows[intRows - 1].Cells[6].Value = "x" + 1;
                dgvCart.Rows[intRows - 1].Cells[8].Value = "Yes";
                dgvCart.Rows[intRows - 1].Cells[9].Value = intDiscountID.ToString();

                decimal.TryParse(dgvCart.Rows[intRows - 1].Cells[3].Value.ToString(), out decItemCost);

                decRemovedAmount = decItemCost * decDiscountAmount;
                decItemCost = decItemCost - decRemovedAmount;

                decimal[] arrDiscountAmounts = new decimal[] {
                            decDiscountAmount, decRemovedAmount
                        };
                //Save discount information
                DiscountInfo = arrDiscountAmounts;

                dgvCart.Rows[intRows - 1].Cells[7].Value = decItemCost.ToString("C");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static int GetSelectedRowQuantity(DataGridView dgvStore)
        {
            //Finds the selected quantity inside the datagridview store, parses it then returns it
                int intQuantity = 0;
                try
                {
                    foreach (DataGridViewRow row in dgvStore.SelectedRows)
                    {
                        int.TryParse(row.Cells[4].Value.ToString(), out intQuantity);
                    }
                }
                catch (FormatException e)
                {
                    MessageBox.Show(e.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return intQuantity;
                }

        public static int GetCartItemQuantity(DataGridView dgvCart, TextBox tbxQuantity)
        {
            string strQuantity = "";
            int intQuantity = 0;
            //Find cart item quantity and store it, replace the x & parse the quantity
            try
            {
                foreach (DataGridViewRow row in dgvCart.SelectedRows)
                {
                    strQuantity = row.Cells[6].Value.ToString();

                    strQuantity = strQuantity.Replace("x", "");

                    int.TryParse(strQuantity, out intQuantity);

                }
            }catch(Exception e)
            {
                clsManager.ErrorMessageBox(e, "Error getting item quantity", "", true);
            }
            tbxQuantity.Text = strQuantity;
            return intQuantity;
        }

        public static void CalculateCostByQuantity(DataGridView dgvStore, DataGridView dgvCart, int intRows, int intQuantity)
        {
            /*Displays the quantity selected for the cart quantity if an acceptable quantity, then gets the selected item cost from the 
             DataGridView Store, multiplies the cost times quantity, adds it as a cell to the cart and displays it*/
            decimal decItemCost = 0;
            decimal decTotalItemCost = 0;
            try
            {
                dgvCart.Rows[intRows - 1].Cells[6].Value = "x" + intQuantity;
                foreach (DataGridViewRow row in dgvStore.SelectedRows)
                {
                    try
                    {

                        decimal.TryParse(row.Cells[3].Value.ToString(), out decItemCost);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                decTotalItemCost = decItemCost * intQuantity;

                dgvCart.Rows[intRows - 1].Cells[7].Value = decTotalItemCost.ToString("C");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Function to check if an item has already been added to the cart then allow edit if user wishes to increase quantity
        public static bool CheckIfItemAdded(DataGridView dgvStore, DataGridView dgvCart, Label lblItemError)
        {
            int intSelectedID = 0;
            int intID = 0;

            //Store selected Item ID
            try
            {
                foreach (DataGridViewRow row in dgvStore.SelectedRows)
                {

                    int.TryParse(row.Cells[0].Value.ToString(), out intSelectedID);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Compare to cart IDs to find if the item already exists in cart, if found return true, if not then return false
            try
            {
                foreach (DataGridViewRow row in dgvCart.Rows)
                {

                    int.TryParse(row.Cells[0].Value.ToString(), out intID);
                    if (intID == intSelectedID)
                    {
                        lblItemError.Visible = true;
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error checking if item is added", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        public static decimal[] DiscountInfo { get; set; }
        public static bool CheckIfDiscountedItemAdded(DataGridView dgvCart, int intDiscountID, decimal decDiscountAmount)
        {
            //Check if the ItemID already exists in the current cart, if it does then make adjustments to the cost of the item
            int intItemID = 0;
            bool bolIsAdded = false;
            try
            {
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    int.TryParse(row.Cells[0].Value.ToString(), out intItemID);

                    if (intDiscountID == intItemID)
                    {
                        bolIsAdded = true;
                        decimal decItemCost, decTotalItemsCost = 0;
                        decimal.TryParse(row.Cells[3].Value.ToString(), out decItemCost);
                        string strTotalItemsCost = row.Cells[7].Value.ToString();

                        decimal decRemovedAmount = decItemCost * decDiscountAmount;
                        strTotalItemsCost = strTotalItemsCost.Replace("$", "");
                        decimal.TryParse(strTotalItemsCost, out decTotalItemsCost);


                        decTotalItemsCost = decTotalItemsCost - decRemovedAmount;

                        row.Cells[7].Value = decTotalItemsCost.ToString("C");

                        row.Cells[8].Value = "Yes";

                        decimal[] arrDiscountAmounts = new decimal[] {
                            decDiscountAmount, decRemovedAmount
                        };

                        DiscountInfo = arrDiscountAmounts;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bolIsAdded;
        }
        public static decimal CalculateAndUpdateBillingSummary(DataGridView dgvCart, Label[] arrLabels, bool bolIsApplied)
        {
            /*Create variables for calculations, find each item(s) cost by storing them in a String, removing the $,
             then parsing the string to a decimal after add the decimal to the SubTotal per each row
            Run calculations for SalesTaxAmount & Total for the order then display to labels*/
            decimal decItemsCost = 0;
            decimal decSubTotal = 0;
            decimal decSalesTaxAmount = 0;
            decimal decTotal = 0;
            string strItemCost = "";
            decimal decSalesTax = 8.25M;
            decimal decDiscountedSubTotal = 0;

            if(dgvCart.Rows.Count == 0)
            {
                arrLabels[0].Text = "SubTotal: " + "$0";
            }
            try
            {
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells[8].Value.ToString() == "No")
                    {
                        //Get Item(s) Cost
                        strItemCost = row.Cells[7].Value.ToString();
                        strItemCost = strItemCost.Replace("$", "");
                        decimal.TryParse(strItemCost, out decItemsCost);
                        //Add to Subtotal
                        decSubTotal += decItemsCost;
                        decDiscountedSubTotal += decItemsCost;
                        //Display Subtotal
                        arrLabels[0].Text = "SubTotal: " + decSubTotal.ToString("C");
                    }
                    else if (row.Cells[8].Value.ToString() == "Yes")
                    {
                        //Item Amount(s) Ordered
                        string strQuantity = row.Cells[6].Value.ToString();
                        strQuantity = strQuantity.Replace("x", "");
                        int intQuantity = 0;
                        int.TryParse(strQuantity, out intQuantity);
                        //Get original cost of item without discount
                        decimal decActualItemCost = 0;
                        decimal.TryParse(row.Cells[3].Value.ToString(), out decActualItemCost);

                        //Combine the original cost of items without the discount applied
                        decimal decCombinedItemCosts = intQuantity * decActualItemCost;

                        //Add to original subtotal then display
                        decSubTotal += decCombinedItemCosts;

                        //Get combined items cost with discount applied
                        strItemCost = row.Cells[7].Value.ToString();
                        strItemCost = strItemCost.Replace("$", "");
                        decimal.TryParse(strItemCost, out decItemsCost);
                        //Add to Discounts Subtotal
                        decDiscountedSubTotal += decItemsCost;
                    }
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException a)
            {
                MessageBox.Show(a.Message, "Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (bolIsApplied)
                {
                    //If discount is applied, get the discount percentage, amount removed & discounted subtotal then display
                    decimal[] arrDiscountAmounts = new decimal[] { };
                    arrDiscountAmounts = DiscountInfo;

                    arrLabels[1].Text = "Discount Percentage: " + arrDiscountAmounts[0].ToString("P0");
                    arrLabels[2].Text = "Amount Discounted: " + arrDiscountAmounts[1].ToString("C");
                    arrLabels[3].Text = "Discounted SubTotal: " + decDiscountedSubTotal.ToString("C");
                }
                else
                {
                    arrLabels[1].Text = "Discount Percentage: " + "0%";
                    arrLabels[2].Text = "Amount Discounted: " + "$0.00";
                    arrLabels[3].Text = "Discounted SubTotal: " + "$0.00";
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error loading Discount Amounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                if (bolIsApplied)
                {
                    //Apply Sales Tax Calculations and find out how much the tax would cost
                    decSalesTaxAmount = decSalesTax / 100;
                    decSalesTaxAmount *= decDiscountedSubTotal;
                    //Add the sales Tax Amount & round by two decimals
                    decTotal = decSalesTaxAmount + decDiscountedSubTotal;
                    decTotal = Decimal.Round(decTotal, 2);
                }
                else
                {
                    //Apply Sales Tax Calculations and find out how much the tax would cost
                    decSalesTaxAmount = decSalesTax / 100;
                    decSalesTaxAmount *= decSubTotal;
                    //Add the sales Tax Amount & round by two decimals
                    decTotal = decSalesTaxAmount + decSubTotal;
                    decTotal = Decimal.Round(decTotal, 2);
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Argument Out of Range Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //Display Sales Tax Amount and Cost
            try
            {
                arrLabels[0].Text = "SubTotal: " + decSubTotal.ToString("C");
                arrLabels[4].Text = "Tax: " + decSalesTaxAmount.ToString("C");
                arrLabels[5].Text = "Total: " + decTotal.ToString("C");
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return decSubTotal;
        }
        public static void SaveCurrentCart(DataGridView dgvSavedCart, DataGridView dgvNewCart)
        {
            //Create Columns for clone of cart
            dgvNewCart.ColumnCount = 10;
            dgvNewCart.Columns[0].Name = "InventoryID";
            dgvNewCart.Columns[1].Name = "Items";
            dgvNewCart.Columns[2].Name = "ItemDescription";
            dgvNewCart.Columns[3].Name = "Retail Price";
            dgvNewCart.Columns[4].Name = "Available Quantity";
            dgvNewCart.Columns[5].Name = "ItemImage";
            dgvNewCart.Columns[6].Name = "Quantity";
            dgvNewCart.Columns[7].Name = "Item Cost";
            dgvNewCart.Columns[8].Name = "Discount Applied";
            dgvNewCart.Columns[9].Name = "DiscountID";

            //Set unneeded columns invisible in cart
            dgvNewCart.Columns["InventoryID"].Visible = false;
            dgvNewCart.Columns["ItemImage"].Visible = false;
            dgvNewCart.Columns["ItemDescription"].Visible = false;
            dgvNewCart.Columns["Available Quantity"].Visible = false;
            dgvNewCart.Columns["Discount Applied"].Visible = false;
            dgvNewCart.Columns["DiscountID"].Visible = false;

            try
            {
                foreach (DataGridViewRow dgvr in dgvSavedCart.Rows)
                {
                    DataGridViewRow r = dgvr.Clone() as DataGridViewRow;
                    foreach (DataGridViewCell cell in dgvr.Cells)
                    {
                        r.Cells[cell.ColumnIndex].Value = cell.Value;
                    }
                    dgvNewCart.Rows.Add(r);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DataGridView Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ApplyDiscount(TextBox tbxDiscount, Label lblDiscountError, DataGridView dgvStore, DataGridView dgvCart)
        {
            //Create Discount Object
            clsSQL.Discount newDiscount = clsSQL.FindDiscount(tbxDiscount, lblDiscountError);

            //If the discount object does have rows, store discount information
            if (newDiscount.bolHasRows) { 
            int intItemID = newDiscount.intItemID;
            int intDiscountID = newDiscount.intDiscountID;
            decimal decDiscountAmount = newDiscount.decDiscountAmount;

                //If the discount is for a certain item, check if the item is added in the cart then adjust the new total item cost
                if (!clsShoppingCart.CheckIfDiscountedItemAdded(dgvCart, intItemID, decDiscountAmount))
                {
                    DialogResult result = MessageBox.Show("Discounted Item not added to cart. Would you like to add it?", "Missing Discounted Item",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        clsShoppingCart.AddDiscountedItem(dgvStore, dgvCart, intItemID, intDiscountID, decDiscountAmount);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
