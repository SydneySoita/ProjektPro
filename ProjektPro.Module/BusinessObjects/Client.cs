using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace ProjektPro.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Client-Module")]

    public class Client : BaseObject 
    {
        public Client(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
        string phoneNumber;
        string lastName;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name),ref name ,value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue (nameof(LastName),ref lastName ,value);
        }

        [Size (SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPropertyValue(nameof(PhoneNumber),ref phoneNumber ,value);    
        }
        [Association("Client-Projects")]
        public XPCollection<Project> Projects
        {
            get
            {
                return GetCollection<Project>(nameof(Projects));
            }

        }

        [Association("Client-Testimonials")]
        public XPCollection<Testimonials> Testimonials
        {
            get
            {
                return GetCollection<Testimonials>(nameof(Testimonials));
            }

        }
    }

}