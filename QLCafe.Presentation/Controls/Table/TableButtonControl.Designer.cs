namespace QLCafe.Presentation.Controls.Table
{
    partial class TableButtonControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnCreateBill = new System.Windows.Forms.Button();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.listBoxOrderItems = new System.Windows.Forms.ListBox();
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.btnCreateBill);
            this.panelMain.Controls.Add(this.btnSwitchTable);
            this.panelMain.Controls.Add(this.btnAddDish);
            this.panelMain.Controls.Add(this.lblTotalAmount);
            this.panelMain.Controls.Add(this.listBoxOrderItems);
            this.panelMain.Controls.Add(this.lblOrderInfo);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.lblTableName);
            this.panelMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(498, 221);
            this.panelMain.TabIndex = 0;
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBill.Location = new System.Drawing.Point(343, 160);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(133, 41);
            this.btnCreateBill.TabIndex = 9;
            this.btnCreateBill.Text = "Thanh toán";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Visible = false;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchTable.Location = new System.Drawing.Point(182, 160);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(133, 41);
            this.btnSwitchTable.TabIndex = 8;
            this.btnSwitchTable.Text = "Chuyển bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Visible = false;
            // 
            // btnAddDish
            // 
            this.btnAddDish.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDish.Location = new System.Drawing.Point(17, 160);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(133, 41);
            this.btnAddDish.TabIndex = 7;
            this.btnAddDish.Text = "Thêm món";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Visible = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(12, 121);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(92, 25);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "Tổng: 0 đ";
            this.lblTotalAmount.Visible = false;
            // 
            // listBoxOrderItems
            // 
            this.listBoxOrderItems.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOrderItems.FormattingEnabled = true;
            this.listBoxOrderItems.ItemHeight = 21;
            this.listBoxOrderItems.Location = new System.Drawing.Point(17, 38);
            this.listBoxOrderItems.Name = "listBoxOrderItems";
            this.listBoxOrderItems.Size = new System.Drawing.Size(459, 67);
            this.listBoxOrderItems.TabIndex = 4;
            this.listBoxOrderItems.Visible = false;
            // 
            // lblOrderInfo
            // 
            this.lblOrderInfo.AutoSize = true;
            this.lblOrderInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblOrderInfo.Location = new System.Drawing.Point(178, 96);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(126, 20);
            this.lblOrderInfo.TabIndex = 3;
            this.lblOrderInfo.Text = "+ Nhấn để Order";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(401, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 21);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trống";
            // 
            // lblTableName
            // 
            this.lblTableName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(12, 6);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(100, 29);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "Bàn 1";
            // 
            // TableButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "TableButtonControl";
            this.Size = new System.Drawing.Size(498, 221);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblOrderInfo;
        private System.Windows.Forms.ListBox listBoxOrderItems;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Button btnSwitchTable;
    }
}
