using Newtonsoft.Json;

namespace ProjectMars.Models
{
    public class LoginData
    {
        public static Login LoginCredentials
        {
            get
            {
                var json = File.ReadAllText("Data\\LoginCredentials.json");
                var data = JsonConvert.DeserializeObject<Login>(json);


                return data;

            }
        }
}   }

