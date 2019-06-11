using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordWizApp.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Name")]
        public string FullName => FirstName + " " + LastName;

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Word> Words { get; set; }

    }
}