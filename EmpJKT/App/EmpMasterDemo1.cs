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
            Console.WriteLine("Enter 1.Save Employee 2. Delete Employee 3.Update Employee 4.Get by Id 5.Get All: 6.Transaction");
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
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
            Console.ReadLine();
        }
    }
    
}
