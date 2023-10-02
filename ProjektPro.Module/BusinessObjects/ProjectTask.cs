using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjektPro.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Project-Module")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ProjectTask : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public ProjectTask(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Status = Status.ToDo;
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        Status status;
        DateTime endDate;
        DateTime startDate;
        string subject;
        Project project;
        Resource resource;
        ProjectSubTask projectSubTask;

        [Association("Project-ProjectTasks")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Subject
        {
            get => subject;
            set => SetPropertyValue(nameof(Subject), ref subject, value);
        }


        public DateTime StartDate
        {
            get => startDate;
            set => SetPropertyValue(nameof(StartDate), ref startDate, value);
        }


        public DateTime EndDate
        {
            get => endDate;
            set => SetPropertyValue(nameof(EndDate), ref endDate, value);
        }


        public Status Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
        [Association("ProjectTask-Resource")]
        public Resource Resource
        {
            get => resource;
            set => SetPropertyValue(nameof(Resource), ref resource, value);
        }

        [Association("ProjectTask-Resources")]
        public XPCollection<Resource> AvailableResources
        {
            get
            {
                return GetCollection<Resource>(nameof(AvailableResources));
            }
        }

        [Association("ProjectTask-ProjectSubTask")]
        public XPCollection<ProjectSubTask> ProjectSubTasks
        {
            get
            {
                return GetCollection<ProjectSubTask>(nameof(ProjectSubTasks));
            }
        }




    }

    public enum Status
    {
        ToDo = 0,
        InProgress = 1,
        Completed = 2,
        Deferred = 3
    }

}