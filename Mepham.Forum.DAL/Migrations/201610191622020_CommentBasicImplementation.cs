namespace Mepham.Forum.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CommentBasicImplementation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "NEWID()")
                                },
                            }),
                        Description = c.String(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        ThreadId = c.Guid(nullable: false),
                        ResponseToCommentId = c.Guid(),
                        CreateDateTime = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDateTime = c.DateTime(),
                        DeleteDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .ForeignKey("dbo.Comments", t => t.ResponseToCommentId)
                .ForeignKey("dbo.Threads", t => t.ThreadId)
                .Index(t => t.AuthorId)
                .Index(t => t.ThreadId)
                .Index(t => t.ResponseToCommentId);
            
            AddColumn("dbo.Threads", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.Comments", "ResponseToCommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "ResponseToCommentId" });
            DropIndex("dbo.Comments", new[] { "ThreadId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropColumn("dbo.Threads", "Description");
            DropTable("dbo.Comments",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDateTime",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "GETDATE()" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "NEWID()" },
                        }
                    },
                });
        }
    }
}
