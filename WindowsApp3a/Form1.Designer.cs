namespace WindowsApp3a
{
    partial class Form1
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
            this.exportExcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exportExcelButton
            // 
            this.exportExcelButton.Location = new System.Drawing.Point(35, 35);
            this.exportExcelButton.Name = "exportExcelButton";
            this.exportExcelButton.Size = new System.Drawing.Size(140, 23);
            this.exportExcelButton.TabIndex = 1;
            this.exportExcelButton.Text = "Export To Excel";
            this.exportExcelButton.UseVisualStyleBackColor = true;
            this.exportExcelButton.Click += new System.EventHandler(this.exportExcelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 92);
            this.Controls.Add(this.exportExcelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel from SQL-Server to Excel";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button exportExcelButton;
    }
}

