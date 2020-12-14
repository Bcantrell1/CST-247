using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HelloWorldService
{
    [DataContract]
    public class User
    {
        public User(int iD, string name, bool preferredCustomer, float income, List<int> highScores)
        {
            ID = iD;
            Name = name;
            PreferredCustomer = preferredCustomer;
            Income = income;
            HighScores = highScores;
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool PreferredCustomer { get; set; }

        [DataMember]
        public float Income { get; set; }

        [DataMember]
        public List<int> HighScores { get; set; }
    }
}