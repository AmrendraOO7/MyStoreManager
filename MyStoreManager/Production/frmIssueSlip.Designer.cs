namespace MyStoreManager.Production
{
    partial class frmIssueSlip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueSlip));
            this.panel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.OrderProddataGridView = new System.Windows.Forms.DataGridView();
            this.btnAssigneeName = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAssigneeName = new System.Windows.Forms.TextBox();
            this.English_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtMiti = new System.Windows.Forms.MaskedTextBox();
            this.lblEstTime = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtDlvMiti = new System.Windows.Forms.Label();
            this.DlvEnglish_dateTimePicker = new System.Windows.Forms.Label();
            this.btnOrderTicket = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderVoucherNum = new System.Windows.Forms.MaskedTextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.ProddataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtProductName = new MyStoreManager.customTools.TextBoxChangedDelay();
            this.btn_order_VoucherSearch = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btn_ProductClear = new System.Windows.Forms.Button();
            this.ShortName = new System.Windows.Forms.Label();
            this.lblPShortname = new System.Windows.Forms.Label();
            this.ProductIDLabel = new System.Windows.Forms.Label();
            this.lbl_Barcode = new System.Windows.Forms.Label();
            this.lbl_ProductID = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Product_Search = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Btn_Product_Insert = new System.Windows.Forms.Button();
            this.Btn_CustoSearch = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVoucherNum = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtCompanyName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_TagStatus = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_CompanyName = new System.Windows.Forms.Label();
            this.lbl_RoleName = new System.Windows.Forms.Label();
            this.lbl_Person = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderProddataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.BlueViolet;
            this.panel.Controls.Add(this.label12);
            this.panel.Controls.Add(this.OrderProddataGridView);
            this.panel.Controls.Add(this.btnAssigneeName);
            this.panel.Controls.Add(this.label7);
            this.panel.Controls.Add(this.txtAssigneeName);
            this.panel.Controls.Add(this.English_dateTimePicker);
            this.panel.Controls.Add(this.txtMiti);
            this.panel.Controls.Add(this.lblEstTime);
            this.panel.Controls.Add(this.label35);
            this.panel.Controls.Add(this.txtDlvMiti);
            this.panel.Controls.Add(this.DlvEnglish_dateTimePicker);
            this.panel.Controls.Add(this.btnOrderTicket);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.txtOrderVoucherNum);
            this.panel.Controls.Add(this.lbl_status);
            this.panel.Controls.Add(this.ProddataGridView);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.btnPrint);
            this.panel.Controls.Add(this.txtProductName);
            this.panel.Controls.Add(this.btn_order_VoucherSearch);
            this.panel.Controls.Add(this.label22);
            this.panel.Controls.Add(this.label14);
            this.panel.Controls.Add(this.txtUnit);
            this.panel.Controls.Add(this.btn_ProductClear);
            this.panel.Controls.Add(this.ShortName);
            this.panel.Controls.Add(this.lblPShortname);
            this.panel.Controls.Add(this.ProductIDLabel);
            this.panel.Controls.Add(this.lbl_Barcode);
            this.panel.Controls.Add(this.lbl_ProductID);
            this.panel.Controls.Add(this.label23);
            this.panel.Controls.Add(this.label8);
            this.panel.Controls.Add(this.txt_Note);
            this.panel.Controls.Add(this.label10);
            this.panel.Controls.Add(this.txt_Quantity);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.btn_Product_Search);
            this.panel.Controls.Add(this.label9);
            this.panel.Controls.Add(this.Btn_Product_Insert);
            this.panel.Controls.Add(this.Btn_CustoSearch);
            this.panel.Controls.Add(this.label20);
            this.panel.Controls.Add(this.label13);
            this.panel.Controls.Add(this.txtVoucherNum);
            this.panel.Controls.Add(this.label11);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.TxtCompanyName);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.lbl_TagStatus);
            this.panel.Controls.Add(this.lbl_Phone);
            this.panel.Controls.Add(this.lbl_Address);
            this.panel.Controls.Add(this.lbl_CompanyName);
            this.panel.Controls.Add(this.lbl_RoleName);
            this.panel.Controls.Add(this.lbl_Person);
            this.panel.Controls.Add(this.Btn_Ok);
            this.panel.Controls.Add(this.panel3);
            this.panel.Controls.Add(this.btn_Delete);
            this.panel.Controls.Add(this.btn_Edit);
            this.panel.Controls.Add(this.btn_New);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Font = new System.Drawing.Font("Verdana", 8F);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(621, 695);
            this.panel.TabIndex = 4;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.GhostWhite;
            this.label12.Location = new System.Drawing.Point(12, 242);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 13);
            this.label12.TabIndex = 915;
            this.label12.Text = "ORDER DETAILS :-";
            // 
            // OrderProddataGridView
            // 
            this.OrderProddataGridView.AllowUserToAddRows = false;
            this.OrderProddataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.OrderProddataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.OrderProddataGridView.BackgroundColor = System.Drawing.Color.White;
            this.OrderProddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderProddataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.OrderProddataGridView.GridColor = System.Drawing.Color.Indigo;
            this.OrderProddataGridView.Location = new System.Drawing.Point(11, 257);
            this.OrderProddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrderProddataGridView.Name = "OrderProddataGridView";
            this.OrderProddataGridView.ReadOnly = true;
            this.OrderProddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrderProddataGridView.Size = new System.Drawing.Size(601, 153);
            this.OrderProddataGridView.TabIndex = 914;
            this.OrderProddataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.OrderProddataGridView_RowPostPaint);
            // 
            // btnAssigneeName
            // 
            this.btnAssigneeName.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btnAssigneeName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAssigneeName.Location = new System.Drawing.Point(381, 202);
            this.btnAssigneeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAssigneeName.Name = "btnAssigneeName";
            this.btnAssigneeName.Size = new System.Drawing.Size(22, 21);
            this.btnAssigneeName.TabIndex = 913;
            this.btnAssigneeName.UseVisualStyleBackColor = true;
            this.btnAssigneeName.Click += new System.EventHandler(this.btnAssigneeName_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 912;
            this.label7.Text = "Assignee Name:-";
            // 
            // txtAssigneeName
            // 
            this.txtAssigneeName.BackColor = System.Drawing.Color.MistyRose;
            this.txtAssigneeName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssigneeName.Location = new System.Drawing.Point(130, 202);
            this.txtAssigneeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAssigneeName.Name = "txtAssigneeName";
            this.txtAssigneeName.ReadOnly = true;
            this.txtAssigneeName.Size = new System.Drawing.Size(249, 21);
            this.txtAssigneeName.TabIndex = 6;
            this.txtAssigneeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAssigneeName_KeyDown);
            this.txtAssigneeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // English_dateTimePicker
            // 
            this.English_dateTimePicker.CalendarMonthBackground = System.Drawing.Color.MistyRose;
            this.English_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.English_dateTimePicker.Location = new System.Drawing.Point(317, 118);
            this.English_dateTimePicker.Name = "English_dateTimePicker";
            this.English_dateTimePicker.Size = new System.Drawing.Size(97, 20);
            this.English_dateTimePicker.TabIndex = 2;
            this.English_dateTimePicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            this.English_dateTimePicker.Leave += new System.EventHandler(this.English_dateTimePicker_Leave);
            // 
            // txtMiti
            // 
            this.txtMiti.BackColor = System.Drawing.Color.MistyRose;
            this.txtMiti.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiti.Location = new System.Drawing.Point(317, 154);
            this.txtMiti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiti.Name = "txtMiti";
            this.txtMiti.ReadOnly = true;
            this.txtMiti.Size = new System.Drawing.Size(99, 21);
            this.txtMiti.TabIndex = 3;
            this.txtMiti.ValidatingType = typeof(System.DateTime);
            this.txtMiti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // lblEstTime
            // 
            this.lblEstTime.AutoSize = true;
            this.lblEstTime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstTime.ForeColor = System.Drawing.Color.White;
            this.lblEstTime.Location = new System.Drawing.Point(407, 195);
            this.lblEstTime.Name = "lblEstTime";
            this.lblEstTime.Size = new System.Drawing.Size(104, 13);
            this.lblEstTime.TabIndex = 908;
            this.lblEstTime.Text = "Total EST Time";
            this.lblEstTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(406, 179);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(114, 13);
            this.label35.TabIndex = 907;
            this.label35.Text = "Total EST Time:-";
            // 
            // txtDlvMiti
            // 
            this.txtDlvMiti.AutoSize = true;
            this.txtDlvMiti.BackColor = System.Drawing.Color.Transparent;
            this.txtDlvMiti.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDlvMiti.ForeColor = System.Drawing.Color.White;
            this.txtDlvMiti.Location = new System.Drawing.Point(421, 157);
            this.txtDlvMiti.Name = "txtDlvMiti";
            this.txtDlvMiti.Size = new System.Drawing.Size(55, 13);
            this.txtDlvMiti.TabIndex = 906;
            this.txtDlvMiti.Text = "Dlv Miti";
            // 
            // DlvEnglish_dateTimePicker
            // 
            this.DlvEnglish_dateTimePicker.AutoSize = true;
            this.DlvEnglish_dateTimePicker.BackColor = System.Drawing.Color.Transparent;
            this.DlvEnglish_dateTimePicker.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DlvEnglish_dateTimePicker.ForeColor = System.Drawing.Color.White;
            this.DlvEnglish_dateTimePicker.Location = new System.Drawing.Point(421, 121);
            this.DlvEnglish_dateTimePicker.Name = "DlvEnglish_dateTimePicker";
            this.DlvEnglish_dateTimePicker.Size = new System.Drawing.Size(62, 13);
            this.DlvEnglish_dateTimePicker.TabIndex = 905;
            this.DlvEnglish_dateTimePicker.Text = "Dlv Date";
            // 
            // btnOrderTicket
            // 
            this.btnOrderTicket.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btnOrderTicket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrderTicket.Location = new System.Drawing.Point(284, 152);
            this.btnOrderTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderTicket.Name = "btnOrderTicket";
            this.btnOrderTicket.Size = new System.Drawing.Size(22, 21);
            this.btnOrderTicket.TabIndex = 902;
            this.btnOrderTicket.UseVisualStyleBackColor = true;
            this.btnOrderTicket.Click += new System.EventHandler(this.btnOrderTicket_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 901;
            this.label4.Text = "Order Ticket No:- ";
            // 
            // txtOrderVoucherNum
            // 
            this.txtOrderVoucherNum.BackColor = System.Drawing.Color.MistyRose;
            this.txtOrderVoucherNum.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderVoucherNum.Location = new System.Drawing.Point(130, 152);
            this.txtOrderVoucherNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrderVoucherNum.Name = "txtOrderVoucherNum";
            this.txtOrderVoucherNum.ReadOnly = true;
            this.txtOrderVoucherNum.Size = new System.Drawing.Size(152, 21);
            this.txtOrderVoucherNum.TabIndex = 4;
            this.txtOrderVoucherNum.ValidatingType = typeof(System.DateTime);
            this.txtOrderVoucherNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderVoucherNum_KeyDown);
            this.txtOrderVoucherNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.ForeColor = System.Drawing.Color.White;
            this.lbl_status.Location = new System.Drawing.Point(165, 103);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(89, 13);
            this.lbl_status.TabIndex = 899;
            this.lbl_status.Text = "Order Status";
            // 
            // ProddataGridView
            // 
            this.ProddataGridView.AllowUserToAddRows = false;
            this.ProddataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ProddataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ProddataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ProddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProddataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ProddataGridView.GridColor = System.Drawing.Color.Indigo;
            this.ProddataGridView.Location = new System.Drawing.Point(10, 483);
            this.ProddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProddataGridView.Name = "ProddataGridView";
            this.ProddataGridView.ReadOnly = true;
            this.ProddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProddataGridView.Size = new System.Drawing.Size(601, 153);
            this.ProddataGridView.TabIndex = 898;
            this.ProddataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProddataGridView_CellContentDoubleClick);
            this.ProddataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ProddataGridView_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(421, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 897;
            this.label1.Text = "Dlv Miti:- ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(421, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 896;
            this.label2.Text = "Dlv Date:- ";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 8F);
            this.btnPrint.ForeColor = System.Drawing.Color.Indigo;
            this.btnPrint.Location = new System.Drawing.Point(528, 187);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(83, 28);
            this.btnPrint.TabIndex = 893;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(10, 461);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(288, 20);
            this.txtProductName.TabIndex = 7;
            this.txtProductName.TextChangedDelayedInterval = 1000;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // btn_order_VoucherSearch
            // 
            this.btn_order_VoucherSearch.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btn_order_VoucherSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_order_VoucherSearch.Location = new System.Drawing.Point(284, 127);
            this.btn_order_VoucherSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_order_VoucherSearch.Name = "btn_order_VoucherSearch";
            this.btn_order_VoucherSearch.Size = new System.Drawing.Size(22, 21);
            this.btn_order_VoucherSearch.TabIndex = 880;
            this.btn_order_VoucherSearch.UseVisualStyleBackColor = true;
            this.btn_order_VoucherSearch.Click += new System.EventHandler(this.btn_order_VoucherSearch_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.GhostWhite;
            this.label22.Location = new System.Drawing.Point(6, 425);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(139, 13);
            this.label22.TabIndex = 877;
            this.label22.Text = "PRODUCT DETAILS :-";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label14.Location = new System.Drawing.Point(482, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 20);
            this.label14.TabIndex = 876;
            this.label14.Text = "Issue Ticket";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnit
            // 
            this.txtUnit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.Location = new System.Drawing.Point(409, 460);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(72, 21);
            this.txtUnit.TabIndex = 9;
            this.txtUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // btn_ProductClear
            // 
            this.btn_ProductClear.BackgroundImage = global::MyStoreManager.Properties.Resources.Redo;
            this.btn_ProductClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ProductClear.Location = new System.Drawing.Point(585, 457);
            this.btn_ProductClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ProductClear.Name = "btn_ProductClear";
            this.btn_ProductClear.Size = new System.Drawing.Size(26, 25);
            this.btn_ProductClear.TabIndex = 853;
            this.btn_ProductClear.UseVisualStyleBackColor = true;
            this.btn_ProductClear.Click += new System.EventHandler(this.btn_ProductClear_Click);
            // 
            // ShortName
            // 
            this.ShortName.AutoSize = true;
            this.ShortName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ShortName.ForeColor = System.Drawing.Color.White;
            this.ShortName.Location = new System.Drawing.Point(220, 423);
            this.ShortName.Name = "ShortName";
            this.ShortName.Size = new System.Drawing.Size(68, 13);
            this.ShortName.TabIndex = 851;
            this.ShortName.Text = "S-Name:-";
            // 
            // lblPShortname
            // 
            this.lblPShortname.AutoSize = true;
            this.lblPShortname.ForeColor = System.Drawing.Color.White;
            this.lblPShortname.Location = new System.Drawing.Point(289, 423);
            this.lblPShortname.Name = "lblPShortname";
            this.lblPShortname.Size = new System.Drawing.Size(45, 13);
            this.lblPShortname.TabIndex = 852;
            this.lblPShortname.Text = "sname";
            // 
            // ProductIDLabel
            // 
            this.ProductIDLabel.AutoSize = true;
            this.ProductIDLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ProductIDLabel.ForeColor = System.Drawing.Color.White;
            this.ProductIDLabel.Location = new System.Drawing.Point(150, 424);
            this.ProductIDLabel.Name = "ProductIDLabel";
            this.ProductIDLabel.Size = new System.Drawing.Size(40, 13);
            this.ProductIDLabel.TabIndex = 846;
            this.ProductIDLabel.Text = "PID:-";
            // 
            // lbl_Barcode
            // 
            this.lbl_Barcode.AutoSize = true;
            this.lbl_Barcode.ForeColor = System.Drawing.Color.White;
            this.lbl_Barcode.Location = new System.Drawing.Point(393, 423);
            this.lbl_Barcode.Name = "lbl_Barcode";
            this.lbl_Barcode.Size = new System.Drawing.Size(41, 13);
            this.lbl_Barcode.TabIndex = 850;
            this.lbl_Barcode.Text = "bcode";
            // 
            // lbl_ProductID
            // 
            this.lbl_ProductID.AutoSize = true;
            this.lbl_ProductID.ForeColor = System.Drawing.Color.White;
            this.lbl_ProductID.Location = new System.Drawing.Point(190, 423);
            this.lbl_ProductID.Name = "lbl_ProductID";
            this.lbl_ProductID.Size = new System.Drawing.Size(24, 13);
            this.lbl_ProductID.TabIndex = 849;
            this.lbl_ProductID.Text = "pid";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(324, 445);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 13);
            this.label23.TabIndex = 848;
            this.label23.Text = "Quantity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(338, 423);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 847;
            this.label8.Text = "B-Code:-";
            // 
            // txt_Note
            // 
            this.txt_Note.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Note.Location = new System.Drawing.Point(58, 639);
            this.txt_Note.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(437, 21);
            this.txt_Note.TabIndex = 11;
            this.txt_Note.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(8, 642);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 845;
            this.label10.Text = "Note:-";
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(327, 460);
            this.txt_Quantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(79, 21);
            this.txt_Quantity.TabIndex = 8;
            this.txt_Quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalDecimal_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(407, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 843;
            this.label5.Text = "Unit:";
            // 
            // btn_Product_Search
            // 
            this.btn_Product_Search.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btn_Product_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Product_Search.Location = new System.Drawing.Point(300, 460);
            this.btn_Product_Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Product_Search.Name = "btn_Product_Search";
            this.btn_Product_Search.Size = new System.Drawing.Size(22, 21);
            this.btn_Product_Search.TabIndex = 842;
            this.btn_Product_Search.UseVisualStyleBackColor = true;
            this.btn_Product_Search.Click += new System.EventHandler(this.btn_Product_Search_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 444);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 841;
            this.label9.Text = "Product Name:";
            // 
            // Btn_Product_Insert
            // 
            this.Btn_Product_Insert.BackColor = System.Drawing.Color.White;
            this.Btn_Product_Insert.Font = new System.Drawing.Font("Verdana", 8F);
            this.Btn_Product_Insert.ForeColor = System.Drawing.Color.Indigo;
            this.Btn_Product_Insert.Location = new System.Drawing.Point(487, 458);
            this.Btn_Product_Insert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Product_Insert.Name = "Btn_Product_Insert";
            this.Btn_Product_Insert.Size = new System.Drawing.Size(97, 24);
            this.Btn_Product_Insert.TabIndex = 10;
            this.Btn_Product_Insert.Text = "&Enter Product";
            this.Btn_Product_Insert.UseVisualStyleBackColor = false;
            this.Btn_Product_Insert.Click += new System.EventHandler(this.Btn_Product_Insert_Click);
            // 
            // Btn_CustoSearch
            // 
            this.Btn_CustoSearch.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.Btn_CustoSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_CustoSearch.Location = new System.Drawing.Point(381, 177);
            this.Btn_CustoSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_CustoSearch.Name = "Btn_CustoSearch";
            this.Btn_CustoSearch.Size = new System.Drawing.Size(22, 21);
            this.Btn_CustoSearch.TabIndex = 828;
            this.Btn_CustoSearch.UseVisualStyleBackColor = true;
            this.Btn_CustoSearch.Click += new System.EventHandler(this.Btn_CustoSearch_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(6, 183);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 13);
            this.label20.TabIndex = 824;
            this.label20.Text = "Company Name:-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(6, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 13);
            this.label13.TabIndex = 823;
            this.label13.Text = "Issue Ticket No:- ";
            // 
            // txtVoucherNum
            // 
            this.txtVoucherNum.BackColor = System.Drawing.Color.MistyRose;
            this.txtVoucherNum.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherNum.Location = new System.Drawing.Point(130, 127);
            this.txtVoucherNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVoucherNum.Name = "txtVoucherNum";
            this.txtVoucherNum.ReadOnly = true;
            this.txtVoucherNum.Size = new System.Drawing.Size(152, 21);
            this.txtVoucherNum.TabIndex = 1;
            this.txtVoucherNum.ValidatingType = typeof(System.DateTime);
            this.txtVoucherNum.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtVoucherNum_MaskInputRejected);
            this.txtVoucherNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherNum_KeyDown);
            this.txtVoucherNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(314, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 822;
            this.label11.Text = "Issue Miti:- ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(314, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 821;
            this.label6.Text = "Issue Date:- ";
            // 
            // TxtCompanyName
            // 
            this.TxtCompanyName.BackColor = System.Drawing.Color.MistyRose;
            this.TxtCompanyName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCompanyName.Location = new System.Drawing.Point(130, 177);
            this.TxtCompanyName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtCompanyName.Name = "TxtCompanyName";
            this.TxtCompanyName.ReadOnly = true;
            this.TxtCompanyName.Size = new System.Drawing.Size(249, 21);
            this.TxtCompanyName.TabIndex = 5;
            this.TxtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCompanyName_KeyDown);
            this.TxtCompanyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GhostWhite;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 820;
            this.label3.Text = "PARTY DETAILS :-";
            // 
            // lbl_TagStatus
            // 
            this.lbl_TagStatus.AutoSize = true;
            this.lbl_TagStatus.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbl_TagStatus.Location = new System.Drawing.Point(8, 665);
            this.lbl_TagStatus.Name = "lbl_TagStatus";
            this.lbl_TagStatus.Size = new System.Drawing.Size(91, 13);
            this.lbl_TagStatus.TabIndex = 111;
            this.lbl_TagStatus.Text = "Copyright msg";
            this.lbl_TagStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Phone.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.ForeColor = System.Drawing.Color.White;
            this.lbl_Phone.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Phone.Location = new System.Drawing.Point(34, 67);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(471, 13);
            this.lbl_Phone.TabIndex = 110;
            this.lbl_Phone.Text = "Phone";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Address
            // 
            this.lbl_Address.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Address.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Address.ForeColor = System.Drawing.Color.White;
            this.lbl_Address.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Address.Location = new System.Drawing.Point(24, 44);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(498, 13);
            this.lbl_Address.TabIndex = 110;
            this.lbl_Address.Text = "Address";
            this.lbl_Address.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_CompanyName
            // 
            this.lbl_CompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CompanyName.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompanyName.ForeColor = System.Drawing.Color.White;
            this.lbl_CompanyName.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_CompanyName.Location = new System.Drawing.Point(24, 9);
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.Size = new System.Drawing.Size(498, 35);
            this.lbl_CompanyName.TabIndex = 110;
            this.lbl_CompanyName.Text = "Company name";
            this.lbl_CompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.AutoSize = true;
            this.lbl_RoleName.ForeColor = System.Drawing.Color.White;
            this.lbl_RoleName.Location = new System.Drawing.Point(444, 665);
            this.lbl_RoleName.Name = "lbl_RoleName";
            this.lbl_RoleName.Size = new System.Drawing.Size(51, 13);
            this.lbl_RoleName.TabIndex = 109;
            this.lbl_RoleName.Text = "User ID";
            this.lbl_RoleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Person
            // 
            this.lbl_Person.AutoSize = true;
            this.lbl_Person.ForeColor = System.Drawing.Color.White;
            this.lbl_Person.Location = new System.Drawing.Point(241, 665);
            this.lbl_Person.Name = "lbl_Person";
            this.lbl_Person.Size = new System.Drawing.Size(69, 13);
            this.lbl_Person.TabIndex = 109;
            this.lbl_Person.Text = "User name";
            this.lbl_Person.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.BackColor = System.Drawing.Color.White;
            this.Btn_Ok.Font = new System.Drawing.Font("Verdana", 8F);
            this.Btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.Btn_Ok.Location = new System.Drawing.Point(501, 639);
            this.Btn_Ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(112, 40);
            this.Btn_Ok.TabIndex = 12;
            this.Btn_Ok.Text = "&Save Order";
            this.Btn_Ok.UseVisualStyleBackColor = false;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::MyStoreManager.Properties.Resources.Logo_PNG;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(528, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(85, 49);
            this.panel3.TabIndex = 53;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.White;
            this.btn_Delete.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Delete.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Delete.Location = new System.Drawing.Point(528, 159);
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
            this.btn_Edit.Location = new System.Drawing.Point(528, 131);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(83, 28);
            this.btn_Edit.TabIndex = 22;
            this.btn_Edit.Text = "&Edit";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.Color.White;
            this.btn_New.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_New.ForeColor = System.Drawing.Color.Indigo;
            this.btn_New.Location = new System.Drawing.Point(528, 103);
            this.btn_New.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(83, 28);
            this.btn_New.TabIndex = 0;
            this.btn_New.Text = "&New";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
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
            // printDocument
            // 
            this.printDocument.DocumentName = "OT Print";
            // 
            // frmIssueSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 695);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIssueSlip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Card";
            this.Load += new System.EventHandler(this.frmIssueSlip_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderProddataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.DataGridView ProddataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private customTools.TextBoxChangedDelay txtProductName;
        private System.Windows.Forms.Button btn_order_VoucherSearch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btn_ProductClear;
        private System.Windows.Forms.Label ShortName;
        private System.Windows.Forms.Label lblPShortname;
        private System.Windows.Forms.Label ProductIDLabel;
        private System.Windows.Forms.Label lbl_Barcode;
        private System.Windows.Forms.Label lbl_ProductID;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Note;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Product_Search;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_Product_Insert;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtVoucherNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtCompanyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_TagStatus;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_CompanyName;
        private System.Windows.Forms.Label lbl_RoleName;
        private System.Windows.Forms.Label lbl_Person;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnOrderTicket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtOrderVoucherNum;
        private System.Windows.Forms.Label txtDlvMiti;
        private System.Windows.Forms.Label DlvEnglish_dateTimePicker;
        private System.Windows.Forms.Button Btn_CustoSearch;
        private System.Windows.Forms.Label lblEstTime;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DateTimePicker English_dateTimePicker;
        private System.Windows.Forms.MaskedTextBox txtMiti;
        private System.Windows.Forms.Button btnAssigneeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAssigneeName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView OrderProddataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInventoryToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}