using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMSample.Common;
using System.Windows.Input;
using System.Windows;
using System.Linq.Expressions;


namespace ContactsFluentMVVM.ViewModels
{
    class ContactsViewModel : INotifyPropertyChanged
    {
        private readonly ICommand insertCmd;

        public ContactsViewModel()
        {
            insertCmd = new RelayCommand(Insert, CanInsert);
        }

        public ICommand InsertCmd { get { return insertCmd; } }

        private bool CanInsert(object obj)
        {
            //validation
            if (String.IsNullOrEmpty(Name) && 
                String.IsNullOrEmpty(Company) &&
                String.IsNullOrEmpty(Telephone) &&
                String.IsNullOrEmpty(Email) &&
                LastCall == null)
                return false;
            return true;
        }

        private void Insert(object obj)
        {
            //encapsulation
            Domain.People people = new Domain.People();
            people.Name = Name;
            people.Company = Company;
            people.Telephone = Telephone;
            people.Email = Email;
            people.Client = Client;
            people.LastCall = LastCall;

            //db
            var session = ((App)Application.Current).session;
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(people);
                transaction.Commit();
            }
        }

        private String name;
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(() => this.Name);
            }
        }

        private String company;
        public String Company
        {
            get { return company; }
            set
            {
                company = value;
                RaisePropertyChanged(() => this.Company);
            }
        }

        private String telephone;
        public String Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                RaisePropertyChanged(() => this.Telephone);
            }
        }

        private String email;
        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(() => this.Email);
            }
        }

        private bool client;
        public bool Client
        {
            get { return client; }
            set
            {
                client = value;
                RaisePropertyChanged(() => this.Client);
            }
        }

        private DateTime? lastCall;
        public DateTime? LastCall
        {
            get { return lastCall; }
            set
            {
                lastCall = value;
                RaisePropertyChanged(() => this.LastCall);
            }
        }

        #region interface methods
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            //Fire the PropertyChanged event in case somebody subscribed to it
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpr = propertyExpression.Body as MemberExpression;
                string propertyName = memberExpr.Member.Name;
                this.RaisePropertyChanged(propertyName);
            }
        }
        #endregion

    }
}
