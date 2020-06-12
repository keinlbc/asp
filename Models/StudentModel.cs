using System;
using System.ComponentModel.DataAnnotations;

namespace aspcourse.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string firsname { get; set; }
        public string lastname { get; set; }
        public string egn { get; set; }
        [DataType(DataType.Date)]
        public DateTime added { get; set; }
        
    }
}
