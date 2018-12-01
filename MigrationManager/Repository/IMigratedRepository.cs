namespace MigrationManager.Repository
{
    using System.Collections.Generic;
    using Migration;
    using Models;

    public interface IMigratedRepository
    {
        IList<IDiscoveredMigration> GetAll();
        bool HasBeenRun(IMigrationStep migrationStep);
        void MarkAsRunned(IMigrationStep migrationStep);
        void MarkAsNotRunned(IMigrationStep migrationStep);
    }
}