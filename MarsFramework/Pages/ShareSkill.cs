using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ActiveOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill(int row)
        {
            //Get test data from excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            string servicetype = (ExcelLib.ReadData(row, "Service Type") != "Hourly") ? "1" : "0";
            string skilltrade  = (ExcelLib.ReadData(row, "Skill Trade") != "Skill-exchange") ? "false" : "true";
            string active      = (ExcelLib.ReadData(row, "Active") != "Active") ? "false" : "true";

            //Enter the Title in textbox
            Title.SendKeys(ExcelLib.ReadData(row, "Title"));

            //Enter the Description in textbox
            Description.SendKeys(ExcelLib.ReadData(row, "Description"));

            //Click on Category Dropdown
            CategoryDropDown.FindElement(By.XPath($"//option[. = '{ExcelLib.ReadData(row, "Category")}']")).Click();

            //Click on SubCategory Dropdown
            SubCategoryDropDown.FindElement(By.XPath($"//option[. = '{ExcelLib.ReadData(row, "Subcategory")}']")).Click();

            //Enter Tag names in textbox
            Tags.Click();
            Tags.SendKeys(ExcelLib.ReadData(row, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Select the Service type
            ServiceTypeOptions.FindElement(By.XPath($"//input[@value='{servicetype}']")).Click();

            //Click on Skill Trade option
            SkillTradeOption.FindElement(By.XPath($"//input[@value='{skilltrade}']")).Click();

            //Enter Skill Exchange
            if (skilltrade == "true")
            {
                SkillExchange.Click();
                SkillExchange.SendKeys(ExcelLib.ReadData(row, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }

            //Click on Active/Hidden option
            ActiveOption.FindElement(By.XPath($"//input[@name='isActive'][@value='{active}']")).Click();

            //Click on Save button
            Save.Click();
        }

        internal void EditShareSkill()
        {

        }

        //Click on ShareSkill Button
        public void GoToShareSkillPage()
        {
            ShareSkillButton.Click();
        }
    }
}
