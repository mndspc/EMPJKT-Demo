using System;
using System.Collections.Generic;
using System.Data;
namespace App
{
    //  This program demo. how to create dataset and datatable from scratch and load collections data into dataset.
    class DataSetDemo2
    {
        DataSet dataSet = new DataSet();
        static  void Main()
        {
            DataSetDemo2 dataSetDemo2 = new DataSetDemo2();
            dataSetDemo2.CreateSchema();

            List<Student> students = new List<Student>
            {
                new Student{StdRollNo=100,StdName="Scott",Email="scott@gmail.com" },
                new Student{StdRollNo=100,StdName="Smith",Email="smith@gmail.com"  },
                new Student{ StdRollNo=102,StdName="Tiger",Email="tiger@gmail.com" }
            };

            dataSetDemo2.AddStudents(students);
            Console.ReadLine();
        }
        public void CreateSchema()
        {
            //  To Create DataTable to hold Collection
            DataTable dtStudent = new DataTable("StdProfile");
            //  To Create DataColumn
            DataColumn dcStdRollNo = new DataColumn("StdRollNo", typeof(int));
            DataColumn dcStdName = new DataColumn("StdName", typeof(string));
            DataColumn dcEmail = new DataColumn("Email", typeof(string));
            //  To add DataColumns into DataTable
            dtStudent.Columns.Add(dcStdRollNo);
            dtStudent.Columns.Add(dcStdName);
            dtStudent.Columns.Add(dcEmail);

            DataColumn[] primaryKeyColumns = {dcStdRollNo };
            dtStudent.PrimaryKey = primaryKeyColumns;

            //To add DataTable into DataSet
            dataSet.Tables.Add(dtStudent);

        }

        public void AddStudents(List<Student> students)
        {
            foreach(var student in students)
            {
                DataRow dataRow = dataSet.Tables["StdProfile"].NewRow();
                dataRow["StdRollNo"] = student.StdRollNo;
                dataRow["StdName"] = student.StdName;
                dataRow["Email"] = student.Email;
                dataSet.Tables["StdProfile"].Rows.Add(dataRow);
            }
            var xmldata = dataSet.GetXml();
            Console.WriteLine(xmldata);
        }
    }

    class Student
    {
        public int StdRollNo { get; set; }
        public string StdName { get; set; }

        public string Email { get; set; }
    }
}
