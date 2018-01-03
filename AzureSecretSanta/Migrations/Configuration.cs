namespace AzureSecretSanta.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AzureSecretSanta.Repository.SecretSanta>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AzureSecretSanta.Repository.SecretSanta";
        }

        protected override void Seed(AzureSecretSanta.Repository.SecretSanta context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
