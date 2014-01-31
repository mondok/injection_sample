using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkDISample.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}