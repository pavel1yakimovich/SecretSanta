using System;
using AzureSecretSanta.Migrations;
using AzureSecretSanta.Models;

namespace AzureSecretSanta.Repository
{
    using System.Data.Entity;

    public class SecretSanta : DbContext
    {
        // Your context has been configured to use a 'SecretSanta' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.SecretSanta' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SecretSanta' 
        // connection string in the application configuration file.
        public SecretSanta()
            : base("name=SecretSanta")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SecretSanta, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasOptional(u => u.SantaOf);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}