namespace QLCafe.Presentation.Controls.Table
{
    partial class TableManagementControl2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel cardPanel; // switched from RoundedPanel to Panel
        private System.Windows.Forms.Label lblTableName;
        private QLCafe.Presentation.Components.RoundedPanel statusPill;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalAmount;

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
            this.cardPanel = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.statusPill = new QLCafe.Presentation.Components.RoundedPanel();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.itemsPanel = new System.Windows.Forms.Panel();
            this.lblItems = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.cardPanel.SuspendLayout();
            this.statusPill.SuspendLayout();
            this.itemsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.White;
            this.cardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanel.Controls.Add(this.btnDelete);
            this.cardPanel.Controls.Add(this.btnEdit);
            this.cardPanel.Controls.Add(this.statusPill);
            this.cardPanel.Controls.Add(this.lblTableName);
            this.cardPanel.Controls.Add(this.itemsPanel);
            this.cardPanel.Controls.Add(this.separator);
            this.cardPanel.Controls.Add(this.lblTotalLabel);
            this.cardPanel.Controls.Add(this.lblTotalAmount);
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(0, 0);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Padding = new System.Windows.Forms.Padding(16);
            this.cardPanel.Size = new System.Drawing.Size(520, 180);
            this.cardPanel.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(432, 16);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 28);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(141)))), ((int)(((byte)(241)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(352, 16);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 28);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // statusPill
            // 
            this.statusPill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.statusPill.BorderColor = System.Drawing.Color.Transparent;
            this.statusPill.BorderThickness = 0;
            this.statusPill.Controls.Add(this.lblStatusText);
            this.statusPill.CornerRadius = 12;
            this.statusPill.Location = new System.Drawing.Point(20, 48);
            this.statusPill.Name = "statusPill";
            this.statusPill.Size = new System.Drawing.Size(90, 28);
            this.statusPill.TabIndex = 4;
            // 
            // lblStatusText
            // 
            this.lblStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblStatusText.Location = new System.Drawing.Point(0, 0);
            this.lblStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(90, 28);
            this.lblStatusText.TabIndex = 0;
            this.lblStatusText.Text = "Có khách";
            this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTableName.Location = new System.Drawing.Point(16, 16);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(83, 32);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Bàn 11";
            // 
            // itemsPanel
            // 
            this.itemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.itemsPanel.Controls.Add(this.lblItems);
            this.itemsPanel.Location = new System.Drawing.Point(20, 84);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.itemsPanel.Size = new System.Drawing.Size(484, 42);
            this.itemsPanel.TabIndex = 2;
            // 
            // lblItems
            // 
            this.lblItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblItems.Location = new System.Drawing.Point(8, 6);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(468, 30);
            this.lblItems.TabIndex = 0;
            this.lblItems.Text = "Cà phê Sữa x2\r\nCà phê Đen x2";
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.BackColor = System.Drawing.Color.Gainsboro;
            this.separator.Location = new System.Drawing.Point(20, 132);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(484, 1);
            this.separator.TabIndex = 3;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 140);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(53, 23);
            this.lblTotalLabel.TabIndex = 7;
            this.lblTotalLabel.Text = "Tổng:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(420, 140);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(91, 23);
            this.lblTotalAmount.TabIndex = 8;
            this.lblTotalAmount.Text = "110.000 đ";
            // 
            // TableManagementControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cardPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "TableManagementControl2";
            this.Size = new System.Drawing.Size(520, 180);
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.statusPill.ResumeLayout(false);
            this.itemsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
