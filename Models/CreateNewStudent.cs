using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CreateNewStudent
    {
        [Required]
        public string FirstName {get; set;}
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MatricNo { get; set; }
        [Required]
        public string StateOfOrigin { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public int Age { get; set; }
    }
}