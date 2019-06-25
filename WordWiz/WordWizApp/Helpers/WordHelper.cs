using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordWizApp.Models;
using System.Security.Principal;



namespace WordWizApp.Helpers
{
    public class WordHelper
    {
        public IEnumerable<Word> GetMyWords(ApplicationDbContext db)
        {
            var currentUser = HttpContext.Current.User.Identity.GetUserId();
            bool isAdmin = HttpContext.Current.User.IsInRole("Admin");
        
            var words = db.Words.Where(w => w.UserId == currentUser || isAdmin);

            return words.AsEnumerable<Word>();

        }
    }
    

    
}