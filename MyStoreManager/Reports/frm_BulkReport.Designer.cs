namespace MyStoreManager.Reports
{
    partial class frm_BulkReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BulkReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel = new System.Windows.Forms.Panel();
            this.ProddataGridView = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmd_VoucherType = new System.Windows.Forms.ComboBox();
            this.btnFilterSearch = new System.Windows.Forms.Button();
            this.rdBtnNepali = new System.Windows.Forms.RadioButton();
            this.rdBtnEnglish = new System.Windows.Forms.RadioButton();
            this.txtTo = new System.Windows.Forms.MaskedTextBox();
            this.txtFrom = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_CompanyName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Person = new System.Windows.Forms.Label();
            this.lbl_RoleName = new System.Windows.Forms.Label();
            this.lbl_TagStatus = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.BlueViolet;
            this.panel.Controls.Add(this.ProddataGridView);
            this.panel.Controls.Add(this.panel4);
            this.panel.Controls.Add(this.panel2);
            this.panel.Controls.Add(this.panel1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Font = new System.Drawing.Font("Verdana", 8F);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1298, 584);
            this.panel.TabIndex = 5;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // ProddataGridView
            // 
            this.ProddataGridView.AllowUserToAddRows = false;
            this.ProddataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProddataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProddataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProddataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ProddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProddataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProddataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProddataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ProddataGridView.GridColor = System.Drawing.Color.Indigo;
            this.ProddataGridView.Location = new System.Drawing.Point(0, 157);
            this.ProddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProddataGridView.Name = "ProddataGridView";
            this.ProddataGridView.ReadOnly = true;
            this.ProddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProddataGridView.Size = new System.Drawing.Size(1298, 397);
            this.ProddataGridView.TabIndex = 931;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cmd_VoucherType);
            this.panel4.Controls.Add(this.btnFilterSearch);
            this.panel4.Controls.Add(this.rdBtnNepali);
            this.panel4.Controls.Add(this.rdBtnEnglish);
            this.panel4.Controls.Add(this.txtTo);
            this.panel4.Controls.Add(this.txtFrom);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnExportToExcel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1298, 57);
            this.panel4.TabIndex = 930;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 937;
            this.label4.Text = "Select Report";
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
            this.cmd_VoucherType.Location = new System.Drawing.Point(3, 33);
            this.cmd_VoucherType.Name = "cmd_VoucherType";
            this.cmd_VoucherType.Size = new System.Drawing.Size(121, 21);
            this.cmd_VoucherType.TabIndex = 936;
            this.cmd_VoucherType.SelectedIndexChanged += new System.EventHandler(this.cmd_VoucherType_SelectedIndexChanged);
            // 
            // btnFilterSearch
            // 
            this.btnFilterSearch.BackColor = System.Drawing.Color.White;
            this.btnFilterSearch.ForeColor = System.Drawing.Color.Black;
            this.btnFilterSearch.Location = new System.Drawing.Point(414, 31);
            this.btnFilterSearch.Name = "btnFilterSearch";
            this.btnFilterSearch.Size = new System.Drawing.Size(106, 23);
            this.btnFilterSearch.TabIndex = 935;
            this.btnFilterSearch.Text = "&Get Report";
            this.btnFilterSearch.UseVisualStyleBackColor = false;
            this.btnFilterSearch.Click += new System.EventHandler(this.btnFilterSearch_Click);
            // 
            // rdBtnNepali
            // 
            this.rdBtnNepali.AutoSize = true;
            this.rdBtnNepali.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.rdBtnNepali.ForeColor = System.Drawing.Color.White;
            this.rdBtnNepali.Location = new System.Drawing.Point(306, 6);
            this.rdBtnNepali.Name = "rdBtnNepali";
            this.rdBtnNepali.Size = new System.Drawing.Size(93, 17);
            this.rdBtnNepali.TabIndex = 933;
            this.rdBtnNepali.Text = "Nepali Miti";
            this.rdBtnNepali.UseVisualStyleBackColor = true;
            this.rdBtnNepali.CheckedChanged += new System.EventHandler(this.rdBtnNepali_CheckedChanged);
            // 
            // rdBtnEnglish
            // 
            this.rdBtnEnglish.AutoSize = true;
            this.rdBtnEnglish.Checked = true;
            this.rdBtnEnglish.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.rdBtnEnglish.ForeColor = System.Drawing.Color.White;
            this.rdBtnEnglish.Location = new System.Drawing.Point(175, 6);
            this.rdBtnEnglish.Name = "rdBtnEnglish";
            this.rdBtnEnglish.Size = new System.Drawing.Size(106, 17);
            this.rdBtnEnglish.TabIndex = 934;
            this.rdBtnEnglish.TabStop = true;
            this.rdBtnEnglish.Text = "English Date";
            this.rdBtnEnglish.UseVisualStyleBackColor = true;
            this.rdBtnEnglish.CheckedChanged += new System.EventHandler(this.rdBtnEnglish_CheckedChanged);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(306, 33);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 932;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(176, 33);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 931;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(277, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 930;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(129, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 929;
            this.label1.Text = "From";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.White;
            this.btnExportToExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportToExcel.Location = new System.Drawing.Point(526, 31);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(139, 23);
            this.btnExportToExcel.TabIndex = 928;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lbl_Phone);
            this.panel2.Controls.Add(this.lbl_Address);
            this.panel2.Controls.Add(this.lbl_CompanyName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1298, 100);
            this.panel2.TabIndex = 929;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label14.Location = new System.Drawing.Point(1191, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 20);
            this.label14.TabIndex = 881;
            this.label14.Text = "Reports";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Phone.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.ForeColor = System.Drawing.Color.White;
            this.lbl_Phone.Location = new System.Drawing.Point(398, 69);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(549, 13);
            this.lbl_Phone.TabIndex = 878;
            this.lbl_Phone.Text = "Phone";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Address
            // 
            this.lbl_Address.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Address.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Address.ForeColor = System.Drawing.Color.White;
            this.lbl_Address.Location = new System.Drawing.Point(398, 46);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(549, 13);
            this.lbl_Address.TabIndex = 879;
            this.lbl_Address.Text = "Address";
            this.lbl_Address.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CompanyName
            // 
            this.lbl_CompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CompanyName.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompanyName.ForeColor = System.Drawing.Color.White;
            this.lbl_CompanyName.Location = new System.Drawing.Point(398, 11);
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.Size = new System.Drawing.Size(549, 35);
            this.lbl_CompanyName.TabIndex = 880;
            this.lbl_CompanyName.Text = "Company name";
            this.lbl_CompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Person);
            this.panel1.Controls.Add(this.lbl_RoleName);
            this.panel1.Controls.Add(this.lbl_TagStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1298, 30);
            this.panel1.TabIndex = 928;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lbl_Person
            // 
            this.lbl_Person.AutoSize = true;
            this.lbl_Person.ForeColor = System.Drawing.Color.White;
            this.lbl_Person.Location = new System.Drawing.Point(611, 10);
            this.lbl_Person.Name = "lbl_Person";
            this.lbl_Person.Size = new System.Drawing.Size(69, 13);
            this.lbl_Person.TabIndex = 109;
            this.lbl_Person.Text = "User name";
            this.lbl_Person.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.AutoSize = true;
            this.lbl_RoleName.ForeColor = System.Drawing.Color.White;
            this.lbl_RoleName.Location = new System.Drawing.Point(1235, 10);
            this.lbl_RoleName.Name = "lbl_RoleName";
            this.lbl_RoleName.Size = new System.Drawing.Size(51, 13);
            this.lbl_RoleName.TabIndex = 109;
            this.lbl_RoleName.Text = "User ID";
            this.lbl_RoleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_TagStatus
            // 
            this.lbl_TagStatus.AutoSize = true;
            this.lbl_TagStatus.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbl_TagStatus.Location = new System.Drawing.Point(12, 10);
            this.lbl_TagStatus.Name = "lbl_TagStatus";
            this.lbl_TagStatus.Size = new System.Drawing.Size(91, 13);
            this.lbl_TagStatus.TabIndex = 111;
            this.lbl_TagStatus.Text = "Copyright msg";
            this.lbl_TagStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::MyStoreManager.Properties.Resources.MyStoreManager_logo1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(1180, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(106, 56);
            this.panel3.TabIndex = 882;
            // 
            // frm_BulkReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 584);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_BulkReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frm_BulkReport_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridView ProddataGridView;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmd_VoucherType;
        private System.Windows.Forms.Button btnFilterSearch;
        private System.Windows.Forms.RadioButton rdBtnNepali;
        private System.Windows.Forms.RadioButton rdBtnEnglish;
        private System.Windows.Forms.MaskedTextBox txtTo;
        private System.Windows.Forms.MaskedTextBox txtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_CompanyName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Person;
        private System.Windows.Forms.Label lbl_RoleName;
        private System.Windows.Forms.Label lbl_TagStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInventoryToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
    }
}