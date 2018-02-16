namespace QuickHash
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxMD5 = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblMD5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnComputeMD5 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnComputeSHA1 = new System.Windows.Forms.Button();
            this.lblSHA1 = new System.Windows.Forms.Label();
            this.tbxSHA1 = new System.Windows.Forms.TextBox();
            this.btnComputeSHA256 = new System.Windows.Forms.Button();
            this.lblSHA256 = new System.Windows.Forms.Label();
            this.tbxSHA256 = new System.Windows.Forms.TextBox();
            this.cbxHashEncoding = new System.Windows.Forms.ComboBox();
            this.cbxSendTo = new System.Windows.Forms.CheckBox();
            this.btnSetFromText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxMD5
            // 
            this.tbxMD5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMD5.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMD5.Location = new System.Drawing.Point(96, 52);
            this.tbxMD5.Name = "tbxMD5";
            this.tbxMD5.ReadOnly = true;
            this.tbxMD5.Size = new System.Drawing.Size(653, 24);
            this.tbxMD5.TabIndex = 2;
            this.tbxMD5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxMD5.WordWrap = false;
            this.tbxMD5.Enter += new System.EventHandler(this.hashBox_Enter);
            this.tbxMD5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hashBox_MouseUp);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Browse";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(93, 16);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(12, 14);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "-";
            // 
            // lblMD5
            // 
            this.lblMD5.AutoSize = true;
            this.lblMD5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMD5.Location = new System.Drawing.Point(12, 57);
            this.lblMD5.Name = "lblMD5";
            this.lblMD5.Size = new System.Drawing.Size(33, 13);
            this.lblMD5.TabIndex = 3;
            this.lblMD5.Text = "MD5";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(768, 147);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnComputeMD5
            // 
            this.btnComputeMD5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComputeMD5.Location = new System.Drawing.Point(755, 52);
            this.btnComputeMD5.Name = "btnComputeMD5";
            this.btnComputeMD5.Size = new System.Drawing.Size(88, 24);
            this.btnComputeMD5.TabIndex = 3;
            this.btnComputeMD5.Text = "Compute";
            this.btnComputeMD5.UseVisualStyleBackColor = true;
            this.btnComputeMD5.Click += new System.EventHandler(this.btnComputeMD5_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(12, 147);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // btnComputeSHA1
            // 
            this.btnComputeSHA1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComputeSHA1.Location = new System.Drawing.Point(755, 82);
            this.btnComputeSHA1.Name = "btnComputeSHA1";
            this.btnComputeSHA1.Size = new System.Drawing.Size(88, 24);
            this.btnComputeSHA1.TabIndex = 5;
            this.btnComputeSHA1.Text = "Compute";
            this.btnComputeSHA1.UseVisualStyleBackColor = true;
            this.btnComputeSHA1.Click += new System.EventHandler(this.btnComputeSHA1_Click);
            // 
            // lblSHA1
            // 
            this.lblSHA1.AutoSize = true;
            this.lblSHA1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSHA1.Location = new System.Drawing.Point(12, 87);
            this.lblSHA1.Name = "lblSHA1";
            this.lblSHA1.Size = new System.Drawing.Size(43, 13);
            this.lblSHA1.TabIndex = 8;
            this.lblSHA1.Text = "SHA-1";
            // 
            // tbxSHA1
            // 
            this.tbxSHA1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSHA1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSHA1.Location = new System.Drawing.Point(96, 82);
            this.tbxSHA1.Name = "tbxSHA1";
            this.tbxSHA1.ReadOnly = true;
            this.tbxSHA1.Size = new System.Drawing.Size(653, 24);
            this.tbxSHA1.TabIndex = 4;
            this.tbxSHA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSHA1.WordWrap = false;
            this.tbxSHA1.Enter += new System.EventHandler(this.hashBox_Enter);
            this.tbxSHA1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hashBox_MouseUp);
            // 
            // btnComputeSHA256
            // 
            this.btnComputeSHA256.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComputeSHA256.Location = new System.Drawing.Point(755, 112);
            this.btnComputeSHA256.Name = "btnComputeSHA256";
            this.btnComputeSHA256.Size = new System.Drawing.Size(88, 24);
            this.btnComputeSHA256.TabIndex = 7;
            this.btnComputeSHA256.Text = "Compute";
            this.btnComputeSHA256.UseVisualStyleBackColor = true;
            this.btnComputeSHA256.Click += new System.EventHandler(this.btnComputeSHA256_Click);
            // 
            // lblSHA256
            // 
            this.lblSHA256.AutoSize = true;
            this.lblSHA256.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSHA256.Location = new System.Drawing.Point(12, 117);
            this.lblSHA256.Name = "lblSHA256";
            this.lblSHA256.Size = new System.Drawing.Size(57, 13);
            this.lblSHA256.TabIndex = 11;
            this.lblSHA256.Text = "SHA-256";
            // 
            // tbxSHA256
            // 
            this.tbxSHA256.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSHA256.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSHA256.Location = new System.Drawing.Point(96, 112);
            this.tbxSHA256.Name = "tbxSHA256";
            this.tbxSHA256.ReadOnly = true;
            this.tbxSHA256.Size = new System.Drawing.Size(653, 24);
            this.tbxSHA256.TabIndex = 6;
            this.tbxSHA256.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxSHA256.WordWrap = false;
            this.tbxSHA256.Enter += new System.EventHandler(this.hashBox_Enter);
            this.tbxSHA256.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hashBox_MouseUp);
            // 
            // cbxHashEncoding
            // 
            this.cbxHashEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxHashEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHashEncoding.FormattingEnabled = true;
            this.cbxHashEncoding.Items.AddRange(new object[] {
            "Hex (Lower case)",
            "Hex (Upper case)",
            "Hex (Separated)",
            "Base64"});
            this.cbxHashEncoding.Location = new System.Drawing.Point(218, 147);
            this.cbxHashEncoding.Name = "cbxHashEncoding";
            this.cbxHashEncoding.Size = new System.Drawing.Size(121, 21);
            this.cbxHashEncoding.TabIndex = 8;
            this.cbxHashEncoding.SelectedIndexChanged += new System.EventHandler(this.cbxHashEncoding_SelectedIndexChanged);
            // 
            // cbxSendTo
            // 
            this.cbxSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSendTo.AutoSize = true;
            this.cbxSendTo.Location = new System.Drawing.Point(568, 151);
            this.cbxSendTo.Name = "cbxSendTo";
            this.cbxSendTo.Size = new System.Drawing.Size(114, 17);
            this.cbxSendTo.TabIndex = 10;
            this.cbxSendTo.Text = "\"Send to\" shortcut";
            this.cbxSendTo.UseVisualStyleBackColor = true;
            this.cbxSendTo.CheckedChanged += new System.EventHandler(this.cbxSendTo_CheckedChanged);
            // 
            // btnSetFromText
            // 
            this.btnSetFromText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetFromText.Location = new System.Drawing.Point(747, 12);
            this.btnSetFromText.Name = "btnSetFromText";
            this.btnSetFromText.Size = new System.Drawing.Size(96, 23);
            this.btnSetFromText.TabIndex = 1;
            this.btnSetFromText.Text = "From text";
            this.btnSetFromText.UseVisualStyleBackColor = true;
            this.btnSetFromText.Click += new System.EventHandler(this.btnSetFromText_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(855, 182);
            this.Controls.Add(this.btnSetFromText);
            this.Controls.Add(this.cbxSendTo);
            this.Controls.Add(this.cbxHashEncoding);
            this.Controls.Add(this.btnComputeSHA256);
            this.Controls.Add(this.lblSHA256);
            this.Controls.Add(this.tbxSHA256);
            this.Controls.Add(this.btnComputeSHA1);
            this.Controls.Add(this.lblSHA1);
            this.Controls.Add(this.tbxSHA1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnComputeMD5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMD5);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.tbxMD5);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Hash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMD5;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblMD5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnComputeMD5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnComputeSHA1;
        private System.Windows.Forms.Label lblSHA1;
        private System.Windows.Forms.TextBox tbxSHA1;
        private System.Windows.Forms.Button btnComputeSHA256;
        private System.Windows.Forms.Label lblSHA256;
        private System.Windows.Forms.TextBox tbxSHA256;
        private System.Windows.Forms.ComboBox cbxHashEncoding;
        private System.Windows.Forms.CheckBox cbxSendTo;
        private System.Windows.Forms.Button btnSetFromText;
    }
}

