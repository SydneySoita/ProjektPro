using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using ProjektPro.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPro.Module.Controllers
{
    public class TaskCompletedController : ViewController
    {
        SimpleAction TaskCompleted;
        public TaskCompletedController()
        {
            TargetObjectType = typeof(ProjectTask);

            TaskCompleted = new SimpleAction(this, "Mark As Complete", DevExpress.Persistent.Base.PredefinedCategory.Edit);
            TaskCompleted.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
            TaskCompleted.Execute += Task_Completed;
            /*Actions.Add(Task_Completed);*/
        }

        private void Task_Completed(object sender, SimpleActionExecuteEventArgs e)
        {
            var taskObject = e.CurrentObject as ProjectTask;

            if (taskObject != null)
            {
                foreach (var subtask in taskObject.ProjectSubTasks)
                {
                    subtask.Status = CurrentStatus.Completed;
                }
                taskObject.Status = Status.Completed;
            }
            this.ObjectSpace.CommitChanges();

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
