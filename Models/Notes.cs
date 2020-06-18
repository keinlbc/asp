using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace aspcourse.Models
{
    [Table("notes")]
    [DataContract]
    public class Note
    {
        private int studentId;
 
        private int noteId;

        //     public Student Student { get; set; }
        public int StudentId { get => studentId; set => studentId = value; }

        [DataMember]
        [Range(2, 6)]
        public decimal score { get; set; }
        public int NoteId { get => noteId; set => noteId = value; }

        [DataMember]
        public string course { get; set; }


    }
}
