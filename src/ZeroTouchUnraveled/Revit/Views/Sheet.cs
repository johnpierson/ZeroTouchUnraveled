using System.Collections.Generic;
using Autodesk.Revit.DB;
using Revit.Elements;
using RevitServices.Persistence;
using RevitServices.Transactions;



namespace ZeroTouchUnraveled.Revit.Views
{
    /// <summary>
    /// Wrapper class for sheets
    /// </summary>
    public class Sheet
    {
        private Sheet() { }

        /// <summary>
        /// Get all placed views on the input sheet.
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static List<global::Revit.Elements.Views.View> GetAllPlacedViews(global::Revit.Elements.Views.Sheet sheet)
        {
            //access the current revit document
            Autodesk.Revit.DB.Document doc = DocumentManager.Instance.CurrentDBDocument;

            //this casts the Dynamo Revit Sheet to a Autodesk.Revit.DB.ViewSheet
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;

            //use the Revit API method on the Autodesk.Revit.DB.ViewSheet element to get all the placed views on the sheet.
            var placedViewIds = viewSheet.GetAllPlacedViews();

            //our list to host our views to output
            var placedViews = new List<global::Revit.Elements.Views.View>();

            //step through each Autodesk.Revit.DB.ElementId element to get it from the current file.
            foreach (ElementId viewId in placedViewIds)
            {
                //get the view as an Autodesk.Revit.DB.View element
                var internalView = doc.GetElement(viewId) as Autodesk.Revit.DB.View;

                //return the view as a Dynamo Revit.Elements.Views.View element by using ToDSType(false) to cast it
                placedViews.Add(internalView.ToDSType(false) as global::Revit.Elements.Views.View);
            }

            //finally, return our newly created list of Revit.Elements.Views.View elements (with clickable green element ids)
            return placedViews;
        }

        /// <summary>
        /// Set the input sheet number.
        /// </summary>
        /// <param name="sheet">The sheet to modify</param>
        /// <param name="sheetNumber">The new sheet number</param>
        /// <returns></returns>
        public static global::Revit.Elements.Views.Sheet SetSheetNumber(global::Revit.Elements.Views.Sheet sheet, string sheetNumber)
        {
            //access the current revit document
            Autodesk.Revit.DB.Document doc = DocumentManager.Instance.CurrentDBDocument;

            //this casts the Dynamo Revit Sheet to a Autodesk.Revit.DB.ViewSheet
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;

            //start our transaction in the current file
            TransactionManager.Instance.EnsureInTransaction(doc);

            //try to set the sheet number
            try
            {
                viewSheet.SheetNumber = sheetNumber;
            }
            //if that failed return a custom error
            catch (System.Exception)
            {
                //viewSheet.SheetNumber = $"{sheetNumber}*";
                throw new System.Exception("Sorry, Revit does not allow you to number two sheets the same. Please try again");
            }

            //finish our transaction and cleanup
            TransactionManager.Instance.TransactionTaskDone();

            //return the original sheet back to the end user
            return sheet;
        }
        /// <summary>
        /// Live Reload modify sheet stuff
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static global::Revit.Elements.Views.Sheet ModifySheetStuff(global::Revit.Elements.Views.Sheet sheet)
        {
            //access the current revit document
            Autodesk.Revit.DB.Document doc = DocumentManager.Instance.CurrentDBDocument;

            //start our transaction in the current file
            TransactionManager.Instance.EnsureInTransaction(doc);

            //finish our transaction and cleanup
            TransactionManager.Instance.TransactionTaskDone();

            //return the original sheet back to the end user
            return sheet;
        }
    }
}
