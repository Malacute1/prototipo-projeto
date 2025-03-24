using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfiumViewer;
using Tesseract;
using ZXing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace DocumentProcessorApp
{
    public class DocumentProcessor
    {
        public static string GetFileType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            if (extension == ".pdf")
                return "PDF";
            if (extension == ".jpg" || extension == ".png")
                return "Image";
            return "Unknown";
        }

        public string ExtractTextFromPdf(string pdfFilePath)
        {
            StringBuilder extractedText = new StringBuilder();

            using (var pdfDocument = PdfiumViewer.PdfDocument.Load(pdfFilePath))
            {
                for (int i = 0; i < pdfDocument.PageCount; i++)
                {
                    // Aqui você renderiza o PDF em uma imagem (Image)
                    using (Image image = pdfDocument.Render(i, 300, 300, true))
                    {
                        // Cast explícito para Bitmap
                        Bitmap bitmapImage = (Bitmap)image;

                        // Chama a versão do método que aceita um Bitmap
                        extractedText.Append(ExtractTextFromImage(bitmapImage));
                    }
                }
            }

            return extractedText.ToString();
        }

        // Método que extrai texto de um arquivo de imagem, dado o caminho do arquivo
        public string ExtractTextFromImage(string imagePath)
        {
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    var result = engine.Process(img);
                    return result.GetText();
                }
            }
        }

        // Método que extrai texto de um Bitmap (imagem já carregada)
        private string ExtractTextFromImage(Bitmap image)
        {
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var img = PixConverter.ToPix(image))
                {
                    var result = engine.Process(img);
                    return result.GetText();
                }
            }
        }

        public string DecodeBarcode(string imagePath)
        {
            var reader = new BarcodeReader();
            using (var barcodeBitmap = (Bitmap)Image.FromFile(imagePath))
            {
                var result = reader.Decode(barcodeBitmap);
                return result?.Text;
            }
        }

        public bool MatchLogo(string imagePath, string logoPath)
        {
            var image = new UMat(imagePath, ImreadModes.Color);
            var logo = new UMat(logoPath, ImreadModes.Color);
            var result = new UMat();

            CvInvoke.MatchTemplate(image, logo, result, TemplateMatchingType.CcoeffNormed);

            double minVal = 0, maxVal = 0;
            Point minLoc = new Point(), maxLoc = new Point();
            CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

            return maxVal > 0.9;
        }

        public string ClassifyDocument(string extractedData)
        {
            if (extractedData.Contains("Invoice"))
                return "Invoice";
            if (extractedData.Contains("Receipt"))
                return "Receipt";
            return "Unknown";
        }

        public static List<string> SeparateDocuments(string imagePath)
        {
            List<string> documents = new List<string> { imagePath };
            return documents;
        }

        public static string ChooseExtractionMethod(string fileType)
        {
            if (fileType == "PDF")
                return "ExtractTextFromPdf";
            if (fileType == "Image")
                return "ExtractTextFromImage";
            return "Unknown";
        }
    }
}
