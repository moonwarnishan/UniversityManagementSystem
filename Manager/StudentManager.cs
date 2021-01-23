using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PracticeWindowsForm.GateWay;
using PracticeWindowsForm.Model;

namespace PracticeWindowsForm.Manager
{
    public class StudentManager
    {
        private  StudentGateWay _studentGateway = new StudentGateWay();
        public string SaveStudent(Student aStudent)
        {
            
            if (_studentGateway.IsRegNoExist(aStudent))
            {
                return "RegNo already Exist";
            }


            int row = _studentGateway.SaveStudent(aStudent);
            if (row >0)
            {
                return "saved successfully.";
            }

            return "something went wrong";
        }

        public List<Student> GetAllStudent()
        {

            return _studentGateway.GetAllValue();
        }

        public String UpdateStudents(Student aStudent)
        {
            if (_studentGateway.IsRegNoExist(aStudent))
            {
                return "Reg Num Already Exist";
            }  
            int row= _studentGateway.UpdateStudentInformation(aStudent);
           if (row > 0)
           {
               return "updated Successfully";
           }

           return "Try Again";
        }
    }
}
