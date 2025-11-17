namespace QLCafe.Presentation.Controls.Table
{
    partial class OrderItemControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.PictureBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.lblTotalPrice);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.btnIncrease);
            this.panel1.Controls.Add(this.btnDecrease);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 122);
            this.panel1.TabIndex = 0;
            // 
            // btnDecrease
            // 
            this.btnDecrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnDecrease.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecrease.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrease.Location = new System.Drawing.Point(7, 39);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(31, 30);
            this.btnDecrease.TabIndex = 0;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = false;
            // 
            // btnIncrease
            // 
            this.btnIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.btnIncrease.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIncrease.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrease.ForeColor = System.Drawing.Color.White;
            this.btnIncrease.Location = new System.Drawing.Point(69, 39);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(31, 30);
            this.btnIncrease.TabIndex = 1;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(3, 12);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(93, 21);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Cà phê sữa";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(44, 43);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(19, 21);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "1";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(258, 48);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(55, 21);
            this.lblTotalPrice.TabIndex = 4;
            this.lblTotalPrice.Text = "20000";
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::QLCafe.Presentation.Properties.Resources.Delete_icon;
            this.btnRemove.Location = new System.Drawing.Point(296, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 42);
            this.btnRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRemove.TabIndex = 5;
            this.btnRemove.TabStop = false;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(7, 76);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(348, 26);
            this.txtNote.TabIndex = 6;
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            this.txtNote.Enter += new System.EventHandler(this.txtNote_Enter);
            this.txtNote.Leave += new System.EventHandler(this.txtNote_Leave);
            // 
            // OrderItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "OrderItemControl";
            this.Size = new System.Drawing.Size(370, 122);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.PictureBox btnRemove;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox txtNote;
    }
}
