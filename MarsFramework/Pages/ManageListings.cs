using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement Delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement ShareSkillButton { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//button[@class='ui button otherPage'][text()='>']")]
        private IWebElement NextPageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ui button otherPage'][text()='<']")]
        private IWebElement PreviousPageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ui button otherPage'][text()='3']")]
        private IWebElement Page3Button { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ui active button currentPage']")]
        private IWebElement CurrentPage { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
        }
        
        public void GoToManageListingsPage()
        {
            manageListingsLink.Click();
        }

        internal void GoToShareSkillPage()
        {
            ShareSkillButton.Click();
        }

        public void DeleteFromTopOfTheList()
        {        
            Delete.Click();
            
            clickActionsButton.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();
            
            //explicitly wait for table data to update by itself
            Thread.Sleep(2000);
        }

        public void GoToNextPage()
        {
            NextPageButton.Click();
        }

        public void GoToPage3()
        {
            Page3Button.Click();
        }

        public void GoToPreviousPage()
        {
            PreviousPageButton.Click();
        }

        public string GetCurrentPage()
        {
            return CurrentPage.Text;
        }
    }
}
