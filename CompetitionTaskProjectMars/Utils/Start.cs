using ProjectMars.Helpers;
using ProjectMars.Models;
using ProjectMars.Pages;

namespace ProjectMars.Utils
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
