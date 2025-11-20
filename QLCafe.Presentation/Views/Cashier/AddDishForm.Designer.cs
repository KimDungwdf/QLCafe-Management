namespace QLCafe.Presentation.Views.Cashier
{
    partial class AddDishForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTableNameHeader = new System.Windows.Forms.Label();
            this.lblHeaderPrefix = new System.Windows.Forms.Label();
            this.PanelContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.bttSend = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmptyOrder = new System.Windows.Forms.Label();
            this.lblCurrentOrde = new System.Windows.Forms.Label();
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.flowLayoutProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.PanelContent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.PanelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.lblTableNameHeader);
            this.panel1.Controls.Add(this.lblHeaderPrefix);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 68);
            this.panel1.TabIndex = 1;
            // 
            // lblTableNameHeader
            // 
            this.lblTableNameHeader.AutoSize = true;
            this.lblTableNameHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNameHeader.ForeColor = System.Drawing.Color.White;
            this.lblTableNameHeader.Location = new System.Drawing.Point(206, 9);
            this.lblTableNameHeader.Name = "lblTableNameHeader";
            this.lblTableNameHeader.Size = new System.Drawing.Size(104, 45);
            this.lblTableNameHeader.TabIndex = 1;
            this.lblTableNameHeader.Text = "Bàn 1";
            // 
            // lblHeaderPrefix
            // 
            this.lblHeaderPrefix.AutoSize = true;
            this.lblHeaderPrefix.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPrefix.ForeColor = System.Drawing.Color.White;
            this.lblHeaderPrefix.Location = new System.Drawing.Point(12, 9);
            this.lblHeaderPrefix.Name = "lblHeaderPrefix";
            this.lblHeaderPrefix.Size = new System.Drawing.Size(203, 45);
            this.lblHeaderPrefix.TabIndex = 0;
            this.lblHeaderPrefix.Text = "Thêm món -";
            // 
            // PanelContent
            // 
            this.PanelContent.BackColor = System.Drawing.Color.White;
            this.PanelContent.Controls.Add(this.panel3);
            this.PanelContent.Controls.Add(this.PanelLeft);
            this.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContent.Location = new System.Drawing.Point(0, 68);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(878, 476);
            this.PanelContent.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutOrderItems);
            this.panel3.Controls.Add(this.panelFooter);
            this.panel3.Controls.Add(this.lblEmptyOrder);
            this.panel3.Controls.Add(this.lblCurrentOrde);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(428, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(450, 476);
            this.panel3.TabIndex = 1;
            // 
            // flowLayoutOrderItems
            // 
            this.flowLayoutOrderItems.AutoScroll = true;
            this.flowLayoutOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutOrderItems.Location = new System.Drawing.Point(10, 39);
            this.flowLayoutOrderItems.Name = "flowLayoutOrderItems";
            this.flowLayoutOrderItems.Size = new System.Drawing.Size(430, 327);
            this.flowLayoutOrderItems.TabIndex = 4;
            this.flowLayoutOrderItems.Visible = false;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.bttSend);
            this.panelFooter.Controls.Add(this.lblTotalAmount);
            this.panelFooter.Controls.Add(this.label2);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(10, 366);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(430, 100);
            this.panelFooter.TabIndex = 3;
            this.panelFooter.Visible = false;
            // 
            // bttSend
            // 
            this.bttSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bttSend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttSend.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bttSend.Location = new System.Drawing.Point(8, 44);
            this.bttSend.Name = "bttSend";
            this.bttSend.Size = new System.Drawing.Size(411, 53);
            this.bttSend.TabIndex = 6;
            this.bttSend.Text = "Xác nhận và gửi xuống bếp";
            this.bttSend.UseVisualStyleBackColor = false;
            this.bttSend.Click += new System.EventHandler(this.bttSend_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(299, 13);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(72, 28);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "20000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng cộng:";
            // 
            // lblEmptyOrder
            // 
            this.lblEmptyOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmptyOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmptyOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblEmptyOrder.Location = new System.Drawing.Point(10, 39);
            this.lblEmptyOrder.Name = "lblEmptyOrder";
            this.lblEmptyOrder.Size = new System.Drawing.Size(430, 427);
            this.lblEmptyOrder.TabIndex = 2;
            this.lblEmptyOrder.Text = "Chưa có món nào được chọn";
            this.lblEmptyOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentOrde
            // 
            this.lblCurrentOrde.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentOrde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentOrde.Location = new System.Drawing.Point(10, 10);
            this.lblCurrentOrde.Name = "lblCurrentOrde";
            this.lblCurrentOrde.Size = new System.Drawing.Size(430, 29);
            this.lblCurrentOrde.TabIndex = 1;
            this.lblCurrentOrde.Text = "Order hiện tại";
            // 
            // PanelLeft
            // 
            this.PanelLeft.Controls.Add(this.flowLayoutProducts);
            this.PanelLeft.Controls.Add(this.label1);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.PanelLeft.Size = new System.Drawing.Size(428, 476);
            this.PanelLeft.TabIndex = 0;
            // 
            // flowLayoutProducts
            // 
            this.flowLayoutProducts.AutoScroll = true;
            this.flowLayoutProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutProducts.Location = new System.Drawing.Point(10, 39);
            this.flowLayoutProducts.Name = "flowLayoutProducts";
            this.flowLayoutProducts.Size = new System.Drawing.Size(408, 427);
            this.flowLayoutProducts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn món";
            // 
            // AddDishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.PanelContent);
            this.Controls.Add(this.panel1);
            this.Name = "AddDishForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDishForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelContent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.PanelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTableNameHeader;
        private System.Windows.Forms.Label lblHeaderPrefix;
        private System.Windows.Forms.Panel PanelContent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOrderItems;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button bttSend;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmptyOrder;
        private System.Windows.Forms.Label lblCurrentOrde;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutProducts;
        private System.Windows.Forms.Label label1;
    }
}