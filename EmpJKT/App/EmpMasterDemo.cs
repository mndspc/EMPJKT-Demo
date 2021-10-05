using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DEL;
namespace App
{
    class EmpMasterDemo
    {
        static void Main()
        {
           
            UserInfoDAL userInfoDAL = new UserInfoDAL();
            UserInfo userInfo = new UserInfo { Email = "admin@gmail.com", Password = "admin123" };
            userInfo.Email = userInfo.Email.Trim('?');
            if (userInfoDAL.ValidateUser(userInfo))
            {
                EmpMasterDAL empMasterDAL = new EmpMasterDAL();
                Console.WriteLine($"Total Employee count is:{ empMasterDAL.GetCount()}");
                Console.WriteLine("Enter 1.Save Employee 2. Delete Employee 3.Update Employee 4.Get by Id 5.Get All: 6.Transaction");
                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        EmpMaster empMaster = new EmpMaster { EmpCode = 129, EmpName = "Sneha", DateofBirth = DateTime.Parse("03-04-1985"), Email = "sneha@gmail.com", DeptCode = 100 };
                        Console.WriteLine(empMasterDAL.Save(empMaster) ? "Employee Saved" : "Error");
                        Console.WriteLine($"Employee count is:{ empMasterDAL.GetCount()}");
                        break;
                    case 2:
                        EmpMaster delEmpMaster = new EmpMaster { EmpCode = 9, EmpName = "Sachin", DateofBirth = DateTime.Parse("02-02-1983"), Email = "sachin@gmail.com", DeptCode = 101 };
                        Console.WriteLine(empMasterDAL.Delete(delEmpMaster) ? "Employee Deleted" : "Error");
                        Console.WriteLine($"Employee count is:{ empMasterDAL.GetCount()}");
                        break;
                    case 3:
                        EmpMaster updateEmpMaster = new EmpMaster { EmpCode = 8, EmpName = "Sachin", DateofBirth = DateTime.Parse("02-02-1983"), Email = "sachin@gmail.com", DeptCode = 101 };
                        Console.WriteLine(empMasterDAL.Update(updateEmpMaster) ? "Employee Updated" : "Error");
                        break;
                    case 4:
                        int empCode = 123;
                        var getEmpMaster = empMasterDAL.GetById(empCode);
                        if (getEmpMaster != null)
                        {
                            Console.WriteLine($"Code={getEmpMaster.EmpCode}\nName={getEmpMaster.EmpName}\nDate of Birth={getEmpMaster.DateofBirth.ToString("dd-MMM-yy")}\nEmail={getEmpMaster.Email}\nDept Code={getEmpMaster.DeptCode}");
                        }
                        else
                        {
                            Console.WriteLine("Employee does not exist");
                        }
                        break;
                    case 5:
                        var empList = empMasterDAL.GetAll();
                        foreach(var emp in empList)
                        {
                            Console.WriteLine($"Code={emp.EmpCode}\tName={emp.EmpName}\tDate of Birth={emp.DateofBirth.ToString("dd-MMM-yy")}\tEmail={emp.Email}\tDept Code={emp.DeptCode}");

                        }
                        break;
                    case 6:
                        Console.WriteLine(empMasterDAL.ExecuteTransaction() ? "Committed" : "Rollbacked");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect Email or Password");
            }
            Console.ReadLine();
        }
    }
}
