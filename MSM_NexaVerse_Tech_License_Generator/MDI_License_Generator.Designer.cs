namespace MSM_NexaVerse_Tech_License_Generator
{
    partial class MDI_License_Generator
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI_License_Generator));
            panel1 = new Panel();
            label4 = new Label();
            lbl_Status = new Label();
            btn_Reload = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btn_Generate = new Button();
            cmd_Days = new ComboBox();
            txt_Key = new TextBox();
            toolTip = new ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lbl_Status);
            panel1.Controls.Add(btn_Reload);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btn_Generate);
            panel1.Controls.Add(cmd_Days);
            panel1.Controls.Add(txt_Key);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 328);
            panel1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Old English Text MT", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(211, 18);
            label4.Name = "label4";
            label4.Size = new Size(388, 28);
            label4.TabIndex = 12;
            label4.Text = "Tech NexaVerse Solution Pvt. Ltd.";
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.BackColor = Color.Transparent;
            lbl_Status.ForeColor = Color.White;
            lbl_Status.Location = new Point(89, 192);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(0, 14);
            lbl_Status.TabIndex = 11;
            // 
            // btn_Reload
            // 
            btn_Reload.Location = new Point(372, 279);
            btn_Reload.Name = "btn_Reload";
            btn_Reload.Size = new Size(92, 37);
            btn_Reload.TabIndex = 3;
            btn_Reload.Text = "&Reload";
            btn_Reload.UseVisualStyleBackColor = true;
            btn_Reload.Click += btn_Reload_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(15, 192);
            label3.Name = "label3";
            label3.Size = new Size(58, 14);
            label3.TabIndex = 2;
            label3.Text = "Status:-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(33, 164);
            label2.Name = "label2";
            label2.Size = new Size(40, 14);
            label2.TabIndex = 1;
            label2.Text = "Key:-";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(25, 136);
            label1.Name = "label1";
            label1.Size = new Size(48, 14);
            label1.TabIndex = 0;
            label1.Text = "Days:-";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(159, 83);
            panel2.TabIndex = 6;
            // 
            // btn_Generate
            // 
            btn_Generate.Location = new Point(515, 279);
            btn_Generate.Name = "btn_Generate";
            btn_Generate.Size = new Size(92, 37);
            btn_Generate.TabIndex = 2;
            btn_Generate.Text = "&Generate";
            btn_Generate.UseVisualStyleBackColor = true;
            btn_Generate.Click += btn_Generate_Click;
            btn_Generate.KeyPress += globalTab_KeyPress;
            // 
            // cmd_Days
            // 
            cmd_Days.FormattingEnabled = true;
            cmd_Days.Items.AddRange(new object[] { "15", "30", "90", "180", "365" });
            cmd_Days.Location = new Point(79, 133);
            cmd_Days.Name = "cmd_Days";
            cmd_Days.Size = new Size(84, 22);
            cmd_Days.TabIndex = 1;
            cmd_Days.KeyPress += globalTab_KeyPress;
            // 
            // txt_Key
            // 
            txt_Key.Location = new Point(79, 161);
            txt_Key.Name = "txt_Key";
            txt_Key.ReadOnly = true;
            txt_Key.Size = new Size(528, 22);
            txt_Key.TabIndex = 10;
            txt_Key.KeyPress += globalTab_KeyPress;
            // 
            // MDI_License_Generator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 328);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDI_License_Generator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MDI_License_Generator";
            Load += MDI_License_Generator_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label lbl_Status;
        private Button btn_Reload;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Button btn_Generate;
        private ComboBox cmd_Days;
        private TextBox txt_Key;
        private ToolTip toolTip;
    }
}



