namespace MyStoreManager.Production
{
    partial class frmOrderProductionStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderProductionStart));
            this.panel = new System.Windows.Forms.Panel();
            this.btn_order_VoucherSearch = new System.Windows.Forms.Button();
            this.txtVoucherNum = new System.Windows.Forms.MaskedTextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProddataGridView = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_TagStatus = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_CompanyName = new System.Windows.Forms.Label();
            this.lbl_RoleName = new System.Windows.Forms.Label();
            this.lbl_Person = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.BlueViolet;
            this.panel.Controls.Add(this.btn_order_VoucherSearch);
            this.panel.Controls.Add(this.txtVoucherNum);
            this.panel.Controls.Add(this.btn_Start);
            this.panel.Controls.Add(this.label1);
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
            this.panel.Size = new System.Drawing.Size(930, 566);
            this.panel.TabIndex = 5;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // btn_order_VoucherSearch
            // 
            this.btn_order_VoucherSearch.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btn_order_VoucherSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_order_VoucherSearch.Location = new System.Drawing.Point(726, 130);
            this.btn_order_VoucherSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_order_VoucherSearch.Name = "btn_order_VoucherSearch";
            this.btn_order_VoucherSearch.Size = new System.Drawing.Size(22, 21);
            this.btn_order_VoucherSearch.TabIndex = 904;
            this.btn_order_VoucherSearch.UseVisualStyleBackColor = true;
            this.btn_order_VoucherSearch.Click += new System.EventHandler(this.btn_order_VoucherSearch_Click);
            // 
            // txtVoucherNum
            // 
            this.txtVoucherNum.BackColor = System.Drawing.Color.MistyRose;
            this.txtVoucherNum.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherNum.Location = new System.Drawing.Point(12, 130);
            this.txtVoucherNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVoucherNum.Name = "txtVoucherNum";
            this.txtVoucherNum.ReadOnly = true;
            this.txtVoucherNum.Size = new System.Drawing.Size(711, 21);
            this.txtVoucherNum.TabIndex = 903;
            this.txtVoucherNum.ValidatingType = typeof(System.DateTime);
            this.txtVoucherNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVoucherNum_KeyPress);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.White;
            this.btn_Start.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Start.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Start.Location = new System.Drawing.Point(780, 125);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(137, 28);
            this.btn_Start.TabIndex = 902;
            this.btn_Start.Text = "&Start Processing";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 900;
            this.label1.Text = "Select Order In-Process";
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
            this.ProddataGridView.Location = new System.Drawing.Point(12, 155);
            this.ProddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProddataGridView.Name = "ProddataGridView";
            this.ProddataGridView.ReadOnly = true;
            this.ProddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProddataGridView.Size = new System.Drawing.Size(905, 372);
            this.ProddataGridView.TabIndex = 898;
            this.ProddataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProddataGridView_CellMouseDoubleClick);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label14.Location = new System.Drawing.Point(759, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 20);
            this.label14.TabIndex = 876;
            this.label14.Text = "In-Process List";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_TagStatus
            // 
            this.lbl_TagStatus.AutoSize = true;
            this.lbl_TagStatus.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbl_TagStatus.Location = new System.Drawing.Point(12, 538);
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
            this.lbl_Phone.Size = new System.Drawing.Size(700, 13);
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
            this.lbl_Address.Size = new System.Drawing.Size(727, 13);
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
            this.lbl_CompanyName.Size = new System.Drawing.Size(727, 35);
            this.lbl_CompanyName.TabIndex = 110;
            this.lbl_CompanyName.Text = "Company name";
            this.lbl_CompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.AutoSize = true;
            this.lbl_RoleName.ForeColor = System.Drawing.Color.White;
            this.lbl_RoleName.Location = new System.Drawing.Point(866, 538);
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
            this.lbl_Person.Location = new System.Drawing.Point(481, 538);
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
            this.panel3.Location = new System.Drawing.Point(790, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 69);
            this.panel3.TabIndex = 53;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
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
            // frmOrderProductionStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 566);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "frmOrderProductionStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order In-Process";
            this.Load += new System.EventHandler(this.frmOrderProductionStart_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProddataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.DataGridView ProddataGridView;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_TagStatus;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_CompanyName;
        private System.Windows.Forms.Label lbl_RoleName;
        private System.Windows.Forms.Label lbl_Person;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_order_VoucherSearch;
        private System.Windows.Forms.MaskedTextBox txtVoucherNum;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}