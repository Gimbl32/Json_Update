
using System.Collections.Generic;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Db
{
    public class UserDataBase
    {

        private static List<User>? UserList = new List<User>();

        public string SaveUsers(List<User> UserList)
        {
            string json = JsonSerializer.Serialize(UserList);

            File.WriteAllText("users.json", json);
            return json;
        }

        public List<User> LoadUsers()
        {
            if (!File.Exists("users.json"))
            {
                return new List<User>();
            }

            string json = File.ReadAllText("users.json");
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }



    }
}
