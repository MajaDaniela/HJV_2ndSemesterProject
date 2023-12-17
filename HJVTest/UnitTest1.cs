using HJV_2ndSemesterProject;
using HJV_2ndSemesterProject.ViewModels;
namespace HJVTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestGetDescription()
        {
            //Arrange
            string target1 = "Korporal";
            string target2 = "Vagtchef";
            string target3 = "Sommertogt";

            //Act
            string s1 = Rank.Corporal.GetDescription(); 
            string s2 = Role.OfficerOfTheWatch.GetDescription();
            string s3 = SailingType.SummerCruise.GetDescription();

            //Assert
            Assert.AreEqual(target1, s1);
            Assert.AreEqual(target2, s2);
            Assert.AreEqual(target3, s3);
        }

            


    }
}