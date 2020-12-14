using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string SayHello()
        {
            return "Hello CST-247 :)";
        }

        public HelloObject GetModelObj(string id)
        {
            HelloObject helloObject = new HelloObject();

            if (int.Parse(id) > 0)
            {
                helloObject.helloBool = true;
                helloObject.helloMessage = "Hello Bool is true!";
            }
            else
            {
                helloObject.helloBool = false;
                helloObject.helloMessage = "Hello Bool is false.";
            }
            return helloObject;

        }
        Random random = new Random();
        List<User> userList = new List<User>();

        public Service1()
        {
            User user1 = new User(1, "Brian", true, 80000, GetListOfScores(random));
            User user2 = new User(2, "Kelsea", true, 60000, GetListOfScores(random));
            User user3 = new User(3, "Tony", false, 100000, GetListOfScores(random));
            User user4 = new User(4, "Kyle", false, 50000, GetListOfScores(random));

            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
            userList.Add(user4);
        }

        private static List<int> GetListOfScores(Random rand)
        {
            List<int> scoresList = new List<int>();

            for (int x = 0; x < 10; x++)
            {
                scoresList.Add(rand.Next(100));
            }

            return scoresList;
        }

        public UserDTO GetAllUsers()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.MessageCode = 1;
            userDTO.MessageText = "Everyone is here";
            userDTO.UserList = userList;

            return userDTO;
        }

        public UserDTO GetUsersByID(string ID)
        {
            UserDTO userDTO = new UserDTO();
            List<User> matchedUsers = userList.Where(x => x.ID == int.Parse(ID)).ToList();

            userDTO.UserList = matchedUsers;
            userDTO.MessageCode = matchedUsers.Count();
            userDTO.MessageText = "Users with the ID of " + ID;

            return userDTO;

        }

        public UserDTO GetUsersByName(string name)
        {
            UserDTO userDTO = new UserDTO();
            List<User> matchedUsers = userList.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

            userDTO.UserList = matchedUsers;
            userDTO.MessageCode = matchedUsers.Count();
            userDTO.MessageText = "People who have " + name + " in their name.";

            return userDTO;

        }
    }
}
