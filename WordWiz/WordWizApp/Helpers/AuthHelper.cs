using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordWizApp.Models;

namespace WordWizApp.Helpers
{
    public class AuthHelper
    {

        public bool IsAdmin(ApplicationDbContext db, string userId)
        {
            var user = db.Users.Where(u => u.Id == userId);
            if (user != null)
            {
               
            }
            return false;
        }
    }
}
        
           
