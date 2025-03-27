using System;
using System.Windows.Forms;
using prototipo; // Referência ao namespace correto

namespace DocumentProcessingApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Inicia o Form1
        }
    }
}
