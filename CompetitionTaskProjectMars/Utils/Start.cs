using CompetitionTaskProjectMars.Helpers;
using CompetitionTaskProjectMars.Pages;

namespace CompetitionTaskProjectMars.Utils
{
    public  class Start : Driver
    {
        public static void SignInAndNavigate()
        {
            ExcelLibHelper.PopulateInCollection(@"Data\Mars.xlsx", "Credentials");
            //launch the browser
            Initialize();
            //call the SignIn class
            SignIn.SigninStep();
        }

      
    }
}
