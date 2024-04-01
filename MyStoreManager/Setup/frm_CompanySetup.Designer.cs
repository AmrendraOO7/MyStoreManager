
namespace MyStoreManager.Setup
{
    partial class frm_CompanySetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CompanySetup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_State = new System.Windows.Forms.TextBox();
            this.txt_Country = new System.Windows.Forms.TextBox();
            this.BtnProgressBar = new System.Windows.Forms.ProgressBar();
            this.cmb_Drive = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.lbl_AddCountry = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.txt_Registration = new System.Windows.Forms.TextBox();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BlueViolet;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.ContextMenuStrip = this.contextMenuStrip;
            this.panel1.Controls.Add(this.txt_State);
            this.panel1.Controls.Add(this.txt_Country);
            this.panel1.Controls.Add(this.BtnProgressBar);
            this.panel1.Controls.Add(this.cmb_Drive);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Controls.Add(this.lbl_AddCountry);
            this.panel1.Controls.Add(this.Btn_Ok);
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.btn_Edit);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txt_City);
            this.panel1.Controls.Add(this.txt_Address);
            this.panel1.Controls.Add(this.txt_Email);
            this.panel1.Controls.Add(this.txt_Contact);
            this.panel1.Controls.Add(this.txt_Registration);
            this.panel1.Controls.Add(this.txtCompName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.GhostWhite;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 256);
            this.panel1.TabIndex = 0;
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
            // txt_State
            // 
            this.txt_State.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_State.Location = new System.Drawing.Point(150, 197);
            this.txt_State.Name = "txt_State";
            this.txt_State.ReadOnly = true;
            this.txt_State.Size = new System.Drawing.Size(190, 21);
            this.txt_State.TabIndex = 7;
            this.txt_State.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_State_KeyDown);
            this.txt_State.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txt_Country
            // 
            this.txt_Country.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Country.Location = new System.Drawing.Point(422, 197);
            this.txt_Country.Name = "txt_Country";
            this.txt_Country.ReadOnly = true;
            this.txt_Country.Size = new System.Drawing.Size(154, 21);
            this.txt_Country.TabIndex = 8;
            this.txt_Country.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_State_KeyDown);
            this.txt_Country.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // BtnProgressBar
            // 
            this.BtnProgressBar.BackColor = System.Drawing.Color.White;
            this.BtnProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnProgressBar.Location = new System.Drawing.Point(0, 242);
            this.BtnProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProgressBar.Name = "BtnProgressBar";
            this.BtnProgressBar.Size = new System.Drawing.Size(672, 10);
            this.BtnProgressBar.TabIndex = 26;
            this.BtnProgressBar.Value = 100;
            // 
            // cmb_Drive
            // 
            this.cmb_Drive.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_Drive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Drive.Font = new System.Drawing.Font("Verdana", 10F);
            this.cmb_Drive.ForeColor = System.Drawing.Color.Indigo;
            this.cmb_Drive.FormattingEnabled = true;
            this.cmb_Drive.Location = new System.Drawing.Point(150, 218);
            this.cmb_Drive.MaxDropDownItems = 10;
            this.cmb_Drive.Name = "cmb_Drive";
            this.cmb_Drive.Size = new System.Drawing.Size(190, 24);
            this.cmb_Drive.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.GhostWhite;
            this.label10.Location = new System.Drawing.Point(9, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 14);
            this.label10.TabIndex = 24;
            this.label10.Text = "Database Location:-";
            // 
            // btn_Search
            // 
            this.btn_Search.BackgroundImage = global::MyStoreManager.Properties.Resources.Zoom;
            this.btn_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Search.Location = new System.Drawing.Point(577, 53);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(25, 23);
            this.btn_Search.TabIndex = 23;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImage = global::MyStoreManager.Properties.Resources.Close;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.Location = new System.Drawing.Point(646, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(25, 23);
            this.btn_Close.TabIndex = 22;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackgroundImage = global::MyStoreManager.Properties.Resources.Refresh;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.Location = new System.Drawing.Point(646, 48);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(25, 23);
            this.btn_Refresh.TabIndex = 21;
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // lbl_AddCountry
            // 
            this.lbl_AddCountry.AutoSize = true;
            this.lbl_AddCountry.BackColor = System.Drawing.Color.Transparent;
            this.lbl_AddCountry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AddCountry.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbl_AddCountry.Location = new System.Drawing.Point(461, 220);
            this.lbl_AddCountry.Name = "lbl_AddCountry";
            this.lbl_AddCountry.Size = new System.Drawing.Size(114, 13);
            this.lbl_AddCountry.TabIndex = 20;
            this.lbl_AddCountry.Text = "&Add State/Country";
            this.lbl_AddCountry.Click += new System.EventHandler(this.lbl_AddCountry_Click);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.BackColor = System.Drawing.Color.White;
            this.Btn_Ok.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.Btn_Ok.Location = new System.Drawing.Point(577, 202);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(95, 35);
            this.Btn_Ok.TabIndex = 9;
            this.Btn_Ok.Text = "&Save";
            this.Btn_Ok.UseVisualStyleBackColor = false;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.White;
            this.btn_Delete.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Delete.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Delete.Location = new System.Drawing.Point(577, 146);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(95, 35);
            this.btn_Delete.TabIndex = 11;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.White;
            this.btn_Edit.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Edit.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Edit.Location = new System.Drawing.Point(577, 111);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(95, 35);
            this.btn_Edit.TabIndex = 10;
            this.btn_Edit.Text = "&Edit";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.White;
            this.btn_Save.Font = new System.Drawing.Font("Verdana", 8F);
            this.btn_Save.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Save.Location = new System.Drawing.Point(577, 76);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(95, 35);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "&New";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::MyStoreManager.Properties.Resources.MyStoreManager_logo1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(114, 50);
            this.panel3.TabIndex = 19;
            // 
            // txt_City
            // 
            this.txt_City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_City.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_City.Location = new System.Drawing.Point(150, 173);
            this.txt_City.Margin = new System.Windows.Forms.Padding(4);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(426, 24);
            this.txt_City.TabIndex = 6;
            this.txt_City.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txt_Address
            // 
            this.txt_Address.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Address.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(150, 149);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(426, 24);
            this.txt_Address.TabIndex = 5;
            this.txt_Address.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txt_Email
            // 
            this.txt_Email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Email.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.Location = new System.Drawing.Point(150, 125);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(426, 24);
            this.txt_Email.TabIndex = 4;
            this.txt_Email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txt_Contact
            // 
            this.txt_Contact.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Contact.Location = new System.Drawing.Point(150, 101);
            this.txt_Contact.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Contact.MaxLength = 15;
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.Size = new System.Drawing.Size(426, 24);
            this.txt_Contact.TabIndex = 3;
            this.txt_Contact.TextChanged += new System.EventHandler(this.txt_Contact_TextChanged);
            this.txt_Contact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txt_Registration
            // 
            this.txt_Registration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Registration.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Registration.Location = new System.Drawing.Point(150, 77);
            this.txt_Registration.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Registration.MaxLength = 30;
            this.txt_Registration.Name = "txt_Registration";
            this.txt_Registration.Size = new System.Drawing.Size(426, 24);
            this.txt_Registration.TabIndex = 2;
            this.txt_Registration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            // 
            // txtCompName
            // 
            this.txtCompName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompName.Location = new System.Drawing.Point(150, 53);
            this.txtCompName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(426, 24);
            this.txtCompName.TabIndex = 1;
            this.txtCompName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.globalTab_KeyPress);
            this.txtCompName.Leave += new System.EventHandler(this.txtCompName_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.GhostWhite;
            this.label9.Location = new System.Drawing.Point(10, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "State:-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.GhostWhite;
            this.label8.Location = new System.Drawing.Point(346, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "Country:-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.GhostWhite;
            this.label7.Location = new System.Drawing.Point(10, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "City:-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.GhostWhite;
            this.label6.Location = new System.Drawing.Point(9, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Address:-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.GhostWhite;
            this.label5.Location = new System.Drawing.Point(9, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email:-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.GhostWhite;
            this.label4.Location = new System.Drawing.Point(10, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contact Number:-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GhostWhite;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Registration No:-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company Name:-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(145, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Setup";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BtnProgressBar_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BtnProgressBar_ProgressChanged);
            // 
            // frm_CompanySetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 256);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_CompanySetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Setup";
            this.Load += new System.EventHandler(this.frm_CompanySetup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.TextBox txt_Registration;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_AddCountry;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ComboBox cmb_Drive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ProgressBar BtnProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TextBox txt_State;
        private System.Windows.Forms.TextBox txt_Country;
    }
}