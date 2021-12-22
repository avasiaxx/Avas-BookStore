
namespace SU21_Final_Project
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnHelp = new System.Windows.Forms.Button();
            this.dgvStore = new System.Windows.Forms.DataGridView();
            this.pbxItemImage = new System.Windows.Forms.PictureBox();
            this.grpSelectedItem = new System.Windows.Forms.GroupBox();
            this.lblBookPrice = new System.Windows.Forms.Label();
            this.lblBookDescription = new System.Windows.Forms.Label();
            this.lblBookName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnFinish = new System.Windows.Forms.Button();
            this.tbxDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.grpFinish = new System.Windows.Forms.GroupBox();
            this.lblDiscountedSubtotal = new System.Windows.Forms.Label();
            this.lblActualDiscountAmount = new System.Windows.Forms.Label();
            this.lblDiscountError = new System.Windows.Forms.Label();
            this.lblDiscountPercentage = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.pbxDecrease = new System.Windows.Forms.PictureBox();
            this.pbxIncrease = new System.Windows.Forms.PictureBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.pbxIncrease2 = new System.Windows.Forms.PictureBox();
            this.pbxDecrease2 = new System.Windows.Forms.PictureBox();
            this.tbxQuantity2 = new System.Windows.Forms.TextBox();
            this.btnDiscounts = new System.Windows.Forms.Button();
            this.lblItemError = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tipDoubleClickInfo = new System.Windows.Forms.ToolTip(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.tbxSearchItemName = new System.Windows.Forms.TextBox();
            this.lblSearchItemName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxItemImage)).BeginInit();
            this.grpSelectedItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.grpFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDecrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIncrease2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDecrease2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.Red;
            this.btnHelp.Location = new System.Drawing.Point(1256, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(59, 30);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dgvStore
            // 
            this.dgvStore.AllowUserToAddRows = false;
            this.dgvStore.AllowUserToDeleteRows = false;
            this.dgvStore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStore.Location = new System.Drawing.Point(81, 56);
            this.dgvStore.MultiSelect = false;
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.ReadOnly = true;
            this.dgvStore.RowHeadersWidth = 30;
            this.dgvStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStore.Size = new System.Drawing.Size(804, 311);
            this.dgvStore.TabIndex = 1;
            this.dgvStore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStore_CellClick);
            this.dgvStore.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStore_CellDoubleClick);
            // 
            // pbxItemImage
            // 
            this.pbxItemImage.Location = new System.Drawing.Point(109, 80);
            this.pbxItemImage.Name = "pbxItemImage";
            this.pbxItemImage.Size = new System.Drawing.Size(166, 168);
            this.pbxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxItemImage.TabIndex = 12;
            this.pbxItemImage.TabStop = false;
            // 
            // grpSelectedItem
            // 
            this.grpSelectedItem.BackColor = System.Drawing.Color.Silver;
            this.grpSelectedItem.Controls.Add(this.lblBookPrice);
            this.grpSelectedItem.Controls.Add(this.lblBookDescription);
            this.grpSelectedItem.Controls.Add(this.lblBookName);
            this.grpSelectedItem.Controls.Add(this.lblPrice);
            this.grpSelectedItem.Controls.Add(this.lblItemDescription);
            this.grpSelectedItem.Controls.Add(this.lblItemName);
            this.grpSelectedItem.Controls.Add(this.pbxItemImage);
            this.grpSelectedItem.Location = new System.Drawing.Point(930, 56);
            this.grpSelectedItem.Name = "grpSelectedItem";
            this.grpSelectedItem.Size = new System.Drawing.Size(385, 363);
            this.grpSelectedItem.TabIndex = 13;
            this.grpSelectedItem.TabStop = false;
            // 
            // lblBookPrice
            // 
            this.lblBookPrice.AutoSize = true;
            this.lblBookPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookPrice.Location = new System.Drawing.Point(165, 329);
            this.lblBookPrice.Name = "lblBookPrice";
            this.lblBookPrice.Size = new System.Drawing.Size(0, 16);
            this.lblBookPrice.TabIndex = 18;
            this.lblBookPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBookDescription
            // 
            this.lblBookDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookDescription.Location = new System.Drawing.Point(6, 267);
            this.lblBookDescription.Name = "lblBookDescription";
            this.lblBookDescription.Size = new System.Drawing.Size(373, 34);
            this.lblBookDescription.TabIndex = 17;
            this.lblBookDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBookName
            // 
            this.lblBookName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookName.Location = new System.Drawing.Point(66, 42);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(252, 35);
            this.lblBookName.TabIndex = 16;
            this.lblBookName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(166, 312);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(45, 16);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "Price:";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDescription.Location = new System.Drawing.Point(150, 251);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(85, 19);
            this.lblItemDescription.TabIndex = 14;
            this.lblItemDescription.Text = "Description:";
            this.lblItemDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(135, 25);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(115, 17);
            this.lblItemName.TabIndex = 13;
            this.lblItemName.Text = "Book Name:";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(81, 373);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add To Cart";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(552, 374);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(161, 33);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove From Cart";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(81, 474);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(804, 305);
            this.dgvCart.TabIndex = 9;
            this.dgvCart.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentDoubleClick);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(109, 242);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(161, 33);
            this.btnFinish.TabIndex = 13;
            this.btnFinish.Text = "Finish Order";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // tbxDiscount
            // 
            this.tbxDiscount.Location = new System.Drawing.Point(208, 203);
            this.tbxDiscount.Name = "tbxDiscount";
            this.tbxDiscount.Size = new System.Drawing.Size(105, 29);
            this.tbxDiscount.TabIndex = 11;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(43, 205);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(159, 18);
            this.lblDiscount.TabIndex = 20;
            this.lblDiscount.Text = "Apply Discount Code:";
            // 
            // grpFinish
            // 
            this.grpFinish.BackColor = System.Drawing.Color.Silver;
            this.grpFinish.Controls.Add(this.lblDiscountedSubtotal);
            this.grpFinish.Controls.Add(this.lblActualDiscountAmount);
            this.grpFinish.Controls.Add(this.lblDiscountError);
            this.grpFinish.Controls.Add(this.lblDiscountPercentage);
            this.grpFinish.Controls.Add(this.btnApply);
            this.grpFinish.Controls.Add(this.lblTotal);
            this.grpFinish.Controls.Add(this.lblTax);
            this.grpFinish.Controls.Add(this.lblSubTotal);
            this.grpFinish.Controls.Add(this.tbxDiscount);
            this.grpFinish.Controls.Add(this.lblDiscount);
            this.grpFinish.Controls.Add(this.btnFinish);
            this.grpFinish.Location = new System.Drawing.Point(930, 445);
            this.grpFinish.Name = "grpFinish";
            this.grpFinish.Size = new System.Drawing.Size(387, 288);
            this.grpFinish.TabIndex = 10;
            this.grpFinish.TabStop = false;
            // 
            // lblDiscountedSubtotal
            // 
            this.lblDiscountedSubtotal.AutoSize = true;
            this.lblDiscountedSubtotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountedSubtotal.Location = new System.Drawing.Point(23, 103);
            this.lblDiscountedSubtotal.Name = "lblDiscountedSubtotal";
            this.lblDiscountedSubtotal.Size = new System.Drawing.Size(155, 18);
            this.lblDiscountedSubtotal.TabIndex = 28;
            this.lblDiscountedSubtotal.Text = "Discounted SubTotal:";
            // 
            // lblActualDiscountAmount
            // 
            this.lblActualDiscountAmount.AutoSize = true;
            this.lblActualDiscountAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualDiscountAmount.Location = new System.Drawing.Point(30, 77);
            this.lblActualDiscountAmount.Name = "lblActualDiscountAmount";
            this.lblActualDiscountAmount.Size = new System.Drawing.Size(148, 18);
            this.lblActualDiscountAmount.TabIndex = 27;
            this.lblActualDiscountAmount.Text = "Amount Discounted:";
            // 
            // lblDiscountError
            // 
            this.lblDiscountError.AutoSize = true;
            this.lblDiscountError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountError.ForeColor = System.Drawing.Color.Red;
            this.lblDiscountError.Location = new System.Drawing.Point(130, 184);
            this.lblDiscountError.Name = "lblDiscountError";
            this.lblDiscountError.Size = new System.Drawing.Size(128, 16);
            this.lblDiscountError.TabIndex = 26;
            this.lblDiscountError.Text = "*Discount Not Found";
            this.lblDiscountError.Visible = false;
            // 
            // lblDiscountPercentage
            // 
            this.lblDiscountPercentage.AutoSize = true;
            this.lblDiscountPercentage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountPercentage.Location = new System.Drawing.Point(20, 51);
            this.lblDiscountPercentage.Name = "lblDiscountPercentage";
            this.lblDiscountPercentage.Size = new System.Drawing.Size(158, 18);
            this.lblDiscountPercentage.TabIndex = 25;
            this.lblDiscountPercentage.Text = "Discount Percentage:";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(318, 202);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(49, 30);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(134, 155);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 18);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "Total:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(143, 129);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(35, 18);
            this.lblTax.TabIndex = 22;
            this.lblTax.Text = "Tax:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(106, 25);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(72, 18);
            this.lblSubTotal.TabIndex = 21;
            this.lblSubTotal.Text = "SubTotal:";
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Location = new System.Drawing.Point(77, 446);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(45, 22);
            this.lblCart.TabIndex = 22;
            this.lblCart.Text = "Cart";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(77, 31);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(56, 22);
            this.lblStore.TabIndex = 23;
            this.lblStore.Text = "Store";
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.Location = new System.Drawing.Point(392, 375);
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.ShortcutsEnabled = false;
            this.tbxQuantity.Size = new System.Drawing.Size(36, 29);
            this.tbxQuantity.TabIndex = 3;
            this.tbxQuantity.Text = "1";
            this.tbxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxQuantity_KeyPress);
            // 
            // pbxDecrease
            // 
            this.pbxDecrease.Image = ((System.Drawing.Image)(resources.GetObject("pbxDecrease.Image")));
            this.pbxDecrease.Location = new System.Drawing.Point(357, 374);
            this.pbxDecrease.Name = "pbxDecrease";
            this.pbxDecrease.Size = new System.Drawing.Size(29, 32);
            this.pbxDecrease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxDecrease.TabIndex = 25;
            this.pbxDecrease.TabStop = false;
            this.pbxDecrease.Click += new System.EventHandler(this.pbxDecrease_Click);
            // 
            // pbxIncrease
            // 
            this.pbxIncrease.Image = ((System.Drawing.Image)(resources.GetObject("pbxIncrease.Image")));
            this.pbxIncrease.Location = new System.Drawing.Point(434, 374);
            this.pbxIncrease.Name = "pbxIncrease";
            this.pbxIncrease.Size = new System.Drawing.Size(29, 32);
            this.pbxIncrease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxIncrease.TabIndex = 26;
            this.pbxIncrease.TabStop = false;
            this.pbxIncrease.Click += new System.EventHandler(this.pbxIncrease_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(378, 409);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(57, 16);
            this.lblQuantity.TabIndex = 27;
            this.lblQuantity.Text = "Quantity";
            // 
            // btnEditItem
            // 
            this.btnEditItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditItem.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.Location = new System.Drawing.Point(552, 435);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(161, 33);
            this.btnEditItem.TabIndex = 7;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = false;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // pbxIncrease2
            // 
            this.pbxIncrease2.Image = ((System.Drawing.Image)(resources.GetObject("pbxIncrease2.Image")));
            this.pbxIncrease2.Location = new System.Drawing.Point(434, 429);
            this.pbxIncrease2.Name = "pbxIncrease2";
            this.pbxIncrease2.Size = new System.Drawing.Size(29, 32);
            this.pbxIncrease2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxIncrease2.TabIndex = 52;
            this.pbxIncrease2.TabStop = false;
            this.pbxIncrease2.Visible = false;
            this.pbxIncrease2.Click += new System.EventHandler(this.pbxIncrease2_Click);
            // 
            // pbxDecrease2
            // 
            this.pbxDecrease2.Image = ((System.Drawing.Image)(resources.GetObject("pbxDecrease2.Image")));
            this.pbxDecrease2.Location = new System.Drawing.Point(357, 429);
            this.pbxDecrease2.Name = "pbxDecrease2";
            this.pbxDecrease2.Size = new System.Drawing.Size(29, 32);
            this.pbxDecrease2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxDecrease2.TabIndex = 51;
            this.pbxDecrease2.TabStop = false;
            this.pbxDecrease2.Visible = false;
            this.pbxDecrease2.Click += new System.EventHandler(this.pbxDecrease2_Click);
            // 
            // tbxQuantity2
            // 
            this.tbxQuantity2.Location = new System.Drawing.Point(392, 432);
            this.tbxQuantity2.Name = "tbxQuantity2";
            this.tbxQuantity2.ShortcutsEnabled = false;
            this.tbxQuantity2.Size = new System.Drawing.Size(36, 29);
            this.tbxQuantity2.TabIndex = 6;
            this.tbxQuantity2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxQuantity2.Visible = false;
            this.tbxQuantity2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxQuantity2_KeyPress);
            // 
            // btnDiscounts
            // 
            this.btnDiscounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnDiscounts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDiscounts.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscounts.Location = new System.Drawing.Point(1039, 739);
            this.btnDiscounts.Name = "btnDiscounts";
            this.btnDiscounts.Size = new System.Drawing.Size(161, 33);
            this.btnDiscounts.TabIndex = 14;
            this.btnDiscounts.Text = "Available Discounts";
            this.btnDiscounts.UseVisualStyleBackColor = false;
            this.btnDiscounts.Click += new System.EventHandler(this.btnDiscounts_Click);
            // 
            // lblItemError
            // 
            this.lblItemError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemError.ForeColor = System.Drawing.Color.Red;
            this.lblItemError.Location = new System.Drawing.Point(157, 35);
            this.lblItemError.Name = "lblItemError";
            this.lblItemError.Size = new System.Drawing.Size(412, 18);
            this.lblItemError.TabIndex = 53;
            this.lblItemError.Text = "*Item Already Added. Please click Edit Item to adjust quantity in cart.";
            this.lblItemError.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(779, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(779, 374);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 33);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear Cart";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbxSearchItemName
            // 
            this.tbxSearchItemName.Location = new System.Drawing.Point(624, 13);
            this.tbxSearchItemName.MaxLength = 100;
            this.tbxSearchItemName.Name = "tbxSearchItemName";
            this.tbxSearchItemName.Size = new System.Drawing.Size(261, 29);
            this.tbxSearchItemName.TabIndex = 0;
            this.tbxSearchItemName.TextChanged += new System.EventHandler(this.tbxSearchItemName_TextChanged);
            // 
            // lblSearchItemName
            // 
            this.lblSearchItemName.AutoSize = true;
            this.lblSearchItemName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchItemName.Location = new System.Drawing.Point(420, 9);
            this.lblSearchItemName.Name = "lblSearchItemName";
            this.lblSearchItemName.Size = new System.Drawing.Size(198, 22);
            this.lblSearchItemName.TabIndex = 32;
            this.lblSearchItemName.Text = "Search by Item Name:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 44);
            this.btnBack.TabIndex = 61;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnFinish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(206)))), ((int)(((byte)(208)))));
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(1327, 784);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tbxSearchItemName);
            this.Controls.Add(this.lblSearchItemName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblItemError);
            this.Controls.Add(this.btnDiscounts);
            this.Controls.Add(this.pbxIncrease2);
            this.Controls.Add(this.pbxDecrease2);
            this.Controls.Add(this.tbxQuantity2);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.pbxIncrease);
            this.Controls.Add(this.pbxDecrease);
            this.Controls.Add(this.tbxQuantity);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.grpFinish);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grpSelectedItem);
            this.Controls.Add(this.dgvStore);
            this.Controls.Add(this.btnHelp);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "2021.08.23";
            this.Text = "Ava\'s Bookstore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxItemImage)).EndInit();
            this.grpSelectedItem.ResumeLayout(false);
            this.grpSelectedItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.grpFinish.ResumeLayout(false);
            this.grpFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDecrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIncrease2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDecrease2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.DataGridView dgvStore;
        private System.Windows.Forms.PictureBox pbxItemImage;
        private System.Windows.Forms.GroupBox grpSelectedItem;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TextBox tbxDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.GroupBox grpFinish;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.PictureBox pbxDecrease;
        private System.Windows.Forms.PictureBox pbxIncrease;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblBookPrice;
        private System.Windows.Forms.Label lblBookDescription;
        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.PictureBox pbxIncrease2;
        private System.Windows.Forms.PictureBox pbxDecrease2;
        private System.Windows.Forms.TextBox tbxQuantity2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDiscounts;
        private System.Windows.Forms.Label lblItemError;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDiscountPercentage;
        private System.Windows.Forms.Label lblDiscountError;
        private System.Windows.Forms.Label lblActualDiscountAmount;
        private System.Windows.Forms.Label lblDiscountedSubtotal;
        public System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.ToolTip tipDoubleClickInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbxSearchItemName;
        private System.Windows.Forms.Label lblSearchItemName;
        private System.Windows.Forms.Button btnBack;
    }
}

