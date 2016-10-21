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
            AutomaticMigrationsEnabled = true;
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
