using System;


namespace DEL
{
    //  This is Model Class for SalarySheetInfo table.
    public class SalarySheetInfo
    {
        public int SalarySheetNo { get; set; }

        public int EmpCode { get; set; }

        public DateTime DateOfSalary { get; set; }

        public double Basic { get; set; }

        public double Hra { get; set; }
        public double Da { get; set; }

        public double NetSalary { get; set; }
    }
}
