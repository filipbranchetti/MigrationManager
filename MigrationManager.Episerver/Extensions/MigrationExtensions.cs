namespace MigrationManager.Episerver.Extensions
{
    using Migration;
    using MigrationManager.Repository.Models;
    using Repository.Store;

    public static class MigrationExtensions
    {
        public static IDiscoveredMigration ConvertToDiscoveredMigration(this MigrationData migrationData)
        {
            return new DiscoveredMigration
            {
                MigrationId = migrationData.MigrationId,
                Name = migrationData.Name,
                Order = migrationData.Order,
                Description = migrationData.Description,
                ExecutedDateTime = migrationData.ExecutedDateTime,
                HasBeenRunned = true
            };
        }

        public static MigrationData ConvertToMigrationData(this IMigrationStep migrationStep)
        {
            return new MigrationData
            {
                MigrationId = migrationStep.Id,
                Name = migrationStep.Name,
                Order = migrationStep.Order,
                Description = migrationStep.Description
            };
        }
    }
}