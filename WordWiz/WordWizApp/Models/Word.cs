using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordWizApp.Models
{
    public class Word
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name="Word")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]        
        [DisplayFormat(DataFormatString = "{0: MMM dd, yyyy}")]
        [Display(Name="Date Created")]
        public DateTime? CreatedDate { get; set; }               

        public string  Feedback { get; set; }

        public bool IsDone { get; set; }

        public string UserId { get; set; }


        public virtual Student Student { get; set; }
        public virtual ICollection<Sentence> Sentences { get; set; }
    }
}