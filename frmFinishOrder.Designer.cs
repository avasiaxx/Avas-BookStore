
namespace FA21_Final_Project
{
    partial class frmFinishOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinishOrder));
            this.grpReview = new System.Windows.Forms.GroupBox();
            this.lblDiscountedSubtotal = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblActualDiscountAmount = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblDiscountPercentage = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grpPaymentInfo = new System.Windows.Forms.GroupBox();
            this.lblErrorCCV = new System.Windows.Forms.Label();
            this.lblErrorExpDate = new System.Windows.Forms.Label();
            this.lblErrorCC = new System.Windows.Forms.Label();
            this.mskCCV = new System.Windows.Forms.MaskedTextBox();
            this.lblCCV = new System.Windows.Forms.Label();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.mskCC = new System.Windows.Forms.MaskedTextBox();
            this.lblCC = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblFinishOrderError = new System.Windows.Forms.Label();
            this.grpReview.SuspendLayout();
            this.grpPaymentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReview
            // 
            this.grpReview.BackColor = System.Drawing.Color.Silver;
            this.grpReview.Controls.Add(this.lblDiscountedSubtotal);
            this.grpReview.Controls.Add(this.lblSubTotal);
            this.grpReview.Controls.Add(this.lblActualDiscountAmount);
            this.grpReview.Controls.Add(this.lblTax);
            this.grpReview.Controls.Add(this.lblDiscountPercentage);
            this.grpReview.Controls.Add(this.lblTotal);
            this.grpReview.Location = new System.Drawing.Point(367, 59);
            this.grpReview.Name = "grpReview";
            this.grpReview.Size = new System.Drawing.Size(320, 226);
            this.grpReview.TabIndex = 0;
            this.grpReview.TabStop = false;
            this.grpReview.Text = "Order Review";
            // 
            // lblDiscountedSubtotal
            // 
            this.lblDiscountedSubtotal.AutoSize = true;
            this.lblDiscountedSubtotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountedSubtotal.Location = new System.Drawing.Point(13, 121);
            this.lblDiscountedSubtotal.Name = "lblDiscountedSubtotal";
            this.lblDiscountedSubtotal.Size = new System.Drawing.Size(155, 18);
            this.lblDiscountedSubtotal.TabIndex = 34;
            this.lblDiscountedSubtotal.Text = "Discounted SubTotal:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(96, 43);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(72, 18);
            this.lblSubTotal.TabIndex = 29;
            this.lblSubTotal.Text = "SubTotal:";
            // 
            // lblActualDiscountAmount
            // 
            this.lblActualDiscountAmount.AutoSize = true;
            this.lblActualDiscountAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualDiscountAmount.Location = new System.Drawing.Point(32, 95);
            this.lblActualDiscountAmount.Name = "lblActualDiscountAmount";
            this.lblActualDiscountAmount.Size = new System.Drawing.Size(136, 18);
            this.lblActualDiscountAmount.TabIndex = 33;
            this.lblActualDiscountAmount.Text = "Amount Removed:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(125, 147);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(35, 18);
            this.lblTax.TabIndex = 30;
            this.lblTax.Text = "Tax:";
            // 
            // lblDiscountPercentage
            // 
            this.lblDiscountPercentage.AutoSize = true;
            this.lblDiscountPercentage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountPercentage.Location = new System.Drawing.Point(10, 69);
            this.lblDiscountPercentage.Name = "lblDiscountPercentage";
            this.lblDiscountPercentage.Size = new System.Drawing.Size(158, 18);
            this.lblDiscountPercentage.TabIndex = 32;
            this.lblDiscountPercentage.Text = "Discount Percentage:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(124, 173);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 18);
            this.lblTotal.TabIndex = 31;
            this.lblTotal.Text = "Total:";
            // 
            // grpPaymentInfo
            // 
            this.grpPaymentInfo.BackColor = System.Drawing.Color.Silver;
            this.grpPaymentInfo.Controls.Add(this.lblErrorCCV);
            this.grpPaymentInfo.Controls.Add(this.lblErrorExpDate);
            this.grpPaymentInfo.Controls.Add(this.lblErrorCC);
            this.grpPaymentInfo.Controls.Add(this.mskCCV);
            this.grpPaymentInfo.Controls.Add(this.lblCCV);
            this.grpPaymentInfo.Controls.Add(this.dtpExpDate);
            this.grpPaymentInfo.Controls.Add(this.lblExpDate);
            this.grpPaymentInfo.Controls.Add(this.mskCC);
            this.grpPaymentInfo.Controls.Add(this.lblCC);
            this.grpPaymentInfo.Location = new System.Drawing.Point(16, 59);
            this.grpPaymentInfo.Name = "grpPaymentInfo";
            this.grpPaymentInfo.Size = new System.Drawing.Size(345, 226);
            this.grpPaymentInfo.TabIndex = 1;
            this.grpPaymentInfo.TabStop = false;
            this.grpPaymentInfo.Text = "Payment Info";
            // 
            // lblErrorCCV
            // 
            this.lblErrorCCV.AutoSize = true;
            this.lblErrorCCV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCCV.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCCV.Location = new System.Drawing.Point(70, 133);
            this.lblErrorCCV.Name = "lblErrorCCV";
            this.lblErrorCCV.Size = new System.Drawing.Size(14, 18);
            this.lblErrorCCV.TabIndex = 44;
            this.lblErrorCCV.Text = "*";
            this.lblErrorCCV.Visible = false;
            // 
            // lblErrorExpDate
            // 
            this.lblErrorExpDate.AutoSize = true;
            this.lblErrorExpDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorExpDate.ForeColor = System.Drawing.Color.Red;
            this.lblErrorExpDate.Location = new System.Drawing.Point(3, 93);
            this.lblErrorExpDate.Name = "lblErrorExpDate";
            this.lblErrorExpDate.Size = new System.Drawing.Size(14, 18);
            this.lblErrorExpDate.TabIndex = 43;
            this.lblErrorExpDate.Text = "*";
            this.lblErrorExpDate.Visible = false;
            // 
            // lblErrorCC
            // 
            this.lblErrorCC.AutoSize = true;
            this.lblErrorCC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCC.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCC.Location = new System.Drawing.Point(20, 63);
            this.lblErrorCC.Name = "lblErrorCC";
            this.lblErrorCC.Size = new System.Drawing.Size(14, 18);
            this.lblErrorCC.TabIndex = 42;
            this.lblErrorCC.Text = "*";
            this.lblErrorCC.Visible = false;
            // 
            // mskCCV
            // 
            this.mskCCV.Location = new System.Drawing.Point(140, 133);
            this.mskCCV.Mask = "000";
            this.mskCCV.Name = "mskCCV";
            this.mskCCV.Size = new System.Drawing.Size(38, 29);
            this.mskCCV.TabIndex = 3;
            this.mskCCV.Click += new System.EventHandler(this.mskCCV_Click);
            // 
            // lblCCV
            // 
            this.lblCCV.AutoSize = true;
            this.lblCCV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCV.Location = new System.Drawing.Point(84, 133);
            this.lblCCV.Name = "lblCCV";
            this.lblCCV.Size = new System.Drawing.Size(50, 18);
            this.lblCCV.TabIndex = 40;
            this.lblCCV.Text = "CCV: ";
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpDate.Location = new System.Drawing.Point(140, 98);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new System.Drawing.Size(121, 29);
            this.dtpExpDate.TabIndex = 2;
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpDate.Location = new System.Drawing.Point(14, 98);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(120, 18);
            this.lblExpDate.TabIndex = 36;
            this.lblExpDate.Text = "Expiration Date:";
            // 
            // mskCC
            // 
            this.mskCC.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskCC.Location = new System.Drawing.Point(140, 63);
            this.mskCC.Mask = "0000 0000 0000 0000";
            this.mskCC.Name = "mskCC";
            this.mskCC.Size = new System.Drawing.Size(197, 29);
            this.mskCC.TabIndex = 1;
            this.mskCC.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskCC.Click += new System.EventHandler(this.mskCC_Click);
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCC.Location = new System.Drawing.Point(40, 63);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(94, 18);
            this.lblCC.TabIndex = 22;
            this.lblCC.Text = "Credit Card:";
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(96, 306);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(161, 33);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "Finish Order";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(191)))), ((int)(((byte)(161)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(452, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.Red;
            this.btnHelp.Location = new System.Drawing.Point(631, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(59, 30);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblFinishOrderError
            // 
            this.lblFinishOrderError.AutoSize = true;
            this.lblFinishOrderError.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishOrderError.ForeColor = System.Drawing.Color.Red;
            this.lblFinishOrderError.Location = new System.Drawing.Point(56, 38);
            this.lblFinishOrderError.Name = "lblFinishOrderError";
            this.lblFinishOrderError.Size = new System.Drawing.Size(14, 18);
            this.lblFinishOrderError.TabIndex = 45;
            this.lblFinishOrderError.Text = "*";
            this.lblFinishOrderError.Visible = false;
            // 
            // frmFinishOrder
            // 
            this.AcceptButton = this.btnFinish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(206)))), ((int)(((byte)(208)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(702, 353);
            this.Controls.Add(this.lblFinishOrderError);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grpPaymentInfo);
            this.Controls.Add(this.grpReview);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "frmFinishOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finish Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFinishOrder_FormClosing);
            this.grpReview.ResumeLayout(false);
            this.grpReview.PerformLayout();
            this.grpPaymentInfo.ResumeLayout(false);
            this.grpPaymentInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReview;
        private System.Windows.Forms.GroupBox grpPaymentInfo;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.Label lblDiscountedSubtotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblActualDiscountAmount;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblDiscountPercentage;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MaskedTextBox mskCC;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.MaskedTextBox mskCCV;
        private System.Windows.Forms.Label lblCCV;
        private System.Windows.Forms.Label lblErrorCCV;
        private System.Windows.Forms.Label lblErrorExpDate;
        private System.Windows.Forms.Label lblErrorCC;
        private System.Windows.Forms.Label lblFinishOrderError;
    }
}