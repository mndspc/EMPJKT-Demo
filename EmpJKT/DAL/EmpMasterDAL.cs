using System;
using System.Collections.Generic;
using DEL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace DAL
{
    public class EmpMasterDAL : IDAL<EmpMaster>
    {
        #region Database Objects
        SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;
        #endregion
        public bool Save(EmpMaster entity)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                //sqlCommand.CommandText = "Insert into EmpMaster Values(" + entity.EmpCode +",'" + entity.EmpName +"','" + entity.DateofBirth + "','" + entity.Email + "'," + entity.DeptCode+")";

                sqlCommand.CommandText = SP.SaveEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value = entity.EmpCode;
                sqlCommand.Parameters.Add("@EmpName", SqlDbType.VarChar, 50).Value = entity.EmpName;
                sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = entity.DateofBirth;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = entity.Email;
                sqlCommand.Parameters.Add("@DeptCode", SqlDbType.Int).Value = entity.DeptCode;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.ExecuteNonQuery();
                return true;
            }catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool Delete(EmpMaster entity)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.DeleteEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value = entity.EmpCode;
               
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool Update(EmpMaster entity)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = SP.UpdateEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value = entity.EmpCode;
                sqlCommand.Parameters.Add("@EmpName", SqlDbType.VarChar, 50).Value = entity.EmpName;
                sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = entity.DateofBirth;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = entity.Email;
                sqlCommand.Parameters.Add("@DeptCode", SqlDbType.Int).Value = entity.DeptCode;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public EmpMaster GetById(object obj)
        {
            var empMaster = new EmpMaster();
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.GetEmpByCode.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value =Convert.ToInt32(obj);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    //  This method open up SqlDataReader and returns true if there is row to read.
                    sqlDataReader.Read();
                    empMaster.EmpCode = Convert.ToInt32(sqlDataReader["EmpCode"]);
                    empMaster.EmpName = Convert.ToString(sqlDataReader["EmpName"]);
                    empMaster.DateofBirth = DateTime.Parse(sqlDataReader["DateofBirth"].ToString());
                    empMaster.Email = Convert.ToString(sqlDataReader["Email"]);
                    empMaster.DeptCode = Convert.ToInt32(sqlDataReader["DeptCode"]);
                }
                 sqlDataReader.Close();
                return empMaster;
            }catch(SqlException ex)
            {
                return empMaster;
            }
            finally
            {
              
                sqlConnection.Close();
            }
        }
        public List<EmpMaster> GetAll()
        {
            var empList = new List<EmpMaster>();
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.GetAll.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                   while(sqlDataReader.Read())
                    {
                        EmpMaster empMaster = new EmpMaster();
                        empMaster.EmpCode = Convert.ToInt32(sqlDataReader["EmpCode"]);
                        empMaster.EmpName = Convert.ToString(sqlDataReader["EmpName"]);
                        empMaster.DateofBirth = DateTime.Parse(sqlDataReader["DateofBirth"].ToString());
                        empMaster.Email = Convert.ToString(sqlDataReader["Email"]);
                        empMaster.DeptCode = Convert.ToInt32(sqlDataReader["DeptCode"]);
                        empList.Add(empMaster);
                    }
                   
                }
                return empList;
            }
            catch(Exception ex)
            {
                return empList;
            }
            finally
            {
                sqlDataReader.Close();
                sqlConnection.Close();
            }
        }

        public int GetCount()
        {
            int count=0;
            try
            {
                sqlCommand.Connection = sqlConnection;
                // sqlCommand.CommandText = SP.GetEmpCount.ToString();
                sqlCommand.CommandText = "select count(*) from EmpMaster";
                sqlCommand.CommandType = CommandType.Text;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count;
            }catch(SqlException ex)
            {
                return count;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
       
    }
}
