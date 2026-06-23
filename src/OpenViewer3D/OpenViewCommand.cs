using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;

namespace OpenViewer3D
{
    [Transaction(TransactionMode.Manual)]
    public class OpenViewCommand : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            string viewName = "OBRA360_AVANCE_SEMANAL";

            View view = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .Cast<View>()
                .FirstOrDefault(v => v.Name == viewName);

            if (view == null)
            {
                TaskDialog.Show("OpenViewer3D", "No se encontró la vista: " + viewName);
                return Result.Failed;
            }

            uidoc.ActiveView = view;

            return Result.Succeeded;
        }
    }
}
