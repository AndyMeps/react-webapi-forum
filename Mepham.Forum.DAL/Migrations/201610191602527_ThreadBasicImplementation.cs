namespace Mepham.Forum.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ThreadBasicImplementation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "ModeratingUserId", "dbo.Users");
            CreateTable(
                "dbo.Threads",
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
                        AuthorUserId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Users", t => t.AuthorUserId)
                .ForeignKey("dbo.Topics", t => t.TopicId)
                .Index(t => t.AuthorUserId)
                .Index(t => t.TopicId);
            
            AddForeignKey("dbo.Topics", "ModeratingUserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "ModeratingUserId", "dbo.Users");
            DropForeignKey("dbo.Threads", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Threads", "AuthorUserId", "dbo.Users");
            DropIndex("dbo.Threads", new[] { "TopicId" });
            DropIndex("dbo.Threads", new[] { "AuthorUserId" });
            DropTable("dbo.Threads",
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
            AddForeignKey("dbo.Topics", "ModeratingUserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
