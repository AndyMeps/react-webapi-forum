using System;
using System.Data.Entity.Validation;
using System.Text;
using Mepham.Forum.Models.Entities;

namespace Mepham.Forum.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Mepham.Forum.DataAccess.ForumContext";

            // DefaultValue Sql Generator
            SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(ForumContext context)
        {
            try
            {
                context.Users.AddOrUpdate(u => u.Id,
                    new User
                    {
                        Id = new Guid("81AD0462-3241-4480-B715-21F4F3656298"),
                        Username = "AndyMeps",
                        Password = "Testing!",
                        CreateDateTime = DateTime.Now
                    },
                    new User
                    {
                        Id = new Guid("82AD0462-3241-4480-B715-21F4F3656298"),
                        Username = "EmmaReeves",
                        Password = "Testing2!",
                        CreateDateTime = DateTime.Now
                    },
                    new User
                    {
                        Id = new Guid("83AD0462-3241-4480-B715-21F4F3656298"),
                        Username = "Test",
                        Password = "abcd1234",
                        CreateDateTime = DateTime.Now
                    }
                );

                context.Topics.AddOrUpdate(t => t.Id,
                    new Topic
                    {
                        Id = new Guid("6D88CED7-D96F-4603-9230-CC38C13DBCC6"),
                        Title = "Motorbikes",
                        Description = "Topic for motorbike discussion",
                        ModeratingUserId = new Guid("81AD0462-3241-4480-B715-21F4F3656298"),
                        CreateDateTime = DateTime.Now
                    },
                    new Topic
                    {
                        Id = new Guid("E596E5ED-6C68-4D33-9ABE-F11A64CE4679"),
                        Title = "Craft Beer",
                        Description = "Topic for craft beer discussion",
                        ModeratingUserId = new Guid("82AD0462-3241-4480-B715-21F4F3656298"),
                        CreateDateTime = DateTime.Now
                    }
                );

                context.Posts.AddOrUpdate(p => p.Id,
                    new Post
                    {
                        Id = new Guid("2737ebdf-7a1c-4afc-8250-d34b741030da"),
                        Title = "News: 2017 Suzuki GSX-R 1000 Announced!",
                        Description = "What do we think about the new Gixxer?!",
                        AuthorId = new Guid("81AD0462-3241-4480-B715-21F4F3656298"),
                        CreateDateTime = DateTime.Now,
                        TopicId = new Guid("6D88CED7-D96F-4603-9230-CC38C13DBCC6")
                    },
                    new Post
                    {
                        Id = new Guid("1F4EA3F7-2ABE-4B1E-926D-9176D73DA7E3"),
                        Title = "Review: Brewdog Punk IPA",
                        Description = "Last night I tried Brewdog's Punk IPA, it's fantastically fruity and easy to drink a few, may explain my headache today! :P Has anyone else tried it? How did you find it?",
                        AuthorId = new Guid("81AD0462-3241-4480-B715-21F4F3656298"),
                        CreateDateTime = DateTime.Now,
                        TopicId = new Guid("E596E5ED-6C68-4D33-9ABE-F11A64CE4679")
                    },
                    new Post
                    {
                        Id = new Guid("26864068-F7F0-4DA8-A488-B8F69AB64322"),
                        Title = "Beavertown Gamma Ray - Opinions?",
                        Description = "Anyone else tried Beavertown's Gamma Ray IPA? I really liked it but my friend wasn't too keen, would love to hear other people's opinions?!",
                        AuthorId = new Guid("81AD0462-3241-4480-B715-21F4F3656298"),
                        CreateDateTime = DateTime.Now,
                        TopicId = new Guid("E596E5ED-6C68-4D33-9ABE-F11A64CE4679")
                    }
                );

                context.Comments.AddOrUpdate(c => c.Id,
                    new Comment
                    {
                        Id = new Guid("53b6b0b1-589c-400e-8e5b-3c36d39923dd"),
                        Description = "It looks fantastic! I think a new design for the Gixxer range was long overdue and it's great to see them catch up with the tech other manufacturers have had for a few years.",
                        AuthorId = new Guid("82AD0462-3241-4480-B715-21F4F3656298"),
                        CreateDateTime = DateTime.Now,
                        PostId = new Guid("2737ebdf-7a1c-4afc-8250-d34b741030da")
                    }
                );

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();

                foreach (var failure in e.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), e
                    ); // Add the original exception as the innerException
            }
        }
    }
}
