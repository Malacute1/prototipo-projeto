using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing; // Biblioteca para QR code e códigos de barras
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Diagnostics;

// Adicionando um alias para o Path de iTextSharp
using Path = System.IO.Path;

namespace DocumentProcessingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Função principal para processar o arquivo
        private void ProcessFile(string filePath)
        {
            Task.Run(() =>
            {
                try
                {
                    string extension = Path.GetExtension(filePath).ToLower(); // Agora é a classe System.IO.Path

                    if (extension == ".pdf")
                    {
                        ExtractTextFromPDF(filePath);
                    }
                    else if (extension == ".jpg" || extension == ".png")
                    {
                        ReadQRCodeFromImage(filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao processar o arquivo: " + ex.Message);
                }
            });
        }

        // Função para extrair texto de um PDF
        private void ExtractTextFromPDF(string filePath)
        {
            StringBuilder extractedText = new StringBuilder();
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        string pageText = PdfTextExtractor.GetTextFromPage(reader, page);
                        extractedText.Append(pageText);
                    }
                }
                DisplayExtractedText(extractedText.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao extrair texto do PDF: " + ex.Message);
            }
        }

        // Função para exibir o texto extraído na interface
        private void DisplayExtractedText(string extractedText)
        {
            // Garantir que a atualização do controle será feita na thread principal
            if (txtExtractedText.InvokeRequired)
            {
                txtExtractedText.Invoke(new Action(() => txtExtractedText.Text = extractedText));
            }
            else
            {
                txtExtractedText.Text = extractedText;
            }
        }

        // Função para ler QR Code de uma imagem
        private void ReadQRCodeFromImage(string filePath)
        {
            try
            {
                var barcodeReader = new BarcodeReader
                {
                    Options = new ZXing.Common.DecodingOptions
                    {
                        TryHarder = true, // Tenta mais intensamente encontrar QR code
                        PossibleFormats = new[] { ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.CODE_128, ZXing.BarcodeFormat.CODE_39, ZXing.BarcodeFormat.EAN_13 }
                    }
                };

                using (var img = new System.Drawing.Bitmap(filePath))
                {
                    var result = barcodeReader.Decode(img);
                    if (result != null)
                    {
                        ProcessQRCodeOrBarcodeResult(result.Text);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum QR Code ou código de barras encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler o QR Code ou código de barras: " + ex.Message);
            }
        }

        // Função para processar o resultado do QR Code
        private void ProcessQRCodeOrBarcodeResult(string result)
        {
            // Atualizar o texto no txtExtractedText de forma segura
            string existingText = txtExtractedText.Text;
            string newText = existingText + Environment.NewLine + "QR Code / Código de Barras Detectado: " + result;

            if (txtExtractedText.InvokeRequired)
            {
                txtExtractedText.Invoke(new Action(() => txtExtractedText.Text = newText));
            }
            else
            {
                txtExtractedText.Text = newText;
            }

            // Verificar se o conteúdo é uma URL e abrir o site se for
            if (Uri.IsWellFormedUriString(result, UriKind.Absolute))
            {
                DialogResult dialogResult = MessageBox.Show($"Abrir o site: {result}?", "QR Code Detectado", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start(result); // Abre o site no navegador
                }
            }
        }

        // Função para o botão de carregar arquivo
        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos PDF, JPG, PNG|*.pdf;*.jpg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ProcessFile(filePath);
                }
            }
        }

        // Função para limpar o TextBox e preparar para o próximo arquivo
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtExtractedText.Clear();
        }
    }
}
