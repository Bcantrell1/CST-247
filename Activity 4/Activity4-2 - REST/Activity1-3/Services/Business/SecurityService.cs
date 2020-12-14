using Activity1_3.Models;
using Activity1_3.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1_3.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);
        }
    }
}