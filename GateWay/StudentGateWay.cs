using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PracticeWindowsForm.Manager;
using PracticeWindowsForm.Model;

namespace PracticeWindowsForm.GateWay
{
    public class StudentGateWay
    {
        static String database = @"Data Source=DESKTOP-J5AVPT5;Initial Catalog=UniversityManagementSystem;
                                                                integrated security=SSPI";

        readonly SqlConnection connection = new SqlConnection(database);
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _query;

        public StudentGateWay()
        {
            connection = new SqlConnection(connection.ConnectionString);
        }

        public int SaveStudent(Student astudent)
        {
            _query = "insert into Students(StudentName,StudentRegNumber,PhoneNo,Email,Department_Id) values(@Name,@RegNo,@MobileNo,@Email,@DepartmentId)";
            
            connection.Open();
            _command = new SqlCommand {CommandText = _query, Connection = connection};
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("Name", astudent.Name);
            _command.Parameters.AddWithValue("RegNo", astudent.RegNo);
            _command.Parameters.AddWithValue("MobileNo", astudent.MobileNo);
            _command.Parameters.AddWithValue("Email", astudent.Email);
            _command.Parameters.AddWithValue("DepartmentId", astudent.DepartmentId);
            int row = _command.ExecuteNonQuery();
            connection.Close();
            return row;
        }

        public bool IsRegNoExist(Student student)
        {
            
            _query = "select * from Students where StudentRegNumber=@RegNo And Student_Id<>@id";
            _command = new SqlCommand(_query, connection);
            _command.Parameters.AddWithValue("RegNo", student.RegNo);
            _command.Parameters.AddWithValue("id", student.id);
            connection.Open();
            _reader = _command.ExecuteReader();
            bool isexist = _reader.HasRows;
            _reader.Close();
            connection.Close();

            return isexist;

        }

        public List<Student> GetAllValue()
        {
            _query = "select * from Students;";
            _command = new SqlCommand(_query, connection);
            connection.Open();
            _reader = _command.ExecuteReader();
            List<Student> students=new List<Student>();
            while (_reader.Read())
            {
                var student = new Student
                {
                    id = Convert.ToInt32(_reader["Student_Id"]),
                    Name = _reader["StudentName"].ToString(),
                    Email = _reader["Email"].ToString(),
                    MobileNo = _reader["PhoneNo"].ToString(),
                    RegNo = _reader["StudentRegNumber"].ToString(),
                    DepartmentId = Convert.ToInt32(_reader["Department_Id"])
                };
                 students.Add(student);

            }

            _reader.Close();
            connection.Close();
            return students;
        }
        public int UpdateStudentInformation(Student student)
        {
            _query = "update Students set StudentName=@Name,PhoneNo=@MobileNo,Email=@Email,Department_id=@DepartmentId,StudentRegNumber=@RegNo Where Student_Id=@id";
            
                connection.Open();
                _command = new SqlCommand();
                _command = new SqlCommand(_query, connection);
                _command.Parameters.AddWithValue("Name",student.Name);
                _command.Parameters.AddWithValue("MobileNo",student.MobileNo);
                _command.Parameters.AddWithValue("Email",student.Email);
                _command.Parameters.AddWithValue("DepartmentId",student.DepartmentId);
                _command.Parameters.AddWithValue("RegNo",student.RegNo);
                _command.Parameters.AddWithValue("id",student.id);
                int row = _command.ExecuteNonQuery();
                connection.Close();
                return row;
        }


    }
}
