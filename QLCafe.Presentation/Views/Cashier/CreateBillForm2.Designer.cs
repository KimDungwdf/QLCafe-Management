namespace QLCafe.Presentation.Views.Cashier
{
    partial class CreateBillForm2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlReceipt = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblSeeYou = new System.Windows.Forms.Label();
            this.lblThanks = new System.Windows.Forms.Label();
            this.lblFinalSeparator = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.btnConfirmCheckout = new System.Windows.Forms.Button();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBank = new System.Windows.Forms.Button();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.btnMomo = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.pnlCalc = new System.Windows.Forms.Panel();
            this.pnlDiscountInputBorder = new System.Windows.Forms.Panel();
            this.txtDiscountInput = new System.Windows.Forms.TextBox();
            this.lblDiscountHint = new System.Windows.Forms.Label();
            this.lblGrandTotalValue = new System.Windows.Forms.Label();
            this.lblGrandTotalText = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.lblDiscountText = new System.Windows.Forms.Label();
            this.lblSubTotalValue = new System.Windows.Forms.Label();
            this.lblSubTotalText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBillId = new System.Windows.Forms.Label();
            this.lblIdLabel = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblDateLabel = new System.Windows.Forms.Label();
            this.lblCashierName = new System.Windows.Forms.Label();
            this.lblCashierLabel = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblTableLabel = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlReceipt.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlCalc.SuspendLayout();
            this.pnlDiscountInputBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReceipt
            // 
            this.pnlReceipt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlReceipt.AutoScroll = true;
            this.pnlReceipt.BackColor = System.Drawing.Color.White;
            this.pnlReceipt.Controls.Add(this.pnlFooter);
            this.pnlReceipt.Controls.Add(this.pnlActions);
            this.pnlReceipt.Controls.Add(this.pnlPayment);
            this.pnlReceipt.Controls.Add(this.pnlCalc);
            this.pnlReceipt.Controls.Add(this.dgvItems);
            this.pnlReceipt.Controls.Add(this.pnlInfo);
            this.pnlReceipt.Controls.Add(this.pnlHeader);
            this.pnlReceipt.Location = new System.Drawing.Point(182, 12);
            this.pnlReceipt.Name = "pnlReceipt";
            this.pnlReceipt.Size = new System.Drawing.Size(450, 952);
            this.pnlReceipt.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblSeeYou);
            this.pnlFooter.Controls.Add(this.lblThanks);
            this.pnlFooter.Controls.Add(this.lblFinalSeparator);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooter.Location = new System.Drawing.Point(0, 869);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(450, 73);
            this.pnlFooter.TabIndex = 6;
            // 
            // lblSeeYou
            // 
            this.lblSeeYou.AutoSize = true;
            this.lblSeeYou.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeeYou.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblSeeYou.Location = new System.Drawing.Point(176, 47);
            this.lblSeeYou.Name = "lblSeeYou";
            this.lblSeeYou.Size = new System.Drawing.Size(93, 21);
            this.lblSeeYou.TabIndex = 22;
            this.lblSeeYou.Text = "Hẹn gặp lại!";
            this.lblSeeYou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThanks
            // 
            this.lblThanks.AutoSize = true;
            this.lblThanks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblThanks.Location = new System.Drawing.Point(105, 22);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(253, 25);
            this.lblThanks.TabIndex = 21;
            this.lblThanks.Text = "*** CẢM ƠN QUÝ KHÁCH ***\"";
            this.lblThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinalSeparator
            // 
            this.lblFinalSeparator.BackColor = System.Drawing.Color.White;
            this.lblFinalSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFinalSeparator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalSeparator.Location = new System.Drawing.Point(0, 0);
            this.lblFinalSeparator.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblFinalSeparator.Name = "lblFinalSeparator";
            this.lblFinalSeparator.Size = new System.Drawing.Size(450, 22);
            this.lblFinalSeparator.TabIndex = 0;
            this.lblFinalSeparator.Text = "--------------------------------------------------------------";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnPrintInvoice);
            this.pnlActions.Controls.Add(this.btnConfirmCheckout);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 763);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.pnlActions.Size = new System.Drawing.Size(450, 106);
            this.pnlActions.TabIndex = 5;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrintInvoice.FlatAppearance.BorderSize = 2;
            this.btnPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.Black;
            this.btnPrintInvoice.Location = new System.Drawing.Point(10, 47);
            this.btnPrintInvoice.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(430, 48);
            this.btnPrintInvoice.TabIndex = 1;
            this.btnPrintInvoice.Text = "In hóa đơn";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            // 
            // btnConfirmCheckout
            // 
            this.btnConfirmCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnConfirmCheckout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfirmCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmCheckout.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCheckout.Location = new System.Drawing.Point(10, 0);
            this.btnConfirmCheckout.Name = "btnConfirmCheckout";
            this.btnConfirmCheckout.Size = new System.Drawing.Size(430, 47);
            this.btnConfirmCheckout.TabIndex = 0;
            this.btnConfirmCheckout.Text = "THANH TOÁN";
            this.btnConfirmCheckout.UseVisualStyleBackColor = false;
            // 
            // pnlPayment
            // 
            this.pnlPayment.Controls.Add(this.panel1);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPayment.Location = new System.Drawing.Point(0, 663);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(450, 100);
            this.pnlPayment.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBank);
            this.panel1.Controls.Add(this.lblPaymentTitle);
            this.panel1.Controls.Add(this.btnMomo);
            this.panel1.Controls.Add(this.btnCash);
            this.panel1.Controls.Add(this.btnCard);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 102);
            this.panel1.TabIndex = 27;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnBank
            // 
            this.btnBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBank.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBank.Location = new System.Drawing.Point(296, 52);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(131, 32);
            this.btnBank.TabIndex = 35;
            this.btnBank.Text = "Chuyển khoản";
            this.btnBank.UseVisualStyleBackColor = true;
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTitle.Location = new System.Drawing.Point(6, 10);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(210, 25);
            this.lblPaymentTitle.TabIndex = 31;
            this.lblPaymentTitle.Text = "Phương thức thanh toán:";
            // 
            // btnMomo
            // 
            this.btnMomo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMomo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMomo.Location = new System.Drawing.Point(197, 52);
            this.btnMomo.Name = "btnMomo";
            this.btnMomo.Size = new System.Drawing.Size(91, 32);
            this.btnMomo.TabIndex = 34;
            this.btnMomo.Text = "Momo";
            this.btnMomo.UseVisualStyleBackColor = true;
            // 
            // btnCash
            // 
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.Location = new System.Drawing.Point(3, 52);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(91, 32);
            this.btnCash.TabIndex = 32;
            this.btnCash.Text = "Tiền mặt";
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // btnCard
            // 
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCard.Location = new System.Drawing.Point(100, 52);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(91, 32);
            this.btnCard.TabIndex = 33;
            this.btnCard.Text = "Thẻ";
            this.btnCard.UseVisualStyleBackColor = true;
            // 
            // pnlCalc
            // 
            this.pnlCalc.Controls.Add(this.pnlDiscountInputBorder);
            this.pnlCalc.Controls.Add(this.lblGrandTotalValue);
            this.pnlCalc.Controls.Add(this.lblGrandTotalText);
            this.pnlCalc.Controls.Add(this.label7);
            this.pnlCalc.Controls.Add(this.lblDiscountValue);
            this.pnlCalc.Controls.Add(this.lblDiscountText);
            this.pnlCalc.Controls.Add(this.lblSubTotalValue);
            this.pnlCalc.Controls.Add(this.lblSubTotalText);
            this.pnlCalc.Controls.Add(this.label6);
            this.pnlCalc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCalc.Location = new System.Drawing.Point(0, 428);
            this.pnlCalc.Name = "pnlCalc";
            this.pnlCalc.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCalc.Size = new System.Drawing.Size(450, 235);
            this.pnlCalc.TabIndex = 3;
            // 
            // pnlDiscountInputBorder
            // 
            this.pnlDiscountInputBorder.Controls.Add(this.txtDiscountInput);
            this.pnlDiscountInputBorder.Controls.Add(this.lblDiscountHint);
            this.pnlDiscountInputBorder.Location = new System.Drawing.Point(13, 147);
            this.pnlDiscountInputBorder.Name = "pnlDiscountInputBorder";
            this.pnlDiscountInputBorder.Size = new System.Drawing.Size(430, 81);
            this.pnlDiscountInputBorder.TabIndex = 26;
            this.pnlDiscountInputBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDiscountInputBorder_Paint);
            // 
            // txtDiscountInput
            // 
            this.txtDiscountInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscountInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountInput.Location = new System.Drawing.Point(8, 39);
            this.txtDiscountInput.Name = "txtDiscountInput";
            this.txtDiscountInput.Size = new System.Drawing.Size(411, 24);
            this.txtDiscountInput.TabIndex = 21;
            this.txtDiscountInput.Text = "0";
            this.txtDiscountInput.TextChanged += new System.EventHandler(this.txtDiscountInput_TextChanged);
            // 
            // lblDiscountHint
            // 
            this.lblDiscountHint.AutoSize = true;
            this.lblDiscountHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountHint.Location = new System.Drawing.Point(3, 10);
            this.lblDiscountHint.Name = "lblDiscountHint";
            this.lblDiscountHint.Size = new System.Drawing.Size(159, 25);
            this.lblDiscountHint.TabIndex = 20;
            this.lblDiscountHint.Text = "Nhập giảm giá (đ):";
            // 
            // lblGrandTotalValue
            // 
            this.lblGrandTotalValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotalValue.Location = new System.Drawing.Point(325, 113);
            this.lblGrandTotalValue.Name = "lblGrandTotalValue";
            this.lblGrandTotalValue.Size = new System.Drawing.Size(107, 25);
            this.lblGrandTotalValue.TabIndex = 25;
            this.lblGrandTotalValue.Text = "225,000đ";
            this.lblGrandTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrandTotalText
            // 
            this.lblGrandTotalText.AutoSize = true;
            this.lblGrandTotalText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotalText.Location = new System.Drawing.Point(7, 110);
            this.lblGrandTotalText.Name = "lblGrandTotalText";
            this.lblGrandTotalText.Size = new System.Drawing.Size(137, 28);
            this.lblGrandTotalText.TabIndex = 24;
            this.lblGrandTotalText.Text = "TỔNG CỘNG:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(447, 23);
            this.label7.TabIndex = 23;
            this.label7.Text = "---------------------------------------------------------------------------------" +
    "------";
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountValue.Location = new System.Drawing.Point(267, 62);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(165, 25);
            this.lblDiscountValue.TabIndex = 22;
            this.lblDiscountValue.Text = "-0đ";
            this.lblDiscountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountText
            // 
            this.lblDiscountText.AutoSize = true;
            this.lblDiscountText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountText.Location = new System.Drawing.Point(3, 62);
            this.lblDiscountText.Name = "lblDiscountText";
            this.lblDiscountText.Size = new System.Drawing.Size(86, 25);
            this.lblDiscountText.TabIndex = 21;
            this.lblDiscountText.Text = "Giảm giá:";
            // 
            // lblSubTotalValue
            // 
            this.lblSubTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalValue.Location = new System.Drawing.Point(279, 23);
            this.lblSubTotalValue.Name = "lblSubTotalValue";
            this.lblSubTotalValue.Size = new System.Drawing.Size(158, 25);
            this.lblSubTotalValue.TabIndex = 20;
            this.lblSubTotalValue.Text = "225,000đ";
            this.lblSubTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotalText
            // 
            this.lblSubTotalText.AutoSize = true;
            this.lblSubTotalText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalText.Location = new System.Drawing.Point(3, 23);
            this.lblSubTotalText.Name = "lblSubTotalText";
            this.lblSubTotalText.Size = new System.Drawing.Size(85, 25);
            this.lblSubTotalText.TabIndex = 19;
            this.lblSubTotalText.Text = "Tạm tính:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(447, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "------";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.ColumnHeadersVisible = false;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colQty,
            this.colPrice,
            this.colTotal});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvItems.Location = new System.Drawing.Point(0, 278);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 62;
            this.dgvItems.RowTemplate.Height = 28;
            this.dgvItems.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(450, 150);
            this.dgvItems.TabIndex = 2;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.lblBillId);
            this.pnlInfo.Controls.Add(this.lblIdLabel);
            this.pnlInfo.Controls.Add(this.lblDateValue);
            this.pnlInfo.Controls.Add(this.lblDateLabel);
            this.pnlInfo.Controls.Add(this.lblCashierName);
            this.pnlInfo.Controls.Add(this.lblCashierLabel);
            this.pnlInfo.Controls.Add(this.lblTableName);
            this.pnlInfo.Controls.Add(this.lblTableLabel);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 109);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(450, 169);
            this.pnlInfo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(447, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "---------------------------------------------------------------------------------" +
    "------";
            // 
            // lblBillId
            // 
            this.lblBillId.AutoSize = true;
            this.lblBillId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillId.Location = new System.Drawing.Point(322, 122);
            this.lblBillId.Name = "lblBillId";
            this.lblBillId.Size = new System.Drawing.Size(110, 25);
            this.lblBillId.TabIndex = 16;
            this.lblBillId.Text = "#HD001234";
            // 
            // lblIdLabel
            // 
            this.lblIdLabel.AutoSize = true;
            this.lblIdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdLabel.Location = new System.Drawing.Point(3, 122);
            this.lblIdLabel.Name = "lblIdLabel";
            this.lblIdLabel.Size = new System.Drawing.Size(72, 25);
            this.lblIdLabel.TabIndex = 15;
            this.lblIdLabel.Text = "Mã HĐ:";
            // 
            // lblDateValue
            // 
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateValue.Location = new System.Drawing.Point(274, 80);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(158, 25);
            this.lblDateValue.TabIndex = 14;
            this.lblDateValue.Text = "21:31 28/01/2026";
            // 
            // lblDateLabel
            // 
            this.lblDateLabel.AutoSize = true;
            this.lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateLabel.Location = new System.Drawing.Point(3, 80);
            this.lblDateLabel.Name = "lblDateLabel";
            this.lblDateLabel.Size = new System.Drawing.Size(58, 25);
            this.lblDateLabel.TabIndex = 13;
            this.lblDateLabel.Text = "Ngày:";
            // 
            // lblCashierName
            // 
            this.lblCashierName.AutoSize = true;
            this.lblCashierName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashierName.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCashierName.Location = new System.Drawing.Point(264, 41);
            this.lblCashierName.Name = "lblCashierName";
            this.lblCashierName.Size = new System.Drawing.Size(168, 25);
            this.lblCashierName.TabIndex = 12;
            this.lblCashierName.Text = "Thu ngân ca chiều";
            this.lblCashierName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCashierLabel
            // 
            this.lblCashierLabel.AutoSize = true;
            this.lblCashierLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashierLabel.Location = new System.Drawing.Point(3, 41);
            this.lblCashierLabel.Name = "lblCashierLabel";
            this.lblCashierLabel.Size = new System.Drawing.Size(90, 25);
            this.lblCashierLabel.TabIndex = 11;
            this.lblCashierLabel.Text = "Thu ngân:";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(370, 5);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(66, 25);
            this.lblTableName.TabIndex = 10;
            this.lblTableName.Text = "BÀN 2";
            // 
            // lblTableLabel
            // 
            this.lblTableLabel.AutoSize = true;
            this.lblTableLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableLabel.Location = new System.Drawing.Point(3, 5);
            this.lblTableLabel.Name = "lblTableLabel";
            this.lblTableLabel.Size = new System.Drawing.Size(45, 25);
            this.lblTableLabel.TabIndex = 9;
            this.lblTableLabel.Text = "Bàn:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(450, 109);
            this.pnlHeader.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(158, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "SĐT: 0123456789";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(447, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(78, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Địa chỉ: Lê Văn Việt, Q.9, TP.Thủ Đức";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "QL CAFE PRO";
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "ProductName";
            this.colName.HeaderText = "Tên món";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQty.HeaderText = "SL";
            this.colQty.MinimumWidth = 8;
            this.colQty.Name = "colQty";
            this.colQty.Width = 50;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPrice.HeaderText = "Đơn giá";
            this.colPrice.MinimumWidth = 8;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTotal.HeaderText = "Thành tiền";
            this.colTotal.MinimumWidth = 8;
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 150;
            // 
            // CreateBillForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(854, 965);
            this.Controls.Add(this.pnlReceipt);
            this.Name = "CreateBillForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateBillForm2";
            this.pnlReceipt.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCalc.ResumeLayout(false);
            this.pnlCalc.PerformLayout();
            this.pnlDiscountInputBorder.ResumeLayout(false);
            this.pnlDiscountInputBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReceipt;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblCashierName;
        private System.Windows.Forms.Label lblCashierLabel;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblTableLabel;
        private System.Windows.Forms.Label lblBillId;
        private System.Windows.Forms.Label lblIdLabel;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblDateLabel;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel pnlCalc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblDiscountText;
        private System.Windows.Forms.Label lblSubTotalValue;
        private System.Windows.Forms.Label lblSubTotalText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGrandTotalValue;
        private System.Windows.Forms.Label lblGrandTotalText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlDiscountInputBorder;
        private System.Windows.Forms.Label lblDiscountHint;
        private System.Windows.Forms.TextBox txtDiscountInput;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnConfirmCheckout;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Label lblFinalSeparator;
        private System.Windows.Forms.Label lblSeeYou;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Button btnMomo;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}