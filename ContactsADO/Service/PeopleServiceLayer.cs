﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsADO.Entities;
using System.Data.SqlServerCe;

namespace ContactsADO.Service
{
    public class PeopleServiceLayer
    {
        public static bool Insert(People objPeople)
        {
            SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Users\ManojKumar\Documents\GitHub\ContactsExample\ContactsADO\bin\Debug\ContactsDB.sdf;Persist Security Info=False;");
            SqlCeCommand com = new SqlCeCommand();
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = @"INSERT INTO People(Name, Company, Telephone, Email, Client, LastCall) "+
                    @"VALUES(@Name, @Company, @Telephone, @Email, @Client, @LastCall)";
                com.Parameters.Add(new SqlCeParameter("Name", objPeople.Name));
                com.Parameters.Add(new SqlCeParameter("Company", objPeople.Company));
                com.Parameters.Add(new SqlCeParameter("Telephone", objPeople.Telephone));
                com.Parameters.Add(new SqlCeParameter("Email", objPeople.Email));
                com.Parameters.Add(new SqlCeParameter("Client", objPeople.Client));
                com.Parameters.Add(new SqlCeParameter("LastCall", objPeople.LastCall));
                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
            }
            return true;
        }
    }
}
