
namespace MyStoreManager.BillEntry.Purchase
{
    partial class frm_PurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PurchaseOrder));
            this.panel = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chk_BillStatus = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToWords = new System.Windows.Forms.Label();
            this.lbldiscamt = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblVatamt = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblBillBDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.btn_Recalculate = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbTransection = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btn_ProductClear = new System.Windows.Forms.Button();
            this.ShortName = new System.Windows.Forms.Label();
            this.lblPShortname = new System.Windows.Forms.Label();
            this.txtDateTime = new System.Windows.Forms.DateTimePicker();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.lbl_TagStatus = new System.Windows.Forms.Label();
            this.ProductIDLabel = new System.Windows.Forms.Label();
            this.lbl_Barcode = new System.Windows.Forms.Label();
            this.lbl_ProductID = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_CompanyName = new System.Windows.Forms.Label();
            this.lbl_RoleName = new System.Windows.Forms.Label();
            this.lbl_Person = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_CustoSearch = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVoucherNum = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMiti = new System.Windows.Forms.MaskedTextBox();
            this.ProddataGridView = new System.Windows.Forms.DataGridView();
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_PurchasePrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Product_Search = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txtPContactnum = new System.Windows.Forms.TextBox();
            this.txtPaddress = new System.Windows.Forms.TextBox();
            this.txtCname = new System.Windows.Forms.TextBox();
            this.TxtPname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Insert = new System.Windows.Forms.Button();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.BlueViolet;
            this.panel.ContextMenuStrip = this.contextMenuStrip;
            this.panel.Controls.Add(this.panel3);
            this.panel.Controls.Add(this.btnPrint);
            this.panel.Controls.Add(this.label22);
            this.panel.Controls.Add(this.label14);
            this.panel.Controls.Add(this.chk_BillStatus);
            this.panel.Controls.Add(this.label9);
            this.panel.Controls.Add(this.lblTotal);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.lblToWords);
            this.panel.Controls.Add(this.lbldiscamt);
            this.panel.Controls.Add(this.label34);
            this.panel.Controls.Add(this.lblVatamt);
            this.panel.Controls.Add(this.label33);
            this.panel.Controls.Add(this.lblBillBDiscount);
            this.panel.Controls.Add(this.txtDiscount);
            this.panel.Controls.Add(this.txtVAT);
            this.panel.Controls.Add(this.btn_Recalculate);
            this.panel.Controls.Add(this.label32);
            this.panel.Controls.Add(this.label31);
            this.panel.Controls.Add(this.lblTotalBill);
            this.panel.Controls.Add(this.label29);
            this.panel.Controls.Add(this.label35);
            this.panel.Controls.Add(this.label30);
            this.panel.Controls.Add(this.cmbTransection);
            this.panel.Controls.Add(this.label17);
            this.panel.Controls.Add(this.label16);
            this.panel.Controls.Add(this.label15);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.lblTotalAmount);
            this.panel.Controls.Add(this.txtUnit);
            this.panel.Controls.Add(this.btn_ProductClear);
            this.panel.Controls.Add(this.ShortName);
            this.panel.Controls.Add(this.lblPShortname);
            this.panel.Controls.Add(this.txtDateTime);
            this.panel.Controls.Add(this.btn_Refresh);
            this.panel.Controls.Add(this.lbl_TagStatus);
            this.panel.Controls.Add(this.ProductIDLabel);
            this.panel.Controls.Add(this.lbl_Barcode);
            this.panel.Controls.Add(this.lbl_ProductID);
            this.panel.Controls.Add(this.lbl_Phone);
            this.panel.Controls.Add(this.lbl_Address);
            this.panel.Controls.Add(this.lbl_CompanyName);
            this.panel.Controls.Add(this.lbl_RoleName);
            this.panel.Controls.Add(this.lbl_Person);
            this.panel.Controls.Add(this.label23);
            this.panel.Controls.Add(this.label8);
            this.panel.Controls.Add(this.Btn_CustoSearch);
            this.panel.Controls.Add(this.label18);
            this.panel.Controls.Add(this.label19);
            this.panel.Controls.Add(this.label20);
            this.panel.Controls.Add(this.label21);
            this.panel.Controls.Add(this.label13);
            this.panel.Controls.Add(this.txtVoucherNum);
            this.panel.Controls.Add(this.label11);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.txtMiti);
            this.panel.Controls.Add(this.ProddataGridView);
            this.panel.Controls.Add(this.txt_Note);
            this.panel.Controls.Add(this.label10);
            this.panel.Controls.Add(this.txt_PurchasePrice);
            this.panel.Controls.Add(this.label7);
            this.panel.Controls.Add(this.txt_Quantity);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.btn_Product_Search);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.txt_Name);
            this.panel.Controls.Add(this.txtPContactnum);
            this.panel.Controls.Add(this.txtPaddress);
            this.panel.Controls.Add(this.txtCname);
            this.panel.Controls.Add(this.TxtPname);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.Btn_Insert);
            this.panel.Controls.Add(this.Btn_Ok);
            this.panel.Controls.Add(this.btn_Delete);
            this.panel.Controls.Add(this.btn_Edit);
            this.panel.Controls.Add(this.btn_Save);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1059, 523);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.recalculateToolStripMenuItem,
            this.viewInventoryToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(190, 70);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // recalculateToolStripMenuItem
            // 
            this.recalculateToolStripMenuItem.Name = "recalculateToolStripMenuItem";
            this.recalculateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.recalculateToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.recalculateToolStripMenuItem.Text = "Recalculate";
            this.recalculateToolStripMenuItem.Click += new System.EventHandler(this.recalculateToolStripMenuItem_Click);
            // 
            // viewInventoryToolStripMenuItem
            // 
            this.viewInventoryToolStripMenuItem.Name = "viewInventoryToolStripMenuItem";
            this.viewInventoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.viewInventoryToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.viewInventoryToolStripMenuItem.Text = "View Inventory";
            this.viewInventoryToolStripMenuItem.Click += new System.EventHandler(this.viewInventoryToolStripMenuItem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 8F);
            this.btnPrint.ForeColor = System.Drawing.Color.Indigo;
            this.btnPrint.Location = new System.Drawing.Point(630, 98);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(83, 28);
            this.btnPrint.TabIndex = 881;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.GhostWhite;
            this.label22.Location = new System.Drawing.Point(9, 183);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(139, 13);
            this.label22.TabIndex = 880;
            this.label22.Text = "PRODUCT DETAILS :-";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label14.Location = new System.Drawing.Point(794, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(264, 20);
            this.label14.TabIndex = 879;
            this.label14.Text = "Purchase Order /Quotation";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_BillStatus
            // 
            this.chk_BillStatus.AutoSize = true;
            this.chk_BillStatus.BackColor = System.Drawing.Color.Transparent;
            this.chk_BillStatus.ForeColor = System.Drawing.Color.GhostWhite;
            this.chk_BillStatus.Location = new System.Drawing.Point(102, 484);
            this.chk_BillStatus.Name = "chk_BillStatus";
            this.chk_BillStatus.Size = new System.Drawing.Size(125, 17);
            this.chk_BillStatus.TabIndex = 830;
            this.chk_BillStatus.Text = "Order Completed";
            this.chk_BillStatus.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.GhostWhite;
            this.label9.Location = new System.Drawing.Point(12, 483);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 14);
            this.label9.TabIndex = 831;
            this.label9.Text = "Bill Status:-";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(822, 221);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 829;
            this.lblTotal.Text = "total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(821, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 828;
            this.label2.Text = "Total";
            // 
            // lblToWords
            // 
            this.lblToWords.AutoSize = true;
            this.lblToWords.BackColor = System.Drawing.Color.Transparent;
            this.lblToWords.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToWords.ForeColor = System.Drawing.Color.White;
            this.lblToWords.Location = new System.Drawing.Point(90, 462);
            this.lblToWords.Name = "lblToWords";
            this.lblToWords.Size = new System.Drawing.Size(48, 13);
            this.lblToWords.TabIndex = 827;
            this.lblToWords.Text = "Words";
            // 
            // lbldiscamt
            // 
            this.lbldiscamt.AutoSize = true;
            this.lbldiscamt.BackColor = System.Drawing.Color.Transparent;
            this.lbldiscamt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiscamt.ForeColor = System.Drawing.Color.White;
            this.lbldiscamt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbldiscamt.Location = new System.Drawing.Point(354, 434);
            this.lbldiscamt.Name = "lbldiscamt";
            this.lbldiscamt.Size = new System.Drawing.Size(62, 13);
            this.lbldiscamt.TabIndex = 826;
            this.lbldiscamt.Text = "disc amt";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(280, 434);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(74, 13);
            this.label34.TabIndex = 825;
            this.label34.Text = "Disc Amt:-";
            // 
            // lblVatamt
            // 
            this.lblVatamt.AutoSize = true;
            this.lblVatamt.BackColor = System.Drawing.Color.Transparent;
            this.lblVatamt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatamt.ForeColor = System.Drawing.Color.White;
            this.lblVatamt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVatamt.Location = new System.Drawing.Point(794, 433);
            this.lblVatamt.Name = "lblVatamt";
            this.lblVatamt.Size = new System.Drawing.Size(57, 13);
            this.lblVatamt.TabIndex = 824;
            this.lblVatamt.Text = "vat amt";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(429, 435);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 13);
            this.label33.TabIndex = 822;
            this.label33.Text = "Amount:-";
            // 
            // lblBillBDiscount
            // 
            this.lblBillBDiscount.AutoSize = true;
            this.lblBillBDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblBillBDiscount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillBDiscount.ForeColor = System.Drawing.Color.White;
            this.lblBillBDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBillBDiscount.Location = new System.Drawing.Point(497, 435);
            this.lblBillBDiscount.Name = "lblBillBDiscount";
            this.lblBillBDiscount.Size = new System.Drawing.Size(56, 13);
            this.lblBillBDiscount.TabIndex = 823;
            this.lblBillBDiscount.Text = "amount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(221, 431);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(36, 21);
            this.txtDiscount.TabIndex = 22;
            this.txtDiscount.Enter += new System.EventHandler(this.txtDiscount_Enter);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalDecimal_KeyPress);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // txtVAT
            // 
            this.txtVAT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT.Location = new System.Drawing.Point(660, 431);
            this.txtVAT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(36, 21);
            this.txtVAT.TabIndex = 23;
            this.txtVAT.Enter += new System.EventHandler(this.txtVAT_Enter);
            this.txtVAT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVAT_KeyDown);
            this.txtVAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalDecimal_KeyPress);
            this.txtVAT.Leave += new System.EventHandler(this.txtVAT_Leave);
            // 
            // btn_Recalculate
            // 
            this.btn_Recalculate.BackColor = System.Drawing.Color.White;
            this.btn_Recalculate.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Recalculate.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Recalculate.Location = new System.Drawing.Point(968, 448);
            this.btn_Recalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Recalculate.Name = "btn_Recalculate";
            this.btn_Recalculate.Size = new System.Drawing.Size(83, 24);
            this.btn_Recalculate.TabIndex = 820;
            this.btn_Recalculate.Text = "&Recalculate";
            this.btn_Recalculate.UseVisualStyleBackColor = false;
            this.btn_Recalculate.Click += new System.EventHandler(this.btn_Recalculate_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(11, 462);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(76, 13);
            this.label32.TabIndex = 818;
            this.label32.Text = "In Words:-";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(882, 433);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 13);
            this.label31.TabIndex = 816;
            this.label31.Text = "Bill Total:-";
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBill.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.Color.White;
            this.lblTotalBill.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalBill.Location = new System.Drawing.Point(964, 433);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(61, 13);
            this.lblTotalBill.TabIndex = 817;
            this.lblTotalBill.Text = "bill total";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(697, 434);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(21, 13);
            this.label29.TabIndex = 815;
            this.label29.Text = "%";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(720, 433);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 13);
            this.label35.TabIndex = 813;
            this.label35.Text = "VAT Amt:-";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(574, 434);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 13);
            this.label30.TabIndex = 813;
            this.label30.Text = "Total VAT:-";
            // 
            // cmbTransection
            // 
            this.cmbTransection.FormattingEnabled = true;
            this.cmbTransection.Items.AddRange(new object[] {
            "CASH",
            "CREDIT"});
            this.cmbTransection.Location = new System.Drawing.Point(938, 151);
            this.cmbTransection.Name = "cmbTransection";
            this.cmbTransection.Size = new System.Drawing.Size(113, 21);
            this.cmbTransection.TabIndex = 812;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(823, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 13);
            this.label17.TabIndex = 811;
            this.label17.Text = "Transection On";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(258, 435);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 810;
            this.label16.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(135, 434);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 808;
            this.label15.Text = "Total Disc:-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 802;
            this.label1.Text = "Total:-";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalAmount.Location = new System.Drawing.Point(63, 434);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(37, 13);
            this.lblTotalAmount.TabIndex = 803;
            this.lblTotalAmount.Text = "total";
            // 
            // txtUnit
            // 
            this.txtUnit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.Location = new System.Drawing.Point(588, 217);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(112, 21);
            this.txtUnit.TabIndex = 10;
            this.txtUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnit_KeyDown);
            this.txtUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnit_KeyPress);
            // 
            // btn_ProductClear
            // 
            this.btn_ProductClear.BackgroundImage = global::MyStoreManager.Properties.Resources.Redo;
            this.btn_ProductClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ProductClear.Location = new System.Drawing.Point(1027, 214);
            this.btn_ProductClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ProductClear.Name = "btn_ProductClear";
            this.btn_ProductClear.Size = new System.Drawing.Size(25, 24);
            this.btn_ProductClear.TabIndex = 801;
            this.btn_ProductClear.UseVisualStyleBackColor = true;
            this.btn_ProductClear.Click += new System.EventHandler(this.btn_ProductClear_Click);
            // 
            // ShortName
            // 
            this.ShortName.AutoSize = true;
            this.ShortName.BackColor = System.Drawing.Color.Transparent;
            this.ShortName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ShortName.ForeColor = System.Drawing.Color.White;
            this.ShortName.Location = new System.Drawing.Point(184, 201);
            this.ShortName.Name = "ShortName";
            this.ShortName.Size = new System.Drawing.Size(68, 13);
            this.ShortName.TabIndex = 124;
            this.ShortName.Text = "S-Name:-";
            // 
            // lblPShortname
            // 
            this.lblPShortname.AutoSize = true;
            this.lblPShortname.BackColor = System.Drawing.Color.Transparent;
            this.lblPShortname.ForeColor = System.Drawing.Color.White;
            this.lblPShortname.Location = new System.Drawing.Point(253, 201);
            this.lblPShortname.Name = "lblPShortname";
            this.lblPShortname.Size = new System.Drawing.Size(45, 13);
            this.lblPShortname.TabIndex = 125;
            this.lblPShortname.Text = "sname";
            // 
            // txtDateTime
            // 
            this.txtDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateTime.Location = new System.Drawing.Point(331, 110);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(97, 21);
            this.txtDateTime.TabIndex = 2;
            this.txtDateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            this.txtDateTime.Leave += new System.EventHandler(this.txtDateTime_Leave);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackgroundImage = global::MyStoreManager.Properties.Resources.Refresh;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.Location = new System.Drawing.Point(308, 499);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(23, 20);
            this.btn_Refresh.TabIndex = 115;
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Visible = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // lbl_TagStatus
            // 
            this.lbl_TagStatus.AutoSize = true;
            this.lbl_TagStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TagStatus.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbl_TagStatus.Location = new System.Drawing.Point(12, 503);
            this.lbl_TagStatus.Name = "lbl_TagStatus";
            this.lbl_TagStatus.Size = new System.Drawing.Size(91, 13);
            this.lbl_TagStatus.TabIndex = 111;
            this.lbl_TagStatus.Text = "Copyright msg";
            // 
            // ProductIDLabel
            // 
            this.ProductIDLabel.AutoSize = true;
            this.ProductIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProductIDLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ProductIDLabel.ForeColor = System.Drawing.Color.White;
            this.ProductIDLabel.Location = new System.Drawing.Point(107, 202);
            this.ProductIDLabel.Name = "ProductIDLabel";
            this.ProductIDLabel.Size = new System.Drawing.Size(40, 13);
            this.ProductIDLabel.TabIndex = 94;
            this.ProductIDLabel.Text = "PID:-";
            // 
            // lbl_Barcode
            // 
            this.lbl_Barcode.AutoSize = true;
            this.lbl_Barcode.ForeColor = System.Drawing.Color.White;
            this.lbl_Barcode.Location = new System.Drawing.Point(358, 201);
            this.lbl_Barcode.Name = "lbl_Barcode";
            this.lbl_Barcode.Size = new System.Drawing.Size(41, 13);
            this.lbl_Barcode.TabIndex = 110;
            this.lbl_Barcode.Text = "bcode";
            // 
            // lbl_ProductID
            // 
            this.lbl_ProductID.AutoSize = true;
            this.lbl_ProductID.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ProductID.ForeColor = System.Drawing.Color.White;
            this.lbl_ProductID.Location = new System.Drawing.Point(147, 201);
            this.lbl_ProductID.Name = "lbl_ProductID";
            this.lbl_ProductID.Size = new System.Drawing.Size(24, 13);
            this.lbl_ProductID.TabIndex = 110;
            this.lbl_ProductID.Text = "pid";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Phone.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.ForeColor = System.Drawing.Color.White;
            this.lbl_Phone.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Phone.Location = new System.Drawing.Point(207, 67);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(637, 13);
            this.lbl_Phone.TabIndex = 110;
            this.lbl_Phone.Text = "Text";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Address
            // 
            this.lbl_Address.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Address.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Address.ForeColor = System.Drawing.Color.White;
            this.lbl_Address.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Address.Location = new System.Drawing.Point(207, 44);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(637, 13);
            this.lbl_Address.TabIndex = 110;
            this.lbl_Address.Text = "Text";
            this.lbl_Address.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_CompanyName
            // 
            this.lbl_CompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CompanyName.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompanyName.ForeColor = System.Drawing.Color.White;
            this.lbl_CompanyName.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_CompanyName.Location = new System.Drawing.Point(207, 9);
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.Size = new System.Drawing.Size(637, 35);
            this.lbl_CompanyName.TabIndex = 110;
            this.lbl_CompanyName.Text = "Text";
            this.lbl_CompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.AutoSize = true;
            this.lbl_RoleName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RoleName.ForeColor = System.Drawing.Color.White;
            this.lbl_RoleName.Location = new System.Drawing.Point(678, 503);
            this.lbl_RoleName.Name = "lbl_RoleName";
            this.lbl_RoleName.Size = new System.Drawing.Size(51, 13);
            this.lbl_RoleName.TabIndex = 109;
            this.lbl_RoleName.Text = "User ID";
            // 
            // lbl_Person
            // 
            this.lbl_Person.AutoSize = true;
            this.lbl_Person.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Person.ForeColor = System.Drawing.Color.White;
            this.lbl_Person.Location = new System.Drawing.Point(374, 503);
            this.lbl_Person.Name = "lbl_Person";
            this.lbl_Person.Size = new System.Drawing.Size(69, 13);
            this.lbl_Person.TabIndex = 109;
            this.lbl_Person.Text = "User name";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(468, 202);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 13);
            this.label23.TabIndex = 99;
            this.label23.Text = "Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(305, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 95;
            this.label8.Text = "B-Code:-";
            // 
            // Btn_CustoSearch
            // 
            this.Btn_CustoSearch.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.Btn_CustoSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_CustoSearch.Location = new System.Drawing.Point(539, 132);
            this.Btn_CustoSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_CustoSearch.Name = "Btn_CustoSearch";
            this.Btn_CustoSearch.Size = new System.Drawing.Size(22, 19);
            this.Btn_CustoSearch.TabIndex = 93;
            this.Btn_CustoSearch.UseVisualStyleBackColor = true;
            this.Btn_CustoSearch.Click += new System.EventHandler(this.Btn_CustoSearch_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(568, 154);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 91;
            this.label18.Text = "Phone";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(567, 133);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 90;
            this.label19.Text = "Address";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(8, 155);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 13);
            this.label20.TabIndex = 88;
            this.label20.Text = "Company Name";
            this.label20.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(9, 133);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 13);
            this.label21.TabIndex = 89;
            this.label21.Text = "Party Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(8, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 84;
            this.label13.Text = "Order No:- ";
            // 
            // txtVoucherNum
            // 
            this.txtVoucherNum.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherNum.Location = new System.Drawing.Point(128, 110);
            this.txtVoucherNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVoucherNum.Name = "txtVoucherNum";
            this.txtVoucherNum.ReadOnly = true;
            this.txtVoucherNum.Size = new System.Drawing.Size(149, 21);
            this.txtVoucherNum.TabIndex = 1;
            this.txtVoucherNum.ValidatingType = typeof(System.DateTime);
            this.txtVoucherNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherNum_KeyDown);
            this.txtVoucherNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(432, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 82;
            this.label11.Text = "Miti:- ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(283, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 82;
            this.label6.Text = "Date:- ";
            // 
            // txtMiti
            // 
            this.txtMiti.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiti.Location = new System.Drawing.Point(475, 110);
            this.txtMiti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiti.Name = "txtMiti";
            this.txtMiti.ReadOnly = true;
            this.txtMiti.Size = new System.Drawing.Size(86, 21);
            this.txtMiti.TabIndex = 3;
            this.txtMiti.ValidatingType = typeof(System.DateTime);
            this.txtMiti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // ProddataGridView
            // 
            this.ProddataGridView.AllowUserToAddRows = false;
            this.ProddataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ProddataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProddataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ProddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProddataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ProddataGridView.GridColor = System.Drawing.Color.Indigo;
            this.ProddataGridView.Location = new System.Drawing.Point(8, 260);
            this.ProddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProddataGridView.Name = "ProddataGridView";
            this.ProddataGridView.ReadOnly = true;
            this.ProddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProddataGridView.Size = new System.Drawing.Size(1043, 169);
            this.ProddataGridView.TabIndex = 800;
            this.ProddataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProddataGridView_CellContentDoubleClick);
            this.ProddataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ProddataGridView_RowPostPaint);
            // 
            // txt_Note
            // 
            this.txt_Note.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Note.Location = new System.Drawing.Point(118, 238);
            this.txt_Note.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(933, 21);
            this.txt_Note.TabIndex = 20;
            this.txt_Note.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(11, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 78;
            this.label10.Text = "Product Note:-";
            // 
            // txt_PurchasePrice
            // 
            this.txt_PurchasePrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PurchasePrice.Location = new System.Drawing.Point(704, 217);
            this.txt_PurchasePrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_PurchasePrice.Name = "txt_PurchasePrice";
            this.txt_PurchasePrice.Size = new System.Drawing.Size(112, 21);
            this.txt_PurchasePrice.TabIndex = 13;
            this.txt_PurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_PurchasePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PurchasePrice_KeyDown);
            this.txt_PurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalDecimal_KeyPress);
            this.txt_PurchasePrice.Leave += new System.EventHandler(this.txt_PurchasePrice_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(703, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "P. Rate";
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(471, 217);
            this.txt_Quantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(112, 21);
            this.txt_Quantity.TabIndex = 9;
            this.txt_Quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalDecimal_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(585, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Unit";
            // 
            // btn_Product_Search
            // 
            this.btn_Product_Search.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btn_Product_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Product_Search.Location = new System.Drawing.Point(443, 217);
            this.btn_Product_Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Product_Search.Name = "btn_Product_Search";
            this.btn_Product_Search.Size = new System.Drawing.Size(22, 21);
            this.btn_Product_Search.TabIndex = 67;
            this.btn_Product_Search.UseVisualStyleBackColor = true;
            this.btn_Product_Search.Click += new System.EventHandler(this.btn_Product_Search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Product Name";
            // 
            // txt_Name
            // 
            this.txt_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Name.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(11, 217);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(432, 21);
            this.txt_Name.TabIndex = 8;
            this.txt_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Name_KeyDown);
            this.txt_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            this.txt_Name.Leave += new System.EventHandler(this.txt_Name_Leave);
            // 
            // txtPContactnum
            // 
            this.txtPContactnum.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPContactnum.Location = new System.Drawing.Point(630, 151);
            this.txtPContactnum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPContactnum.Name = "txtPContactnum";
            this.txtPContactnum.Size = new System.Drawing.Size(187, 21);
            this.txtPContactnum.TabIndex = 7;
            this.txtPContactnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txtPaddress
            // 
            this.txtPaddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaddress.Location = new System.Drawing.Point(630, 130);
            this.txtPaddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaddress.Name = "txtPaddress";
            this.txtPaddress.Size = new System.Drawing.Size(421, 21);
            this.txtPaddress.TabIndex = 6;
            this.txtPaddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txtCname
            // 
            this.txtCname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCname.Location = new System.Drawing.Point(128, 152);
            this.txtCname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCname.Name = "txtCname";
            this.txtCname.Size = new System.Drawing.Size(433, 21);
            this.txtCname.TabIndex = 5;
            this.txtCname.Visible = false;
            this.txtCname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // TxtPname
            // 
            this.TxtPname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPname.Location = new System.Drawing.Point(128, 131);
            this.TxtPname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPname.Name = "TxtPname";
            this.TxtPname.ReadOnly = true;
            this.TxtPname.Size = new System.Drawing.Size(411, 21);
            this.TxtPname.TabIndex = 4;
            this.TxtPname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPname_KeyDown);
            this.TxtPname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            this.TxtPname.Leave += new System.EventHandler(this.TxtPname_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GhostWhite;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "SUPPLIER DETAILS :-";
            // 
            // Btn_Insert
            // 
            this.Btn_Insert.BackColor = System.Drawing.Color.White;
            this.Btn_Insert.Font = new System.Drawing.Font("Verdana", 8F);
            this.Btn_Insert.ForeColor = System.Drawing.Color.Indigo;
            this.Btn_Insert.Location = new System.Drawing.Point(932, 214);
            this.Btn_Insert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Insert.Name = "Btn_Insert";
            this.Btn_Insert.Size = new System.Drawing.Size(98, 24);
            this.Btn_Insert.TabIndex = 21;
            this.Btn_Insert.Text = "&Enter Product";
            this.Btn_Insert.UseVisualStyleBackColor = false;
            this.Btn_Insert.Click += new System.EventHandler(this.Btn_Insert_Click);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.BackColor = System.Drawing.Color.White;
            this.Btn_Ok.Font = new System.Drawing.Font("Verdana", 8F);
            this.Btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.Btn_Ok.Location = new System.Drawing.Point(943, 476);
            this.Btn_Ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(108, 40);
            this.Btn_Ok.TabIndex = 24;
            this.Btn_Ok.Text = "&Save";
            this.Btn_Ok.UseVisualStyleBackColor = false;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.White;
            this.btn_Delete.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Delete.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Delete.Location = new System.Drawing.Point(968, 98);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(83, 28);
            this.btn_Delete.TabIndex = 23;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.White;
            this.btn_Edit.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Edit.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Edit.Location = new System.Drawing.Point(885, 98);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(83, 28);
            this.btn_Edit.TabIndex = 22;
            this.btn_Edit.Text = "&Edit";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.White;
            this.btn_Save.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Save.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Save.Location = new System.Drawing.Point(802, 98);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(83, 28);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "&Create";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BtnProgressBar_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BtnProgressBar_ProgressChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "PO Print";
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::MyStoreManager.Properties.Resources.MyStoreManager_logo1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(952, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(106, 56);
            this.panel3.TabIndex = 882;
            // 
            // frm_PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 523);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "frm_PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.frm_PurchaseOrder_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.TextBox txtPContactnum;
        private System.Windows.Forms.TextBox txtPaddress;
        private System.Windows.Forms.TextBox txtCname;
        private System.Windows.Forms.TextBox TxtPname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Product_Search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.TextBox txt_PurchasePrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Note;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtVoucherNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtMiti;
        private System.Windows.Forms.DataGridView ProddataGridView;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button Btn_CustoSearch;
        private System.Windows.Forms.Label ProductIDLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbl_Barcode;
        private System.Windows.Forms.Label lbl_ProductID;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_CompanyName;
        private System.Windows.Forms.Label lbl_Person;
        private System.Windows.Forms.Label lbl_TagStatus;
        private System.Windows.Forms.Label lbl_RoleName;
        private System.Windows.Forms.Button Btn_Insert;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.DateTimePicker txtDateTime;
        private System.Windows.Forms.Label ShortName;
        private System.Windows.Forms.Label lblPShortname;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btn_ProductClear;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbTransection;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Button btn_Recalculate;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblBillBDiscount;
        private System.Windows.Forms.Label lblVatamt;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lbldiscamt;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lblToWords;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem recalculateToolStripMenuItem;
        private System.Windows.Forms.CheckBox chk_BillStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripMenuItem viewInventoryToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel3;
    }
}