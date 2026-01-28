namespace QLCafe.Presentation.Views.Inventory
{
    partial class StockInHistoryForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBank = new System.Windows.Forms.Button();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.btnMomo = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.label2.Location = new System.Drawing.Point(-242, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1288, 2);
            this.label2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.label1.Image = global::QLCafe.Presentation.Properties.Resources.Screenshot_2026_01_28_125602_removebg_preview;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-246, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng Kết Phiếu Nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBank
            // 
            this.btnBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBank.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBank.Location = new System.Drawing.Point(469, 75);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(131, 32);
            this.btnBank.TabIndex = 30;
            this.btnBank.Text = "Chuyển khoản";
            this.btnBank.UseVisualStyleBackColor = true;
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTitle.Location = new System.Drawing.Point(179, 47);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(210, 25);
            this.lblPaymentTitle.TabIndex = 26;
            this.lblPaymentTitle.Text = "Phương thức thanh toán:";
            // 
            // btnMomo
            // 
            this.btnMomo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMomo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMomo.Location = new System.Drawing.Point(370, 75);
            this.btnMomo.Name = "btnMomo";
            this.btnMomo.Size = new System.Drawing.Size(91, 32);
            this.btnMomo.TabIndex = 29;
            this.btnMomo.Text = "Momo";
            this.btnMomo.UseVisualStyleBackColor = true;
            // 
            // btnCash
            // 
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.Location = new System.Drawing.Point(176, 76);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(91, 32);
            this.btnCash.TabIndex = 27;
            this.btnCash.Text = "Tiền mặt";
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // btnCard
            // 
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCard.Location = new System.Drawing.Point(273, 75);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(91, 32);
            this.btnCard.TabIndex = 28;
            this.btnCard.Text = "Thẻ";
            this.btnCard.UseVisualStyleBackColor = true;
            // 
            // StockInHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.lblPaymentTitle);
            this.Controls.Add(this.btnMomo);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StockInHistoryForm";
            this.Text = "StockInHistoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Button btnMomo;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnCard;
    }
}