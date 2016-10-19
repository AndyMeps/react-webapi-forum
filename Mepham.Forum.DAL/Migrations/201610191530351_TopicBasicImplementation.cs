namespace Mepham.Forum.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class TopicBasicImplementation : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Users", t => t.ModeratingUserId, cascadeDelete: true)
                .Index(t => t.ModeratingUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "ModeratingUserId", "dbo.Users");
            DropIndex("dbo.Topics", new[] { "ModeratingUserId" });
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
        }
    }
}
