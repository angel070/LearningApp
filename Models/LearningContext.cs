using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class LearningContext:DbContext
    {
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Course> Courses { get; set; }
         public DbSet<Topic> Topics { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
} 