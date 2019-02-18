namespace SelectionsFromComboBox
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
            this.cboPickList = new System.Windows.Forms.ComboBox();
            this.lblPickListDescription = new System.Windows.Forms.Label();
            this.lblPickListIdentifier = new System.Windows.Forms.Label();
            this.productByIdentifierButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboPickList
            // 
            this.cboPickList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPickList.FormattingEnabled = true;
            this.cboPickList.Location = new System.Drawing.Point(22, 63);
            this.cboPickList.Name = "cboPickList";
            this.cboPickList.Size = new System.Drawing.Size(227, 21);
            this.cboPickList.TabIndex = 0;
            // 
            // lblPickListDescription
            // 
            this.lblPickListDescription.AutoSize = true;
            this.lblPickListDescription.Location = new System.Drawing.Point(19, 9);
            this.lblPickListDescription.Name = "lblPickListDescription";
            this.lblPickListDescription.Size = new System.Drawing.Size(35, 13);
            this.lblPickListDescription.TabIndex = 1;
            this.lblPickListDescription.Text = "label1";
            // 
            // lblPickListIdentifier
            // 
            this.lblPickListIdentifier.AutoSize = true;
            this.lblPickListIdentifier.Location = new System.Drawing.Point(19, 35);
            this.lblPickListIdentifier.Name = "lblPickListIdentifier";
            this.lblPickListIdentifier.Size = new System.Drawing.Size(35, 13);
            this.lblPickListIdentifier.TabIndex = 2;
            this.lblPickListIdentifier.Text = "label1";
            // 
            // productByIdentifierButton
            // 
            this.productByIdentifierButton.Location = new System.Drawing.Point(282, 63);
            this.productByIdentifierButton.Name = "productByIdentifierButton";
            this.productByIdentifierButton.Size = new System.Drawing.Size(75, 23);
            this.productByIdentifierButton.TabIndex = 3;
            this.productByIdentifierButton.Text = "Get";
            this.productByIdentifierButton.UseVisualStyleBackColor = true;
            this.productByIdentifierButton.Click += new System.EventHandler(this.productByIdentifierButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 427);
            this.Controls.Add(this.productByIdentifierButton);
            this.Controls.Add(this.lblPickListIdentifier);
            this.Controls.Add(this.lblPickListDescription);
            this.Controls.Add(this.cboPickList);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL-Server NuGet Package DataBinding";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPickList;
        private System.Windows.Forms.Label lblPickListDescription;
        private System.Windows.Forms.Label lblPickListIdentifier;
        private System.Windows.Forms.Button productByIdentifierButton;
    }
}

