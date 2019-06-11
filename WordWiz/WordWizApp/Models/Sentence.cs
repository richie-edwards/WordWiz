using System;
using System.ComponentModel.DataAnnotations;

namespace WordWizApp.Models
{
    public class Sentence
    {
        [Required]
        public int Id { get; set; }

        public int WordId { get; set; }

        [Display(Name = "Sentence")]
        public string Name { get; set; }

        [Display(Name = "Completed?")]
        public bool IsDone { get; set; }

        // virtual takes advantage of Lazy Loading. How?
        public virtual Word Word { get; set; }
    }
}