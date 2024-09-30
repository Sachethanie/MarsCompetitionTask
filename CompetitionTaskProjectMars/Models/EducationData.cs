using Newtonsoft.Json;

namespace ProjectMars.Models
{
    public class EducationTestData
    {
        public static IEnumerable<TestCaseData> AddEducation
        {
            get
            {
                var json = File.ReadAllText("Data\\AddEducation.json");
                var data = JsonConvert.DeserializeObject<List<Education>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }

        public static IEnumerable<TestCaseData> EditEducation
        {
            get
            {
                var json = File.ReadAllText("Data\\EditEducation.json");
                var data = JsonConvert.DeserializeObject<List<EditEducation>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }
            }
        }

        public static IEnumerable<TestCaseData> MandetoryFieldValidationOfEducation
        {
            get
            {
                var json = File.ReadAllText("Data\\MandetoryFieldValidationOfEducation.json");
                var data = JsonConvert.DeserializeObject<List<Education>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }

        public static IEnumerable<TestCaseData> EditEducationRecordToAnotherExistingEducationRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\EditEducationRecordToAnotherExistingEducationRecord.json");
                var data = JsonConvert.DeserializeObject<List<EditEducation>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }
            }
        }

        public static IEnumerable<TestCaseData> AddInvalidEducationRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\AddInvalidEducationRecord.json");
                var data = JsonConvert.DeserializeObject<List<Education>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }
    }
}
