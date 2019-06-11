using System;
using System.ComponentModel.DataAnnotations;


namespace WordWizApp.Models
{
    public enum Type
    {
        Admin, Student
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}