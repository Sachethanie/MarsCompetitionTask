using CompetitionTaskProjectMars.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskProjectMars.Models
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

