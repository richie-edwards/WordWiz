using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordWizApp.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
                
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: MMM dd yyyy}")]
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }


        public virtual Role Role { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}