using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DEL;
namespace App
{
    class EmpMasterDemo1
    {
        static void Main()
        {
            EmpMasterDAL1 empMasterDAL1 = new EmpMasterDAL1();
            Console.WriteLine("Enter 1.Save Employee 2. Delete Employee 3.Update Employee 4.Get by Id 5.Get All: 6.Get Emp Info with Salary");
            int response = int.Parse(Console.ReadLine());
            switch (response)
            {
                case 1:
                    EmpMaster empMaster = new EmpMaster {EmpCode=131,EmpName="Sunil",DateofBirth=DateTime.Parse("03-04-1980"),Email="sunil@gmail.com" ,DeptCode=100};
                    Console.WriteLine(empMasterDAL1.Save(empMaster) ? "Employee Saved" : "Error");
                    break;
                case 2:
                    EmpMaster delEmpMaster = new EmpMaster { EmpCode = 131, EmpName = "Sunil", DateofBirth = DateTime.Parse("03-04-1980"), Email = "sunil@gmail.com", DeptCode = 100 };
                    Console.WriteLine(empMasterDAL1.Delete(delEmpMaster) ? "Employee Deleted" : "Error");
                 
                    break;
                case 3:
                    break;
                case 4:
                    int empCode = 100;
                    var empByCode = empMasterDAL1.GetById(empCode);
                    if (empByCode != null)
                    {
                        Console.WriteLine($"Code={empByCode.EmpCode}\tName={empByCode.EmpName}\tDate of Birth={empByCode.DateofBirth}\tEmail={empByCode.Email}\tDept Code={empByCode.DeptCode}");
                    }
                    else
                    {
                        Console.WriteLine("Employee does not exist");
                    }
                    break;
                case 5:
                    var empList = empMasterDAL1.GetAll();
                    if (empList != null)
                    {
                        foreach(var emp in empList)
                        {
                            Console.WriteLine($"Code={emp.EmpCode}\tName={emp.EmpName}\tDate of Birth={emp.DateofBirth}\tEmail={emp.Email}\tDept Code={emp.DeptCode}");

                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no Employee");
                    }
                    break;
                case 6:
                    var empWithSalaryInfo = empMasterDAL1.EmpInfowithSalary();
                    if (empWithSalaryInfo != null)
                    {
                        foreach (var employee in empWithSalaryInfo)
                        {
                            Console.WriteLine($"Code={employee.EmpCode}\tName={employee.EmpName}\tDEmail={employee.Email}\tNet Salary={employee.NetSalary}");

                        }
                    }
                    break;
            }
            Console.ReadLine();
        }
    }
    
}
