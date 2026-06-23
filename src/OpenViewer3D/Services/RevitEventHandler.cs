using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Linq;

namespace OpenViewer3D.Services
{
    public class RevitEventHandler : IExternalEventHandler
    {
        public static string ViewToOpen = "OBRA360_AVANCE_SEMANAL";

        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = uidoc.Document;

            View view = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .Cast<View>()
                .FirstOrDefault(v => v.Name == ViewToOpen);

            if (view != null)
            {
                uidoc.ActiveView = view;
            }
        }

        public string GetName()
        {
            return "OpenViewer3D_RevitEventHandler";
        }
    }
}
