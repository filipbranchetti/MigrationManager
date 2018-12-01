namespace MigrationManager.Repository.Models
{
    using System;
    using Enums;

    public class DiscoveredMigration : IDiscoveredMigration
    {
        public Guid MigrationId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MigrationStatus Status { get; set; } = MigrationStatus.HasNotBeenRunned;
        public DateTime ExecutedDateTime { get; set; }
    }
}