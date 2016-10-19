namespace Mepham.Forum.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class TestingDefaultValueAttribute : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "CreateDateTime", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                    },
                }));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "NEWID()")
                    },
                }));
            AddPrimaryKey("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "NEWID()", newValue: null)
                    },
                }));
            DropColumn("dbo.Users", "CreateDateTime",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "SqlDefaultValue", "GETDATE()" },
                });
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
