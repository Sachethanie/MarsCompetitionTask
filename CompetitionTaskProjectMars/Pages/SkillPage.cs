using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ProjectMars.Helpers;

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
        public static void NavigateToSkillForm()
        {
            IWebElement skillTab = driver.FindElement(By.XPath("//a[@class='item' and text()='Skills']"));
            skillTab.Click();
        }
        public static void CleaupAllSkillDataBeforeStartTest()
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


        public static IWebElement GetEditPencilIcon(string skill)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{skill}']]//i[contains(@class, 'outline write icon')]"));
        }

        public static IWebElement GetDeletePencilIcon(string skill)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{skill}']]//i[contains(@class, 'remove icon')]"));
        }

        public void ViewSkillInTable(string skill, string level)
        {
            var skillRow = driver.FindElements(By.XPath($"//tr[td[text()='{skill}'] and td[text()='{level}']]"));
            Assert.That(skillRow, Is.Not.Null, "skill {skill}, level {level} was not found in the list");
        }

        public void CannotViewSkillInTable(string skill)
        {
            var skillRow = driver.FindElements(By.XPath($"//tr[td[text()='{skill}']]"));
            Assert.That(skillRow, Is.Empty, $"skill {skill} was found in the list, but it should have been deleted.");
        }

        public void AssertionPopupMessage(string expectedMessage)
        {
            Thread.Sleep(1000);
            var toastMessageElement = driver.FindElements(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.First().Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void SuccessfullyAddNewSkill(string skill, string level)
        {

            AddNewButton.Click();
            AddSkill.SendKeys(skill);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            dropdown.SelectByText(level);
            AddButton.Click();
        }

        public void CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(string newSkill)
        {
            AddNewButton.Click();
            AddSkill.SendKeys(newSkill);
            AddButton.Click();
        }

        public void SuccessfullyEditExistingSkillAndSkillLevel(string skill, string level, string newSkill, string newLevel)
        {
            var editPencilIcon = GetEditPencilIcon(skill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(newSkill);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(newLevel);
            AddSkillLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel(string skill, string newSkill)
        {
            var editPencilIcon = GetEditPencilIcon(skill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(newSkill);
            UpdateButton.Click();
        }

        public void SuccsfullyEditSkillLevelWithoutEditSkill(string skill, string level, string newLevel)
        {
            var editPencilIcon = GetEditPencilIcon(skill);
            editPencilIcon.Click();
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(newLevel);
            AddSkillLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void CannotBeAbleToEditExistngSkillAndSkillLevelToAnotherExistingSkill(string skill, string level, string newSkill, string newLevel)
        {
            var editPencilIcon = GetEditPencilIcon(skill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(newSkill);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(newLevel);
            AddSkillLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void SuccesffullydeleteExistingSkill(string skill)
        {
            var deletePencilIcon = GetDeletePencilIcon(skill);
            deletePencilIcon.Click();

        }
        public static void CleanUpExistingSkill(string skill)
        {
            Thread.Sleep(3000);
            var deletePencilIcon = GetDeletePencilIcon(skill);

            deletePencilIcon?.Click();
        }

    }
}
