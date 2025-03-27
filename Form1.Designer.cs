namespace DocumentProcessingApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtExtractedText;

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
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtExtractedText = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // btnUpload
            this.btnUpload.Location = new System.Drawing.Point(12, 12);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 40);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Adicionar Arquivo";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(118, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // txtExtractedText
            this.txtExtractedText.Location = new System.Drawing.Point(12, 58);
            this.txtExtractedText.Multiline = true;
            this.txtExtractedText.Name = "txtExtractedText";
            this.txtExtractedText.Size = new System.Drawing.Size(400, 200);
            this.txtExtractedText.TabIndex = 2;

            // Form1
            this.ClientSize = new System.Drawing.Size(424, 271);
            this.Controls.Add(this.txtExtractedText);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpload);
            this.Name = "Form1";
            this.Text = "Processador de Documentos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
