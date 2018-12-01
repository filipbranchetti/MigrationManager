namespace MigrationManager.Repository.Models
{
    using System;
    using Enums;

    public interface IDiscoveredMigration
    {
        Guid MigrationId { get; set; }
        int Order { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        MigrationStatus Status { get; set; }
        DateTime ExecutedDateTime { get; set; }
    }
}