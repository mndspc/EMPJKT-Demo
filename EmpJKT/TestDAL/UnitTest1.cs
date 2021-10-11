using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DEL;
namespace TestDAL
{
    [TestClass]
    public class EmpMasterDALTest
    {
        [TestMethod]
        public void TestGetById()
        {
            //Arrange:This is first step of Unit test. It perform necessary setup for the test.
            EmpMasterDAL empMasterDAL = new EmpMasterDAL();
            var empMaster = new EmpMaster();
            var empMaster1 = new EmpMaster {EmpCode=123,EmpName= "Scott",DateofBirth=DateTime.Parse("1980-02-03"),Email= "scott@gmail.com",DeptCode= 101 };

            //Act:This is a middle step of unit test.It execute unit test.
            empMaster = empMasterDAL.GetById(123);

            //Assert:This is a last step of unit test. In this step we check or verify results.
            Assert.AreEqual(empMaster.EmpCode, empMaster1.EmpCode);
            //Assert.AreSame(empMaster, empMaster1);
        }

        [TestMethod]
        public void TestValidateUser()
        {
            //Arrange:
            UserInfoDAL userInfoDAL = new UserInfoDAL();
            var userInfo = new UserInfo {Email= "admin123@gmail.com",Password= "admin123" };

            //Act:
            var flag = userInfoDAL.ValidateUser(userInfo);

            //Assert:
            //Assert.IsTrue(flag);
            Assert.IsFalse(flag);

       
        }

    }
}
