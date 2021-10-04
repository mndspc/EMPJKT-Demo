using System;
using System.Collections.Generic;
using DEL;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class UserInfoDAL : IDAL<UserInfo>
    {
        #region Database Objects
        SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;
        #endregion
        public bool Delete(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserInfo GetById(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Save(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(UserInfo userInfo)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.ValiadateEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = userInfo.Email;
                sqlCommand.Parameters.Add("@pass", SqlDbType.VarChar, 20).Value = userInfo.Password;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }catch(SqlException ex)
            {
                return false;
            }
            finally
            {
                sqlDataReader.Close();
                sqlConnection.Close();
            }
        }
    }
}
