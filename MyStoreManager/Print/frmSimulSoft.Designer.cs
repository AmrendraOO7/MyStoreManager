namespace MyStoreManager.Print
{
    partial class frmSimulSoft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimulSoft));
            this.BtnPrintCall = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // BtnPrintCall
            // 
            this.BtnPrintCall.Location = new System.Drawing.Point(1133, 657);
            this.BtnPrintCall.Name = "BtnPrintCall";
            this.BtnPrintCall.Size = new System.Drawing.Size(117, 37);
            this.BtnPrintCall.TabIndex = 1;
            this.BtnPrintCall.Text = "&Print";
            this.BtnPrintCall.UseVisualStyleBackColor = true;
            this.BtnPrintCall.Click += new System.EventHandler(this.BtnPrintCall_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Location = new System.Drawing.Point(12, 12);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1115, 817);
            this.reportViewer.TabIndex = 2;
            // 
            // frmSimulSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 961);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.BtnPrintCall);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSimulSoft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print";
            this.Load += new System.EventHandler(this.frmSimulSoft_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnPrintCall;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}