namespace MigrationManager.Repository.Models
{
    using System;

    public interface IDiscoveredMigration
    {
        Guid MigrationId { get; set; }
        int Order { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool HasBeenRunned { get; set; }
        DateTime ExecutedDateTime { get; set; }
    }
}