namespace MigrationManager.Migration
{
    using System;

    public interface IMigrationStep
    {
        Guid Id { get; }
        int Order { get; }
        string Name { get; }
        string Description { get; }
        void Up();
        void Down();
    }
}
