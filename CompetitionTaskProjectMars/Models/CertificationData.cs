using Newtonsoft.Json;

namespace ProjectMars.Models
{
    public class CertificationTestData
    {
        public static IEnumerable<TestCaseData> AddCertifications
        {
            get
            {
                var json = File.ReadAllText("Data\\AddCertifications.json");
                var data = JsonConvert.DeserializeObject<List<Certification>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }

        public static IEnumerable<TestCaseData> EditCertifications
        {
            get
            {
                var json = File.ReadAllText("Data\\EditCertifications.json");
                var data = JsonConvert.DeserializeObject<List<EditCertification>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }
            }
        }

        public static IEnumerable<TestCaseData> MandetoryFieldValidationOfCertification
        {
            get
            {
                var json = File.ReadAllText("Data\\MandetoryFieldValidationOfCertification.json");
                var data = JsonConvert.DeserializeObject<List<Certification>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }

        public static IEnumerable<TestCaseData> EditOneValueOfCertification
        {
            get
            {
                var json = File.ReadAllText("Data\\EditOneValueOfCertification.json");
                var data = JsonConvert.DeserializeObject<List<EditCertification>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }
            }
        }

        public static IEnumerable<TestCaseData> EditCertificationRecordToAnotherExistingCertificationRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\EditCertificationRecordToAnotherExistingCertificationRecord.json");
                var data = JsonConvert.DeserializeObject<List<EditCertification>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item.Create, item.Update);
                }
            }
        }

        public static IEnumerable<TestCaseData> AddInvalidCertificationRecord
        {
            get
            {
                var json = File.ReadAllText("Data\\AddInvalidCertificationRecord.json");
                var data = JsonConvert.DeserializeObject<List<Certification>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }
    }
}      
     
