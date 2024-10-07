using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ProjectMars.Helpers;
using ProjectMars.Models;

namespace ProjectMars.Pages
{
    public class SkillPage : Driver
    {
        private static IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@class='ui teal button'][text()='Add New']"));
        private static IWebElement AddSkill => driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Skill']"));
        private static IWebElement AddSkillLevel => driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='level']"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//input[@type='button'and @class='ui teal button ']"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//input[@class='ui button' and @value='Cancel']"));
        public void NavigateToSkillForm()
        {
            IWebElement skillTab = driver.FindElement(By.XPath("//a[@class='item' and text()='Skills']"));
            skillTab.Click();
        }
        public void CleaupAllSkillDataBeforeStartTest()
        {

            var deleteButtons = driver.FindElements(By.XPath($"//div[@data-tab='second']//i[contains(@class, 'remove icon')]"));
            foreach (var deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void SuccessfullyClickCancelButton()
        {

            CancelButton.Click();
        }


        public static IWebElement GetEditPencilIcon(Skills addSkill)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{addSkill.Skill}']]//i[contains(@class, 'outline write icon')]"));
        }

        public static IWebElement GetDeletePencilIcon(Skills addSkill)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{addSkill.Skill}']]//i[contains(@class, 'remove icon')]"));
        }

        public void ViewSkillInTable(Skills addSkill)
        {
            var skillRow = driver.FindElements(By.XPath($"//tr[td[text()='{addSkill.Skill}'] and td[text()='{addSkill.Level}']]"));
            Assert.That(skillRow, Is.Not.Null, "skill {skill}, level {level} was not found in the list");
        }

        public void CannotViewSkillInTable(Skills addSkill)
        {
            var skillRow = driver.FindElements(By.XPath($"//tr[td[text()='{addSkill.Skill}']]"));
            Assert.That(skillRow, Is.Empty, $"skill {addSkill.Skill} was found in the list, but it should have been deleted.");
        }

        public void AssertionPopupMessage(string expectedMessage)
        {
            Thread.Sleep(1000);
            var toastMessageElement = driver.FindElements(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.First().Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void SuccessfullyAddNewSkill(Skills addSkill)
        {

            AddNewButton.Click();
            AddSkill.SendKeys(addSkill.Skill);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            dropdown.SelectByText(addSkill.Level);
            AddButton.Click();
        }

        public void CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(Skills addSkill)
        {
            AddNewButton.Click();
            AddSkill.SendKeys(addSkill.Skill);
            AddButton.Click();
        }

        public void CannotBeAbleToAddExistingSkillRecordAsANewSkillRecord(Skills addSkill)
        {
            AddNewButton.Click();
            AddSkill.SendKeys(addSkill.Skill);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            dropdown.SelectByText(addSkill.Level);
            AddButton.Click();
            CancelButton.Click();
        }

        public void SuccessfullyEditExistingSkillAndSkillLevel(Skills addSkill, Skills editSkill)
        {
            var editPencilIcon = GetEditPencilIcon(addSkill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(editSkill.Skill);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(editSkill.Level);
            AddSkillLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }
       
        public void CannotBeAbleToEditExistngSkillAndSkillLevelToAnotherExistingSkill(Skills addSkill, Skills editSkill)
        {
            var editPencilIcon = GetEditPencilIcon(addSkill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(addSkill.Skill);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(addSkill.Level);
            AddSkillLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
            CancelButton.Click();
        }

        public void SuccesffullydeleteExistingSkill(Skills addSkill)
        {
            var deletePencilIcon = GetDeletePencilIcon(addSkill);
            deletePencilIcon.Click();

        }
        public void CleanUpAddedSkillAfterTest(Skills addSkill)
        {
            Thread.Sleep(3000);
            var deletePencilIcon = GetDeletePencilIcon(addSkill);

            deletePencilIcon?.Click();
        }

    }
}
