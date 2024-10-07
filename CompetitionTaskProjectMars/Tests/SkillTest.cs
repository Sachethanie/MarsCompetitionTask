using ProjectMars.Helpers;
using ProjectMars.Models;
using ProjectMars.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Tests
{
    [TestFixture]
    public class SkillTest : BaseClass
    {
        private readonly SkillPage skillPage;
        private Skills _SkillToCleanup;

        public SkillTest()
        {
            skillPage = new SkillPage();
        }

        [SetUp, Order(0)]
        public void navigateToSkillFormTest()
        {
            skillPage.NavigateToSkillForm();
        }

        [SetUp, Order(1)]
        public void CleanUpBeforeTestStarts()
        {
            skillPage.CleaupAllSkillDataBeforeStartTest();
        }

        [TearDown]
        public void Cleanup()
        {
            // Cleanup only the data that was affected by the current test
            if (_SkillToCleanup != null)
            {
                skillPage.CleanUpAddedSkillAfterTest(_SkillToCleanup);
                _SkillToCleanup = null; // Reset for the next test
            }
        }

        [Test]
        [TestCaseSource(typeof(SkillTestData), nameof(SkillTestData.AddSkill))]
        public void SuccessfullyAddSkill(Skills addSkill)
        {
            //act 
            skillPage.SuccessfullyAddNewSkill(addSkill);
            _SkillToCleanup = addSkill;

            //Assert 
            var expectedMessage = $"{addSkill.Skill} has been added to your skills";
            skillPage.AssertionPopupMessage(expectedMessage);
            skillPage.ViewSkillInTable(addSkill);
        }

        [Test]
        [TestCaseSource(typeof(SkillTestData), nameof(SkillTestData.EditSkill))]
        public void SuccessfullyEditSkill(Skills addSkill, Skills editSkill)
        {
            //act 
            skillPage.SuccessfullyAddNewSkill(addSkill);
            skillPage.SuccessfullyEditExistingSkillAndSkillLevel(addSkill, editSkill);
            _SkillToCleanup = editSkill;

            //Assert 
            var expectedMessage = $"{editSkill.Skill} has been updated to your skills";
            skillPage.AssertionPopupMessage(expectedMessage);
            skillPage.ViewSkillInTable(editSkill);
        }

        [Test]
        [TestCaseSource(typeof(SkillTestData), nameof(SkillTestData.MandetoryFieldValidationOfSkill))]
        public void MandetoryFieldsValidation(Skills addSkill)
        {
            //act 
            skillPage.CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(addSkill);
           

            //Assert 
            var expectedMessage = "Please enter skill and experience level";
            skillPage.AssertionPopupMessage(expectedMessage);           
        }

       
        [Test]
        [TestCaseSource(typeof(SkillTestData), nameof(SkillTestData.AddSkill))]
        public void CannotBeAbleToAddExistingSkillRecordAsANewSkillRecord(Skills addSkill)
        {
            //act 
            //skillPage.SuccessfullyAddNewSkill(addSkill);
            skillPage.CannotBeAbleToAddExistingSkillRecordAsANewSkillRecord(addSkill);
            _SkillToCleanup = addSkill;

            //Assert 
            var expectedMessage = "This skill is already exist in your skill list.";
            skillPage.AssertionPopupMessage(expectedMessage);
           
        }

        [Test]
        [TestCaseSource(typeof(SkillTestData), nameof(SkillTestData.EditSkill))]
        public void CannotBeAbleToEditSkillRecordToAnotherExistingSkillRecord(Skills addSkill, Skills editSkill)
        {
            //act 
            skillPage.SuccessfullyAddNewSkill(addSkill);
            skillPage.CannotBeAbleToEditExistngSkillAndSkillLevelToAnotherExistingSkill(addSkill, editSkill);
            _SkillToCleanup = addSkill;

            //Assert 
            var expectedMessage = "This skill is already added to your skill list.";
            skillPage.AssertionPopupMessage(expectedMessage);            
        }

        [Test]
        [TestCaseSource(typeof(SkillTestData), nameof(SkillTestData.AddSkill))]
        public void CannotBeAbleToAddSkillRecordWithInvalidData(Skills addSkill)
        {
            //act 
            skillPage.SuccessfullyAddNewSkill(addSkill);
            _SkillToCleanup = addSkill;

            //Assert 
            var expectedMessage = $"{addSkill.Skill} has been added to your skills"; // But In this System allows to add invalid skills
            skillPage.AssertionPopupMessage(expectedMessage);
            skillPage.ViewSkillInTable(addSkill);
        }


        [Test]
        [TestCaseSource(typeof(SkillTestData), nameof(SkillTestData.AddSkill))]
        public void SuccessfullyDeleteAddedSkill(Skills addSkill)
        {
            test = extent.CreateTest("Successfully Delete Added skill").Info("Test Started");

            //act
            skillPage.SuccessfullyAddNewSkill(addSkill);
            skillPage.SuccesffullydeleteExistingSkill(addSkill);


            //Assert
            var expectedMessage = $"{addSkill.Skill} has been deleted";
            skillPage.AssertionPopupMessage(expectedMessage);

            skillPage.CannotViewSkillInTable(addSkill);
        }


    }
}
 




 

    

