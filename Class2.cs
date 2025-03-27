using System;

namespace DocumentProcessorApp
{
    public class AuditTrail
    {
        public void LogAction(string action, string details)
        {
            // Gravar a ação no log
            Console.WriteLine($"Ação: {action}, Detalhes: {details}");
        }
    }
}
