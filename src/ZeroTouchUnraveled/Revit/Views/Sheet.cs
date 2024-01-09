using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Revit.Elements;
using Revit.Elements.Views;
using RevitServices.Persistence;



namespace ZeroTouchUnraveled.Revit.Views.Sheet
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
    }
}
