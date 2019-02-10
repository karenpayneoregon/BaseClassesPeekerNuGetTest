namespace NullExceptionsExample
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
            this.initializeNullArrayItemButton = new System.Windows.Forms.Button();
            this.AttemptToAddItemNullCollectionButton = new System.Windows.Forms.Button();
            this.InvalidCastExceptionFromObjectToIntButton = new System.Windows.Forms.Button();
            this.InvalidOperationExceptionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // initializeNullArrayItemButton
            // 
            this.initializeNullArrayItemButton.Location = new System.Drawing.Point(12, 12);
            this.initializeNullArrayItemButton.Name = "initializeNullArrayItemButton";
            this.initializeNullArrayItemButton.Size = new System.Drawing.Size(394, 23);
            this.initializeNullArrayItemButton.TabIndex = 1;
            this.initializeNullArrayItemButton.Text = "Initialize null array object";
            this.initializeNullArrayItemButton.UseVisualStyleBackColor = true;
            this.initializeNullArrayItemButton.Click += new System.EventHandler(this.InitializeNullArrayItemButton_Click);
            // 
            // AttemptToAddItemNullCollectionButton
            // 
            this.AttemptToAddItemNullCollectionButton.Location = new System.Drawing.Point(12, 40);
            this.AttemptToAddItemNullCollectionButton.Name = "AttemptToAddItemNullCollectionButton";
            this.AttemptToAddItemNullCollectionButton.Size = new System.Drawing.Size(394, 23);
            this.AttemptToAddItemNullCollectionButton.TabIndex = 2;
            this.AttemptToAddItemNullCollectionButton.Text = "Attempt to add item to null collection";
            this.AttemptToAddItemNullCollectionButton.UseVisualStyleBackColor = true;
            this.AttemptToAddItemNullCollectionButton.Click += new System.EventHandler(this.AttemptToAddItemNullCollectionButton_Click);
            // 
            // InvalidCastExceptionFromObjectToIntButton
            // 
            this.InvalidCastExceptionFromObjectToIntButton.Location = new System.Drawing.Point(13, 68);
            this.InvalidCastExceptionFromObjectToIntButton.Name = "InvalidCastExceptionFromObjectToIntButton";
            this.InvalidCastExceptionFromObjectToIntButton.Size = new System.Drawing.Size(394, 23);
            this.InvalidCastExceptionFromObjectToIntButton.TabIndex = 3;
            this.InvalidCastExceptionFromObjectToIntButton.Text = "InvalidCastException from object to int";
            this.InvalidCastExceptionFromObjectToIntButton.UseVisualStyleBackColor = true;
            this.InvalidCastExceptionFromObjectToIntButton.Click += new System.EventHandler(this.InvalidCastExceptionFromObjectToIntButton_Click);
            // 
            // InvalidOperationExceptionButton
            // 
            this.InvalidOperationExceptionButton.Location = new System.Drawing.Point(13, 96);
            this.InvalidOperationExceptionButton.Name = "InvalidOperationExceptionButton";
            this.InvalidOperationExceptionButton.Size = new System.Drawing.Size(394, 23);
            this.InvalidOperationExceptionButton.TabIndex = 4;
            this.InvalidOperationExceptionButton.Text = "InvalidOperationException (using First rather than FirstOrDefault)";
            this.InvalidOperationExceptionButton.UseVisualStyleBackColor = true;
            this.InvalidOperationExceptionButton.Click += new System.EventHandler(this.InvalidOperationExceptionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 133);
            this.Controls.Add(this.InvalidOperationExceptionButton);
            this.Controls.Add(this.InvalidCastExceptionFromObjectToIntButton);
            this.Controls.Add(this.AttemptToAddItemNullCollectionButton);
            this.Controls.Add(this.initializeNullArrayItemButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "(C#) Dealing with nulls with NuGet package";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button initializeNullArrayItemButton;
        private System.Windows.Forms.Button AttemptToAddItemNullCollectionButton;
        private System.Windows.Forms.Button InvalidCastExceptionFromObjectToIntButton;
        private System.Windows.Forms.Button InvalidOperationExceptionButton;
    }
}

