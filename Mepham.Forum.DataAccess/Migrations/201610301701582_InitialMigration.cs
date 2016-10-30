namespace Mepham.Forum.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
                        PostId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .ForeignKey("dbo.Comments", t => t.ResponseToCommentId)
                .Index(t => t.AuthorId)
                .Index(t => t.PostId)
                .Index(t => t.ResponseToCommentId);
            
            CreateTable(
                "dbo.Users",
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
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
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
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        TopicId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Topics", t => t.TopicId)
                .Index(t => t.AuthorId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
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
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        ModeratingUserId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Users", t => t.ModeratingUserId)
                .Index(t => t.ModeratingUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ResponseToCommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Posts", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "ModeratingUserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Users");
            DropIndex("dbo.Topics", new[] { "ModeratingUserId" });
            DropIndex("dbo.Posts", new[] { "TopicId" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "ResponseToCommentId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropTable("dbo.Topics",
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
            DropTable("dbo.Posts",
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
            DropTable("dbo.Users",
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
