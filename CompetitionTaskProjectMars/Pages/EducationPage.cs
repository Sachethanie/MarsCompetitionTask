using CompetitionTaskProjectMars.Helpers;
using CompetitionTaskProjectMars.Models;
using OpenQA.Selenium;

namespace CompetitionTaskProjectMars.Pages
{
    public class EducationPage : Driver
    {
        private static IWebElement EducationTab => driver.FindElement(By.XPath("//a[@class='item' and text()='Education']"));
        private static IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@data-tab='third']//div[@class='ui teal button ' and text()='Add New']"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button ']"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//div[@data-tab='third']//input[@type='button' and @class='ui teal button']"));
        private static IWebElement UniversityName => driver.FindElement(By.XPath("//input[@type='text' and @name='instituteName']"));
        private static IWebElement CountryOfCollage => driver.FindElement(By.XPath("//select[@name='country']"));
        private static IWebElement Title => driver.FindElement(By.XPath("//select[@name='title']"));
        private static IWebElement Degree => driver.FindElement(By.XPath("//input[@type='text' and @name='degree']"));
        private static IWebElement YearOfGraduation => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//input[@type='button' and @class='ui button']"));

        public void NavigateToEductaionForm()
        {
            EducationTab.Click();
        }

        public void CleanUpDataBeforeTestStart()
        {
            int iRowsCount = driver.FindElements(By.XPath("//div[@data-tab='third']//table[@class='ui fixed table']/tbody/tr")).Count;
            for (int i = 0; i < iRowsCount; i++)
            {
                var deleteButtonNew = driver.FindElement(By.XPath($"//div[@data-tab='third']//i[contains(@class, 'remove icon')]"));
                deleteButtonNew.Click();
                Thread.Sleep(2000);
            }
        }

        public void CleanUpAddedEducationAfterTest(Education education)
        {                        
                var deletePencilIcon = GetDeletePencilIcon(education);

            deletePencilIcon?.Click();            
        }

