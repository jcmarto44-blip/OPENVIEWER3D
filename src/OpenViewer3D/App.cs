using Autodesk.Revit.UI;
using System;
using System.Reflection;

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

            RibbonPanel panel = application.CreateRibbonPanel(tabName, "OpenViewer3D");

            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData(
                "OpenViewer3DButton",
                "Abrir Vista 3D",
                assemblyPath,
                "OpenViewer3D.OpenViewCommand"
            );

            PushButton button = panel.AddItem(buttonData) as PushButton;
            button.ToolTip = "Abre la vista OBRA360_AVANCE_SEMANAL";

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
