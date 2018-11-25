namespace MigrationManager.Repository.Models
{
    using System;

    public class DiscoveredMigration : IDiscoveredMigration
    {
        public Guid MigrationId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasBeenRunned { get; set; }
        public DateTime ExecutedDateTime { get; set; }
    }
}