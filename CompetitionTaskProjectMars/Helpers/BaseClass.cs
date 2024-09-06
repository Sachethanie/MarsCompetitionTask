using CompetitionTaskProjectMars.Utils;

namespace CompetitionTaskProjectMars.Helpers
{
    public class BaseClass : Driver
    {

        [SetUp]
        public void Setup()
        {
            Start.SignInAndNavigate();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}







