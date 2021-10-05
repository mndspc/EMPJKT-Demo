using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DEL;
namespace DAL
{
  public  class EmpMasterDAL1 : IDAL<EmpMaster>
    {
        #region Database Objects
        SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
       
        SqlDataAdapter sqlDataAdapter=new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        #endregion
        public bool Save(EmpMaster entity)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.SaveEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value = entity.EmpCode;
                sqlCommand.Parameters.Add("@EmpName", SqlDbType.VarChar, 50).Value = entity.EmpName;
                sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = entity.DateofBirth;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = entity.Email;
                sqlCommand.Parameters.Add("@DeptCode", SqlDbType.Int).Value = entity.DeptCode;
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(EmpMaster entity)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.DeleteEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value = entity.EmpCode;
                
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(EmpMaster entity)
        {
            throw new NotImplementedException();
        }
       
        public EmpMaster GetById(object obj)
        {
            throw new NotImplementedException();
        }
        public List<EmpMaster> GetAll()
        {
            throw new NotImplementedException();
        }

      
    }
}
