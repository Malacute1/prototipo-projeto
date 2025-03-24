using System;
using System.IO;
using System.Windows.Forms;
using Tesseract;
using ZXing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace DocumentProcessorApp
{
    public partial class Form1 : Form
    {
        private DocumentProcessor processor;

        public Form1()
        {
            InitializeComponent();
            processor = new DocumentProcessor();
        }

        // Evento do botão para selecionar arquivo
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.png|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Verifica se o arquivo existe
                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("O arquivo não foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtFilePath.Text = filePath;

                    // Determina o tipo de arquivo com base na extensão
                    string fileType = GetFileType(filePath);
                    lblFileType.Text = "File Type: " + fileType;

                    // Processa o documento com base no tipo
                    ProcessDocument(filePath, fileType);
                }
            }
        }

        // Função para determinar o tipo de arquivo com base na extensão
        private string GetFileType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            if (extension == ".pdf")
            {
                return "PDF";
            }
            else if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
            {
                return "Image";
            }
            else
            {
                return "Unknown";
            }
        }

        // Método para processar o documento com base no tipo
        private void ProcessDocument(string filePath, string fileType)
        {
            try
            {
                string extractedText = string.Empty;
                string documentType = "Unknown";
                string barcodeData = "N/A";
                bool isLogoMatched = false;

                // Processa documentos em PDF
                if (fileType == "PDF")
                {
                    extractedText = processor.ExtractTextFromPdf(filePath);
                    documentType = processor.ClassifyDocument(extractedText);
                }
                // Processa imagens
                else if (fileType == "Image")
                {
                    extractedText = processor.ExtractTextFromImage(filePath);
                    documentType = processor.ClassifyDocument(extractedText);

                    barcodeData = processor.DecodeBarcode(filePath) ?? "No barcode detected";

                    // Caminho do logo para verificação
                    string logoPath = @"C:\path\to\logo.png"; // Verifique se o caminho é válido
                    if (File.Exists(logoPath))
                    {
                        isLogoMatched = processor.MatchLogo(filePath, logoPath);
                    }
                    else
                    {
                        MessageBox.Show("Logo não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Atualiza a interface com os resultados
                UpdateUI(extractedText, documentType, barcodeData, isLogoMatched);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Arquivo não encontrado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Acesso negado ao arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar o documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Atualiza os campos da interface
        private void UpdateUI(string extractedText, string documentType, string barcodeData, bool isLogoMatched)
        {
            txtExtractedText.Text = extractedText;
            lblDocumentType.Text = "Document Type: " + documentType;
            lblBarcode.Text = "Decoded Barcode: " + barcodeData;
            lblLogoMatch.Text = "Logo Matched: " + (isLogoMatched ? "Yes" : "No");
        }

        // Limpa os campos da interface
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFilePath.Clear();
            txtExtractedText.Clear();
            lblFileType.Text = "File Type: ";
            lblDocumentType.Text = "Document Type: ";
            lblBarcode.Text = "Decoded Barcode: ";
            lblLogoMatch.Text = "Logo Matched: ";
        }
    }
}
