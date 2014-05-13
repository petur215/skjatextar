namespace skjatextar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        TranslationID = c.Int(),
                        CommentText = c.String(),
                        commentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Translations", t => t.TranslationID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.TranslationID);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        LikeCount = c.Int(nullable: false),
                        Text = c.String(),
                        VideoID = c.Int(),
                        DeafCheck = c.Boolean(nullable: false),
                        DateLastEdited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Videos", t => t.VideoID)
                .Index(t => t.VideoID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TranslationID = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        UserID = c.Int(),
                        LikeCount = c.Int(nullable: false),
                        NewRequest = c.String(),
                        RequestSent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "TranslationID", "dbo.Translations");
            DropForeignKey("dbo.Translations", "VideoID", "dbo.Videos");
            DropForeignKey("dbo.Videos", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Requests", new[] { "UserID" });
            DropIndex("dbo.Videos", new[] { "CategoryID" });
            DropIndex("dbo.Translations", new[] { "VideoID" });
            DropIndex("dbo.Comments", new[] { "TranslationID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropTable("dbo.Requests");
            DropTable("dbo.Likes");
            DropTable("dbo.Users");
            DropTable("dbo.Videos");
            DropTable("dbo.Translations");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
