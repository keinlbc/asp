using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcourse.Models
{

    
    [Table("students")]
    public class Student
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public int fn { get; set; }
        [DataType(DataType.Date)]
        public DateTime birthday { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        [RegularExpression("(КН|СИ|ИС|И|М|ПМ)")]
        public string speciality { get; set; }
        [Range(1, 4, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int course { get; set; }

        [EmailAddress]
        public string email { get; set; }

        public ICollection<Note> notes { get; set; }

    }
}
