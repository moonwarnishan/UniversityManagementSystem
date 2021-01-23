using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PracticeWindowsForm.Manager;
using PracticeWindowsForm.Model;

namespace PracticeWindowsForm.GateWay
{
    public class DepartmentGateway
    {
        static String database = @"Data Source=DESKTOP-J5AVPT5;Initial Catalog=UniversityManagementSystem;
                                                                integrated security=SSPI";

        readonly SqlConnection connection = new SqlConnection(database);
        private SqlCommand _command;
        private SqlDataReader reader;
        private string _query;

        public DepartmentGateway()
        {
            connection = new SqlConnection(connection.ConnectionString);
        }

        public List<Department> GetallDepartments()
        {
            _query = "select * from Department;";
            _command = new SqlCommand(_query,connection);
            connection.Open();
            reader = _command.ExecuteReader();
            List<Department> depertmentsList = new List<Department>();
            while (reader.Read())
            {
                var department = new Department()
                {
                    DepartmentId = Convert.ToInt32(reader["Id"]),
                    Code = reader["Department_Code"].ToString(),
                    DepartmentName=reader["Department_Name"].ToString()
                };

                depertmentsList.Add(department);
            }
            reader.Close();
            connection.Close();
            return depertmentsList;

        }

        
    }
}
