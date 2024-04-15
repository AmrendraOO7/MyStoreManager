
namespace MyStoreManager.Setup
{
    partial class frm_Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Configuration));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCompType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBillMsg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkAutoPrint = new System.Windows.Forms.CheckBox();
            this.chkPrintMessage = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkReturnNotes = new System.Windows.Forms.CheckBox();
            this.chkNotes = new System.Windows.Forms.CheckBox();
            this.chk_DateTime_Check = new System.Windows.Forms.CheckBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Color = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_IsAdmin = new System.Windows.Forms.CheckBox();
            this.cmb_FiscalYear = new System.Windows.Forms.ComboBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.chkProduction = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BlueViolet;
            this.panel1.Controls.Add(this.chkProduction);
            this.panel1.Controls.Add(this.cmbCompType);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBillMsg);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.chkAutoPrint);
            this.panel1.Controls.Add(this.chkPrintMessage);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chkReturnNotes);
            this.panel1.Controls.Add(this.chkNotes);
            this.panel1.Controls.Add(this.chk_DateTime_Check);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.txtVAT);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmb_Color);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chk_IsAdmin);
            this.panel1.Controls.Add(this.cmb_FiscalYear);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_Ok);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 324);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbCompType
            // 
            this.cmbCompType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCompType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompType.Font = new System.Drawing.Font("Verdana", 10F);
            this.cmbCompType.ForeColor = System.Drawing.Color.Indigo;
            this.cmbCompType.FormattingEnabled = true;
            this.cmbCompType.Items.AddRange(new object[] {
            "Select Type",
            "PAN",
            "VAT"});
            this.cmbCompType.Location = new System.Drawing.Point(152, 61);
            this.cmbCompType.MaxDropDownItems = 10;
            this.cmbCompType.Name = "cmbCompType";
            this.cmbCompType.Size = new System.Drawing.Size(161, 24);
            this.cmbCompType.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.GhostWhite;
            this.label8.Location = new System.Drawing.Point(12, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 14);
            this.label8.TabIndex = 63;
            this.label8.Text = "Reg Type:-";
            // 
            // txtBillMsg
            // 
            this.txtBillMsg.Location = new System.Drawing.Point(130, 239);
            this.txtBillMsg.Name = "txtBillMsg";
            this.txtBillMsg.Size = new System.Drawing.Size(407, 24);
            this.txtBillMsg.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.GhostWhite;
            this.label7.Location = new System.Drawing.Point(24, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 14);
            this.label7.TabIndex = 61;
            this.label7.Text = "Bill Message:-";
            // 
            // chkAutoPrint
            // 
            this.chkAutoPrint.AutoSize = true;
            this.chkAutoPrint.BackColor = System.Drawing.Color.Transparent;
            this.chkAutoPrint.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chkAutoPrint.ForeColor = System.Drawing.Color.GhostWhite;
            this.chkAutoPrint.Location = new System.Drawing.Point(162, 201);
            this.chkAutoPrint.Name = "chkAutoPrint";
            this.chkAutoPrint.Size = new System.Drawing.Size(92, 18);
            this.chkAutoPrint.TabIndex = 60;
            this.chkAutoPrint.Text = "Auto Print";
            this.chkAutoPrint.UseVisualStyleBackColor = false;
            this.chkAutoPrint.CheckedChanged += new System.EventHandler(this.chkAutoPrint_CheckedChanged);
            // 
            // chkPrintMessage
            // 
            this.chkPrintMessage.AutoSize = true;
            this.chkPrintMessage.BackColor = System.Drawing.Color.Transparent;
            this.chkPrintMessage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chkPrintMessage.ForeColor = System.Drawing.Color.GhostWhite;
            this.chkPrintMessage.Location = new System.Drawing.Point(37, 201);
            this.chkPrintMessage.Name = "chkPrintMessage";
            this.chkPrintMessage.Size = new System.Drawing.Size(119, 18);
            this.chkPrintMessage.TabIndex = 59;
            this.chkPrintMessage.Text = "Print Message";
            this.chkPrintMessage.UseVisualStyleBackColor = false;
            this.chkPrintMessage.CheckedChanged += new System.EventHandler(this.chkPrintMessage_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.GhostWhite;
            this.label6.Location = new System.Drawing.Point(8, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(538, 14);
            this.label6.TabIndex = 56;
            this.label6.Text = "___________________________________________________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.GhostWhite;
            this.label5.Location = new System.Drawing.Point(5, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(539, 14);
            this.label5.TabIndex = 55;
            this.label5.Text = "____Mandatory/Non-mandatory___________________________________";
            // 
            // chkReturnNotes
            // 
            this.chkReturnNotes.AutoSize = true;
            this.chkReturnNotes.BackColor = System.Drawing.Color.Transparent;
            this.chkReturnNotes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chkReturnNotes.ForeColor = System.Drawing.Color.GhostWhite;
            this.chkReturnNotes.Location = new System.Drawing.Point(238, 177);
            this.chkReturnNotes.Name = "chkReturnNotes";
            this.chkReturnNotes.Size = new System.Drawing.Size(112, 18);
            this.chkReturnNotes.TabIndex = 52;
            this.chkReturnNotes.Text = "Return Notes";
            this.chkReturnNotes.UseVisualStyleBackColor = false;
            // 
            // chkNotes
            // 
            this.chkNotes.AutoSize = true;
            this.chkNotes.BackColor = System.Drawing.Color.Transparent;
            this.chkNotes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chkNotes.ForeColor = System.Drawing.Color.GhostWhite;
            this.chkNotes.Location = new System.Drawing.Point(162, 177);
            this.chkNotes.Name = "chkNotes";
            this.chkNotes.Size = new System.Drawing.Size(64, 18);
            this.chkNotes.TabIndex = 51;
            this.chkNotes.Text = "Notes";
            this.chkNotes.UseVisualStyleBackColor = false;
            // 
            // chk_DateTime_Check
            // 
            this.chk_DateTime_Check.AutoSize = true;
            this.chk_DateTime_Check.BackColor = System.Drawing.Color.Transparent;
            this.chk_DateTime_Check.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chk_DateTime_Check.ForeColor = System.Drawing.Color.GhostWhite;
            this.chk_DateTime_Check.Location = new System.Drawing.Point(37, 177);
            this.chk_DateTime_Check.Name = "chk_DateTime_Check";
            this.chk_DateTime_Check.Size = new System.Drawing.Size(101, 18);
            this.chk_DateTime_Check.TabIndex = 50;
            this.chk_DateTime_Check.Text = "Check Date";
            this.chk_DateTime_Check.UseVisualStyleBackColor = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(426, 110);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(115, 24);
            this.txtDiscount.TabIndex = 49;
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(426, 86);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(115, 24);
            this.txtVAT.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.GhostWhite;
            this.label4.Location = new System.Drawing.Point(341, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 47;
            this.label4.Text = "Discount:-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GhostWhite;
            this.label3.Location = new System.Drawing.Point(372, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 46;
            this.label3.Text = "VAT:-";
            // 
            // cmb_Color
            // 
            this.cmb_Color.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_Color.Font = new System.Drawing.Font("Verdana", 10F);
            this.cmb_Color.ForeColor = System.Drawing.Color.Indigo;
            this.cmb_Color.FormattingEnabled = true;
            this.cmb_Color.Location = new System.Drawing.Point(151, 110);
            this.cmb_Color.MaxDropDownItems = 10;
            this.cmb_Color.Name = "cmb_Color";
            this.cmb_Color.Size = new System.Drawing.Size(163, 24);
            this.cmb_Color.TabIndex = 45;
            this.cmb_Color.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_Color_DrawItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 14);
            this.label2.TabIndex = 44;
            this.label2.Text = "Background Color:-";
            // 
            // chk_IsAdmin
            // 
            this.chk_IsAdmin.AutoSize = true;
            this.chk_IsAdmin.BackColor = System.Drawing.Color.Transparent;
            this.chk_IsAdmin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chk_IsAdmin.ForeColor = System.Drawing.Color.GhostWhite;
            this.chk_IsAdmin.Location = new System.Drawing.Point(356, 177);
            this.chk_IsAdmin.Name = "chk_IsAdmin";
            this.chk_IsAdmin.Size = new System.Drawing.Size(144, 18);
            this.chk_IsAdmin.TabIndex = 43;
            this.chk_IsAdmin.Text = "Admin Permission";
            this.chk_IsAdmin.UseVisualStyleBackColor = false;
            // 
            // cmb_FiscalYear
            // 
            this.cmb_FiscalYear.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_FiscalYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FiscalYear.Font = new System.Drawing.Font("Verdana", 10F);
            this.cmb_FiscalYear.ForeColor = System.Drawing.Color.Indigo;
            this.cmb_FiscalYear.FormattingEnabled = true;
            this.cmb_FiscalYear.Location = new System.Drawing.Point(152, 86);
            this.cmb_FiscalYear.MaxDropDownItems = 10;
            this.cmb_FiscalYear.Name = "cmb_FiscalYear";
            this.cmb_FiscalYear.Size = new System.Drawing.Size(161, 24);
            this.cmb_FiscalYear.TabIndex = 42;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackgroundImage = global::MyStoreManager.Properties.Resources.Refresh;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.Location = new System.Drawing.Point(3, 298);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(25, 23);
            this.btn_Refresh.TabIndex = 41;
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(182, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 26);
            this.label1.TabIndex = 39;
            this.label1.Text = "Configuration";
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.BackColor = System.Drawing.Color.White;
            this.Btn_Ok.Font = new System.Drawing.Font("Verdana", 8F);
            this.Btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.Btn_Ok.Location = new System.Drawing.Point(469, 293);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(77, 28);
            this.Btn_Ok.TabIndex = 35;
            this.Btn_Ok.Text = "&OK";
            this.Btn_Ok.UseVisualStyleBackColor = false;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.GhostWhite;
            this.label9.Location = new System.Drawing.Point(12, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 14);
            this.label9.TabIndex = 38;
            this.label9.Text = "FiscalYear:-";
            // 
            // chkProduction
            // 
            this.chkProduction.AutoSize = true;
            this.chkProduction.BackColor = System.Drawing.Color.Transparent;
            this.chkProduction.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chkProduction.ForeColor = System.Drawing.Color.GhostWhite;
            this.chkProduction.Location = new System.Drawing.Point(258, 201);
            this.chkProduction.Name = "chkProduction";
            this.chkProduction.Size = new System.Drawing.Size(97, 18);
            this.chkProduction.TabIndex = 65;
            this.chkProduction.Text = "Production";
            this.chkProduction.UseVisualStyleBackColor = false;
            this.chkProduction.CheckedChanged += new System.EventHandler(this.chkProduction_CheckedChanged);
            // 
            // frm_Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 324);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.frm_Configuration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_FiscalYear;
        private System.Windows.Forms.ComboBox cmb_Color;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_IsAdmin;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_DateTime_Check;
        private System.Windows.Forms.CheckBox chkReturnNotes;
        private System.Windows.Forms.CheckBox chkNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAutoPrint;
        private System.Windows.Forms.CheckBox chkPrintMessage;
        private System.Windows.Forms.ComboBox cmbCompType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBillMsg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkProduction;
    }
}