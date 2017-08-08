using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlatPlanet.Models
{
    public class ExamContext : DbContext
    {
        public ExamContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Exam> Exams { get; set; }
    }
}