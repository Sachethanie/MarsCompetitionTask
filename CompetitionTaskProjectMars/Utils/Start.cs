using CompetitionTaskProjectMars.Helpers;
using CompetitionTaskProjectMars.Models;
using CompetitionTaskProjectMars.Pages;
using Newtonsoft.Json;

namespace CompetitionTaskProjectMars.Utils
{
    public  class Start : Driver
    {
      
        public static void SignInAndNavigate()
        {
            
            Initialize();

            var login = LoginData.LoginCredentials;
            //call the SignIn class
            SignIn.SigninStep(login);
        }      
    }
}
