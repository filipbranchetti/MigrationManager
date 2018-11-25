namespace MigrationManager.Extensions
{
    using Migration;
    using Repository.Models;

    public static class MigrationExtensions
    {
        public static IDiscoveredMigration ConvertToRegisteredMigration(this IMigrationStep migrationStep)
        {
            return new DiscoveredMigration
            {
                MigrationId = migrationStep.Id,
                Description = migrationStep.Description,
                Name = migrationStep.Name,
                Order = migrationStep.Order
            };
        }
    }
}