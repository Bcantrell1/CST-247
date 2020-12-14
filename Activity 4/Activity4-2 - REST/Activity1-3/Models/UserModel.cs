using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Activity1_3.Models
{
    public class UserModel
    {
        [Required]
        [DisplayName("User Name")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Password { get; set; }
    

    public UserModel(string userName, string password)
    {
        this.Username = userName;
        this.Password = password; 
    }
    public UserModel () { }
    }
}