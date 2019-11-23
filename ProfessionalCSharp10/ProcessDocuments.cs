using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp10
{
   public class ProcessDocuments
    {
        public static Task Start(DocumentManager dm)=>Task.Run(new ProcessDocuments(dm).Run);

        protected ProcessDocuments(DocumentManager dm) =>
            _documentManager = dm ?? throw new ArgumentException(nameof(dm));

        private DocumentManager _documentManager;
        protected async Task Run()
        {
            while (true)
            {
                if (_documentManager.IsDocumentAvailable)
                {
                    Document doc = _documentManager.GetDocument();
                    Console.WriteLine(doc.Title);
                }
                await Task.Delay(new Random().Next(20));
            }
        }

      


    }
}
