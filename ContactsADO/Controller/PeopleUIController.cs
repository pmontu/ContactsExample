using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsADO.Entities;
using ContactsADO.Service;

namespace ContactsADO.Controller
{
    public class PeopleUIController
    {        
        public static bool Insert(People objPeople)
        {
            return PeopleServiceLayer.Insert(objPeople);
        }
    }
}
