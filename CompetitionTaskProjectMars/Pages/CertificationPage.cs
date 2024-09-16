using CompetitionTaskProjectMars.Helpers;
using CompetitionTaskProjectMars.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CompetitionTaskProjectMars.Pages
{
    public class CertificationPage : Driver
    {
        private static IWebElement CertificationTab => driver.FindElement(By.XPath("//a[@class='item' and text()='Certifications']"));
        private static IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']//div[@class='ui teal button ' and text()='Add New']"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@type='button' and @class='ui teal button ']"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']//input[@type='button' and @class='ui teal button']"));
        private static IWebElement Certificate => driver.FindElement(By.XPath("//input[@type='text' and @name='certificationName']"));
        private static IWebElement CertifiedFrom => driver.FindElement(By.XPath("//input[@class='received-from capitalize' and @name='certificationFrom']"));
        private static IWebElement Year => driver.FindElement(By.XPath("//select[@name='certificationYear']"));
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//input[@type='button' and @class='ui button']"));

        public void NavigateToCertificationForm()
        {
            CertificationTab.Click();
        }

        public void CleanUpDataBeforeTestStart()
        {
            int iRowsCount = driver.FindElements(By.XPath("//div[@data-tab='fourth']//table[@class='ui fixed table']/tbody/tr")).Count;
            for (int i = 0; i < iRowsCount; i++)
            {
                var deleteButtonNew = driver.FindElement(By.XPath($"//div[@data-tab='fourth']//i[contains(@class, 'remove icon')]"));
                deleteButtonNew.Click();
                Thread.Sleep(2000);
            }
        }

        public void CleanUpAddedCertificationAfterTest(Certification certification)
        {
            var deletePencilIcon = GetDeletePencilIcon(certification);
            
            deletePencilIcon?.Click();
        }

        public void AssertionPopupMessage(string expectedMessage)
        {
            Thread.Sleep(1000);
            var toastMessageElement = driver.FindElements(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.First().Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void ViewCertificationInTable(Certification certification)
        {
            var certificationRows = driver.FindElements(By.XPath($"//tr[td[text()='{certification.Certificate}'] and td[text()='{certification.CertifiedFrom}'] and td[text()='{certification.Year}']]//i[contains(@class, 'outline write icon')]"));
            Assert.That(certificationRows, Is.Not.Null, $"Education {certification} was not found in the list");
        }

        public void CannotViewEducationInTable(Certification certification)
        {
            var certificationRows = driver.FindElements(By.XPath($"//tr[td[text()='{certification.Certificate}'] and td[text()='{certification.CertifiedFrom}'] and td[text()='{certification.Year}']]//i[contains(@class, 'outline write icon')]"));
            Assert.That(certificationRows, Is.Empty, $"Education {certification.Certificate} was found in the list, but it should  not have been in the list.");
        }

        public static IWebElement GetEditPencilIcon(Certification certification)
        {
            //unique key - university name, country, degree, title  check the all value in the raw and get the pecil icon    
            return driver.FindElement(By.XPath($"//tr[td[text()='{certification.Certificate}'] and td[text()='{certification.CertifiedFrom}'] and td[text()='{certification.Year}']]//i[contains(@class, 'outline write icon')]"));
        }

        public static IWebElement GetDeletePencilIcon(Certification certification)
        {
            //
            By loadingImage = By.ClassName("ns-box");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingImage));

            //unique key - university name, country, degree, title  check the all value in the raw and get the pecil icon    
            return driver.FindElement(By.XPath($"//tr[td[text()='{certification.Certificate}'] and td[text()='{certification.CertifiedFrom}'] and td[text()='{certification.Year}']]//i[contains(@class, 'remove icon')]"));           

        }

        public void SuccessfullyAddCertificationRecord(Certification addCertification)
        {
            AddNewButton.Click();
            Certificate.SendKeys(addCertification.Certificate);
            CertifiedFrom.SendKeys(addCertification.CertifiedFrom);
            Year.SendKeys(addCertification.Year);
            AddButton.Click();

        }
        public void CannotBeAbleToAddCertificationRecordWithoutAddingAllFields(Certification mandetoryFieldValidation)
        {
            AddNewButton.Click();
            if (!string.IsNullOrEmpty(mandetoryFieldValidation.Certificate))
            {
                Certificate.SendKeys(mandetoryFieldValidation.Certificate);
            }

            if (!string.IsNullOrEmpty(mandetoryFieldValidation.CertifiedFrom))
            {
                CertifiedFrom.SendKeys(mandetoryFieldValidation.CertifiedFrom);
            }


            if (!string.IsNullOrEmpty(mandetoryFieldValidation.Year))
            {
                Year.SendKeys(mandetoryFieldValidation.Year);
            }

            AddButton.Click();
        }

        public void CannotBeAbleToAddExistingCertificationRecordAsANewCertificationRecord(Certification addCertification)
        {
            AddNewButton.Click();
            Certificate.SendKeys(addCertification.Certificate);
            CertifiedFrom.SendKeys(addCertification.CertifiedFrom);
            Year.SendKeys(addCertification.Year);
            AddButton.Click();
            CancelButton.Click();

        }
        public void SuccessfullyEditCertificationRecord(Certification addCertification, Certification editCertification)
        {
            var editPencilIcon = GetEditPencilIcon(addCertification);
            editPencilIcon.Click();
            Certificate.Clear();
            Certificate.SendKeys(editCertification.Certificate);
            CertifiedFrom.Clear();
            CertifiedFrom.SendKeys(editCertification.CertifiedFrom);
            Year.Click();
            Year.SendKeys(editCertification.Year);
            UpdateButton.Click();
        }

        public void SuccessfullyEditOnlyOneValueOfCertificationRecord(Certification addCertification, Certification editCertification)
        {
            var editPencilIcon = GetEditPencilIcon(addCertification);
            editPencilIcon.Click();
            Certificate.Clear();
            Certificate.SendKeys(editCertification.Certificate);
            UpdateButton.Click();
        }
        public void CannotBeAbleToEditExistingCertificationToAnotherExistingCertificationRecord(Certification addCertification, Certification editCertification)
        {
            var editPencilIcon = GetEditPencilIcon(addCertification);
            editPencilIcon.Click();
            Certificate.Clear();
            Certificate.SendKeys(editCertification.Certificate);
            CertifiedFrom.Clear();
            CertifiedFrom.SendKeys(editCertification.CertifiedFrom);
            Year.Click();
            Year.SendKeys(editCertification.Year);
            UpdateButton.Click();
            CancelButton.Click();
        }
        public void CannotBeAbleToAddInvalidCertificationRecord(Certification addCertification)
        {
            AddNewButton.Click();
            Certificate.SendKeys(addCertification.Certificate);
            CertifiedFrom.SendKeys(addCertification.CertifiedFrom);
            Year.SendKeys(addCertification.Year);
            AddButton.Click(); 
        }

        public void SuccessfullyDeleteCertificationRecord(Certification addCertification)
        {
            var deletePencilIcon = GetDeletePencilIcon(addCertification);
            deletePencilIcon.Click();
        }
    }
}

