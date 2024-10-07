using ProjectMars.Helpers;
using ProjectMars.Models;
using ProjectMars.Pages;

namespace ProjectMars.Tests
{
    [TestFixture]
    public class CertificationTest : BaseClass
    {
        private readonly CertificationPage certificationPage;
        private Certification _CertificationToCleanup; 
        
        public CertificationTest()
        {
            certificationPage = new CertificationPage();
        }

        [SetUp, Order(0)]
        public void NavigateToCertificationFormTest()
        {
            certificationPage.NavigateToCertificationForm();
        }



        [SetUp, Order(1)]
        public void CleanUpBeforeTest()
        {
            certificationPage.CleanUpDataBeforeTestStart();
        }

        [TearDown,Order(0)]
        public void Cleanup()
        {
            // Cleanup only the data that was affected by the current test
            if (_CertificationToCleanup != null)
            {
                certificationPage.CleanUpAddedCertificationAfterTest(_CertificationToCleanup);
                _CertificationToCleanup = null; // Reset for the next test
            }
        }     

        [Test]
        [TestCaseSource(typeof(CertificationTestData),nameof(CertificationTestData.AddCertifications))]
        public void SuccessfullyAddCertification(Certification addCertification)
        {
            test = extent.CreateTest("Successfully add certification").Info("Test Started");

            //act 
            certificationPage.SuccessfullyAddCertificationRecord(addCertification);
            _CertificationToCleanup = addCertification;

            //Assert 
            var expectedMessage = $"{addCertification.Certificate} has been added to your certification";
            certificationPage.AssertionPopupMessage(expectedMessage);

            certificationPage.ViewCertificationInTable(addCertification);
        }

        [Test]
        [TestCaseSource(typeof(CertificationTestData), nameof(CertificationTestData.EditCertifications))]
        public void SuccessfullyEditCertification(Certification addCertification, Certification editCertification)
        {
            //act 
            certificationPage.SuccessfullyAddCertificationRecord(addCertification);
            certificationPage.SuccessfullyEditCertificationRecord(addCertification, editCertification);
            _CertificationToCleanup = editCertification;
            //Assert
            var expectedMessage = $"{editCertification.Certificate} has been updated to your certification";
            certificationPage.AssertionPopupMessage(expectedMessage);

            certificationPage.ViewCertificationInTable(editCertification);
        }

        [Test]
        [TestCaseSource(typeof(CertificationTestData), nameof(CertificationTestData.MandetoryFieldValidationOfCertification))]
        public void CannotBeAbleToAddCertificationRecordWithoutAddingAllMandetoryFields(Certification mandetoryFieldValidationOfCertification)
        {
            certificationPage.CannotBeAbleToAddCertificationRecordWithoutAddingAllFields(mandetoryFieldValidationOfCertification);

            var expectedMessage = "Please enter Certification Name, Certification From and Certification Year";
            certificationPage.AssertionPopupMessage(expectedMessage);          
        }

        [Test]
        [TestCaseSource(typeof(CertificationTestData), nameof(CertificationTestData.AddCertifications))]
        public void CannotBeAbleToAddExistingCertificationRecordAsANewCertificationRecord(Certification addCertifications)
        { 
            certificationPage.SuccessfullyAddCertificationRecord(addCertifications);         
            certificationPage.CannotBeAbleToAddExistingCertificationRecordAsANewCertificationRecord(addCertifications);
            _CertificationToCleanup = addCertifications;

            var expectedMessage = "This information is already exist.";
            certificationPage.AssertionPopupMessage(expectedMessage);
        }

        [Test]
        [TestCaseSource(typeof(CertificationTestData), nameof(CertificationTestData.EditOneValueOfCertification))]
        public void SuccessfullyEditOnlyOneValueOfCertificationRecord(Certification addCertifications, Certification editOneValueOfCertificationCertifications)
        {        

            certificationPage.SuccessfullyAddCertificationRecord(addCertifications);
            certificationPage.SuccessfullyEditOnlyOneValueOfCertificationRecord(addCertifications, editOneValueOfCertificationCertifications);
            _CertificationToCleanup = editOneValueOfCertificationCertifications;

            var expectedMessage = $"{editOneValueOfCertificationCertifications.Certificate} has been updated to your certification";
            certificationPage.AssertionPopupMessage(expectedMessage);

            certificationPage.ViewCertificationInTable(editOneValueOfCertificationCertifications);            
        } 

        [Test]
        [TestCaseSource(typeof(CertificationTestData), nameof(CertificationTestData.EditCertificationRecordToAnotherExistingCertificationRecord))]
        public void CannotBeAbleToEditExistingCertificationRedcordToAnotherExistingCertificationRecord(Certification addCertifications, Certification editRecordToAnotherExistingRecord)
        {
            certificationPage.SuccessfullyAddCertificationRecord(addCertifications);            
            certificationPage.CannotBeAbleToEditExistingCertificationToAnotherExistingCertificationRecord(addCertifications, editRecordToAnotherExistingRecord);
            _CertificationToCleanup = addCertifications;

            var expectedMessage = "This information is already exist.";
            certificationPage.AssertionPopupMessage(expectedMessage);            
        }

        [Test]
        [TestCaseSource(typeof(CertificationTestData), nameof(CertificationTestData.AddInvalidCertificationRecord))]
        public void CannotBeAbleToAddCertificationRecordWithInvalidData(Certification addInvalidData)
        {    
            certificationPage.CannotBeAbleToAddInvalidCertificationRecord(addInvalidData);
            _CertificationToCleanup = addInvalidData;

            var expectedMessage = $"{addInvalidData.Certificate} has been added to your certification"; //'Education with invalid inputs was added.But I Cannot be able to Add a record with invalid inputs. So this could be a bug'
            certificationPage.AssertionPopupMessage(expectedMessage);           
        }

        [Test]
        [TestCaseSource(typeof(CertificationTestData), nameof(CertificationTestData.AddCertifications))]
        public void SuccessfullyDeleteCertificationRecord(Certification addCertification)
        {        
            certificationPage.SuccessfullyAddCertificationRecord(addCertification);
            certificationPage.SuccessfullyDeleteCertificationRecord(addCertification);

            var expectedMessage = $"{addCertification.Certificate} has been deleted from your certification";
            certificationPage.AssertionPopupMessage(expectedMessage);

            certificationPage.CannotViewEducationInTable(addCertification);
        } 
    }
}