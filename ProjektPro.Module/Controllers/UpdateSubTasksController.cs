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

namespace ProjektPro.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class UpdateSubTasksController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        SimpleAction UpdateSubtasks;
        public UpdateSubTasksController()
        {
            TargetObjectType = typeof(ProjectTask);

            UpdateSubtasks = new SimpleAction(this, "Update Sub Tasks", DevExpress.Persistent.Base.PredefinedCategory.Edit);
            UpdateSubtasks.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            UpdateSubtasks.Execute += Update_SubTasks;
            /*Actions.Add(Task_Completed);*/
        }

        private void Update_SubTasks(object sender, SimpleActionExecuteEventArgs e)
        {
            var taskObject = e.CurrentObject as ProjectTask;

            if (taskObject != null)
            {
                bool allSubtasksCompleted = taskObject.ProjectSubTasks.All(subtask => subtask.Status == CurrentStatus.Completed);
                if (allSubtasksCompleted)
                {
                    taskObject.Status = Status.Completed;
                }
            }
            this.ObjectSpace.CommitChanges();



            /*bool allSubtasksCompleted = taskObject.ProjectSubTask.All(subtask => subtask.Status == CurrentStatus.Completed);

            else if (allSubtasksCompleted)
          {
              taskObject.Status = Status.Completed;
              this.ObjectSpace.CommitChanges();
          }*/

            /*foreach (var subtask in taskObject.ProjectSubTasks)
            {
                subtask.Status = CurrentStatus.Completed;
            }*/

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
