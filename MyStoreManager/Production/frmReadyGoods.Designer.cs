namespace MyStoreManager.Production
{
    partial class frmReadyGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadyGoods));
            this.ProddataGridView = new System.Windows.Forms.DataGridView();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label14 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.panel = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_order_TextSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFilterSearch = new System.Windows.Forms.Button();
            this.rdBtnNepali = new System.Windows.Forms.RadioButton();
            this.rdBtnEnglish = new System.Windows.Forms.RadioButton();
            this.txtTo = new System.Windows.Forms.MaskedTextBox();
            this.txtFrom = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnReadyAndDelivered = new System.Windows.Forms.RadioButton();
            this.rdDeliveredGoods = new System.Windows.Forms.RadioButton();
            this.rdBtnReadyGoods = new System.Windows.Forms.RadioButton();
            this.rdBtnAll = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSearchOption = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_TagStatus = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_CompanyName = new System.Windows.Forms.Label();
            this.lbl_RoleName = new System.Windows.Forms.Label();
            this.lbl_Person = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.ProddataGridView.Location = new System.Drawing.Point(10, 222);
            this.ProddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProddataGridView.Name = "ProddataGridView";
            this.ProddataGridView.ReadOnly = true;
            this.ProddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProddataGridView.Size = new System.Drawing.Size(989, 372);
            this.ProddataGridView.TabIndex = 898;
            this.ProddataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProddataGridView_CellMouseDoubleClick);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label14.Location = new System.Drawing.Point(841, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 20);
            this.label14.TabIndex = 876;
            this.label14.Text = "Ready Goods";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 26);
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "OT Print";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.BlueViolet;
            this.panel.Controls.Add(this.groupBox3);
            this.panel.Controls.Add(this.ProddataGridView);
            this.panel.Controls.Add(this.label14);
            this.panel.Controls.Add(this.lbl_TagStatus);
            this.panel.Controls.Add(this.lbl_Phone);
            this.panel.Controls.Add(this.lbl_Address);
            this.panel.Controls.Add(this.lbl_CompanyName);
            this.panel.Controls.Add(this.lbl_RoleName);
            this.panel.Controls.Add(this.lbl_Person);
            this.panel.Controls.Add(this.panel3);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Font = new System.Drawing.Font("Verdana", 8F);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1009, 627);
            this.panel.TabIndex = 4;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btn_order_TextSearch);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.btnExportToExcel);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.txtSearch);
            this.groupBox3.Controls.Add(this.cmbSearchOption);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(987, 120);
            this.groupBox3.TabIndex = 901;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // btn_order_TextSearch
            // 
            this.btn_order_TextSearch.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btn_order_TextSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_order_TextSearch.Location = new System.Drawing.Point(682, 82);
            this.btn_order_TextSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_order_TextSearch.Name = "btn_order_TextSearch";
            this.btn_order_TextSearch.Size = new System.Drawing.Size(26, 24);
            this.btn_order_TextSearch.TabIndex = 909;
            this.btn_order_TextSearch.UseVisualStyleBackColor = true;
            this.btn_order_TextSearch.Click += new System.EventHandler(this.btn_order_TextSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnFilterSearch);
            this.groupBox2.Controls.Add(this.rdBtnNepali);
            this.groupBox2.Controls.Add(this.rdBtnEnglish);
            this.groupBox2.Controls.Add(this.txtTo);
            this.groupBox2.Controls.Add(this.txtFrom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(730, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 99);
            this.groupBox2.TabIndex = 900;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Wise Search";
            // 
            // btnFilterSearch
            // 
            this.btnFilterSearch.BackColor = System.Drawing.Color.White;
            this.btnFilterSearch.ForeColor = System.Drawing.Color.Black;
            this.btnFilterSearch.Location = new System.Drawing.Point(157, 64);
            this.btnFilterSearch.Name = "btnFilterSearch";
            this.btnFilterSearch.Size = new System.Drawing.Size(75, 23);
            this.btnFilterSearch.TabIndex = 907;
            this.btnFilterSearch.Text = "Search";
            this.btnFilterSearch.UseVisualStyleBackColor = false;
            this.btnFilterSearch.Click += new System.EventHandler(this.btnFilterSearch_Click);
            // 
            // rdBtnNepali
            // 
            this.rdBtnNepali.AutoSize = true;
            this.rdBtnNepali.Location = new System.Drawing.Point(147, 14);
            this.rdBtnNepali.Name = "rdBtnNepali";
            this.rdBtnNepali.Size = new System.Drawing.Size(93, 17);
            this.rdBtnNepali.TabIndex = 905;
            this.rdBtnNepali.Text = "Nepali Miti";
            this.rdBtnNepali.UseVisualStyleBackColor = true;
            this.rdBtnNepali.CheckedChanged += new System.EventHandler(this.rdBtnNepali_CheckedChanged);
            // 
            // rdBtnEnglish
            // 
            this.rdBtnEnglish.AutoSize = true;
            this.rdBtnEnglish.Checked = true;
            this.rdBtnEnglish.Location = new System.Drawing.Point(16, 14);
            this.rdBtnEnglish.Name = "rdBtnEnglish";
            this.rdBtnEnglish.Size = new System.Drawing.Size(106, 17);
            this.rdBtnEnglish.TabIndex = 906;
            this.rdBtnEnglish.TabStop = true;
            this.rdBtnEnglish.Text = "English Date";
            this.rdBtnEnglish.UseVisualStyleBackColor = true;
            this.rdBtnEnglish.CheckedChanged += new System.EventHandler(this.rdBtnEnglish_CheckedChanged);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(51, 67);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 21);
            this.txtTo.TabIndex = 904;
            this.txtTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalDecimal_KeyPress);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(51, 44);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 21);
            this.txtFrom.TabIndex = 903;
            this.txtFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GlobalDecimal_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 902;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 901;
            this.label1.Text = "From";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.White;
            this.btnExportToExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportToExcel.Location = new System.Drawing.Point(526, 33);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(139, 23);
            this.btnExportToExcel.TabIndex = 908;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdBtnReadyAndDelivered);
            this.groupBox1.Controls.Add(this.rdDeliveredGoods);
            this.groupBox1.Controls.Add(this.rdBtnReadyGoods);
            this.groupBox1.Controls.Add(this.rdBtnAll);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 52);
            this.groupBox1.TabIndex = 899;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Status";
            // 
            // rdBtnReadyAndDelivered
            // 
            this.rdBtnReadyAndDelivered.AutoSize = true;
            this.rdBtnReadyAndDelivered.Location = new System.Drawing.Point(250, 20);
            this.rdBtnReadyAndDelivered.Name = "rdBtnReadyAndDelivered";
            this.rdBtnReadyAndDelivered.Size = new System.Drawing.Size(146, 17);
            this.rdBtnReadyAndDelivered.TabIndex = 0;
            this.rdBtnReadyAndDelivered.Text = "Ready && Delivered";
            this.rdBtnReadyAndDelivered.UseVisualStyleBackColor = true;
            this.rdBtnReadyAndDelivered.CheckedChanged += new System.EventHandler(this.rdBtnReadyAndDelivered_CheckedChanged);
            // 
            // rdDeliveredGoods
            // 
            this.rdDeliveredGoods.AutoSize = true;
            this.rdDeliveredGoods.Location = new System.Drawing.Point(118, 20);
            this.rdDeliveredGoods.Name = "rdDeliveredGoods";
            this.rdDeliveredGoods.Size = new System.Drawing.Size(132, 17);
            this.rdDeliveredGoods.TabIndex = 0;
            this.rdDeliveredGoods.Text = "Delivered Goods";
            this.rdDeliveredGoods.UseVisualStyleBackColor = true;
            this.rdDeliveredGoods.CheckedChanged += new System.EventHandler(this.rdDeliveredGoods_CheckedChanged);
            // 
            // rdBtnReadyGoods
            // 
            this.rdBtnReadyGoods.AutoSize = true;
            this.rdBtnReadyGoods.Checked = true;
            this.rdBtnReadyGoods.Location = new System.Drawing.Point(9, 20);
            this.rdBtnReadyGoods.Name = "rdBtnReadyGoods";
            this.rdBtnReadyGoods.Size = new System.Drawing.Size(109, 17);
            this.rdBtnReadyGoods.TabIndex = 0;
            this.rdBtnReadyGoods.TabStop = true;
            this.rdBtnReadyGoods.Text = "Ready Goods";
            this.rdBtnReadyGoods.UseVisualStyleBackColor = true;
            this.rdBtnReadyGoods.CheckedChanged += new System.EventHandler(this.rdBtnReadyGoods_CheckedChanged);
            // 
            // rdBtnAll
            // 
            this.rdBtnAll.AutoSize = true;
            this.rdBtnAll.Location = new System.Drawing.Point(396, 20);
            this.rdBtnAll.Name = "rdBtnAll";
            this.rdBtnAll.Size = new System.Drawing.Size(42, 17);
            this.rdBtnAll.TabIndex = 0;
            this.rdBtnAll.Text = "All";
            this.rdBtnAll.UseVisualStyleBackColor = true;
            this.rdBtnAll.CheckedChanged += new System.EventHandler(this.rdBtnAll_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(293, 82);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(389, 23);
            this.txtSearch.TabIndex = 904;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cmbSearchOption
            // 
            this.cmbSearchOption.FormattingEnabled = true;
            this.cmbSearchOption.Location = new System.Drawing.Point(137, 81);
            this.cmbSearchOption.Name = "cmbSearchOption";
            this.cmbSearchOption.Size = new System.Drawing.Size(156, 24);
            this.cmbSearchOption.TabIndex = 903;
            this.cmbSearchOption.SelectedIndexChanged += new System.EventHandler(this.cmbSearchOption_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 902;
            this.label3.Text = "Select search by:-";
            // 
            // lbl_TagStatus
            // 
            this.lbl_TagStatus.AutoSize = true;
            this.lbl_TagStatus.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbl_TagStatus.Location = new System.Drawing.Point(21, 605);
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
            this.lbl_Phone.Location = new System.Drawing.Point(160, 69);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(549, 13);
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
            this.lbl_Address.Location = new System.Drawing.Point(160, 46);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(549, 13);
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
            this.lbl_CompanyName.Location = new System.Drawing.Point(160, 11);
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.Size = new System.Drawing.Size(549, 35);
            this.lbl_CompanyName.TabIndex = 110;
            this.lbl_CompanyName.Text = "Company name";
            this.lbl_CompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.AutoSize = true;
            this.lbl_RoleName.ForeColor = System.Drawing.Color.White;
            this.lbl_RoleName.Location = new System.Drawing.Point(935, 605);
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
            this.lbl_Person.Location = new System.Drawing.Point(480, 605);
            this.lbl_Person.Name = "lbl_Person";
            this.lbl_Person.Size = new System.Drawing.Size(69, 13);
            this.lbl_Person.TabIndex = 109;
            this.lbl_Person.Text = "User name";
            this.lbl_Person.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::MyStoreManager.Properties.Resources.Logo_PNG;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(893, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(106, 56);
            this.panel3.TabIndex = 53;
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
            // frmReadyGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 627);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmReadyGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ready Goods";
            this.Load += new System.EventHandler(this.frmReadyGoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ProddataGridView;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lbl_TagStatus;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_CompanyName;
        private System.Windows.Forms.Label lbl_RoleName;
        private System.Windows.Forms.Label lbl_Person;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtnReadyAndDelivered;
        private System.Windows.Forms.RadioButton rdDeliveredGoods;
        private System.Windows.Forms.RadioButton rdBtnReadyGoods;
        private System.Windows.Forms.RadioButton rdBtnAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFilterSearch;
        private System.Windows.Forms.RadioButton rdBtnNepali;
        private System.Windows.Forms.RadioButton rdBtnEnglish;
        private System.Windows.Forms.MaskedTextBox txtTo;
        private System.Windows.Forms.MaskedTextBox txtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbSearchOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_order_TextSearch;
    }
}