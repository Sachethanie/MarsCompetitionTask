using Newtonsoft.Json;
namespace ProjectMars.Models
{
    public class LanguageTestData
    {
        public static IEnumerable<TestCaseData> AddLanguage
        {
            get
            {
                var json = File.ReadAllText("Data\\AddLanguage.json");
                var data =JsonConvert.DeserializeObject<List<Languages>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }

        }

        public static IEnumerable<TestCaseData> EditLanguage
        {
            get
            {
                var json = File.ReadAllText("Data\\EditLanguage.json");
                var data = JsonConvert.DeserializeObject<List<EditLanguage>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }


            }
        }

        public static IEnumerable <TestCaseData> MandetoryFieldValidationOfLanguage
        {
            get
            {
                var json = File.ReadAllText("Data\\MandetoryFieldValidationOfLanguage.json");
                var data = JsonConvert.DeserializeObject<List<Languages>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }

        public static IEnumerable<TestCaseData> EditLanguageRecordToAnotherExistingLanguageRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\EditLanguageRecordToAnotherExistingLanguageRecord.json");
                var data = JsonConvert.DeserializeObject<List<EditLanguage>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }

            }
        }

        public static IEnumerable<TestCaseData> AddInvalidLanguageRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\AddInvalidLanguageRecord.json");
                var data = JsonConvert.DeserializeObject<List<Languages>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }

            }
        }


    }
}
