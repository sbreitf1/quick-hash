namespace QuickHash
{
    partial class EnterStringForm
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
            this.tbxString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxString
            // 
            this.tbxString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxString.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxString.Location = new System.Drawing.Point(0, 0);
            this.tbxString.Multiline = true;
            this.tbxString.Name = "tbxString";
            this.tbxString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxString.Size = new System.Drawing.Size(501, 198);
            this.tbxString.TabIndex = 0;
            this.tbxString.WordWrap = false;
            this.tbxString.TextChanged += new System.EventHandler(this.tbxString_TextChanged);
            this.tbxString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxString_KeyDown);
            // 
            // EnterStringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 198);
            this.Controls.Add(this.tbxString);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterStringForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "From text";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnterStringForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxString;
    }
}