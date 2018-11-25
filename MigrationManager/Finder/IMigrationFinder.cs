namespace MigrationManager.Finder
{
    using System;
    using System.Collections.Generic;
    using Migration;

    public interface IMigrationFinder
    {
        List<IMigrationStep> FindAllMigrationSteps();
        IMigrationStep GetMigration(Guid guid);
    }
}