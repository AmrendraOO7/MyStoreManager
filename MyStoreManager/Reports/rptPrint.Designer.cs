namespace MyStoreManager.Reports
{
    partial class rptPrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptPrint));
            this.panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grpBillMaster = new System.Windows.Forms.GroupBox();
            this.PO_ReferenceNoText = new System.Windows.Forms.Label();
            this.PO_ReferenceNo = new System.Windows.Forms.Label();
            this.refText = new System.Windows.Forms.Label();
            this.lbl_refNumber = new System.Windows.Forms.Label();
            this.POText = new System.Windows.Forms.Label();
            this.lbl_PONumber = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_CurrentTotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ProddataGridView = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCname = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_VAT_Amt = new System.Windows.Forms.Label();
            this.lbl_discount_Amt = new System.Windows.Forms.Label();
            this.lbl_DiscountPC = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_VatPC = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_Words = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.receivedLbl = new System.Windows.Forms.Label();
            this.txtPContactnum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_text = new System.Windows.Forms.Label();
            this.lblChange_Bal = new System.Windows.Forms.Label();
            this.lblReceivedAmt = new System.Windows.Forms.Label();
            this.TxtTransection = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPaddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_CompanyName = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_Operator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMiti = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrintDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_formName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_voucherNumber = new System.Windows.Forms.TextBox();
            this.cmd_VoucherType = new System.Windows.Forms.ComboBox();
            this.lbl_voucherForm = new System.Windows.Forms.Label();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpBillMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Indigo;
            this.panel.Controls.Add(this.panel2);
            this.panel.Controls.Add(this.lbl_formName);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.txt_voucherNumber);
            this.panel.Controls.Add(this.cmd_VoucherType);
            this.panel.Controls.Add(this.lbl_voucherForm);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1057, 639);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.grpBillMaster);
            this.panel2.Controls.Add(this.lbl_CompanyName);
            this.panel2.Controls.Add(this.lbl_Phone);
            this.panel2.Controls.Add(this.lbl_Address);
            this.panel2.Controls.Add(this.lbl_Operator);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtMiti);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtPrintDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1052, 548);
            this.panel2.TabIndex = 11;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(945, 505);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 39);
            this.btnPrint.TabIndex = 115;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grpBillMaster
            // 
            this.grpBillMaster.Controls.Add(this.PO_ReferenceNoText);
            this.grpBillMaster.Controls.Add(this.PO_ReferenceNo);
            this.grpBillMaster.Controls.Add(this.refText);
            this.grpBillMaster.Controls.Add(this.lbl_refNumber);
            this.grpBillMaster.Controls.Add(this.POText);
            this.grpBillMaster.Controls.Add(this.lbl_PONumber);
            this.grpBillMaster.Controls.Add(this.lblNote);
            this.grpBillMaster.Controls.Add(this.label12);
            this.grpBillMaster.Controls.Add(this.lbl_CurrentTotal);
            this.grpBillMaster.Controls.Add(this.label14);
            this.grpBillMaster.Controls.Add(this.ProddataGridView);
            this.grpBillMaster.Controls.Add(this.label20);
            this.grpBillMaster.Controls.Add(this.txtCname);
            this.grpBillMaster.Controls.Add(this.lbl_Total);
            this.grpBillMaster.Controls.Add(this.lbl_VAT_Amt);
            this.grpBillMaster.Controls.Add(this.lbl_discount_Amt);
            this.grpBillMaster.Controls.Add(this.lbl_DiscountPC);
            this.grpBillMaster.Controls.Add(this.label13);
            this.grpBillMaster.Controls.Add(this.label6);
            this.grpBillMaster.Controls.Add(this.lbl_VatPC);
            this.grpBillMaster.Controls.Add(this.label11);
            this.grpBillMaster.Controls.Add(this.lbl_Words);
            this.grpBillMaster.Controls.Add(this.label15);
            this.grpBillMaster.Controls.Add(this.receivedLbl);
            this.grpBillMaster.Controls.Add(this.txtPContactnum);
            this.grpBillMaster.Controls.Add(this.label10);
            this.grpBillMaster.Controls.Add(this.lbl_text);
            this.grpBillMaster.Controls.Add(this.lblChange_Bal);
            this.grpBillMaster.Controls.Add(this.lblReceivedAmt);
            this.grpBillMaster.Controls.Add(this.TxtTransection);
            this.grpBillMaster.Controls.Add(this.label9);
            this.grpBillMaster.Controls.Add(this.txtPaddress);
            this.grpBillMaster.Controls.Add(this.label7);
            this.grpBillMaster.Controls.Add(this.TxtPname);
            this.grpBillMaster.Controls.Add(this.label3);
            this.grpBillMaster.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBillMaster.Location = new System.Drawing.Point(9, 131);
            this.grpBillMaster.Name = "grpBillMaster";
            this.grpBillMaster.Size = new System.Drawing.Size(1033, 368);
            this.grpBillMaster.TabIndex = 114;
            this.grpBillMaster.TabStop = false;
            // 
            // PO_ReferenceNoText
            // 
            this.PO_ReferenceNoText.AutoSize = true;
            this.PO_ReferenceNoText.BackColor = System.Drawing.Color.Transparent;
            this.PO_ReferenceNoText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PO_ReferenceNoText.ForeColor = System.Drawing.Color.White;
            this.PO_ReferenceNoText.Location = new System.Drawing.Point(236, 63);
            this.PO_ReferenceNoText.Name = "PO_ReferenceNoText";
            this.PO_ReferenceNoText.Size = new System.Drawing.Size(114, 13);
            this.PO_ReferenceNoText.TabIndex = 810;
            this.PO_ReferenceNoText.Text = "PO Reference No:-";
            this.PO_ReferenceNoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PO_ReferenceNo
            // 
            this.PO_ReferenceNo.AutoSize = true;
            this.PO_ReferenceNo.BackColor = System.Drawing.Color.Transparent;
            this.PO_ReferenceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PO_ReferenceNo.ForeColor = System.Drawing.Color.White;
            this.PO_ReferenceNo.Location = new System.Drawing.Point(356, 63);
            this.PO_ReferenceNo.Name = "PO_ReferenceNo";
            this.PO_ReferenceNo.Size = new System.Drawing.Size(103, 13);
            this.PO_ReferenceNo.TabIndex = 811;
            this.PO_ReferenceNo.Text = "PO_ReferenceNo";
            this.PO_ReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // refText
            // 
            this.refText.AutoSize = true;
            this.refText.BackColor = System.Drawing.Color.Transparent;
            this.refText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refText.ForeColor = System.Drawing.Color.White;
            this.refText.Location = new System.Drawing.Point(244, 42);
            this.refText.Name = "refText";
            this.refText.Size = new System.Drawing.Size(106, 13);
            this.refText.TabIndex = 808;
            this.refText.Text = "Ref Bill Number:-";
            this.refText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_refNumber
            // 
            this.lbl_refNumber.AutoSize = true;
            this.lbl_refNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbl_refNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_refNumber.ForeColor = System.Drawing.Color.White;
            this.lbl_refNumber.Location = new System.Drawing.Point(356, 42);
            this.lbl_refNumber.Name = "lbl_refNumber";
            this.lbl_refNumber.Size = new System.Drawing.Size(88, 13);
            this.lbl_refNumber.TabIndex = 809;
            this.lbl_refNumber.Text = "refBill number";
            this.lbl_refNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // POText
            // 
            this.POText.AutoSize = true;
            this.POText.BackColor = System.Drawing.Color.Transparent;
            this.POText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POText.ForeColor = System.Drawing.Color.White;
            this.POText.Location = new System.Drawing.Point(268, 21);
            this.POText.Name = "POText";
            this.POText.Size = new System.Drawing.Size(82, 13);
            this.POText.TabIndex = 806;
            this.POText.Text = "PO Number:-";
            this.POText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PONumber
            // 
            this.lbl_PONumber.AutoSize = true;
            this.lbl_PONumber.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PONumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PONumber.ForeColor = System.Drawing.Color.White;
            this.lbl_PONumber.Location = new System.Drawing.Point(356, 21);
            this.lbl_PONumber.Name = "lbl_PONumber";
            this.lbl_PONumber.Size = new System.Drawing.Size(72, 13);
            this.lbl_PONumber.TabIndex = 807;
            this.lbl_PONumber.Text = "PO Number";
            this.lbl_PONumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.White;
            this.lblNote.Location = new System.Drawing.Point(69, 313);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(33, 13);
            this.lblNote.TabIndex = 804;
            this.lblNote.Text = "Note";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 805;
            this.label12.Text = "Note:-";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CurrentTotal
            // 
            this.lbl_CurrentTotal.AutoSize = true;
            this.lbl_CurrentTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CurrentTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CurrentTotal.ForeColor = System.Drawing.Color.White;
            this.lbl_CurrentTotal.Location = new System.Drawing.Point(912, 297);
            this.lbl_CurrentTotal.Name = "lbl_CurrentTotal";
            this.lbl_CurrentTotal.Size = new System.Drawing.Size(34, 13);
            this.lbl_CurrentTotal.TabIndex = 802;
            this.lbl_CurrentTotal.Text = "Total";
            this.lbl_CurrentTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(828, 297);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 803;
            this.label14.Text = "Total:-";
            // 
            // ProddataGridView
            // 
            this.ProddataGridView.AllowUserToAddRows = false;
            this.ProddataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProddataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProddataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ProddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProddataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ProddataGridView.GridColor = System.Drawing.Color.Indigo;
            this.ProddataGridView.Location = new System.Drawing.Point(8, 124);
            this.ProddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProddataGridView.Name = "ProddataGridView";
            this.ProddataGridView.ReadOnly = true;
            this.ProddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProddataGridView.Size = new System.Drawing.Size(1016, 169);
            this.ProddataGridView.TabIndex = 801;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(25, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Party Name:-";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCname
            // 
            this.txtCname.AutoSize = true;
            this.txtCname.BackColor = System.Drawing.Color.Transparent;
            this.txtCname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCname.ForeColor = System.Drawing.Color.White;
            this.txtCname.Location = new System.Drawing.Point(109, 42);
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(62, 13);
            this.txtCname.TabIndex = 9;
            this.txtCname.Text = "Company";
            this.txtCname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Total.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total.ForeColor = System.Drawing.Color.White;
            this.lbl_Total.Location = new System.Drawing.Point(912, 347);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(82, 13);
            this.lbl_Total.TabIndex = 9;
            this.lbl_Total.Text = "Total Amount";
            this.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_VAT_Amt
            // 
            this.lbl_VAT_Amt.AutoSize = true;
            this.lbl_VAT_Amt.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VAT_Amt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VAT_Amt.ForeColor = System.Drawing.Color.White;
            this.lbl_VAT_Amt.Location = new System.Drawing.Point(912, 329);
            this.lbl_VAT_Amt.Name = "lbl_VAT_Amt";
            this.lbl_VAT_Amt.Size = new System.Drawing.Size(77, 13);
            this.lbl_VAT_Amt.TabIndex = 9;
            this.lbl_VAT_Amt.Text = "VAT Amount";
            this.lbl_VAT_Amt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_discount_Amt
            // 
            this.lbl_discount_Amt.AutoSize = true;
            this.lbl_discount_Amt.BackColor = System.Drawing.Color.Transparent;
            this.lbl_discount_Amt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discount_Amt.ForeColor = System.Drawing.Color.White;
            this.lbl_discount_Amt.Location = new System.Drawing.Point(912, 313);
            this.lbl_discount_Amt.Name = "lbl_discount_Amt";
            this.lbl_discount_Amt.Size = new System.Drawing.Size(104, 13);
            this.lbl_discount_Amt.TabIndex = 9;
            this.lbl_discount_Amt.Text = "Discount Amount";
            this.lbl_discount_Amt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_DiscountPC
            // 
            this.lbl_DiscountPC.AutoSize = true;
            this.lbl_DiscountPC.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DiscountPC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DiscountPC.ForeColor = System.Drawing.Color.White;
            this.lbl_DiscountPC.Location = new System.Drawing.Point(874, 313);
            this.lbl_DiscountPC.Name = "lbl_DiscountPC";
            this.lbl_DiscountPC.Size = new System.Drawing.Size(32, 13);
            this.lbl_DiscountPC.TabIndex = 9;
            this.lbl_DiscountPC.Text = "DPC";
            this.lbl_DiscountPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(806, 314);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Discount:-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(810, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Payable:-";
            // 
            // lbl_VatPC
            // 
            this.lbl_VatPC.AutoSize = true;
            this.lbl_VatPC.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VatPC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VatPC.ForeColor = System.Drawing.Color.White;
            this.lbl_VatPC.Location = new System.Drawing.Point(875, 329);
            this.lbl_VatPC.Name = "lbl_VatPC";
            this.lbl_VatPC.Size = new System.Drawing.Size(31, 13);
            this.lbl_VatPC.TabIndex = 9;
            this.lbl_VatPC.Text = "VPC";
            this.lbl_VatPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(834, 331);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "VAT:-";
            // 
            // lbl_Words
            // 
            this.lbl_Words.AutoSize = true;
            this.lbl_Words.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Words.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Words.ForeColor = System.Drawing.Color.White;
            this.lbl_Words.Location = new System.Drawing.Point(69, 339);
            this.lbl_Words.Name = "lbl_Words";
            this.lbl_Words.Size = new System.Drawing.Size(42, 13);
            this.lbl_Words.TabIndex = 9;
            this.lbl_Words.Text = "Words";
            this.lbl_Words.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(22, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Business On:-";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // receivedLbl
            // 
            this.receivedLbl.AutoSize = true;
            this.receivedLbl.BackColor = System.Drawing.Color.Transparent;
            this.receivedLbl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivedLbl.ForeColor = System.Drawing.Color.White;
            this.receivedLbl.Location = new System.Drawing.Point(233, 21);
            this.receivedLbl.Name = "receivedLbl";
            this.receivedLbl.Size = new System.Drawing.Size(117, 13);
            this.receivedLbl.TabIndex = 9;
            this.receivedLbl.Text = "Received Amount:-";
            this.receivedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPContactnum
            // 
            this.txtPContactnum.AutoSize = true;
            this.txtPContactnum.BackColor = System.Drawing.Color.Transparent;
            this.txtPContactnum.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPContactnum.ForeColor = System.Drawing.Color.White;
            this.txtPContactnum.Location = new System.Drawing.Point(109, 84);
            this.txtPContactnum.Name = "txtPContactnum";
            this.txtPContactnum.Size = new System.Drawing.Size(51, 13);
            this.txtPContactnum.TabIndex = 9;
            this.txtPContactnum.Text = "Contact";
            this.txtPContactnum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 339);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Words:-";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.White;
            this.lbl_text.Location = new System.Drawing.Point(233, 42);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(117, 13);
            this.lbl_text.TabIndex = 9;
            this.lbl_text.Text = "Change Returned:-";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChange_Bal
            // 
            this.lblChange_Bal.AutoSize = true;
            this.lblChange_Bal.BackColor = System.Drawing.Color.Transparent;
            this.lblChange_Bal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange_Bal.ForeColor = System.Drawing.Color.White;
            this.lblChange_Bal.Location = new System.Drawing.Point(356, 42);
            this.lblChange_Bal.Name = "lblChange_Bal";
            this.lblChange_Bal.Size = new System.Drawing.Size(107, 13);
            this.lblChange_Bal.TabIndex = 9;
            this.lblChange_Bal.Text = "Change Returned";
            this.lblChange_Bal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReceivedAmt
            // 
            this.lblReceivedAmt.AutoSize = true;
            this.lblReceivedAmt.BackColor = System.Drawing.Color.Transparent;
            this.lblReceivedAmt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivedAmt.ForeColor = System.Drawing.Color.White;
            this.lblReceivedAmt.Location = new System.Drawing.Point(356, 21);
            this.lblReceivedAmt.Name = "lblReceivedAmt";
            this.lblReceivedAmt.Size = new System.Drawing.Size(107, 13);
            this.lblReceivedAmt.TabIndex = 9;
            this.lblReceivedAmt.Text = "Received Amount";
            this.lblReceivedAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtTransection
            // 
            this.TxtTransection.AutoSize = true;
            this.TxtTransection.BackColor = System.Drawing.Color.Transparent;
            this.TxtTransection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTransection.ForeColor = System.Drawing.Color.White;
            this.TxtTransection.Location = new System.Drawing.Point(109, 105);
            this.TxtTransection.Name = "TxtTransection";
            this.TxtTransection.Size = new System.Drawing.Size(77, 13);
            this.TxtTransection.TabIndex = 9;
            this.TxtTransection.Text = "Business On";
            this.TxtTransection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(44, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cotntact:-";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaddress
            // 
            this.txtPaddress.AutoSize = true;
            this.txtPaddress.BackColor = System.Drawing.Color.Transparent;
            this.txtPaddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaddress.ForeColor = System.Drawing.Color.White;
            this.txtPaddress.Location = new System.Drawing.Point(109, 63);
            this.txtPaddress.Name = "txtPaddress";
            this.txtPaddress.Size = new System.Drawing.Size(53, 13);
            this.txtPaddress.TabIndex = 9;
            this.txtPaddress.Text = "Address";
            this.txtPaddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Party Address:-";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtPname
            // 
            this.TxtPname.AutoSize = true;
            this.TxtPname.BackColor = System.Drawing.Color.Transparent;
            this.TxtPname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPname.ForeColor = System.Drawing.Color.White;
            this.TxtPname.Location = new System.Drawing.Point(109, 21);
            this.TxtPname.Name = "TxtPname";
            this.TxtPname.Size = new System.Drawing.Size(94, 13);
            this.TxtPname.TabIndex = 9;
            this.TxtPname.Text = "Contact Person";
            this.TxtPname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Contact Person:-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CompanyName
            // 
            this.lbl_CompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CompanyName.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompanyName.ForeColor = System.Drawing.Color.White;
            this.lbl_CompanyName.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_CompanyName.Location = new System.Drawing.Point(188, 4);
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.Size = new System.Drawing.Size(637, 35);
            this.lbl_CompanyName.TabIndex = 113;
            this.lbl_CompanyName.Text = "Text";
            this.lbl_CompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Phone.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.ForeColor = System.Drawing.Color.White;
            this.lbl_Phone.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Phone.Location = new System.Drawing.Point(188, 62);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(637, 13);
            this.lbl_Phone.TabIndex = 111;
            this.lbl_Phone.Text = "Text";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Address
            // 
            this.lbl_Address.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Address.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Address.ForeColor = System.Drawing.Color.White;
            this.lbl_Address.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Address.Location = new System.Drawing.Point(188, 39);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(637, 13);
            this.lbl_Address.TabIndex = 112;
            this.lbl_Address.Text = "Text";
            this.lbl_Address.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Operator
            // 
            this.lbl_Operator.AutoSize = true;
            this.lbl_Operator.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Operator.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Operator.ForeColor = System.Drawing.Color.White;
            this.lbl_Operator.Location = new System.Drawing.Point(78, 531);
            this.lbl_Operator.Name = "lbl_Operator";
            this.lbl_Operator.Size = new System.Drawing.Size(58, 13);
            this.lbl_Operator.TabIndex = 13;
            this.lbl_Operator.Text = "Operator";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Operator:-";
            // 
            // txtMiti
            // 
            this.txtMiti.AutoSize = true;
            this.txtMiti.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiti.ForeColor = System.Drawing.Color.White;
            this.txtMiti.Location = new System.Drawing.Point(883, 101);
            this.txtMiti.Name = "txtMiti";
            this.txtMiti.Size = new System.Drawing.Size(26, 13);
            this.txtMiti.TabIndex = 11;
            this.txtMiti.Text = "Miti";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(845, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Miti:-";
            // 
            // txtPrintDate
            // 
            this.txtPrintDate.AutoSize = true;
            this.txtPrintDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrintDate.ForeColor = System.Drawing.Color.White;
            this.txtPrintDate.Location = new System.Drawing.Point(883, 88);
            this.txtPrintDate.Name = "txtPrintDate";
            this.txtPrintDate.Size = new System.Drawing.Size(34, 13);
            this.txtPrintDate.TabIndex = 9;
            this.txtPrintDate.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(807, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Print Date:-";
            // 
            // lbl_formName
            // 
            this.lbl_formName.AutoSize = true;
            this.lbl_formName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_formName.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_formName.ForeColor = System.Drawing.Color.White;
            this.lbl_formName.Location = new System.Drawing.Point(512, 12);
            this.lbl_formName.Name = "lbl_formName";
            this.lbl_formName.Size = new System.Drawing.Size(84, 25);
            this.lbl_formName.TabIndex = 9;
            this.lbl_formName.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select Bill Type";
            // 
            // txt_voucherNumber
            // 
            this.txt_voucherNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_voucherNumber.ForeColor = System.Drawing.Color.Black;
            this.txt_voucherNumber.Location = new System.Drawing.Point(129, 43);
            this.txt_voucherNumber.Name = "txt_voucherNumber";
            this.txt_voucherNumber.ReadOnly = true;
            this.txt_voucherNumber.Size = new System.Drawing.Size(126, 21);
            this.txt_voucherNumber.TabIndex = 8;
            this.txt_voucherNumber.Text = "Press F1 here";
            this.txt_voucherNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_voucherNumber_KeyDown);
            // 
            // cmd_VoucherType
            // 
            this.cmd_VoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmd_VoucherType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_VoucherType.FormattingEnabled = true;
            this.cmd_VoucherType.Items.AddRange(new object[] {
            "Purchase Order",
            "Purchase Entry",
            "Purchase Return",
            "Sales Entry",
            "Sales Return"});
            this.cmd_VoucherType.Location = new System.Drawing.Point(2, 43);
            this.cmd_VoucherType.Name = "cmd_VoucherType";
            this.cmd_VoucherType.Size = new System.Drawing.Size(121, 21);
            this.cmd_VoucherType.TabIndex = 12;
            // 
            // lbl_voucherForm
            // 
            this.lbl_voucherForm.AutoSize = true;
            this.lbl_voucherForm.BackColor = System.Drawing.Color.Transparent;
            this.lbl_voucherForm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_voucherForm.ForeColor = System.Drawing.Color.White;
            this.lbl_voucherForm.Location = new System.Drawing.Point(129, 27);
            this.lbl_voucherForm.Name = "lbl_voucherForm";
            this.lbl_voucherForm.Size = new System.Drawing.Size(41, 13);
            this.lbl_voucherForm.TabIndex = 10;
            this.lbl_voucherForm.Text = "label1";
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.viewInventoryToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(190, 48);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // viewInventoryToolStripMenuItem
            // 
            this.viewInventoryToolStripMenuItem.Name = "viewInventoryToolStripMenuItem";
            this.viewInventoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.viewInventoryToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.viewInventoryToolStripMenuItem.Text = "View Inventory";
            this.viewInventoryToolStripMenuItem.Click += new System.EventHandler(this.viewInventoryToolStripMenuItem_Click);
            // 
            // rptPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 639);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "rptPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.rptPurchaseOrder_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpBillMaster.ResumeLayout(false);
            this.grpBillMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpBillMaster;
        private System.Windows.Forms.Label PO_ReferenceNoText;
        private System.Windows.Forms.Label PO_ReferenceNo;
        private System.Windows.Forms.Label refText;
        private System.Windows.Forms.Label lbl_refNumber;
        private System.Windows.Forms.Label POText;
        private System.Windows.Forms.Label lbl_PONumber;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_CurrentTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView ProddataGridView;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label txtCname;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_VAT_Amt;
        private System.Windows.Forms.Label lbl_discount_Amt;
        private System.Windows.Forms.Label lbl_DiscountPC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_VatPC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_Words;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label receivedLbl;
        private System.Windows.Forms.Label txtPContactnum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label lblChange_Bal;
        private System.Windows.Forms.Label lblReceivedAmt;
        private System.Windows.Forms.Label TxtTransection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtPaddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TxtPname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_CompanyName;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_Operator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtMiti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtPrintDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_formName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_voucherNumber;
        private System.Windows.Forms.ComboBox cmd_VoucherType;
        private System.Windows.Forms.Label lbl_voucherForm;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInventoryToolStripMenuItem;
        private System.Windows.Forms.Button btnPrint;
    }
}