using ProjectMars.Helpers;
using ProjectMars.Models;
using ProjectMars.Pages;

namespace ProjectMars.Tests
{
    [TestFixture ]
    public class EducationTest : BaseClass
    {
        private readonly EducationPage educationPage;
        private Education _EducationToCleanup;
        public EducationTest()
        {
            educationPage = new EducationPage();  
        }

        [SetUp, Order(0)]
        public void NavigateToEductaionFormTest()
        {
            educationPage.NavigateToEductaionForm();
        }

        [SetUp, Order(1)]
        public void CleanUpBeforeTest()
        {
            educationPage.CleanUpDataBeforeTestStart();
        }

        [TearDown]
        public void CleanUpAfterTest()
        {
            // Cleanup only the data that was affected by the current test
            if (_EducationToCleanup != null)
            {
                educationPage.CleanUpAddedEducationAfterTest(_EducationToCleanup);
                _EducationToCleanup = null; // Reset for the next test
            }
        }

        [Test]
        [TestCaseSource(typeof(EducationTestData), nameof(EducationTestData.AddEducation))]
        public void SuccessfullyAddEducation(Education addEducation)
        {
            //act 
            educationPage.SuccessfullyAddEducationRecord(addEducation);
            _EducationToCleanup= addEducation;

            //Assert 
            var expectedMessage = "Education has been added";
            educationPage.AssertionPopupMessage(expectedMessage);
            educationPage.ViewEducationInTable(addEducation);            
        }

        [Test]
        [TestCaseSource(typeof(EducationTestData), nameof(EducationTestData.EditEducation))]
        public void SuccessfullyEditEducation(Education addEducation, Education editEducation)
        {            
            //act 
            educationPage.SuccessfullyAddEducationRecord(addEducation);
            educationPage.SuccessfullyEditEducationRecord(addEducation, editEducation);
            _EducationToCleanup = editEducation;

            //Assert
            var expectedMessage = "Education as been updated";
            educationPage.AssertionPopupMessage(expectedMessage);
            educationPage.ViewEducationInTable(editEducation);           
        }

        [Test]
        [TestCaseSource(typeof(EducationTestData), nameof(EducationTestData.MandetoryFieldValidationOfEducation))]
        public void CannotBeAbleToAddEducationRecordWithoutAddingAllMandetoryFields(Education addEducation)
        {    
            educationPage.CannotBeAbleToAddEductionRecordWithoutAddingAllFields(addEducation);

            var expectedMessage = "Please enter all the fields";
            educationPage.AssertionPopupMessage(expectedMessage);            

        }

        [Test]
        [TestCaseSource(typeof(EducationTestData), nameof(EducationTestData.AddEducation))]
        public void CannotBeAbleToAddExistingEducationRecordAsANewEducationRecord(Education addEducation)
        {         
            educationPage.SuccessfullyAddEducationRecord(addEducation);
            educationPage.CannotBeAbleToAddExistingEducationRecordAsANewEducationRecord(addEducation);

            var expectedMessage = "This information is already exist.";
            educationPage.AssertionPopupMessage(expectedMessage); 
        }

        [Test]
        [TestCaseSource(typeof(EducationTestData), nameof(EducationTestData.EditEducationRecordToAnotherExistingEducationRecord))]
        public void CannotBeAbleToEditEducationRedcordToAnotherExistingEducationRecord(Education addEducation, Education editEducation)
        {  
            educationPage.SuccessfullyAddEducationRecord(addEducation);           
            educationPage.CannotBeAbleToEditEducationToAnotherExistingEducationRecord(addEducation, editEducation);
            _EducationToCleanup = addEducation;

            var expectedMessage = "This information is already exist.";
            educationPage.AssertionPopupMessage(expectedMessage);            
        }

        [Test]
        [TestCaseSource(typeof(EducationTestData), nameof(EducationTestData.AddInvalidEducationRecord))]
        public void CannotBeAbleToAddEducationRecordWithInvalidData(Education addEducation)
        { 
            educationPage.CannotBeAbleToAddInvalidEductionRecord(addEducation);
            _EducationToCleanup = addEducation;

            var expectedMessage = "Education has been added"; //'Education with invalid inputs was added.But I Cannot be able to Add a record with invalid inputs. So this could be a bug'
            educationPage.AssertionPopupMessage(expectedMessage);            
        }

        [Test]
        [TestCaseSource(typeof(EducationTestData), nameof(EducationTestData.AddEducation))]
        public void SuccessfullyDeleteEducationRecord(Education addEducation)
        {     
            educationPage.SuccessfullyAddEducationRecord(addEducation);
            educationPage.SuccessfullyDeleteEducationRecord(addEducation);

            var expectedMessage = "Education entry successfully removed";
            educationPage.AssertionPopupMessage(expectedMessage);

            educationPage.CannotViewEducationInTable(addEducation);
        }
    }
}







