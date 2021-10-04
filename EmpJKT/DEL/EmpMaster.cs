using System;


namespace DEL
{
    //  This is Model Class for EmpMaster table.
    public class EmpMaster
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
        public int DeptCode { get; set; }
    }
}
