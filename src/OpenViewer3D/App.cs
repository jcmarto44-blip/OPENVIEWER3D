using Autodesk.Revit.UI;

namespace OpenViewer3D
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "OBRA360";

            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch { }

            application.CreateRibbonPanel(tabName, "OpenViewer3D");

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
