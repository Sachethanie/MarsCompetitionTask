using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ProjectMars.Helpers;

namespace ProjectMars.Pages
{
    public class LanguagePage : Driver
    {
        private static IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@class='ui teal button '][text()='Add New']"));
        private static IWebElement AddLanguage => driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Language']"));
        private static IWebElement AddLanguageLevel => driver.FindElement(By.XPath("//select [@class='ui dropdown' and @name='level']"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//input[@class='ui button' and @value='Cancel']"));

        private const int MaxNumberofLanguagesToBeAdded = 4;


        public static void CleaupAllLanguageDataBeforeStartTest()
        {
            int iRowsCount = driver.FindElements(By.XPath("//div[@data-tab='first']//table[@class='ui fixed table']/tbody/tr")).Count;
            for (int i = 0; i < iRowsCount; i++)
            {
                var deleteButtonNew = driver.FindElement(By.XPath($"//div[@data-tab='first']//i[contains(@class, 'remove icon')]"));
                deleteButtonNew.Click();
                Thread.Sleep(2000);
            }
        }
        public static IWebElement GetEditPencilIcon(string language)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{language}']]//i[contains(@class, 'outline write icon')]"));
        }

        public static IWebElement GetDeletePencilIcon(string language)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{language}']]//i[contains(@class, 'remove icon')]"));
        }

        public void SuccessfullyClickCancelButton()
        {

            CancelButton.Click();
        }

        public void SuccessfullyAddNewLanguage(string newLanguage, string newLevel)
        {
            AddNewButton.Click();
            AddLanguage.SendKeys(newLanguage);
            SelectElement dropdown = new SelectElement(AddLanguageLevel);
            dropdown.SelectByText(newLevel);
            AddButton.Click();
        }

        public void ViewLanguageInTable(string newLanguage, string newLevel)
        {
            var languageRow = driver.FindElements(By.XPath($"//tr[td[text()='{newLanguage}'] and td[text()='{newLevel}']]"));
            Assert.That(languageRow, Is.Not.Null, "$Language {language}, level {level} was not found in the list");
        }

        public void CannotViewLanguageInTable(string language)
        {
            var languageRows = driver.FindElements(By.XPath($"//tr[td[text()='{language}']]"));
            Assert.That(languageRows, Is.Empty, $"Language {language} was found in the list, but it should  not have been in the list.");
        }

        public void AssertionPopupMessage(string expectedMessage)
        {
            Thread.Sleep(1000);
            var toastMessageElement = driver.FindElements(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.First().Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(string newLanguage)
        {
            AddNewButton.Click();
            AddLanguage.SendKeys(newLanguage);
            AddButton.Click();
        }

        public void SuccessfullyEditExistingLanguageAndLanguageLevel(string language, string level, string newLanguage, string newLevel)
        {

            var editPencilIcon = GetEditPencilIcon(language);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(newLanguage);
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(newLevel);
            AddLanguageLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(string language, string newLanguage)
        {

            var editPencilIcon = GetEditPencilIcon(language);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(newLanguage);
            UpdateButton.Click();
        }

        public void SuccsfullyEditLanguageLevelWithoutEditLanguage(string language, string level, string newLevel)
        {

            var editPencilIcon = GetEditPencilIcon(language);
            editPencilIcon.Click();
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(newLevel);
            AddLanguageLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(string language, string languageLevel, string newLanguage, string newLevel)
        {

            var editPencilIcon = GetEditPencilIcon(language);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(newLanguage);
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(newLevel);
            AddLanguageLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void SuccessfullydeleteExistingLanguage(string language)
        {
            var deletePencilIcon = GetDeletePencilIcon(language);
            deletePencilIcon.Click();
        }

        public static void CleanUpExistingLanguage(string language)
        {
            var deletePencilIcon = GetDeletePencilIcon(language);

            deletePencilIcon?.Click();
        }

        public void WhenIAddLanguagesUntilICannotAddMore()
        {
            bool canAddMore = true;
            int maxLanguagesToTry = MaxNumberofLanguagesToBeAdded;


            for (int i = 0; i < maxLanguagesToTry && canAddMore; i++)
            {
                try
                {
                    if (AddNewButton == null)
                    {
                        break;
                    }

                    var language = $"laguage{i}";
                    SuccessfullyAddNewLanguage(language, "Basic");

                    System.Threading.Thread.Sleep(500);

                    // Check if the language was added (e.g., by checking if it appears in a list)
                    var addedLanguageElement = driver.FindElement(By.XPath($"//tr[td[text()='laguage{i}']]"));
                    if (addedLanguageElement == null)
                    {
                        canAddMore = false;
                    }
                }
                catch (NoSuchElementException)
                {
                    canAddMore = false;
                }
            }
        }

        public void SeeTheMaximumNumberOfLanguagesAdded()
        {
            int iRowsCount = driver.FindElements(By.XPath("//div[@data-tab='first']//table[@class='ui fixed table']/tbody/tr")).Count;
            Assert.That(iRowsCount, Is.EqualTo(MaxNumberofLanguagesToBeAdded), $"Expected to add a maximum of {MaxNumberofLanguagesToBeAdded} languages, but added {iRowsCount}.");
        }
    }
}
