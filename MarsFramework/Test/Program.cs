using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

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
                //initial steps common to all test cases
                CommonStartupSteps();
                Generate3PageList();
                
                //click next page button
                PageObjManageList.GoToNextPage();             
                
                //assert that the page navigated properly
                StringAssert.Contains("2", PageObjManageList.GetCurrentPage());

                //log test results
                LogTestResults("2", "Next page button test passed", "Next page button test failed");

                //screenshot
                String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
                test.Log(LogStatus.Info, "Image example: " + img);

                //final steps common to all test cases
                Remove3PageList();
            }

            [Test]
            public void CheckPageNumberButton()
            {
                //initial steps common to all test cases
                CommonStartupSteps();
                Generate3PageList();
                
                //click a page number button
                PageObjManageList.GoToPage3();

                //assert that the page navigated properly
                StringAssert.Contains("3", PageObjManageList.GetCurrentPage());

                //log test results
                LogTestResults("3", "Page number button test passed", "Page number button test failed");

                //screenshot
                String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
                test.Log(LogStatus.Info, "Image example: " + img);

                //final steps common to all test cases
                Remove3PageList();
            }

            [Test]
            public void CheckPreviousPageButton()
            {
                //initial steps common to all test cases
                CommonStartupSteps();
                Generate3PageList();
                
                //click page 3 button then click previous page button
                PageObjManageList.GoToPage3();             
                PageObjManageList.GoToPreviousPage();

                //assert that the page navigated properly
                StringAssert.Contains("2", PageObjManageList.GetCurrentPage());

                //log test results
                LogTestResults("2", " Previous page button test passed", "Previous page button test failed");

                //screenshot
                String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
                test.Log(LogStatus.Info, "Image example: " + img);

                //final steps common to all test cases
                Remove3PageList();
            }





            //initial test steps common to all test cases
            private void CommonStartupSteps()
            {
                //Set waiting time for all elements to 5 seconds
                GlobalDefinitions.wait(5);
                
                //create new page objects
                PageObjManageList = new ManageListings();
                PageObjShareSkill = new ShareSkill();
                
                //go to ListManagement page
                PageObjManageList.GoToManageListingsPage();
            }

            //generate a 3-page list of items 
            private void Generate3PageList()
            {
                for (int r = 2; r <= 12; r++) 
                {
                    PageObjManageList.GoToShareSkillPage();
                    PageObjShareSkill.EnterShareSkill(r);
                }
            }

            //remove the 3-page list of items
            private void Remove3PageList()
            {
                PageObjManageList.GoToManageListingsPage();
                for (int i = 1; i <= 11; i++) 
                {
                    PageObjManageList.DeleteFromTopOfTheList();
                }
            }

            //log test results
            private void LogTestResults(string expectedoutput, string passmessage, string failmessage)
            {
                if (PageObjManageList.GetCurrentPage() == expectedoutput)
                {
                    test.Log(LogStatus.Pass, passmessage);
                }
                else
                {
                    test.Log(LogStatus.Fail, failmessage);
                }
            }
        }
    }
}