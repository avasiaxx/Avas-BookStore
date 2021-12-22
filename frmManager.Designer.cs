
namespace FA21_Final_Project
{
    partial class frmManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.tabView = new System.Windows.Forms.TabControl();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.grpSearchItem = new System.Windows.Forms.GroupBox();
            this.tbxSearchGenre = new System.Windows.Forms.TextBox();
            this.lblSearchGenre = new System.Windows.Forms.Label();
            this.tbxSearchInventoryID = new System.Windows.Forms.TextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.tbxSearchItemName = new System.Windows.Forms.TextBox();
            this.lblSearchItemName = new System.Windows.Forms.Label();
            this.btnPrintInventory = new System.Windows.Forms.Button();
            this.btnCancelItemEdit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.grpEditItem = new System.Windows.Forms.GroupBox();
            this.tbxEditItemQuantity = new System.Windows.Forms.TextBox();
            this.tbxEditItemCost = new System.Windows.Forms.TextBox();
            this.tbxEditRetailPrice = new System.Windows.Forms.TextBox();
            this.grpDiscontinuedItemEdit = new System.Windows.Forms.GroupBox();
            this.lblEditDisc = new System.Windows.Forms.Label();
            this.cbxEditDisc = new System.Windows.Forms.CheckBox();
            this.lblEditGenre = new System.Windows.Forms.Label();
            this.tbxEditGenre = new System.Windows.Forms.TextBox();
            this.btnEditImage = new System.Windows.Forms.Button();
            this.pbxEditItemImage = new System.Windows.Forms.PictureBox();
            this.lblItemQuantityEdit = new System.Windows.Forms.Label();
            this.tbxEditItemName = new System.Windows.Forms.TextBox();
            this.lblItemCostEdit = new System.Windows.Forms.Label();
            this.tbxEditItemDesc = new System.Windows.Forms.TextBox();
            this.lblRetailPriceEdit = new System.Windows.Forms.Label();
            this.lblItemDescripEdit = new System.Windows.Forms.Label();
            this.lblItemNameEdit = new System.Windows.Forms.Label();
            this.grpAddItem = new System.Windows.Forms.GroupBox();
            this.tbxAddItemQuantity = new System.Windows.Forms.TextBox();
            this.grpAddDisc = new System.Windows.Forms.GroupBox();
            this.lblAddItemDiscon = new System.Windows.Forms.Label();
            this.cbxAddDiscontinued = new System.Windows.Forms.CheckBox();
            this.tbxAddItemCost = new System.Windows.Forms.TextBox();
            this.lblItemGenre = new System.Windows.Forms.Label();
            this.tbxAddItemPrice = new System.Windows.Forms.TextBox();
            this.tbxAddItemGenre = new System.Windows.Forms.TextBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.pbxAddItemImage = new System.Windows.Forms.PictureBox();
            this.lblItemQuantity = new System.Windows.Forms.Label();
            this.lblItemCost = new System.Windows.Forms.Label();
            this.lblItemRetailPrice = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.tbxAddItemDesc = new System.Windows.Forms.TextBox();
            this.tbxAddItemName = new System.Windows.Forms.TextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.grpSearchCustomer = new System.Windows.Forms.GroupBox();
            this.tbxMemberID = new System.Windows.Forms.TextBox();
            this.lblMemberID = new System.Windows.Forms.Label();
            this.tbxSearchFirstName = new System.Windows.Forms.TextBox();
            this.lblCustFirstName = new System.Windows.Forms.Label();
            this.tbxSearchLastName = new System.Windows.Forms.TextBox();
            this.lblCustLastName = new System.Windows.Forms.Label();
            this.tbxCustomerSearchEmail = new System.Windows.Forms.TextBox();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.lblCustEmail = new System.Windows.Forms.Label();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.grpPreviousCustomersOrders = new System.Windows.Forms.GroupBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.grpAccDelDisable = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpDeleted = new System.Windows.Forms.GroupBox();
            this.chkCustDeleted = new System.Windows.Forms.CheckBox();
            this.grpEnableDisable = new System.Windows.Forms.GroupBox();
            this.chkCustEnabledDisabled = new System.Windows.Forms.CheckBox();
            this.tabManagers = new System.Windows.Forms.TabPage();
            this.grpManagerActivation = new System.Windows.Forms.GroupBox();
            this.grpManager = new System.Windows.Forms.GroupBox();
            this.chkIsManager = new System.Windows.Forms.CheckBox();
            this.grpActive = new System.Windows.Forms.GroupBox();
            this.chkManagerActive = new System.Windows.Forms.CheckBox();
            this.btnSaveManager = new System.Windows.Forms.Button();
            this.grpAccDeleted = new System.Windows.Forms.GroupBox();
            this.chkManagerDeleted = new System.Windows.Forms.CheckBox();
            this.grpAccountEnable = new System.Windows.Forms.GroupBox();
            this.chkManagerEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxSalary = new System.Windows.Forms.TextBox();
            this.btnApplyManagerSalary = new System.Windows.Forms.Button();
            this.lblManagerSalary = new System.Windows.Forms.Label();
            this.btnEditManager = new System.Windows.Forms.Button();
            this.btnDisplayInfo = new System.Windows.Forms.Button();
            this.btnAddNewManager = new System.Windows.Forms.Button();
            this.dgvManagers = new System.Windows.Forms.DataGridView();
            this.tabDiscounts = new System.Windows.Forms.TabPage();
            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
            this.btnCancelDiscountEdit = new System.Windows.Forms.Button();
            this.btnEditDiscount = new System.Windows.Forms.Button();
            this.btnCancelDiscountCreation = new System.Windows.Forms.Button();
            this.btnSaveDiscount = new System.Windows.Forms.Button();
            this.grpEditDiscount = new System.Windows.Forms.GroupBox();
            this.lblAvailableItemEdit = new System.Windows.Forms.Label();
            this.cbxAvailableItemEdit = new System.Windows.Forms.ComboBox();
            this.lblExpDateEdit = new System.Windows.Forms.Label();
            this.dtpExpDateEdit = new System.Windows.Forms.DateTimePicker();
            this.lblDiscPercEdit = new System.Windows.Forms.Label();
            this.cbxDiscAmountEdit = new System.Windows.Forms.ComboBox();
            this.lblDiscountDescEdit = new System.Windows.Forms.Label();
            this.tbxDiscountDescriptionEdit = new System.Windows.Forms.TextBox();
            this.grpCreateDiscount = new System.Windows.Forms.GroupBox();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDiscountPercentage = new System.Windows.Forms.Label();
            this.cbxDiscAmount = new System.Windows.Forms.ComboBox();
            this.lblDiscountDescription = new System.Windows.Forms.Label();
            this.tbxNewDiscountDescription = new System.Windows.Forms.TextBox();
            this.lblAvailableItems = new System.Windows.Forms.Label();
            this.cbxAvailableItems = new System.Windows.Forms.ComboBox();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.grpSalesReports = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.dtpReports = new System.Windows.Forms.DateTimePicker();
            this.btnDaily = new System.Windows.Forms.Button();
            this.btnMonthly = new System.Windows.Forms.Button();
            this.btnWeekly = new System.Windows.Forms.Button();
            this.dgvOrdersForReports = new System.Windows.Forms.DataGridView();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tabView.SuspendLayout();
            this.tabInventory.SuspendLayout();
            this.grpSearchItem.SuspendLayout();
            this.grpEditItem.SuspendLayout();
            this.grpDiscontinuedItemEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditItemImage)).BeginInit();
            this.grpAddItem.SuspendLayout();
            this.grpAddDisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.grpSearchCustomer.SuspendLayout();
            this.grpPreviousCustomersOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpAccDelDisable.SuspendLayout();
            this.grpDeleted.SuspendLayout();
            this.grpEnableDisable.SuspendLayout();
            this.tabManagers.SuspendLayout();
            this.grpManagerActivation.SuspendLayout();
            this.grpManager.SuspendLayout();
            this.grpActive.SuspendLayout();
            this.grpAccDeleted.SuspendLayout();
            this.grpAccountEnable.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).BeginInit();
            this.tabDiscounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
            this.grpEditDiscount.SuspendLayout();
            this.grpCreateDiscount.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.grpSalesReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersForReports)).BeginInit();
            this.SuspendLayout();
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.tabInventory);
            this.tabView.Controls.Add(this.tabCustomers);
            this.tabView.Controls.Add(this.tabManagers);
            this.tabView.Controls.Add(this.tabDiscounts);
            this.tabView.Controls.Add(this.tabReports);
            this.tabView.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.Location = new System.Drawing.Point(-2, 32);
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.tabView.Size = new System.Drawing.Size(971, 645);
            this.tabView.TabIndex = 0;
            // 
            // tabInventory
            // 
            this.tabInventory.BackColor = System.Drawing.Color.Silver;
            this.tabInventory.Controls.Add(this.grpSearchItem);
            this.tabInventory.Controls.Add(this.btnPrintInventory);
            this.tabInventory.Controls.Add(this.btnCancelItemEdit);
            this.tabInventory.Controls.Add(this.btnEdit);
            this.tabInventory.Controls.Add(this.btnCancel);
            this.tabInventory.Controls.Add(this.btnAddItem);
            this.tabInventory.Controls.Add(this.grpEditItem);
            this.tabInventory.Controls.Add(this.grpAddItem);
            this.tabInventory.Controls.Add(this.dgvInventory);
            this.tabInventory.Location = new System.Drawing.Point(4, 25);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventory.Size = new System.Drawing.Size(963, 616);
            this.tabInventory.TabIndex = 0;
            this.tabInventory.Text = "Inventory";
            // 
            // grpSearchItem
            // 
            this.grpSearchItem.Controls.Add(this.tbxSearchGenre);
            this.grpSearchItem.Controls.Add(this.lblSearchGenre);
            this.grpSearchItem.Controls.Add(this.tbxSearchInventoryID);
            this.grpSearchItem.Controls.Add(this.lblItemID);
            this.grpSearchItem.Controls.Add(this.tbxSearchItemName);
            this.grpSearchItem.Controls.Add(this.lblSearchItemName);
            this.grpSearchItem.Location = new System.Drawing.Point(10, 279);
            this.grpSearchItem.Name = "grpSearchItem";
            this.grpSearchItem.Size = new System.Drawing.Size(947, 60);
            this.grpSearchItem.TabIndex = 1;
            this.grpSearchItem.TabStop = false;
            this.grpSearchItem.Text = "Search Item By:";
            // 
            // tbxSearchGenre
            // 
            this.tbxSearchGenre.Location = new System.Drawing.Point(756, 21);
            this.tbxSearchGenre.MaxLength = 100;
            this.tbxSearchGenre.Name = "tbxSearchGenre";
            this.tbxSearchGenre.Size = new System.Drawing.Size(148, 22);
            this.tbxSearchGenre.TabIndex = 4;
            this.tbxSearchGenre.TextChanged += new System.EventHandler(this.tbxSearchGenre_TextChanged);
            // 
            // lblSearchGenre
            // 
            this.lblSearchGenre.AutoSize = true;
            this.lblSearchGenre.Location = new System.Drawing.Point(703, 24);
            this.lblSearchGenre.Name = "lblSearchGenre";
            this.lblSearchGenre.Size = new System.Drawing.Size(47, 16);
            this.lblSearchGenre.TabIndex = 36;
            this.lblSearchGenre.Text = "Genre:";
            // 
            // tbxSearchInventoryID
            // 
            this.tbxSearchInventoryID.Location = new System.Drawing.Point(454, 21);
            this.tbxSearchInventoryID.MaxLength = 100;
            this.tbxSearchInventoryID.Name = "tbxSearchInventoryID";
            this.tbxSearchInventoryID.Size = new System.Drawing.Size(148, 22);
            this.tbxSearchInventoryID.TabIndex = 3;
            this.tbxSearchInventoryID.TextChanged += new System.EventHandler(this.tbxSearchInventoryID_TextChanged);
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(371, 24);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(79, 16);
            this.lblItemID.TabIndex = 34;
            this.lblItemID.Text = "Inventory ID:";
            // 
            // tbxSearchItemName
            // 
            this.tbxSearchItemName.Location = new System.Drawing.Point(123, 21);
            this.tbxSearchItemName.MaxLength = 100;
            this.tbxSearchItemName.Name = "tbxSearchItemName";
            this.tbxSearchItemName.Size = new System.Drawing.Size(192, 22);
            this.tbxSearchItemName.TabIndex = 2;
            this.tbxSearchItemName.TextChanged += new System.EventHandler(this.tbxSearchItemName_TextChanged);
            // 
            // lblSearchItemName
            // 
            this.lblSearchItemName.AutoSize = true;
            this.lblSearchItemName.Location = new System.Drawing.Point(42, 24);
            this.lblSearchItemName.Name = "lblSearchItemName";
            this.lblSearchItemName.Size = new System.Drawing.Size(75, 16);
            this.lblSearchItemName.TabIndex = 32;
            this.lblSearchItemName.Text = "Item Name:";
            // 
            // btnPrintInventory
            // 
            this.btnPrintInventory.Location = new System.Drawing.Point(400, 345);
            this.btnPrintInventory.Name = "btnPrintInventory";
            this.btnPrintInventory.Size = new System.Drawing.Size(145, 23);
            this.btnPrintInventory.TabIndex = 17;
            this.btnPrintInventory.Text = "View Inventory Report";
            this.btnPrintInventory.UseVisualStyleBackColor = true;
            this.btnPrintInventory.Click += new System.EventHandler(this.btnPrintInventory_Click);
            // 
            // btnCancelItemEdit
            // 
            this.btnCancelItemEdit.Location = new System.Drawing.Point(739, 349);
            this.btnCancelItemEdit.Name = "btnCancelItemEdit";
            this.btnCancelItemEdit.Size = new System.Drawing.Size(75, 23);
            this.btnCancelItemEdit.TabIndex = 19;
            this.btnCancelItemEdit.Text = "Cancel";
            this.btnCancelItemEdit.UseVisualStyleBackColor = true;
            this.btnCancelItemEdit.Click += new System.EventHandler(this.btnCancelItemEdit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(658, 349);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit Item";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(138, 349);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 5;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // grpEditItem
            // 
            this.grpEditItem.Controls.Add(this.tbxEditItemQuantity);
            this.grpEditItem.Controls.Add(this.tbxEditItemCost);
            this.grpEditItem.Controls.Add(this.tbxEditRetailPrice);
            this.grpEditItem.Controls.Add(this.grpDiscontinuedItemEdit);
            this.grpEditItem.Controls.Add(this.lblEditGenre);
            this.grpEditItem.Controls.Add(this.tbxEditGenre);
            this.grpEditItem.Controls.Add(this.btnEditImage);
            this.grpEditItem.Controls.Add(this.pbxEditItemImage);
            this.grpEditItem.Controls.Add(this.lblItemQuantityEdit);
            this.grpEditItem.Controls.Add(this.tbxEditItemName);
            this.grpEditItem.Controls.Add(this.lblItemCostEdit);
            this.grpEditItem.Controls.Add(this.tbxEditItemDesc);
            this.grpEditItem.Controls.Add(this.lblRetailPriceEdit);
            this.grpEditItem.Controls.Add(this.lblItemDescripEdit);
            this.grpEditItem.Controls.Add(this.lblItemNameEdit);
            this.grpEditItem.Enabled = false;
            this.grpEditItem.Location = new System.Drawing.Point(491, 368);
            this.grpEditItem.Name = "grpEditItem";
            this.grpEditItem.Size = new System.Drawing.Size(470, 248);
            this.grpEditItem.TabIndex = 20;
            this.grpEditItem.TabStop = false;
            this.grpEditItem.Text = "Edit Item";
            // 
            // tbxEditItemQuantity
            // 
            this.tbxEditItemQuantity.Location = new System.Drawing.Point(111, 133);
            this.tbxEditItemQuantity.Name = "tbxEditItemQuantity";
            this.tbxEditItemQuantity.ShortcutsEnabled = false;
            this.tbxEditItemQuantity.Size = new System.Drawing.Size(192, 22);
            this.tbxEditItemQuantity.TabIndex = 25;
            this.tbxEditItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEditItemQuantity_KeyPress);
            // 
            // tbxEditItemCost
            // 
            this.tbxEditItemCost.Location = new System.Drawing.Point(111, 105);
            this.tbxEditItemCost.MaxLength = 12;
            this.tbxEditItemCost.Name = "tbxEditItemCost";
            this.tbxEditItemCost.ShortcutsEnabled = false;
            this.tbxEditItemCost.Size = new System.Drawing.Size(192, 22);
            this.tbxEditItemCost.TabIndex = 24;
            this.tbxEditItemCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEditItemCost_KeyPress);
            // 
            // tbxEditRetailPrice
            // 
            this.tbxEditRetailPrice.Location = new System.Drawing.Point(111, 77);
            this.tbxEditRetailPrice.MaxLength = 12;
            this.tbxEditRetailPrice.Name = "tbxEditRetailPrice";
            this.tbxEditRetailPrice.ShortcutsEnabled = false;
            this.tbxEditRetailPrice.Size = new System.Drawing.Size(192, 22);
            this.tbxEditRetailPrice.TabIndex = 23;
            this.tbxEditRetailPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxEditRetailPrice_KeyPress);
            // 
            // grpDiscontinuedItemEdit
            // 
            this.grpDiscontinuedItemEdit.Controls.Add(this.lblEditDisc);
            this.grpDiscontinuedItemEdit.Controls.Add(this.cbxEditDisc);
            this.grpDiscontinuedItemEdit.Location = new System.Drawing.Point(143, 189);
            this.grpDiscontinuedItemEdit.Name = "grpDiscontinuedItemEdit";
            this.grpDiscontinuedItemEdit.Size = new System.Drawing.Size(123, 45);
            this.grpDiscontinuedItemEdit.TabIndex = 27;
            this.grpDiscontinuedItemEdit.TabStop = false;
            // 
            // lblEditDisc
            // 
            this.lblEditDisc.AutoSize = true;
            this.lblEditDisc.Location = new System.Drawing.Point(7, 17);
            this.lblEditDisc.Name = "lblEditDisc";
            this.lblEditDisc.Size = new System.Drawing.Size(87, 16);
            this.lblEditDisc.TabIndex = 28;
            this.lblEditDisc.Text = "Discontinued:";
            // 
            // cbxEditDisc
            // 
            this.cbxEditDisc.AutoSize = true;
            this.cbxEditDisc.Location = new System.Drawing.Point(100, 19);
            this.cbxEditDisc.Name = "cbxEditDisc";
            this.cbxEditDisc.Size = new System.Drawing.Size(15, 14);
            this.cbxEditDisc.TabIndex = 28;
            this.cbxEditDisc.UseVisualStyleBackColor = true;
            // 
            // lblEditGenre
            // 
            this.lblEditGenre.AutoSize = true;
            this.lblEditGenre.Location = new System.Drawing.Point(7, 161);
            this.lblEditGenre.Name = "lblEditGenre";
            this.lblEditGenre.Size = new System.Drawing.Size(47, 16);
            this.lblEditGenre.TabIndex = 25;
            this.lblEditGenre.Text = "Genre:";
            // 
            // tbxEditGenre
            // 
            this.tbxEditGenre.Location = new System.Drawing.Point(111, 161);
            this.tbxEditGenre.MaxLength = 60;
            this.tbxEditGenre.Name = "tbxEditGenre";
            this.tbxEditGenre.Size = new System.Drawing.Size(192, 22);
            this.tbxEditGenre.TabIndex = 26;
            // 
            // btnEditImage
            // 
            this.btnEditImage.Location = new System.Drawing.Point(331, 144);
            this.btnEditImage.Name = "btnEditImage";
            this.btnEditImage.Size = new System.Drawing.Size(94, 23);
            this.btnEditImage.TabIndex = 29;
            this.btnEditImage.Text = "Edit Image";
            this.btnEditImage.UseVisualStyleBackColor = true;
            this.btnEditImage.Click += new System.EventHandler(this.btnEditImage_Click);
            // 
            // pbxEditItemImage
            // 
            this.pbxEditItemImage.Location = new System.Drawing.Point(320, 41);
            this.pbxEditItemImage.Name = "pbxEditItemImage";
            this.pbxEditItemImage.Size = new System.Drawing.Size(123, 97);
            this.pbxEditItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxEditItemImage.TabIndex = 14;
            this.pbxEditItemImage.TabStop = false;
            // 
            // lblItemQuantityEdit
            // 
            this.lblItemQuantityEdit.AutoSize = true;
            this.lblItemQuantityEdit.Location = new System.Drawing.Point(7, 133);
            this.lblItemQuantityEdit.Name = "lblItemQuantityEdit";
            this.lblItemQuantityEdit.Size = new System.Drawing.Size(61, 16);
            this.lblItemQuantityEdit.TabIndex = 22;
            this.lblItemQuantityEdit.Text = "Quantity:";
            // 
            // tbxEditItemName
            // 
            this.tbxEditItemName.Location = new System.Drawing.Point(111, 21);
            this.tbxEditItemName.MaxLength = 100;
            this.tbxEditItemName.Name = "tbxEditItemName";
            this.tbxEditItemName.Size = new System.Drawing.Size(192, 22);
            this.tbxEditItemName.TabIndex = 21;
            // 
            // lblItemCostEdit
            // 
            this.lblItemCostEdit.AutoSize = true;
            this.lblItemCostEdit.Location = new System.Drawing.Point(7, 105);
            this.lblItemCostEdit.Name = "lblItemCostEdit";
            this.lblItemCostEdit.Size = new System.Drawing.Size(39, 16);
            this.lblItemCostEdit.TabIndex = 21;
            this.lblItemCostEdit.Text = "Cost:";
            // 
            // tbxEditItemDesc
            // 
            this.tbxEditItemDesc.Location = new System.Drawing.Point(111, 49);
            this.tbxEditItemDesc.Name = "tbxEditItemDesc";
            this.tbxEditItemDesc.Size = new System.Drawing.Size(192, 22);
            this.tbxEditItemDesc.TabIndex = 22;
            // 
            // lblRetailPriceEdit
            // 
            this.lblRetailPriceEdit.AutoSize = true;
            this.lblRetailPriceEdit.Location = new System.Drawing.Point(7, 77);
            this.lblRetailPriceEdit.Name = "lblRetailPriceEdit";
            this.lblRetailPriceEdit.Size = new System.Drawing.Size(79, 16);
            this.lblRetailPriceEdit.TabIndex = 20;
            this.lblRetailPriceEdit.Text = "Retail Price:";
            // 
            // lblItemDescripEdit
            // 
            this.lblItemDescripEdit.AutoSize = true;
            this.lblItemDescripEdit.Location = new System.Drawing.Point(7, 49);
            this.lblItemDescripEdit.Name = "lblItemDescripEdit";
            this.lblItemDescripEdit.Size = new System.Drawing.Size(106, 16);
            this.lblItemDescripEdit.TabIndex = 19;
            this.lblItemDescripEdit.Text = "Item Description:";
            // 
            // lblItemNameEdit
            // 
            this.lblItemNameEdit.AutoSize = true;
            this.lblItemNameEdit.Location = new System.Drawing.Point(7, 21);
            this.lblItemNameEdit.Name = "lblItemNameEdit";
            this.lblItemNameEdit.Size = new System.Drawing.Size(75, 16);
            this.lblItemNameEdit.TabIndex = 18;
            this.lblItemNameEdit.Text = "Item Name:";
            // 
            // grpAddItem
            // 
            this.grpAddItem.Controls.Add(this.tbxAddItemQuantity);
            this.grpAddItem.Controls.Add(this.grpAddDisc);
            this.grpAddItem.Controls.Add(this.tbxAddItemCost);
            this.grpAddItem.Controls.Add(this.lblItemGenre);
            this.grpAddItem.Controls.Add(this.tbxAddItemPrice);
            this.grpAddItem.Controls.Add(this.tbxAddItemGenre);
            this.grpAddItem.Controls.Add(this.btnAddImage);
            this.grpAddItem.Controls.Add(this.pbxAddItemImage);
            this.grpAddItem.Controls.Add(this.lblItemQuantity);
            this.grpAddItem.Controls.Add(this.lblItemCost);
            this.grpAddItem.Controls.Add(this.lblItemRetailPrice);
            this.grpAddItem.Controls.Add(this.lblItemDescription);
            this.grpAddItem.Controls.Add(this.lblItemName);
            this.grpAddItem.Controls.Add(this.tbxAddItemDesc);
            this.grpAddItem.Controls.Add(this.tbxAddItemName);
            this.grpAddItem.Enabled = false;
            this.grpAddItem.Location = new System.Drawing.Point(1, 368);
            this.grpAddItem.Name = "grpAddItem";
            this.grpAddItem.Size = new System.Drawing.Size(489, 248);
            this.grpAddItem.TabIndex = 7;
            this.grpAddItem.TabStop = false;
            this.grpAddItem.Text = "Add Item";
            // 
            // tbxAddItemQuantity
            // 
            this.tbxAddItemQuantity.Location = new System.Drawing.Point(115, 133);
            this.tbxAddItemQuantity.Name = "tbxAddItemQuantity";
            this.tbxAddItemQuantity.ShortcutsEnabled = false;
            this.tbxAddItemQuantity.Size = new System.Drawing.Size(192, 22);
            this.tbxAddItemQuantity.TabIndex = 12;
            this.tbxAddItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAddItemQuantity_KeyPress);
            // 
            // grpAddDisc
            // 
            this.grpAddDisc.Controls.Add(this.lblAddItemDiscon);
            this.grpAddDisc.Controls.Add(this.cbxAddDiscontinued);
            this.grpAddDisc.Location = new System.Drawing.Point(151, 189);
            this.grpAddDisc.Name = "grpAddDisc";
            this.grpAddDisc.Size = new System.Drawing.Size(123, 45);
            this.grpAddDisc.TabIndex = 14;
            this.grpAddDisc.TabStop = false;
            // 
            // lblAddItemDiscon
            // 
            this.lblAddItemDiscon.AutoSize = true;
            this.lblAddItemDiscon.Location = new System.Drawing.Point(7, 17);
            this.lblAddItemDiscon.Name = "lblAddItemDiscon";
            this.lblAddItemDiscon.Size = new System.Drawing.Size(87, 16);
            this.lblAddItemDiscon.TabIndex = 28;
            this.lblAddItemDiscon.Text = "Discontinued:";
            // 
            // cbxAddDiscontinued
            // 
            this.cbxAddDiscontinued.AutoSize = true;
            this.cbxAddDiscontinued.Location = new System.Drawing.Point(100, 19);
            this.cbxAddDiscontinued.Name = "cbxAddDiscontinued";
            this.cbxAddDiscontinued.Size = new System.Drawing.Size(15, 14);
            this.cbxAddDiscontinued.TabIndex = 15;
            this.cbxAddDiscontinued.UseVisualStyleBackColor = true;
            // 
            // tbxAddItemCost
            // 
            this.tbxAddItemCost.Location = new System.Drawing.Point(115, 105);
            this.tbxAddItemCost.MaxLength = 12;
            this.tbxAddItemCost.Name = "tbxAddItemCost";
            this.tbxAddItemCost.Size = new System.Drawing.Size(192, 22);
            this.tbxAddItemCost.TabIndex = 11;
            this.tbxAddItemCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAddItemCost_KeyPress);
            // 
            // lblItemGenre
            // 
            this.lblItemGenre.AutoSize = true;
            this.lblItemGenre.Location = new System.Drawing.Point(4, 164);
            this.lblItemGenre.Name = "lblItemGenre";
            this.lblItemGenre.Size = new System.Drawing.Size(47, 16);
            this.lblItemGenre.TabIndex = 27;
            this.lblItemGenre.Text = "Genre:";
            // 
            // tbxAddItemPrice
            // 
            this.tbxAddItemPrice.Location = new System.Drawing.Point(115, 77);
            this.tbxAddItemPrice.MaxLength = 12;
            this.tbxAddItemPrice.Name = "tbxAddItemPrice";
            this.tbxAddItemPrice.ShortcutsEnabled = false;
            this.tbxAddItemPrice.Size = new System.Drawing.Size(192, 22);
            this.tbxAddItemPrice.TabIndex = 10;
            this.tbxAddItemPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAddItemPrice_KeyPress);
            // 
            // tbxAddItemGenre
            // 
            this.tbxAddItemGenre.Location = new System.Drawing.Point(115, 161);
            this.tbxAddItemGenre.MaxLength = 60;
            this.tbxAddItemGenre.Name = "tbxAddItemGenre";
            this.tbxAddItemGenre.Size = new System.Drawing.Size(192, 22);
            this.tbxAddItemGenre.TabIndex = 13;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(357, 147);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(94, 23);
            this.btnAddImage.TabIndex = 17;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // pbxAddItemImage
            // 
            this.pbxAddItemImage.Location = new System.Drawing.Point(340, 44);
            this.pbxAddItemImage.Name = "pbxAddItemImage";
            this.pbxAddItemImage.Size = new System.Drawing.Size(123, 97);
            this.pbxAddItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAddItemImage.TabIndex = 13;
            this.pbxAddItemImage.TabStop = false;
            // 
            // lblItemQuantity
            // 
            this.lblItemQuantity.AutoSize = true;
            this.lblItemQuantity.Location = new System.Drawing.Point(4, 136);
            this.lblItemQuantity.Name = "lblItemQuantity";
            this.lblItemQuantity.Size = new System.Drawing.Size(61, 16);
            this.lblItemQuantity.TabIndex = 12;
            this.lblItemQuantity.Text = "Quantity:";
            // 
            // lblItemCost
            // 
            this.lblItemCost.AutoSize = true;
            this.lblItemCost.Location = new System.Drawing.Point(4, 108);
            this.lblItemCost.Name = "lblItemCost";
            this.lblItemCost.Size = new System.Drawing.Size(39, 16);
            this.lblItemCost.TabIndex = 11;
            this.lblItemCost.Text = "Cost:";
            // 
            // lblItemRetailPrice
            // 
            this.lblItemRetailPrice.AutoSize = true;
            this.lblItemRetailPrice.Location = new System.Drawing.Point(4, 80);
            this.lblItemRetailPrice.Name = "lblItemRetailPrice";
            this.lblItemRetailPrice.Size = new System.Drawing.Size(79, 16);
            this.lblItemRetailPrice.TabIndex = 10;
            this.lblItemRetailPrice.Text = "Retail Price:";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.Location = new System.Drawing.Point(4, 52);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(106, 16);
            this.lblItemDescription.TabIndex = 9;
            this.lblItemDescription.Text = "Item Description:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(4, 24);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(75, 16);
            this.lblItemName.TabIndex = 8;
            this.lblItemName.Text = "Item Name:";
            // 
            // tbxAddItemDesc
            // 
            this.tbxAddItemDesc.Location = new System.Drawing.Point(115, 49);
            this.tbxAddItemDesc.Name = "tbxAddItemDesc";
            this.tbxAddItemDesc.Size = new System.Drawing.Size(192, 22);
            this.tbxAddItemDesc.TabIndex = 9;
            // 
            // tbxAddItemName
            // 
            this.tbxAddItemName.Location = new System.Drawing.Point(115, 21);
            this.tbxAddItemName.MaxLength = 100;
            this.tbxAddItemName.Name = "tbxAddItemName";
            this.tbxAddItemName.Size = new System.Drawing.Size(192, 22);
            this.tbxAddItemName.TabIndex = 8;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(3, 3);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(957, 270);
            this.dgvInventory.TabIndex = 0;
            this.dgvInventory.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInventory_ColumnHeaderMouseClick);
            this.dgvInventory.SelectionChanged += new System.EventHandler(this.dgvInventory_SelectionChanged);
            // 
            // tabCustomers
            // 
            this.tabCustomers.BackColor = System.Drawing.Color.Silver;
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.grpSearchCustomer);
            this.tabCustomers.Controls.Add(this.grpPreviousCustomersOrders);
            this.tabCustomers.Controls.Add(this.grpAccDelDisable);
            this.tabCustomers.Location = new System.Drawing.Point(4, 25);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(963, 616);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Customers";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(4, 3);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(956, 305);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
            // 
            // grpSearchCustomer
            // 
            this.grpSearchCustomer.Controls.Add(this.tbxMemberID);
            this.grpSearchCustomer.Controls.Add(this.lblMemberID);
            this.grpSearchCustomer.Controls.Add(this.tbxSearchFirstName);
            this.grpSearchCustomer.Controls.Add(this.lblCustFirstName);
            this.grpSearchCustomer.Controls.Add(this.tbxSearchLastName);
            this.grpSearchCustomer.Controls.Add(this.lblCustLastName);
            this.grpSearchCustomer.Controls.Add(this.tbxCustomerSearchEmail);
            this.grpSearchCustomer.Controls.Add(this.btnEditCustomer);
            this.grpSearchCustomer.Controls.Add(this.lblCustEmail);
            this.grpSearchCustomer.Controls.Add(this.btnNewOrder);
            this.grpSearchCustomer.Controls.Add(this.btnAddCustomer);
            this.grpSearchCustomer.Location = new System.Drawing.Point(590, 430);
            this.grpSearchCustomer.Name = "grpSearchCustomer";
            this.grpSearchCustomer.Size = new System.Drawing.Size(375, 184);
            this.grpSearchCustomer.TabIndex = 44;
            this.grpSearchCustomer.TabStop = false;
            this.grpSearchCustomer.Text = "Search Customer:";
            // 
            // tbxMemberID
            // 
            this.tbxMemberID.Location = new System.Drawing.Point(168, 105);
            this.tbxMemberID.Name = "tbxMemberID";
            this.tbxMemberID.Size = new System.Drawing.Size(145, 22);
            this.tbxMemberID.TabIndex = 12;
            this.tbxMemberID.TextChanged += new System.EventHandler(this.tbxMemberID_TextChanged);
            // 
            // lblMemberID
            // 
            this.lblMemberID.AutoSize = true;
            this.lblMemberID.Location = new System.Drawing.Point(61, 103);
            this.lblMemberID.Name = "lblMemberID";
            this.lblMemberID.Size = new System.Drawing.Size(75, 16);
            this.lblMemberID.TabIndex = 51;
            this.lblMemberID.Text = "Member ID:";
            // 
            // tbxSearchFirstName
            // 
            this.tbxSearchFirstName.Location = new System.Drawing.Point(168, 21);
            this.tbxSearchFirstName.Name = "tbxSearchFirstName";
            this.tbxSearchFirstName.Size = new System.Drawing.Size(145, 22);
            this.tbxSearchFirstName.TabIndex = 9;
            this.tbxSearchFirstName.TextChanged += new System.EventHandler(this.tbxSearchFirstName_TextChanged);
            // 
            // lblCustFirstName
            // 
            this.lblCustFirstName.AutoSize = true;
            this.lblCustFirstName.Location = new System.Drawing.Point(61, 21);
            this.lblCustFirstName.Name = "lblCustFirstName";
            this.lblCustFirstName.Size = new System.Drawing.Size(76, 16);
            this.lblCustFirstName.TabIndex = 49;
            this.lblCustFirstName.Text = "First Name:";
            // 
            // tbxSearchLastName
            // 
            this.tbxSearchLastName.Location = new System.Drawing.Point(168, 49);
            this.tbxSearchLastName.Name = "tbxSearchLastName";
            this.tbxSearchLastName.Size = new System.Drawing.Size(145, 22);
            this.tbxSearchLastName.TabIndex = 10;
            this.tbxSearchLastName.TextChanged += new System.EventHandler(this.tbxSearchLastName_TextChanged);
            // 
            // lblCustLastName
            // 
            this.lblCustLastName.AutoSize = true;
            this.lblCustLastName.Location = new System.Drawing.Point(61, 50);
            this.lblCustLastName.Name = "lblCustLastName";
            this.lblCustLastName.Size = new System.Drawing.Size(75, 16);
            this.lblCustLastName.TabIndex = 47;
            this.lblCustLastName.Text = "Last Name:";
            // 
            // tbxCustomerSearchEmail
            // 
            this.tbxCustomerSearchEmail.Location = new System.Drawing.Point(168, 77);
            this.tbxCustomerSearchEmail.Name = "tbxCustomerSearchEmail";
            this.tbxCustomerSearchEmail.Size = new System.Drawing.Size(145, 22);
            this.tbxCustomerSearchEmail.TabIndex = 11;
            this.tbxCustomerSearchEmail.TextChanged += new System.EventHandler(this.tbxCustomerSearchEmail_TextChanged);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(139, 156);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(106, 23);
            this.btnEditCustomer.TabIndex = 14;
            this.btnEditCustomer.Text = "Edit Customer";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // lblCustEmail
            // 
            this.lblCustEmail.AutoSize = true;
            this.lblCustEmail.Location = new System.Drawing.Point(61, 75);
            this.lblCustEmail.Name = "lblCustEmail";
            this.lblCustEmail.Size = new System.Drawing.Size(45, 16);
            this.lblCustEmail.TabIndex = 45;
            this.lblCustEmail.Text = "Email:";
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(251, 156);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(121, 23);
            this.btnNewOrder.TabIndex = 15;
            this.btnNewOrder.Text = "Start New Order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(3, 156);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(130, 23);
            this.btnAddCustomer.TabIndex = 13;
            this.btnAddCustomer.Text = "Add New Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // grpPreviousCustomersOrders
            // 
            this.grpPreviousCustomersOrders.Controls.Add(this.dgvOrders);
            this.grpPreviousCustomersOrders.Location = new System.Drawing.Point(4, 314);
            this.grpPreviousCustomersOrders.Name = "grpPreviousCustomersOrders";
            this.grpPreviousCustomersOrders.Size = new System.Drawing.Size(580, 296);
            this.grpPreviousCustomersOrders.TabIndex = 1;
            this.grpPreviousCustomersOrders.TabStop = false;
            this.grpPreviousCustomersOrders.Text = "Previous Customer\'s Orders";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(6, 20);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(568, 270);
            this.dgvOrders.TabIndex = 2;
            // 
            // grpAccDelDisable
            // 
            this.grpAccDelDisable.Controls.Add(this.btnSave);
            this.grpAccDelDisable.Controls.Add(this.grpDeleted);
            this.grpAccDelDisable.Controls.Add(this.grpEnableDisable);
            this.grpAccDelDisable.Location = new System.Drawing.Point(592, 314);
            this.grpAccDelDisable.Name = "grpAccDelDisable";
            this.grpAccDelDisable.Size = new System.Drawing.Size(375, 131);
            this.grpAccDelDisable.TabIndex = 3;
            this.grpAccDelDisable.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(144, 92);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpDeleted
            // 
            this.grpDeleted.Controls.Add(this.chkCustDeleted);
            this.grpDeleted.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDeleted.Location = new System.Drawing.Point(203, 16);
            this.grpDeleted.Name = "grpDeleted";
            this.grpDeleted.Size = new System.Drawing.Size(129, 70);
            this.grpDeleted.TabIndex = 6;
            this.grpDeleted.TabStop = false;
            this.grpDeleted.Text = "Account Deleted";
            // 
            // chkCustDeleted
            // 
            this.chkCustDeleted.AutoSize = true;
            this.chkCustDeleted.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustDeleted.Location = new System.Drawing.Point(57, 35);
            this.chkCustDeleted.Name = "chkCustDeleted";
            this.chkCustDeleted.Size = new System.Drawing.Size(15, 14);
            this.chkCustDeleted.TabIndex = 7;
            this.chkCustDeleted.UseVisualStyleBackColor = true;
            // 
            // grpEnableDisable
            // 
            this.grpEnableDisable.Controls.Add(this.chkCustEnabledDisabled);
            this.grpEnableDisable.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEnableDisable.Location = new System.Drawing.Point(35, 16);
            this.grpEnableDisable.Name = "grpEnableDisable";
            this.grpEnableDisable.Size = new System.Drawing.Size(129, 70);
            this.grpEnableDisable.TabIndex = 4;
            this.grpEnableDisable.TabStop = false;
            this.grpEnableDisable.Text = "Account Enabled/Disabled";
            // 
            // chkCustEnabledDisabled
            // 
            this.chkCustEnabledDisabled.AutoSize = true;
            this.chkCustEnabledDisabled.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustEnabledDisabled.Location = new System.Drawing.Point(57, 35);
            this.chkCustEnabledDisabled.Name = "chkCustEnabledDisabled";
            this.chkCustEnabledDisabled.Size = new System.Drawing.Size(15, 14);
            this.chkCustEnabledDisabled.TabIndex = 5;
            this.chkCustEnabledDisabled.UseVisualStyleBackColor = true;
            // 
            // tabManagers
            // 
            this.tabManagers.BackColor = System.Drawing.Color.Silver;
            this.tabManagers.Controls.Add(this.grpManagerActivation);
            this.tabManagers.Controls.Add(this.groupBox2);
            this.tabManagers.Controls.Add(this.dgvManagers);
            this.tabManagers.Location = new System.Drawing.Point(4, 25);
            this.tabManagers.Name = "tabManagers";
            this.tabManagers.Size = new System.Drawing.Size(963, 616);
            this.tabManagers.TabIndex = 2;
            this.tabManagers.Text = "Managers";
            // 
            // grpManagerActivation
            // 
            this.grpManagerActivation.Controls.Add(this.grpManager);
            this.grpManagerActivation.Controls.Add(this.grpActive);
            this.grpManagerActivation.Controls.Add(this.btnSaveManager);
            this.grpManagerActivation.Controls.Add(this.grpAccDeleted);
            this.grpManagerActivation.Controls.Add(this.grpAccountEnable);
            this.grpManagerActivation.Location = new System.Drawing.Point(481, 313);
            this.grpManagerActivation.Name = "grpManagerActivation";
            this.grpManagerActivation.Size = new System.Drawing.Size(366, 197);
            this.grpManagerActivation.TabIndex = 7;
            this.grpManagerActivation.TabStop = false;
            // 
            // grpManager
            // 
            this.grpManager.Controls.Add(this.chkIsManager);
            this.grpManager.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpManager.Location = new System.Drawing.Point(203, 94);
            this.grpManager.Name = "grpManager";
            this.grpManager.Size = new System.Drawing.Size(129, 70);
            this.grpManager.TabIndex = 14;
            this.grpManager.TabStop = false;
            this.grpManager.Text = "Manager Permissions";
            // 
            // chkIsManager
            // 
            this.chkIsManager.AutoSize = true;
            this.chkIsManager.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsManager.Location = new System.Drawing.Point(57, 35);
            this.chkIsManager.Name = "chkIsManager";
            this.chkIsManager.Size = new System.Drawing.Size(15, 14);
            this.chkIsManager.TabIndex = 15;
            this.chkIsManager.UseVisualStyleBackColor = true;
            // 
            // grpActive
            // 
            this.grpActive.Controls.Add(this.chkManagerActive);
            this.grpActive.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpActive.Location = new System.Drawing.Point(35, 94);
            this.grpActive.Name = "grpActive";
            this.grpActive.Size = new System.Drawing.Size(129, 70);
            this.grpActive.TabIndex = 12;
            this.grpActive.TabStop = false;
            this.grpActive.Text = "Active";
            // 
            // chkManagerActive
            // 
            this.chkManagerActive.AutoSize = true;
            this.chkManagerActive.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManagerActive.Location = new System.Drawing.Point(57, 35);
            this.chkManagerActive.Name = "chkManagerActive";
            this.chkManagerActive.Size = new System.Drawing.Size(15, 14);
            this.chkManagerActive.TabIndex = 13;
            this.chkManagerActive.UseVisualStyleBackColor = true;
            // 
            // btnSaveManager
            // 
            this.btnSaveManager.Location = new System.Drawing.Point(146, 170);
            this.btnSaveManager.Name = "btnSaveManager";
            this.btnSaveManager.Size = new System.Drawing.Size(75, 23);
            this.btnSaveManager.TabIndex = 16;
            this.btnSaveManager.Text = "Save";
            this.btnSaveManager.UseVisualStyleBackColor = true;
            this.btnSaveManager.Click += new System.EventHandler(this.btnSaveManager_Click);
            // 
            // grpAccDeleted
            // 
            this.grpAccDeleted.Controls.Add(this.chkManagerDeleted);
            this.grpAccDeleted.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAccDeleted.Location = new System.Drawing.Point(203, 18);
            this.grpAccDeleted.Name = "grpAccDeleted";
            this.grpAccDeleted.Size = new System.Drawing.Size(129, 70);
            this.grpAccDeleted.TabIndex = 10;
            this.grpAccDeleted.TabStop = false;
            this.grpAccDeleted.Text = "Account Deleted";
            // 
            // chkManagerDeleted
            // 
            this.chkManagerDeleted.AutoSize = true;
            this.chkManagerDeleted.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManagerDeleted.Location = new System.Drawing.Point(57, 35);
            this.chkManagerDeleted.Name = "chkManagerDeleted";
            this.chkManagerDeleted.Size = new System.Drawing.Size(15, 14);
            this.chkManagerDeleted.TabIndex = 11;
            this.chkManagerDeleted.UseVisualStyleBackColor = true;
            // 
            // grpAccountEnable
            // 
            this.grpAccountEnable.Controls.Add(this.chkManagerEnabled);
            this.grpAccountEnable.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAccountEnable.Location = new System.Drawing.Point(35, 18);
            this.grpAccountEnable.Name = "grpAccountEnable";
            this.grpAccountEnable.Size = new System.Drawing.Size(129, 70);
            this.grpAccountEnable.TabIndex = 8;
            this.grpAccountEnable.TabStop = false;
            this.grpAccountEnable.Text = "Account Enabled/Disabled";
            // 
            // chkManagerEnabled
            // 
            this.chkManagerEnabled.AutoSize = true;
            this.chkManagerEnabled.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManagerEnabled.Location = new System.Drawing.Point(57, 35);
            this.chkManagerEnabled.Name = "chkManagerEnabled";
            this.chkManagerEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkManagerEnabled.TabIndex = 9;
            this.chkManagerEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxSalary);
            this.groupBox2.Controls.Add(this.btnApplyManagerSalary);
            this.groupBox2.Controls.Add(this.lblManagerSalary);
            this.groupBox2.Controls.Add(this.btnEditManager);
            this.groupBox2.Controls.Add(this.btnDisplayInfo);
            this.groupBox2.Controls.Add(this.btnAddNewManager);
            this.groupBox2.Location = new System.Drawing.Point(116, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 129);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manage Managers";
            // 
            // tbxSalary
            // 
            this.tbxSalary.Location = new System.Drawing.Point(174, 29);
            this.tbxSalary.MaxLength = 10;
            this.tbxSalary.Name = "tbxSalary";
            this.tbxSalary.ShortcutsEnabled = false;
            this.tbxSalary.Size = new System.Drawing.Size(158, 22);
            this.tbxSalary.TabIndex = 2;
            this.tbxSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSalary_KeyPress);
            // 
            // btnApplyManagerSalary
            // 
            this.btnApplyManagerSalary.Location = new System.Drawing.Point(187, 65);
            this.btnApplyManagerSalary.Name = "btnApplyManagerSalary";
            this.btnApplyManagerSalary.Size = new System.Drawing.Size(145, 23);
            this.btnApplyManagerSalary.TabIndex = 4;
            this.btnApplyManagerSalary.Text = "Apply New Salary";
            this.btnApplyManagerSalary.UseVisualStyleBackColor = true;
            this.btnApplyManagerSalary.Click += new System.EventHandler(this.ApplyManagerSalary_Click);
            // 
            // lblManagerSalary
            // 
            this.lblManagerSalary.AutoSize = true;
            this.lblManagerSalary.Location = new System.Drawing.Point(64, 29);
            this.lblManagerSalary.Name = "lblManagerSalary";
            this.lblManagerSalary.Size = new System.Drawing.Size(103, 16);
            this.lblManagerSalary.TabIndex = 51;
            this.lblManagerSalary.Text = "Manager Salary:";
            // 
            // btnEditManager
            // 
            this.btnEditManager.Location = new System.Drawing.Point(36, 65);
            this.btnEditManager.Name = "btnEditManager";
            this.btnEditManager.Size = new System.Drawing.Size(145, 23);
            this.btnEditManager.TabIndex = 3;
            this.btnEditManager.Text = "Edit Manager";
            this.btnEditManager.UseVisualStyleBackColor = true;
            this.btnEditManager.Click += new System.EventHandler(this.btnEditManager_Click);
            // 
            // btnDisplayInfo
            // 
            this.btnDisplayInfo.Location = new System.Drawing.Point(187, 94);
            this.btnDisplayInfo.Name = "btnDisplayInfo";
            this.btnDisplayInfo.Size = new System.Drawing.Size(145, 23);
            this.btnDisplayInfo.TabIndex = 6;
            this.btnDisplayInfo.Text = "Manager Information";
            this.btnDisplayInfo.UseVisualStyleBackColor = true;
            this.btnDisplayInfo.Click += new System.EventHandler(this.btnDisplayInfo_Click);
            // 
            // btnAddNewManager
            // 
            this.btnAddNewManager.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewManager.Location = new System.Drawing.Point(36, 94);
            this.btnAddNewManager.Name = "btnAddNewManager";
            this.btnAddNewManager.Size = new System.Drawing.Size(145, 23);
            this.btnAddNewManager.TabIndex = 5;
            this.btnAddNewManager.Text = "Create New Manager";
            this.btnAddNewManager.UseVisualStyleBackColor = true;
            this.btnAddNewManager.Click += new System.EventHandler(this.btnAddNewManager_Click);
            // 
            // dgvManagers
            // 
            this.dgvManagers.AllowUserToAddRows = false;
            this.dgvManagers.AllowUserToDeleteRows = false;
            this.dgvManagers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagers.Location = new System.Drawing.Point(0, 0);
            this.dgvManagers.MultiSelect = false;
            this.dgvManagers.Name = "dgvManagers";
            this.dgvManagers.ReadOnly = true;
            this.dgvManagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManagers.Size = new System.Drawing.Size(960, 243);
            this.dgvManagers.TabIndex = 0;
            this.dgvManagers.SelectionChanged += new System.EventHandler(this.dgvManagers_SelectionChanged);
            // 
            // tabDiscounts
            // 
            this.tabDiscounts.BackColor = System.Drawing.Color.Silver;
            this.tabDiscounts.Controls.Add(this.dgvDiscounts);
            this.tabDiscounts.Controls.Add(this.btnCancelDiscountEdit);
            this.tabDiscounts.Controls.Add(this.btnEditDiscount);
            this.tabDiscounts.Controls.Add(this.btnCancelDiscountCreation);
            this.tabDiscounts.Controls.Add(this.btnSaveDiscount);
            this.tabDiscounts.Controls.Add(this.grpEditDiscount);
            this.tabDiscounts.Controls.Add(this.grpCreateDiscount);
            this.tabDiscounts.Location = new System.Drawing.Point(4, 25);
            this.tabDiscounts.Name = "tabDiscounts";
            this.tabDiscounts.Size = new System.Drawing.Size(963, 616);
            this.tabDiscounts.TabIndex = 4;
            this.tabDiscounts.Text = "Discounts";
            // 
            // dgvDiscounts
            // 
            this.dgvDiscounts.AllowUserToAddRows = false;
            this.dgvDiscounts.AllowUserToDeleteRows = false;
            this.dgvDiscounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscounts.Location = new System.Drawing.Point(0, 0);
            this.dgvDiscounts.MultiSelect = false;
            this.dgvDiscounts.Name = "dgvDiscounts";
            this.dgvDiscounts.ReadOnly = true;
            this.dgvDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscounts.Size = new System.Drawing.Size(963, 275);
            this.dgvDiscounts.TabIndex = 0;
            this.dgvDiscounts.SelectionChanged += new System.EventHandler(this.dgvDiscounts_SelectionChanged);
            // 
            // btnCancelDiscountEdit
            // 
            this.btnCancelDiscountEdit.Location = new System.Drawing.Point(728, 327);
            this.btnCancelDiscountEdit.Name = "btnCancelDiscountEdit";
            this.btnCancelDiscountEdit.Size = new System.Drawing.Size(125, 23);
            this.btnCancelDiscountEdit.TabIndex = 9;
            this.btnCancelDiscountEdit.Text = "Cancel";
            this.btnCancelDiscountEdit.UseVisualStyleBackColor = true;
            this.btnCancelDiscountEdit.Click += new System.EventHandler(this.btnCancelDiscountEdit_Click);
            // 
            // btnEditDiscount
            // 
            this.btnEditDiscount.Location = new System.Drawing.Point(597, 327);
            this.btnEditDiscount.Name = "btnEditDiscount";
            this.btnEditDiscount.Size = new System.Drawing.Size(125, 23);
            this.btnEditDiscount.TabIndex = 8;
            this.btnEditDiscount.Text = "Edit Discount";
            this.btnEditDiscount.UseVisualStyleBackColor = true;
            this.btnEditDiscount.Click += new System.EventHandler(this.btnEditDiscount_Click);
            // 
            // btnCancelDiscountCreation
            // 
            this.btnCancelDiscountCreation.Location = new System.Drawing.Point(245, 327);
            this.btnCancelDiscountCreation.Name = "btnCancelDiscountCreation";
            this.btnCancelDiscountCreation.Size = new System.Drawing.Size(125, 23);
            this.btnCancelDiscountCreation.TabIndex = 2;
            this.btnCancelDiscountCreation.Text = "Cancel";
            this.btnCancelDiscountCreation.UseVisualStyleBackColor = true;
            this.btnCancelDiscountCreation.Click += new System.EventHandler(this.btnCancelDiscountCreation_Click);
            // 
            // btnSaveDiscount
            // 
            this.btnSaveDiscount.Location = new System.Drawing.Point(114, 327);
            this.btnSaveDiscount.Name = "btnSaveDiscount";
            this.btnSaveDiscount.Size = new System.Drawing.Size(125, 23);
            this.btnSaveDiscount.TabIndex = 1;
            this.btnSaveDiscount.Text = "Create Discount";
            this.btnSaveDiscount.UseVisualStyleBackColor = true;
            this.btnSaveDiscount.Click += new System.EventHandler(this.btnSaveDiscount_Click);
            // 
            // grpEditDiscount
            // 
            this.grpEditDiscount.Controls.Add(this.lblAvailableItemEdit);
            this.grpEditDiscount.Controls.Add(this.cbxAvailableItemEdit);
            this.grpEditDiscount.Controls.Add(this.lblExpDateEdit);
            this.grpEditDiscount.Controls.Add(this.dtpExpDateEdit);
            this.grpEditDiscount.Controls.Add(this.lblDiscPercEdit);
            this.grpEditDiscount.Controls.Add(this.cbxDiscAmountEdit);
            this.grpEditDiscount.Controls.Add(this.lblDiscountDescEdit);
            this.grpEditDiscount.Controls.Add(this.tbxDiscountDescriptionEdit);
            this.grpEditDiscount.Enabled = false;
            this.grpEditDiscount.Location = new System.Drawing.Point(476, 349);
            this.grpEditDiscount.Name = "grpEditDiscount";
            this.grpEditDiscount.Size = new System.Drawing.Size(480, 179);
            this.grpEditDiscount.TabIndex = 10;
            this.grpEditDiscount.TabStop = false;
            this.grpEditDiscount.Text = "Edit Discount";
            // 
            // lblAvailableItemEdit
            // 
            this.lblAvailableItemEdit.Location = new System.Drawing.Point(14, 29);
            this.lblAvailableItemEdit.Name = "lblAvailableItemEdit";
            this.lblAvailableItemEdit.Size = new System.Drawing.Size(98, 41);
            this.lblAvailableItemEdit.TabIndex = 16;
            this.lblAvailableItemEdit.Text = "Available Items For Discounts:";
            // 
            // cbxAvailableItemEdit
            // 
            this.cbxAvailableItemEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAvailableItemEdit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAvailableItemEdit.FormattingEnabled = true;
            this.cbxAvailableItemEdit.Location = new System.Drawing.Point(118, 42);
            this.cbxAvailableItemEdit.Name = "cbxAvailableItemEdit";
            this.cbxAvailableItemEdit.Size = new System.Drawing.Size(348, 22);
            this.cbxAvailableItemEdit.TabIndex = 11;
            this.cbxAvailableItemEdit.SelectedValueChanged += new System.EventHandler(this.cbxAvailableItemEdit_SelectedValueChanged);
            // 
            // lblExpDateEdit
            // 
            this.lblExpDateEdit.AutoSize = true;
            this.lblExpDateEdit.Location = new System.Drawing.Point(136, 130);
            this.lblExpDateEdit.Name = "lblExpDateEdit";
            this.lblExpDateEdit.Size = new System.Drawing.Size(66, 16);
            this.lblExpDateEdit.TabIndex = 14;
            this.lblExpDateEdit.Text = "Exp Date:";
            // 
            // dtpExpDateEdit
            // 
            this.dtpExpDateEdit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpDateEdit.Location = new System.Drawing.Point(208, 128);
            this.dtpExpDateEdit.Name = "dtpExpDateEdit";
            this.dtpExpDateEdit.Size = new System.Drawing.Size(135, 22);
            this.dtpExpDateEdit.TabIndex = 14;
            // 
            // lblDiscPercEdit
            // 
            this.lblDiscPercEdit.AutoSize = true;
            this.lblDiscPercEdit.Location = new System.Drawing.Point(69, 74);
            this.lblDiscPercEdit.Name = "lblDiscPercEdit";
            this.lblDiscPercEdit.Size = new System.Drawing.Size(133, 16);
            this.lblDiscPercEdit.TabIndex = 12;
            this.lblDiscPercEdit.Text = "Discount Percentage:";
            // 
            // cbxDiscAmountEdit
            // 
            this.cbxDiscAmountEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDiscAmountEdit.FormattingEnabled = true;
            this.cbxDiscAmountEdit.Items.AddRange(new object[] {
            "10%",
            "25%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "100%"});
            this.cbxDiscAmountEdit.Location = new System.Drawing.Point(208, 70);
            this.cbxDiscAmountEdit.Name = "cbxDiscAmountEdit";
            this.cbxDiscAmountEdit.Size = new System.Drawing.Size(119, 24);
            this.cbxDiscAmountEdit.TabIndex = 12;
            this.cbxDiscAmountEdit.SelectedValueChanged += new System.EventHandler(this.cbxDiscAmountEdit_SelectedValueChanged);
            // 
            // lblDiscountDescEdit
            // 
            this.lblDiscountDescEdit.AutoSize = true;
            this.lblDiscountDescEdit.Location = new System.Drawing.Point(70, 102);
            this.lblDiscountDescEdit.Name = "lblDiscountDescEdit";
            this.lblDiscountDescEdit.Size = new System.Drawing.Size(132, 16);
            this.lblDiscountDescEdit.TabIndex = 10;
            this.lblDiscountDescEdit.Text = "Discount Description:";
            // 
            // tbxDiscountDescriptionEdit
            // 
            this.tbxDiscountDescriptionEdit.Location = new System.Drawing.Point(208, 100);
            this.tbxDiscountDescriptionEdit.Name = "tbxDiscountDescriptionEdit";
            this.tbxDiscountDescriptionEdit.ShortcutsEnabled = false;
            this.tbxDiscountDescriptionEdit.Size = new System.Drawing.Size(258, 22);
            this.tbxDiscountDescriptionEdit.TabIndex = 13;
            // 
            // grpCreateDiscount
            // 
            this.grpCreateDiscount.Controls.Add(this.lblExpDate);
            this.grpCreateDiscount.Controls.Add(this.dtpExpDate);
            this.grpCreateDiscount.Controls.Add(this.lblDiscountPercentage);
            this.grpCreateDiscount.Controls.Add(this.cbxDiscAmount);
            this.grpCreateDiscount.Controls.Add(this.lblDiscountDescription);
            this.grpCreateDiscount.Controls.Add(this.tbxNewDiscountDescription);
            this.grpCreateDiscount.Controls.Add(this.lblAvailableItems);
            this.grpCreateDiscount.Controls.Add(this.cbxAvailableItems);
            this.grpCreateDiscount.Enabled = false;
            this.grpCreateDiscount.Location = new System.Drawing.Point(6, 349);
            this.grpCreateDiscount.Name = "grpCreateDiscount";
            this.grpCreateDiscount.Size = new System.Drawing.Size(464, 179);
            this.grpCreateDiscount.TabIndex = 3;
            this.grpCreateDiscount.TabStop = false;
            this.grpCreateDiscount.Text = "Create Discount";
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Location = new System.Drawing.Point(101, 130);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(66, 16);
            this.lblExpDate.TabIndex = 14;
            this.lblExpDate.Text = "Exp Date:";
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpDate.Location = new System.Drawing.Point(173, 128);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new System.Drawing.Size(105, 22);
            this.dtpExpDate.TabIndex = 7;
            // 
            // lblDiscountPercentage
            // 
            this.lblDiscountPercentage.AutoSize = true;
            this.lblDiscountPercentage.Location = new System.Drawing.Point(34, 72);
            this.lblDiscountPercentage.Name = "lblDiscountPercentage";
            this.lblDiscountPercentage.Size = new System.Drawing.Size(133, 16);
            this.lblDiscountPercentage.TabIndex = 12;
            this.lblDiscountPercentage.Text = "Discount Percentage:";
            // 
            // cbxDiscAmount
            // 
            this.cbxDiscAmount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDiscAmount.FormattingEnabled = true;
            this.cbxDiscAmount.Items.AddRange(new object[] {
            "10%",
            "25%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "100%"});
            this.cbxDiscAmount.Location = new System.Drawing.Point(173, 70);
            this.cbxDiscAmount.Name = "cbxDiscAmount";
            this.cbxDiscAmount.Size = new System.Drawing.Size(105, 24);
            this.cbxDiscAmount.TabIndex = 5;
            this.cbxDiscAmount.SelectedValueChanged += new System.EventHandler(this.cbxDiscAmount_SelectedValueChanged);
            // 
            // lblDiscountDescription
            // 
            this.lblDiscountDescription.AutoSize = true;
            this.lblDiscountDescription.Location = new System.Drawing.Point(35, 100);
            this.lblDiscountDescription.Name = "lblDiscountDescription";
            this.lblDiscountDescription.Size = new System.Drawing.Size(132, 16);
            this.lblDiscountDescription.TabIndex = 10;
            this.lblDiscountDescription.Text = "Discount Description:";
            // 
            // tbxNewDiscountDescription
            // 
            this.tbxNewDiscountDescription.Location = new System.Drawing.Point(173, 100);
            this.tbxNewDiscountDescription.Name = "tbxNewDiscountDescription";
            this.tbxNewDiscountDescription.ShortcutsEnabled = false;
            this.tbxNewDiscountDescription.Size = new System.Drawing.Size(285, 22);
            this.tbxNewDiscountDescription.TabIndex = 6;
            // 
            // lblAvailableItems
            // 
            this.lblAvailableItems.Location = new System.Drawing.Point(6, 29);
            this.lblAvailableItems.Name = "lblAvailableItems";
            this.lblAvailableItems.Size = new System.Drawing.Size(98, 41);
            this.lblAvailableItems.TabIndex = 1;
            this.lblAvailableItems.Text = "Available Items For Discounts:";
            // 
            // cbxAvailableItems
            // 
            this.cbxAvailableItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAvailableItems.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAvailableItems.FormattingEnabled = true;
            this.cbxAvailableItems.Location = new System.Drawing.Point(110, 42);
            this.cbxAvailableItems.Name = "cbxAvailableItems";
            this.cbxAvailableItems.Size = new System.Drawing.Size(348, 22);
            this.cbxAvailableItems.TabIndex = 4;
            this.cbxAvailableItems.SelectedValueChanged += new System.EventHandler(this.cbxAvailableItems_SelectedValueChanged);
            // 
            // tabReports
            // 
            this.tabReports.BackColor = System.Drawing.Color.Silver;
            this.tabReports.Controls.Add(this.grpSalesReports);
            this.tabReports.Controls.Add(this.dgvOrdersForReports);
            this.tabReports.Location = new System.Drawing.Point(4, 25);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(963, 616);
            this.tabReports.TabIndex = 3;
            this.tabReports.Text = "Reports";
            // 
            // grpSalesReports
            // 
            this.grpSalesReports.Controls.Add(this.btnReload);
            this.grpSalesReports.Controls.Add(this.btnViewReport);
            this.grpSalesReports.Controls.Add(this.dtpReports);
            this.grpSalesReports.Controls.Add(this.btnDaily);
            this.grpSalesReports.Controls.Add(this.btnMonthly);
            this.grpSalesReports.Controls.Add(this.btnWeekly);
            this.grpSalesReports.Location = new System.Drawing.Point(243, 325);
            this.grpSalesReports.Name = "grpSalesReports";
            this.grpSalesReports.Size = new System.Drawing.Size(476, 184);
            this.grpSalesReports.TabIndex = 1;
            this.grpSalesReports.TabStop = false;
            this.grpSalesReports.Tag = "";
            this.grpSalesReports.Text = "Sales Reports";
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(238, 136);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(121, 30);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Reload Orders";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(117, 136);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(115, 30);
            this.btnViewReport.TabIndex = 6;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // dtpReports
            // 
            this.dtpReports.Location = new System.Drawing.Point(126, 98);
            this.dtpReports.Name = "dtpReports";
            this.dtpReports.Size = new System.Drawing.Size(232, 22);
            this.dtpReports.TabIndex = 5;
            // 
            // btnDaily
            // 
            this.btnDaily.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaily.Location = new System.Drawing.Point(66, 47);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(82, 30);
            this.btnDaily.TabIndex = 2;
            this.btnDaily.Text = "Daily";
            this.btnDaily.UseVisualStyleBackColor = true;
            this.btnDaily.Click += new System.EventHandler(this.btnDaily_Click);
            // 
            // btnMonthly
            // 
            this.btnMonthly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthly.Location = new System.Drawing.Point(328, 47);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(82, 30);
            this.btnMonthly.TabIndex = 4;
            this.btnMonthly.Text = "Monthly";
            this.btnMonthly.UseVisualStyleBackColor = true;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);
            // 
            // btnWeekly
            // 
            this.btnWeekly.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeekly.Location = new System.Drawing.Point(196, 47);
            this.btnWeekly.Name = "btnWeekly";
            this.btnWeekly.Size = new System.Drawing.Size(82, 30);
            this.btnWeekly.TabIndex = 3;
            this.btnWeekly.Text = "Weekly";
            this.btnWeekly.UseVisualStyleBackColor = true;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);
            // 
            // dgvOrdersForReports
            // 
            this.dgvOrdersForReports.AllowUserToAddRows = false;
            this.dgvOrdersForReports.AllowUserToDeleteRows = false;
            this.dgvOrdersForReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrdersForReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersForReports.Location = new System.Drawing.Point(0, 0);
            this.dgvOrdersForReports.MultiSelect = false;
            this.dgvOrdersForReports.Name = "dgvOrdersForReports";
            this.dgvOrdersForReports.ReadOnly = true;
            this.dgvOrdersForReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdersForReports.Size = new System.Drawing.Size(960, 305);
            this.dgvOrdersForReports.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.Red;
            this.btnHelp.Location = new System.Drawing.Point(903, 2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(59, 30);
            this.btnHelp.TabIndex = 50;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(206)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(964, 667);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabView);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManager_FormClosing);
            this.Load += new System.EventHandler(this.frmManager_Load);
            this.tabView.ResumeLayout(false);
            this.tabInventory.ResumeLayout(false);
            this.grpSearchItem.ResumeLayout(false);
            this.grpSearchItem.PerformLayout();
            this.grpEditItem.ResumeLayout(false);
            this.grpEditItem.PerformLayout();
            this.grpDiscontinuedItemEdit.ResumeLayout(false);
            this.grpDiscontinuedItemEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditItemImage)).EndInit();
            this.grpAddItem.ResumeLayout(false);
            this.grpAddItem.PerformLayout();
            this.grpAddDisc.ResumeLayout(false);
            this.grpAddDisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.grpSearchCustomer.ResumeLayout(false);
            this.grpSearchCustomer.PerformLayout();
            this.grpPreviousCustomersOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.grpAccDelDisable.ResumeLayout(false);
            this.grpDeleted.ResumeLayout(false);
            this.grpDeleted.PerformLayout();
            this.grpEnableDisable.ResumeLayout(false);
            this.grpEnableDisable.PerformLayout();
            this.tabManagers.ResumeLayout(false);
            this.grpManagerActivation.ResumeLayout(false);
            this.grpManager.ResumeLayout(false);
            this.grpManager.PerformLayout();
            this.grpActive.ResumeLayout(false);
            this.grpActive.PerformLayout();
            this.grpAccDeleted.ResumeLayout(false);
            this.grpAccDeleted.PerformLayout();
            this.grpAccountEnable.ResumeLayout(false);
            this.grpAccountEnable.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).EndInit();
            this.tabDiscounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
            this.grpEditDiscount.ResumeLayout(false);
            this.grpEditDiscount.PerformLayout();
            this.grpCreateDiscount.ResumeLayout(false);
            this.grpCreateDiscount.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.grpSalesReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersForReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TabPage tabManagers;
        private System.Windows.Forms.TabPage tabDiscounts;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.GroupBox grpEditItem;
        private System.Windows.Forms.GroupBox grpAddItem;
        private System.Windows.Forms.TextBox tbxAddItemDesc;
        private System.Windows.Forms.TextBox tbxAddItemName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblItemQuantityEdit;
        private System.Windows.Forms.TextBox tbxEditItemName;
        private System.Windows.Forms.Label lblItemCostEdit;
        private System.Windows.Forms.TextBox tbxEditItemDesc;
        private System.Windows.Forms.Label lblRetailPriceEdit;
        private System.Windows.Forms.Label lblItemDescripEdit;
        private System.Windows.Forms.Label lblItemNameEdit;
        private System.Windows.Forms.Label lblItemQuantity;
        private System.Windows.Forms.Label lblItemCost;
        private System.Windows.Forms.Label lblItemRetailPrice;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button btnCancelItemEdit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnEditImage;
        private System.Windows.Forms.PictureBox pbxEditItemImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.PictureBox pbxAddItemImage;
        private System.Windows.Forms.GroupBox grpDiscontinuedItemEdit;
        private System.Windows.Forms.Label lblEditDisc;
        private System.Windows.Forms.CheckBox cbxEditDisc;
        private System.Windows.Forms.Label lblEditGenre;
        private System.Windows.Forms.TextBox tbxEditGenre;
        private System.Windows.Forms.GroupBox grpAddDisc;
        private System.Windows.Forms.Label lblAddItemDiscon;
        private System.Windows.Forms.CheckBox cbxAddDiscontinued;
        private System.Windows.Forms.Label lblItemGenre;
        private System.Windows.Forms.TextBox tbxAddItemGenre;
        private System.Windows.Forms.TextBox tbxEditItemQuantity;
        private System.Windows.Forms.TextBox tbxEditItemCost;
        private System.Windows.Forms.TextBox tbxEditRetailPrice;
        private System.Windows.Forms.TextBox tbxAddItemQuantity;
        private System.Windows.Forms.Button btnPrintInventory;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.GroupBox grpSearchCustomer;
        private System.Windows.Forms.GroupBox grpPreviousCustomersOrders;
        private System.Windows.Forms.TextBox tbxCustomerSearchEmail;
        private System.Windows.Forms.Label lblCustEmail;
        private System.Windows.Forms.TextBox tbxSearchFirstName;
        private System.Windows.Forms.Label lblCustFirstName;
        private System.Windows.Forms.TextBox tbxSearchLastName;
        private System.Windows.Forms.Label lblCustLastName;
        private System.Windows.Forms.TextBox tbxMemberID;
        private System.Windows.Forms.Label lblMemberID;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvManagers;
        private System.Windows.Forms.GroupBox grpAccDelDisable;
        private System.Windows.Forms.GroupBox grpEnableDisable;
        private System.Windows.Forms.GroupBox grpDeleted;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkCustDeleted;
        private System.Windows.Forms.CheckBox chkCustEnabledDisabled;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEditManager;
        private System.Windows.Forms.Button btnDisplayInfo;
        private System.Windows.Forms.Button btnAddNewManager;
        private System.Windows.Forms.GroupBox grpManagerActivation;
        private System.Windows.Forms.Button btnSaveManager;
        private System.Windows.Forms.GroupBox grpAccDeleted;
        private System.Windows.Forms.CheckBox chkManagerDeleted;
        private System.Windows.Forms.GroupBox grpAccountEnable;
        private System.Windows.Forms.CheckBox chkManagerEnabled;
        private System.Windows.Forms.Label lblManagerSalary;
        private System.Windows.Forms.Button btnApplyManagerSalary;
        private System.Windows.Forms.GroupBox grpManager;
        private System.Windows.Forms.CheckBox chkIsManager;
        private System.Windows.Forms.GroupBox grpActive;
        private System.Windows.Forms.CheckBox chkManagerActive;
        private System.Windows.Forms.GroupBox grpCreateDiscount;
        private System.Windows.Forms.ComboBox cbxAvailableItems;
        private System.Windows.Forms.Label lblAvailableItems;
        private System.Windows.Forms.Label lblDiscountPercentage;
        private System.Windows.Forms.ComboBox cbxDiscAmount;
        private System.Windows.Forms.Label lblDiscountDescription;
        private System.Windows.Forms.TextBox tbxNewDiscountDescription;
        private System.Windows.Forms.GroupBox grpEditDiscount;
        private System.Windows.Forms.Label lblExpDateEdit;
        private System.Windows.Forms.DateTimePicker dtpExpDateEdit;
        private System.Windows.Forms.Label lblDiscPercEdit;
        private System.Windows.Forms.ComboBox cbxDiscAmountEdit;
        private System.Windows.Forms.Label lblDiscountDescEdit;
        private System.Windows.Forms.TextBox tbxDiscountDescriptionEdit;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Label lblAvailableItemEdit;
        private System.Windows.Forms.ComboBox cbxAvailableItemEdit;
        private System.Windows.Forms.Button btnCancelDiscountEdit;
        private System.Windows.Forms.Button btnEditDiscount;
        private System.Windows.Forms.Button btnCancelDiscountCreation;
        private System.Windows.Forms.Button btnSaveDiscount;
        private System.Windows.Forms.DataGridView dgvDiscounts;
        private System.Windows.Forms.GroupBox grpSalesReports;
        private System.Windows.Forms.DateTimePicker dtpReports;
        private System.Windows.Forms.Button btnDaily;
        private System.Windows.Forms.Button btnMonthly;
        private System.Windows.Forms.Button btnWeekly;
        private System.Windows.Forms.DataGridView dgvOrdersForReports;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox tbxAddItemCost;
        private System.Windows.Forms.TextBox tbxAddItemPrice;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox grpSearchItem;
        private System.Windows.Forms.TextBox tbxSearchItemName;
        private System.Windows.Forms.Label lblSearchItemName;
        private System.Windows.Forms.TextBox tbxSearchInventoryID;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.TextBox tbxSearchGenre;
        private System.Windows.Forms.Label lblSearchGenre;
        private System.Windows.Forms.TextBox tbxSalary;
    }
}