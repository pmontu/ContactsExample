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
            return true;
        }

        private void Insert(object obj)
        {
            MessageBox.Show("Inserted\n");
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
