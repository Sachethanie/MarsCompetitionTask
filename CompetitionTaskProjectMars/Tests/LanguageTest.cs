using ProjectMars.Helpers;
using ProjectMars.Models;
using ProjectMars.Pages;

namespace ProjectMars.Tests
{
    [TestFixture]
    public class LanguageTest : BaseClass
    {
        private readonly LanguagePage languagePage;
        private Languages _LanguageToCleanup;

        public LanguageTest()
        {
            languagePage = new LanguagePage();
        }

        [SetUp]
        public void CleanUpBeforeTestStarts()
        {
            languagePage.CleaupAllLanguageDataBeforeStartTest();
        }

        [TearDown]
        public void Cleanup()
        {
            // Cleanup only the data that was affected by the current test
            if (_LanguageToCleanup != null)
            {
                languagePage.CleanUpAddedLanguageAfterTest(_LanguageToCleanup);
                _LanguageToCleanup = null; // Reset for the next test
            }
        }

        [Test]
        [TestCaseSource(typeof(LanguageTestData), nameof(LanguageTestData.AddLanguage))]
        public void SuccessfullyAddNewLanguage(Languages addLanguage)
        {
            test = extent.CreateTest("Successfully Add Language").Info("Test Started");

            //act
            languagePage.SuccessfullyAddNewLanguage(addLanguage);
            _LanguageToCleanup = addLanguage;

            //Assert
            var expectedMessage = $"{addLanguage.Language} has been added to your languages";
            languagePage.AssertionPopupMessage(expectedMessage);

            languagePage.ViewLanguageInTable(addLanguage);
        }

        [Test]
        [TestCaseSource(typeof(LanguageTestData), nameof(LanguageTestData.EditLanguage))]
        public void SuccessfullyEditLanguage(Languages addLanguage, Languages editLanguage)
        {
            test = extent.CreateTest("Successfully Edit Language").Info("Test Started");

            //act
            languagePage.SuccessfullyAddNewLanguage(addLanguage);
            languagePage.SuccessfullyEditExistingLanguageAndLanguageLevel(addLanguage, editLanguage);
            _LanguageToCleanup = editLanguage;

            var expectedMessage = $"{editLanguage.Language} has been updated to your languages";
            languagePage.AssertionPopupMessage(expectedMessage);

            languagePage.ViewLanguageInTable(editLanguage);

        }

        [Test]
        [TestCaseSource(typeof(LanguageTestData), nameof(LanguageTestData.MandetoryFieldValidationOfLanguage))]
        public void MandetoryFieldValidation(Languages addLanguage)
        {
            test = extent.CreateTest("Mandetory Field Validation").Info("Test Started");

            //act
            languagePage.CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(addLanguage);


            //Assert
            var expectedMessage = "Please enter language and level";
            languagePage.AssertionPopupMessage(expectedMessage);


        }

        [Test]
        [TestCaseSource(typeof(LanguageTestData), nameof(LanguageTestData.AddLanguage))]
        public void CannotBeAbleToAddExistingLanguageAsANewLanguage(Languages addLanguage)
        {
            test = extent.CreateTest("Cannot Be Able To Add Existing Language As A New Language").Info("Test Started");

            //act
            languagePage.SuccessfullyAddNewLanguage(addLanguage);
            languagePage.CannotBeAbleToAddExistingLanguageRecordAsANewLanguageRecord(addLanguage);
            _LanguageToCleanup = addLanguage;

            var expectedMessage = "This language is already exist in your language list.";
            languagePage.AssertionPopupMessage(expectedMessage);

        }

        [Test]
        [TestCaseSource(typeof(LanguageTestData), nameof(LanguageTestData.EditLanguageRecordToAnotherExistingLanguageRecord))]
        public void CannotBeAbleToEditLanguageRecordToAnotherExistingLanguageRecord(Languages addLanguage, Languages editLanguage)
        {
            test = extent.CreateTest("Cannot Be Able To Edit Language Record To Another Existing Language Record").Info("Test Started");

            //act
            languagePage.SuccessfullyAddNewLanguage(addLanguage);
            languagePage.CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(addLanguage, editLanguage);
            _LanguageToCleanup = addLanguage;

            var expectedMessage = "This language is already added to your language list.";
            languagePage.AssertionPopupMessage(expectedMessage);
        }


        [Test]
        [TestCaseSource(typeof(LanguageTestData), nameof(LanguageTestData.AddInvalidLanguageRecord))]
        public void AddInvalidLanguageRecord(Languages addLanguage)
        {
            test = extent.CreateTest("CannotBeAbleToEditLanguageRecordToAnotherExistingLanguageRecord").Info("Test Started");

            //act 
            languagePage.CannotBeAbleToAddInvalidLanguage(addLanguage);
            _LanguageToCleanup = addLanguage;

            var expectedMessage = $"{addLanguage.Language} has been added to your languages"; //// But In this Systemitallows to add invalidlanguages
            _LanguageToCleanup = addLanguage;
            languagePage.AssertionPopupMessage(expectedMessage);

            languagePage.ViewLanguageInTable(addLanguage);
        }

        [Test]
        [TestCaseSource(typeof(LanguageTestData), nameof(LanguageTestData.AddLanguage))]
        public void SuccessfullyDeleteAddedLanguage(Languages addLanguage)
        {
            test = extent.CreateTest("Successfully Delete Added Language").Info("Test Started");

            //act
            languagePage.SuccessfullyAddNewLanguage(addLanguage);
            languagePage.SuccessfullydeleteExistingLanguage(addLanguage);
            

            //Assert
            var expectedMessage = $"{addLanguage.Language} has been deleted from your languages";
            languagePage.AssertionPopupMessage(expectedMessage);

            languagePage.CannotViewLanguageInTable(addLanguage);
        }
    }

}
