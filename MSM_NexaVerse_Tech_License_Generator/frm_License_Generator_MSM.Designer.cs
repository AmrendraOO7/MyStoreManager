namespace MSM_NexaVerse_Tech_License_Generator
{
    partial class License_Generator_MSM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License_Generator_MSM));
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            chk_PasswordBtn = new CheckBox();
            btn_Login = new Button();
            btn_Exit = new Button();
            txt_Password = new TextBox();
            txt_UserName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(chk_PasswordBtn);
            panel1.Controls.Add(btn_Login);
            panel1.Controls.Add(btn_Exit);
            panel1.Controls.Add(txt_Password);
            panel1.Controls.Add(txt_UserName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 227);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(58, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(164, 88);
            panel2.TabIndex = 53;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(58, 22);
            label1.Name = "label1";
            label1.Size = new Size(374, 18);
            label1.TabIndex = 52;
            label1.Text = "MSM NexaVerse Tech Licsence Generator";
            // 
            // chk_PasswordBtn
            // 
            chk_PasswordBtn.AutoSize = true;
            chk_PasswordBtn.Font = new Font("Verdana", 6.5F, FontStyle.Regular, GraphicsUnit.Point);
            chk_PasswordBtn.ForeColor = Color.Black;
            chk_PasswordBtn.Location = new Point(395, 128);
            chk_PasswordBtn.Margin = new Padding(4, 3, 4, 3);
            chk_PasswordBtn.Name = "chk_PasswordBtn";
            chk_PasswordBtn.Size = new Size(101, 16);
            chk_PasswordBtn.TabIndex = 51;
            chk_PasswordBtn.Text = "Show Password";
            chk_PasswordBtn.UseVisualStyleBackColor = true;
            chk_PasswordBtn.CheckedChanged += chk_PasswordBtn_CheckedChanged;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Transparent;
            btn_Login.BackgroundImage = (Image)resources.GetObject("btn_Login.BackgroundImage");
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(416, 150);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(80, 28);
            btn_Login.TabIndex = 47;
            btn_Login.Text = "&Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.BackgroundImage = (Image)resources.GetObject("btn_Exit.BackgroundImage");
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Location = new Point(267, 150);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(80, 28);
            btn_Exit.TabIndex = 50;
            btn_Exit.Text = "&Exit";
            btn_Exit.UseVisualStyleBackColor = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(357, 98);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(139, 23);
            txt_Password.TabIndex = 46;
            txt_Password.UseSystemPasswordChar = true;
            txt_Password.KeyPress += globalTab_KeyPress;
            // 
            // txt_UserName
            // 
            txt_UserName.Location = new Point(357, 68);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(139, 23);
            txt_UserName.TabIndex = 45;
            txt_UserName.KeyPress += globalTab_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(264, 101);
            label3.Name = "label3";
            label3.Size = new Size(72, 14);
            label3.TabIndex = 48;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(264, 71);
            label2.Name = "label2";
            label2.Size = new Size(80, 14);
            label2.TabIndex = 49;
            label2.Text = "User Name";
            // 
            // License_Generator_MSM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 227);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "License_Generator_MSM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "License_Generator_MSM_Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private CheckBox chk_PasswordBtn;
        private Button btn_Login;
        private Button btn_Exit;
        private TextBox txt_Password;
        private TextBox txt_UserName;
        private Label label3;
        private Label label2;
    }
}