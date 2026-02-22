using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitModelQuickCheck
{
    [Transaction(TransactionMode.Manual)]
    public class CmdQuickCheck : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            int warningCount = doc.GetWarnings().Count;

            int importedCadCount = new FilteredElementCollector(doc)
                .OfClass(typeof(ImportInstance))
                .WhereElementIsNotElementType()
                .Cast<ImportInstance>()
                .Count(x => !x.IsLinked);

            int linkedCadCount = new FilteredElementCollector(doc)
                .OfClass(typeof(ImportInstance))
                .WhereElementIsNotElementType()
                .Cast<ImportInstance>()
                .Count(x => x.IsLinked);

            int inPlaceCount = new FilteredElementCollector(doc)
                .OfClass(typeof(Family))
                .Cast<Family>()
                .Count(f => f.IsInPlace);

            TaskDialog.Show("Model Quick Check",
                $"Warnings            : {warningCount}\n" +
                $"Imported CAD (DWG)  : {importedCadCount}\n" +
                $"Linked CAD (DWG)    : {linkedCadCount}\n" +
                $"In-Place Families   : {inPlaceCount}");

            return Result.Succeeded;
        }
    }
}