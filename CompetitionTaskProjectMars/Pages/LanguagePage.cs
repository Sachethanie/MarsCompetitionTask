using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ProjectMars.Helpers;
using RazorEngine;
using ProjectMars.Models;

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


        public void CleaupAllLanguageDataBeforeStartTest()
        {
            int iRowsCount = driver.FindElements(By.XPath("//div[@data-tab='first']//table[@class='ui fixed table']/tbody/tr")).Count;
            for (int i = 0; i < iRowsCount; i++)
            {
                var deleteButtonNew = driver.FindElement(By.XPath($"//div[@data-tab='first']//i[contains(@class, 'remove icon')]"));
                deleteButtonNew.Click();
                Thread.Sleep(2000);
            }
        }
        public static IWebElement GetEditPencilIcon(Languages language)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{language.Language}']]//i[contains(@class, 'outline write icon')]"));
        }

        public static IWebElement GetDeletePencilIcon(Languages language)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{language.Language}']]//i[contains(@class, 'remove icon')]"));
        }

        public void SuccessfullyClickCancelButton()
        {

            CancelButton.Click();
        }

        public void SuccessfullyAddNewLanguage(Languages addLanguage)
        {
            AddNewButton.Click();
            AddLanguage.SendKeys(addLanguage.Language);
            SelectElement dropdown = new SelectElement(AddLanguageLevel);
            dropdown.SelectByText(addLanguage.Level);
            AddButton.Click();
        }

        public void ViewLanguageInTable(Languages language)
        {
            var languageRow = driver.FindElements(By.XPath($"//tr[td[text()='{language.Language}'] and td[text()='{language.Level}']]"));
            Assert.That(languageRow, Is.Not.Null, "$Language {language}, level {level} was not found in the list");
        }

        public void CannotViewLanguageInTable(Languages language)
        {
            var languageRows = driver.FindElements(By.XPath($"//tr[td[text()='{language.Language}']]"));
            Assert.That(languageRows, Is.Empty, $"Language {language.Language} was found in the list, but it should  not have been in the list.");
        }

        public void AssertionPopupMessage(string expectedMessage)
        {
            Thread.Sleep(1000);
            var toastMessageElement = driver.FindElements(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.First().Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(Languages mandetoryFieldValidation)
        {
            AddNewButton.Click();
            AddLanguage.SendKeys(mandetoryFieldValidation.Language);
            AddButton.Click();
        }

        public void CannotBeAbleToAddExistingLanguageRecordAsANewLanguageRecord(Languages addLanguage)
        {
            AddNewButton.Click();
            AddLanguage.SendKeys(addLanguage.Language);
            SelectElement dropdown = new SelectElement(AddLanguageLevel);
            dropdown.SelectByText(addLanguage.Level);
            AddButton.Click();
            CancelButton.Click();
        }

        public void SuccessfullyEditExistingLanguageAndLanguageLevel(Languages addLanguage, Languages editLanguage)
        {

            var editPencilIcon = GetEditPencilIcon(addLanguage);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(editLanguage.Language);
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(editLanguage.Level);
            AddLanguageLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void SuccessfullyEditOneValueOfLanguage(Languages addLanguage, Languages editLanguage)
        {

            var editPencilIcon = GetEditPencilIcon(addLanguage);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(editLanguage.Language);
            UpdateButton.Click();
        }        

        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(Languages addLanguage, Languages editLanguage)
        {

            var editPencilIcon = GetEditPencilIcon(addLanguage);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(editLanguage.Language);
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(editLanguage.Level);
            AddLanguageLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
            CancelButton.Click();
        }

        public void CannotBeAbleToAddInvalidLanguage(Languages addLanguage)
        {
            AddNewButton.Click();
            AddLanguage.SendKeys(addLanguage.Language);
            SelectElement dropdown = new SelectElement(AddLanguageLevel);
            dropdown.SelectByText(addLanguage.Level);
            AddButton.Click();
        }

        public void SuccessfullydeleteExistingLanguage(Languages language)
        {
            var deletePencilIcon = GetDeletePencilIcon(language);
            deletePencilIcon.Click();
        }

        public void CleanUpAddedLanguageAfterTest(Languages language)
        {
            var deletePencilIcon = GetDeletePencilIcon(language);

            deletePencilIcon?.Click();
        }

        //public void WhenIAddLanguagesUntilICannotAddMore()
        //{
        //    bool canAddMore = true;
        //    int maxLanguagesToTry = MaxNumberofLanguagesToBeAdded;


        //    for (int i = 0; i < maxLanguagesToTry && canAddMore; i++)
        //    {
        //        try
        //        {
        //            if (AddNewButton == null)
        //            {
        //                break;
        //            }

        //            var language = $"laguage{i}";
        //            SuccessfullyAddNewLanguage(language, "Basic");

        //            System.Threading.Thread.Sleep(500);

        //            // Check if the language was added (e.g., by checking if it appears in a list)
        //            var addedLanguageElement = driver.FindElement(By.XPath($"//tr[td[text()='laguage{i}']]"));
        //            if (addedLanguageElement == null)
        //            {
        //                canAddMore = false;
        //            }
        //        }
        //        catch (NoSuchElementException)
        //        {
        //            canAddMore = false;
        //        }
        //    }
        //}

        //public void SeeTheMaximumNumberOfLanguagesAdded()
        //{
        //    int iRowsCount = driver.FindElements(By.XPath("//div[@data-tab='first']//table[@class='ui fixed table']/tbody/tr")).Count;
        //    Assert.That(iRowsCount, Is.EqualTo(MaxNumberofLanguagesToBeAdded), $"Expected to add a maximum of {MaxNumberofLanguagesToBeAdded} languages, but added {iRowsCount}.");
        //}
    }
}
