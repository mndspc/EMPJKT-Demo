using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using DEL;
using System.Data.SqlClient;
using System.Configuration;
namespace App
{
    //  This program demo how to GetXML data from DataSet and How to Export data into XML file from DataSet.
    class DataSetDemo1
    {
        #region Database Objects
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet("Employees");
        #endregion
        static void Main()
        {
            DataSetDemo1 dataSetDemo1 = new DataSetDemo1();
            //dataSetDemo1.GetXML();
           // dataSetDemo1.SaveAsXML();
            dataSetDemo1.ReadXMLIntoDataSet();
            Console.ReadLine();
        }

        public  void GetXML()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText ="GetAll";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataAdapter.SelectCommand = sqlCommand;
                dataSet.Reset();
                sqlDataAdapter.Fill(dataSet, "Emp");
                string xmlStr = dataSet.GetXml();
                Console.WriteLine(xmlStr);
                string xmlSchemaStr = dataSet.GetXmlSchema();
                Console.WriteLine(xmlSchemaStr);

              
            }
            catch (SqlException ex)
            {
               
            }
        }

        public void SaveAsXML()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "GetAll";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataAdapter.SelectCommand = sqlCommand;
                dataSet.Reset();
                sqlDataAdapter.Fill(dataSet, "Emp");
                dataSet.WriteXml("Employee.xml");
                Console.WriteLine("Data Exported Successfully");

            }
            catch (SqlException ex)
            {

            }
        }

        public void ReadXMLIntoDataSet()
        {
            try
            {
                dataSet.ReadXml("Employee.xml", XmlReadMode.Auto);
                var xmlData = dataSet.GetXml();
                Console.WriteLine(xmlData);
            }catch(SqlException ex)
            {

            }
        }
    }
}
