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
            var empMaster = new EmpMaster();
            try{
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.GetEmpByCode.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value = Convert.ToInt32(obj);

                sqlDataAdapter.SelectCommand = sqlCommand;
                dataSet.Reset();
                sqlDataAdapter.Fill(dataSet, "Emp");

                if (dataSet.Tables["Emp"].Rows.Count > 0)
                {
                    DataRow dataRow = dataSet.Tables["Emp"].Rows[0];

                    empMaster.EmpCode = Convert.ToInt32(dataRow[0]);
                    empMaster.EmpName = Convert.ToString(dataRow[1]);
                    empMaster.DateofBirth = DateTime.Parse(dataRow[2].ToString());
                    empMaster.Email = Convert.ToString(dataRow[3]);
                    empMaster.DeptCode = Convert.ToInt32(dataRow[4]);
                    return empMaster;
                }
                else
                {
                    return null;
                }
                
            }catch(SqlException ex)
            {
                return empMaster;
            }
        }
        public List<EmpMaster> GetAll()
        {
            var empList = new  List<EmpMaster>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.GetAll.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand = sqlCommand;
                dataSet.Reset();
                sqlDataAdapter.Fill(dataSet, "EmpAll");
                if (dataSet.Tables["EmpAll"].Rows.Count > 0)
                {
                    foreach(DataRow datarow in dataSet.Tables["EmpAll"].Rows)
                    {
                        var empMaster = new EmpMaster();
                        empMaster.EmpCode = Convert.ToInt32(datarow[0]);
                        empMaster.EmpName = Convert.ToString(datarow[1]);
                        empMaster.DateofBirth = DateTime.Parse(datarow[2].ToString());
                        empMaster.Email = Convert.ToString(datarow[3]);
                        empMaster.DeptCode = Convert.ToInt32(datarow[4]);
                        empList.Add(empMaster);
                    }
                    return empList;
                }
                else
                {
                    return null;
                }
            }catch(SqlException ex)
            {
                return null;
            }
        }

        public List<SelectEmpSalaryInfo> EmpInfowithSalary()
        {
            //--CREATE A VIEW TO SELECT SALARYINFO AND EMP INFO
            //CREATE VIEW SelectEmpSalaryInfo
            //AS
            //SELECT E.EmpCode,E.EmpName,E.Email,S.NetSalary FROM EmpMaster E
            //INNER JOIN
            //SalarySheetInfo S
            //ON
            //E.EmpCode = S.EmpCode

            var empList = new List<SelectEmpSalaryInfo>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from SelectEmpSalaryInfo";
                sqlCommand.CommandType = CommandType.Text;
                sqlDataAdapter.SelectCommand = sqlCommand;
                dataSet.Reset();
                sqlDataAdapter.Fill(dataSet, "EmpInfoWithSalary");
                if (dataSet.Tables["EmpInfoWithSalary"].Rows.Count > 0)
                {
                    foreach (DataRow datarow in dataSet.Tables["EmpInfoWithSalary"].Rows)
                    {
                        var emp = new SelectEmpSalaryInfo();
                        emp.EmpCode = Convert.ToInt32(datarow[0]);
                        emp.EmpName= Convert.ToString(datarow[1]);
                        emp.Email = datarow[2].ToString();
                        
                        emp.NetSalary = Convert.ToDouble(datarow[3]);
                        empList.Add(emp);
                    }
                    return empList;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
      
    }
}
