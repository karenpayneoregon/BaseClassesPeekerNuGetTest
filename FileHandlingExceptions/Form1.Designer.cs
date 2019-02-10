namespace FileHandlingExceptions
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
            this.readNonExistingBaseExceptionPropertiesFileButton = new System.Windows.Forms.Button();
            this.readNonExistingConventionalFileButton = new System.Windows.Forms.Button();
            this.readExistingBaseExceptionPropertiesFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // readNonExistingBaseExceptionPropertiesFileButton
            // 
            this.readNonExistingBaseExceptionPropertiesFileButton.Location = new System.Drawing.Point(18, 17);
            this.readNonExistingBaseExceptionPropertiesFileButton.Name = "readNonExistingBaseExceptionPropertiesFileButton";
            this.readNonExistingBaseExceptionPropertiesFileButton.Size = new System.Drawing.Size(394, 23);
            this.readNonExistingBaseExceptionPropertiesFileButton.TabIndex = 0;
            this.readNonExistingBaseExceptionPropertiesFileButton.Text = "Read non-existing file with managed exception handling";
            this.readNonExistingBaseExceptionPropertiesFileButton.UseVisualStyleBackColor = true;
            this.readNonExistingBaseExceptionPropertiesFileButton.Click += new System.EventHandler(this.readNonExistingBaseExceptionPropertiesFileButton_Click);
            // 
            // readNonExistingConventionalFileButton
            // 
            this.readNonExistingConventionalFileButton.Location = new System.Drawing.Point(18, 46);
            this.readNonExistingConventionalFileButton.Name = "readNonExistingConventionalFileButton";
            this.readNonExistingConventionalFileButton.Size = new System.Drawing.Size(394, 23);
            this.readNonExistingConventionalFileButton.TabIndex = 1;
            this.readNonExistingConventionalFileButton.Text = "Read non-existing file conventional";
            this.readNonExistingConventionalFileButton.UseVisualStyleBackColor = true;
            this.readNonExistingConventionalFileButton.Click += new System.EventHandler(this.readNonExistingConventionalFileButton_Click);
            // 
            // readExistingBaseExceptionPropertiesFileButton
            // 
            this.readExistingBaseExceptionPropertiesFileButton.Location = new System.Drawing.Point(18, 75);
            this.readExistingBaseExceptionPropertiesFileButton.Name = "readExistingBaseExceptionPropertiesFileButton";
            this.readExistingBaseExceptionPropertiesFileButton.Size = new System.Drawing.Size(394, 23);
            this.readExistingBaseExceptionPropertiesFileButton.TabIndex = 2;
            this.readExistingBaseExceptionPropertiesFileButton.Text = "Read existing file";
            this.readExistingBaseExceptionPropertiesFileButton.UseVisualStyleBackColor = true;
            this.readExistingBaseExceptionPropertiesFileButton.Click += new System.EventHandler(this.readExistingBaseExceptionPropertiesFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 117);
            this.Controls.Add(this.readExistingBaseExceptionPropertiesFileButton);
            this.Controls.Add(this.readNonExistingConventionalFileButton);
            this.Controls.Add(this.readNonExistingBaseExceptionPropertiesFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "(C#) Example for dealing with file i/o exceptions with NuGet package";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button readNonExistingBaseExceptionPropertiesFileButton;
        private System.Windows.Forms.Button readNonExistingConventionalFileButton;
        private System.Windows.Forms.Button readExistingBaseExceptionPropertiesFileButton;
    }
}

