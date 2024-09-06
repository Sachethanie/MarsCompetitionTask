using Newtonsoft.Json;

namespace CompetitionTaskProjectMars.Models
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

        public static IEnumerable<TestCaseData> AddInalidData
        {
            get
            {
                var json = File.ReadAllText("Data\\AddInvalidData.json");
                var data = JsonConvert.DeserializeObject<List<Certification>>(json);

                foreach (var item in data)
                {
                    yield return new TestCaseData(item);
                }
            }
        }



        public static Certification GetNewCertification()
        {
            return new Certification()
            {
                Certificate = "Test Analysis",
                CertifiedFrom = "Industry Connect",
                Year = "2024",

            };
        }
         
       

        public static Certification EditCertification()
        {
            return new Certification()
            {
                Certificate = "ISTQB",
                CertifiedFrom = "International Software Testing Qualifications Board",
                Year = "2024",
            };
        }

        public static Certification AddEducationRecordWithoutAddingAllMandatoryFields()
        {
            return new Certification()
            {
                Certificate = "Test Analysis",
                Year = "2020",
            };
        }

        public static Certification EditCertificationRecordByEditingOneValue()
        {
            return new Certification()
            {
                Certificate = "ISTQB",
                CertifiedFrom = "Industry Connect",
                Year = "2024",
            };
        }

        public static Certification InvalidCertificationRecord()
        {
            return new Certification()
            {
                Certificate = "ABC!@#123",
                CertifiedFrom = "QWe123$%^",
                Year = "2024",

            };

        }

    }
}      
     
