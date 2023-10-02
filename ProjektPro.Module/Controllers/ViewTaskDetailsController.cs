using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using ProjektPro.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektPro.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ViewTaskDetailsController : ViewController <ListView>
    {
        
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ViewTaskDetailsController()
        {
            TargetObjectType = typeof(ProjectTask);
            PopupWindowShowAction Details = new PopupWindowShowAction(
                this, "Show Task Details", PredefinedCategory.Edit);
            Details.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            Details.TargetObjectsCriteria = "Not IsNewObject(This)";
            Details.CustomizePopupWindowParams += viewTaskDetails;


        }
        void viewTaskDetails(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(View.ObjectTypeInfo.Type);
            var objectToShow = objectSpace.GetObject(View.CurrentObject);
            if (objectToShow != null)
            {
                DetailView createdView = Application.CreateDetailView(objectSpace, objectToShow);
                createdView.ViewEditMode = ViewEditMode.Edit;
                e.View = createdView;
            }
             
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
