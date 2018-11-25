namespace MigrationManager.Tests.Migrations
{
    using System;
    using Migration;

    internal class MigrationsStep : IMigrationStep
    {
        public Guid Id => Guid.NewGuid();
        public int Order => 1;
        public string Name => "name";
        public string Description => "description";

        public void Up()
        {
            throw new NotImplementedException();
        }

        public void Down()
        {
            throw new NotImplementedException();
        }
    }
}