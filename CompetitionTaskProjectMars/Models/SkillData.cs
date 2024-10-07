using Newtonsoft.Json;
namespace ProjectMars.Models
{
    public class SkillTestData
    {
        public static IEnumerable<TestCaseData> AddSkill
        {
            get
            {
                var json = File.ReadAllText("Data\\AddSkill.json");
                var data = JsonConvert.DeserializeObject<List<Skills>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }

        }

        public static IEnumerable<TestCaseData> EditSkill
        {
            get
            {
                var json = File.ReadAllText("Data\\EditSkill.json");
                var data = JsonConvert.DeserializeObject<List<EditSkill>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }


            }
        }

        public static IEnumerable<TestCaseData> MandetoryFieldValidationOfSkill
        {
            get
            {
                var json = File.ReadAllText("Data\\MandetoryFieldValidationOfSkill.json");
                var data = JsonConvert.DeserializeObject<List<Skills>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }

        public static IEnumerable<TestCaseData> EditSkillRecordToAnotherExistingSkillRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\EditSkillRecordToAnotherExistingSkillRecord.json");
                var data = JsonConvert.DeserializeObject<List<EditSkill>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }

            }
        }

        public static IEnumerable<TestCaseData> AddInvalidSkillRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\AddInvalidSkillRecord.json");
                var data = JsonConvert.DeserializeObject<List<Skills>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }

            }
        }


    }
}
