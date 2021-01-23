using System;
using System.Collections.Generic;
using System.Text;
using PracticeWindowsForm.GateWay;
using PracticeWindowsForm.Model;

namespace PracticeWindowsForm.Manager
{
    public class DepartmnetManager
    {
        private DepartmentGateway departmentGateway=new DepartmentGateway();
        public List<Department> GetAlldept()
        {
            return departmentGateway.GetallDepartments();
        }
    }
}
