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
        public string firstname { get; set; }
        public string lastname { get; set; }
        [Required]
        public int fn { get; set; }
        [DataType(DataType.Date)]
        public DateTime birthday { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string speciality { get; set; }
        [Range(1,4)]
        public int course { get; set; }

        public ICollection<Note> notes { get; set; }

    }
}
