using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Linq;

namespace OpenViewer3D.Services
{
    public class CommandListener
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task CheckCommands(UIApplication uiapp)
        {
            try
            {
                // URL de tu API en Vercel (ajústala después)
                string url = "https://tuapp.vercel.app/api/openviewer3d-endpoint?project=1001&view=OBRA360_AVANCE_SEMANAL";

                string response = await client.GetStringAsync(url);

                // Validación simple del comando
                if (response.Contains("openView"))
                {
                    UIDocument uidoc = uiapp.ActiveUIDocument;
                    Document doc = uidoc.Document;

                    string viewName = "OBRA360_AVANCE_SEMANAL";

                    View view = new FilteredElementCollector(doc)
                        .OfClass(typeof(View3D))
                        .Cast<View>()
                        .FirstOrDefault(v => v.Name == viewName);

                    if (view != null)
                    {
                        uidoc.ActiveView = view;
                    }
                }
            }
            catch
            {
                // Evita romper Revit si falla la conexión
            }
        }
    }
}
