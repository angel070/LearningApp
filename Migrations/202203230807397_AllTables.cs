namespace Learning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ans = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        level = c.String(nullable: false),
                        ProgrammeId = c.String(nullable: false),
                        Programme_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programmes", t => t.Programme_Id)
                .Index(t => t.Programme_Id);
            
            CreateTable(
                "dbo.Programmes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FileName = c.String(nullable: false),
                        FilePath = c.String(nullable: false),
                        Description = c.String(),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        subtopic = c.String(),
                        CourseId = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        Note = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opt = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quest = c.String(),
                        Reason = c.String(),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        User_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User_Role", t => t.User_RoleId, cascadeDelete: true)
                .Index(t => t.User_RoleId);
            
            CreateTable(
                "dbo.User_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImageTitle = c.String(),
                        FilePath = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registers", "User_RoleId", "dbo.User_Role");
            DropForeignKey("dbo.Quizs", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Notes", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Materials", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Programme_Id", "dbo.Programmes");
            DropIndex("dbo.Registers", new[] { "User_RoleId" });
            DropIndex("dbo.Quizs", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "TopicId" });
            DropIndex("dbo.Notes", new[] { "TopicId" });
            DropIndex("dbo.Topics", new[] { "Course_Id" });
            DropIndex("dbo.Materials", new[] { "TopicId" });
            DropIndex("dbo.Courses", new[] { "Programme_Id" });
            DropTable("dbo.Sliders");
            DropTable("dbo.User_Role");
            DropTable("dbo.Registers");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
            DropTable("dbo.Notes");
            DropTable("dbo.Topics");
            DropTable("dbo.Materials");
            DropTable("dbo.Programmes");
            DropTable("dbo.Courses");
            DropTable("dbo.Answers");
        }
    }
}
