using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsADO.Entities;
using ContactsADO.Controller;

namespace ContactsADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            People objPeople = new People();
            objPeople.Client = cbxClient.Checked;
            objPeople.Company = txtCompany.Text;
            objPeople.Email = txtEmail.Text;
            objPeople.LastCall = dtLastCall.Value;
            objPeople.Name = txtName.Text;
            objPeople.Telephone = txtTelephone.Text;
            PeopleUIController.Insert(objPeople);
        }
    }
}
