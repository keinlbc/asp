using Microsoft.EntityFrameworkCore;
using aspcourse.Models;
using System;


namespace student.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Note> note { get; set; }



        
        

    }
}