using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint2")]
        class User : Global.Base
        {
            ManageListings PageObjManageList;
            ShareSkill PageObjShareSkill;

            [Test]
            public void CheckNextPageButton()
            {
                CommonStartupSteps();
                Generate3PageList();
                test = extent.StartTest("Sample Report");
                PageObjManageList.GoToNextPage();             
                StringAssert.Contains("2", PageObjManageList.GetCurrentPage());
                test.Log(LogStatus.Pass, "Next Page Button Test passed");
                Remove3PageList();
            }

            [Test]
            public void CheckPageNumberButton()
            {
                CommonStartupSteps();
                Generate3PageList();
                test = extent.StartTest("Sample Report");
                PageObjManageList.GoToPage3();              
                StringAssert.Contains("3", PageObjManageList.GetCurrentPage());
                test.Log(LogStatus.Pass, "Page Number Button Test passed");
                Remove3PageList();
            }

            [Test]
            public void CheckPreviousPageButton()
            {
                CommonStartupSteps();
                Generate3PageList();
                test = extent.StartTest("Sample Report");
                PageObjManageList.GoToPage3();             
                PageObjManageList.GoToPreviousPage();
                StringAssert.Contains("2", PageObjManageList.GetCurrentPage());
                test.Log(LogStatus.Pass, "Next Page Button Test passed");
                Remove3PageList();
            }

            private void CommonStartupSteps()
            {
                GlobalDefinitions.wait(5);
                PageObjManageList = new ManageListings();
                PageObjShareSkill = new ShareSkill();
                PageObjManageList.GoToManageListingsPage();
            }

            private void Generate3PageList()
            {
                for (int r = 2; r <= 12; r++) {
                    PageObjManageList.GoToShareSkillPage();
                    PageObjShareSkill.EnterShareSkill(r);
                }
            }

            private void Remove3PageList()
            {
                PageObjManageList.GoToManageListingsPage();
                for (int i = 1; i <= 11; i++) {
                    PageObjManageList.DeleteFromTopOfTheList();
                }
            }
        }
    }
}