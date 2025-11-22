namespace QLCafe.Presentation.Controls.Table
{
    partial class TableManagementControl
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
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnEditDish = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.listBoxOrderItems = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.listBoxItems);
            this.panelMain.Controls.Add(this.btnDeleteTable);
            this.panelMain.Controls.Add(this.btnEditDish);
            this.panelMain.Controls.Add(this.lblTotalAmount);
            this.panelMain.Controls.Add(this.listBoxOrderItems);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Controls.Add(this.lblTableName);
            this.panelMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMain.Location = new System.Drawing.Point(8, 8);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(332, 155);
            this.panelMain.TabIndex = 1;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // listBoxItems
            // 
            this.listBoxItems.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(11, 28);
            this.listBoxItems.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(307, 43);
            this.listBoxItems.TabIndex = 9;
            this.listBoxItems.Visible = false;
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.BackColor = System.Drawing.Color.Red;
            this.btnDeleteTable.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTable.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeleteTable.Location = new System.Drawing.Point(215, 119);
            this.btnDeleteTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(89, 27);
            this.btnDeleteTable.TabIndex = 8;
            this.btnDeleteTable.Text = "Xóa";
            this.btnDeleteTable.UseVisualStyleBackColor = false;
            this.btnDeleteTable.Visible = false;
            // 
            // btnEditDish
            // 
            this.btnEditDish.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEditDish.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDish.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditDish.Location = new System.Drawing.Point(24, 119);
            this.btnEditDish.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditDish.Name = "btnEditDish";
            this.btnEditDish.Size = new System.Drawing.Size(89, 27);
            this.btnEditDish.TabIndex = 7;
            this.btnEditDish.Text = "Sửa";
            this.btnEditDish.UseVisualStyleBackColor = false;
            this.btnEditDish.Visible = false;
            this.btnEditDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(8, 79);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(59, 15);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "Tổng: 0 đ";
            this.lblTotalAmount.Visible = false;
            // 
            // listBoxOrderItems
            // 
            this.listBoxOrderItems.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOrderItems.FormattingEnabled = true;
            this.listBoxOrderItems.Location = new System.Drawing.Point(11, 25);
            this.listBoxOrderItems.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxOrderItems.Name = "listBoxOrderItems";
            this.listBoxOrderItems.Size = new System.Drawing.Size(307, 43);
            this.listBoxOrderItems.TabIndex = 4;
            this.listBoxOrderItems.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(267, 9);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trống";
            // 
            // lblTableName
            // 
            this.lblTableName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(8, 4);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(67, 19);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "Bàn 1";
            // 
            // TableManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "TableManagementControl";
            this.Size = new System.Drawing.Size(388, 188);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnEditDish;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.ListBox listBoxOrderItems;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.ListBox listBoxItems;
    }
}
