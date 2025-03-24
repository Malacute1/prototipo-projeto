namespace DocumentProcessorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFileType = new System.Windows.Forms.Label();
            this.txtExtractedText = new System.Windows.Forms.TextBox();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblLogoMatch = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(30, 30);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(120, 30);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Selecionar Arquivo";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);

            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(170, 35);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(400, 23);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.ReadOnly = true;

            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(30, 80);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(63, 15);
            this.lblFileType.TabIndex = 2;
            this.lblFileType.Text = "File Type: ";

            // 
            // txtExtractedText
            // 
            this.txtExtractedText.Location = new System.Drawing.Point(30, 120);
            this.txtExtractedText.Multiline = true;
            this.txtExtractedText.Name = "txtExtractedText";
            this.txtExtractedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExtractedText.Size = new System.Drawing.Size(540, 200);
            this.txtExtractedText.TabIndex = 3;
            this.txtExtractedText.ReadOnly = true;

            // 
            // lblDocumentType
            // 
            this.lblDocumentType.AutoSize = true;
            this.lblDocumentType.Location = new System.Drawing.Point(30, 340);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(97, 15);
            this.lblDocumentType.TabIndex = 4;
            this.lblDocumentType.Text = "Document Type: ";

            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(30, 380);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(91, 15);
            this.lblBarcode.TabIndex = 5;
            this.lblBarcode.Text = "Decoded Barcode: ";

            // 
            // lblLogoMatch
            // 
            this.lblLogoMatch.AutoSize = true;
            this.lblLogoMatch.Location = new System.Drawing.Point(30, 420);
            this.lblLogoMatch.Name = "lblLogoMatch";
            this.lblLogoMatch.Size = new System.Drawing.Size(84, 15);
            this.lblLogoMatch.TabIndex = 6;
            this.lblLogoMatch.Text = "Logo Matched: ";

            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(30, 460);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblLogoMatch);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblDocumentType);
            this.Controls.Add(this.txtExtractedText);
            this.Controls.Add(this.lblFileType);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "Form1";
            this.Text = "Document Processor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.TextBox txtExtractedText;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblLogoMatch;
        private System.Windows.Forms.Button btnClear;
    }
}