        public void AssertionPopupMessage(string expectedMessage)
        {
            Thread.Sleep(1000);
            var toastMessageElement = driver.FindElements(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.First ().Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }
        
        public void ViewEducationInTable(Education education)
        {
            var educationRow = driver.FindElements(By.XPath($"//tr[td[text()='{education.UniversityName}'] and td[text()='{education.CountryOfCollage}'] and td[text()='{education.Degree}']]//i[contains(@class, 'outline write icon')]"));
            Assert.That(educationRow, Is.Not.Null, $"Education {education} was not found in the list");
        }

        public void CannotViewEducationInTable(Education education)
        {
            var educationRows = driver.FindElements(By.XPath($"//tr[td[text()='{education.UniversityName}'] and td[text()='{education.CountryOfCollage}'] and td[text()='{education.Degree}']]//i[contains(@class, 'outline write icon')]"));
            Assert.That(educationRows, Is.Empty, $"Education {education.UniversityName} was found in the list, but it should  not have been in the list.");
        }

        public static IWebElement GetEditPencilIcon(Education education)
        {
            //unique key - university name, country, degree, title  check the all value in the raw and get the pecil icon    
            return driver.FindElement(By.XPath($"//tr[td[text()='{education.UniversityName}'] and td[text()='{education.CountryOfCollage}'] and td[text()='{education.Degree}']]//i[contains(@class, 'outline write icon')]"));
        }

        public static IWebElement GetDeletePencilIcon(Education education)
        {
            //unique key - university name, country, degree, title  check the all value in the raw and get the pecil icon    
            return driver.FindElement(By.XPath($"//tr[td[text()='{education.UniversityName}'] and td[text()='{education.CountryOfCollage}'] and td[text()='{education.Degree}']]//i[contains(@class, 'remove icon')]"));
        }
        public void SuccessfullyAddEducationRecord(Education addEducation)
        {
            AddNewButton.Click();
            UniversityName.SendKeys(addEducation.UniversityName);
            CountryOfCollage.SendKeys(addEducation.CountryOfCollage);
            Title.SendKeys(addEducation.Title);
            Degree.SendKeys(addEducation.Degree);
            YearOfGraduation.SendKeys(addEducation.YearOfGraduation);
            AddButton.Click();
        }

        public void CannotBeAbleToAddEductionRecordWithoutAddingAllFields(Education mandetoryFieldValidation)
        {
            AddNewButton.Click();
            if (!string.IsNullOrEmpty(mandetoryFieldValidation.UniversityName))
            {
                UniversityName.SendKeys(mandetoryFieldValidation.UniversityName);
            }

            if (!string.IsNullOrEmpty(mandetoryFieldValidation.CountryOfCollage))
            {
                CountryOfCollage.SendKeys(mandetoryFieldValidation.CountryOfCollage);
            }

            if (!string.IsNullOrEmpty(mandetoryFieldValidation.Degree))
            {
                Degree.SendKeys(mandetoryFieldValidation.Degree);
            }

            if (!string.IsNullOrEmpty(mandetoryFieldValidation.Title))
            {
                Title.SendKeys(mandetoryFieldValidation.Title);
            }

            if (!string.IsNullOrEmpty(mandetoryFieldValidation.YearOfGraduation))
            {
                YearOfGraduation.SendKeys(mandetoryFieldValidation.YearOfGraduation);
            }
            AddButton.Click();
        }

        public void CannotBeAbleToAddExistingEducationRecordAsANewEducationRecord(Education addEducation)
        {
            AddNewButton.Click();
            UniversityName.SendKeys(addEducation.UniversityName);
            CountryOfCollage.SendKeys(addEducation.CountryOfCollage);
            Title.SendKeys(addEducation.Title);
            Degree.SendKeys(addEducation.Degree);
            YearOfGraduation.SendKeys(addEducation.YearOfGraduation);
            AddButton.Click();
            CancelButton.Click();
        } 

        public void SuccessfullyEditEducationRecord(Education addEducation, Education editEducation)
        {
            var editPencilIcon = GetEditPencilIcon(addEducation);
            editPencilIcon.Click();
            UniversityName.Clear();
            UniversityName.SendKeys(editEducation.UniversityName);
            CountryOfCollage.Click();
            CountryOfCollage.SendKeys(editEducation.CountryOfCollage);
            Title.Click();
            Title.SendKeys(editEducation.Title);
            Degree.Clear();
            Degree.SendKeys(editEducation.Degree);
            YearOfGraduation.Click();
            YearOfGraduation.SendKeys(editEducation.YearOfGraduation);
            UpdateButton.Click();
        }              

        public void CannotBeAbleToEditEducationToAnotherExistingEducationRecord(Education addEducation, Education editEducation)
        {
            var editPencilIcon = GetEditPencilIcon(addEducation);
            editPencilIcon.Click();
            UniversityName.Clear();
            UniversityName.SendKeys(editEducation.UniversityName);
            CountryOfCollage.Click();
            CountryOfCollage.SendKeys(editEducation.CountryOfCollage);
            Title.Click();
            Title.SendKeys(editEducation.Title);
            Degree.Clear();
            Degree.SendKeys(editEducation.Degree);
            YearOfGraduation.Click();
            YearOfGraduation.SendKeys(editEducation.YearOfGraduation);
            UpdateButton.Click();
            CancelButton.Click();
        }

        public void CannotBeAbleToAddInvalidEductionRecord(Education addEducation)
        {
            AddNewButton.Click();
            UniversityName.SendKeys(addEducation.UniversityName);
            CountryOfCollage.SendKeys(addEducation.CountryOfCollage);
            Title.SendKeys(addEducation.Title);
            Degree.SendKeys(addEducation.Degree);
            YearOfGraduation.SendKeys(addEducation.YearOfGraduation);
            AddButton.Click();
        }

        public void SuccessfullyDeleteEducationRecord(Education addEducation)
        {
            var deletePencilIcon = GetDeletePencilIcon(addEducation); 
            deletePencilIcon.Click();
        }
    }   
    
}
