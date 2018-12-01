namespace MigrationManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Extensions;
    using Finder;
    using Migration;
    using Repository;
    using Repository.Models;

    public class MigrationService
    {
        private readonly IMigrationFinder _finder;
        private readonly IMigratedRepository _migratedRepo;

        public MigrationService(
            IMigratedRepository migratedRepo,
            IMigrationFinder finder)
        {
            _migratedRepo = migratedRepo;
            _finder = finder;
        }

        public IMigrationStep GetMigration(Guid guid)
        {
            return _finder.GetMigration(guid);
        }

        public IList<IDiscoveredMigration> GetAllMigrationSteps()
        {
            var list = new List<IDiscoveredMigration>();
            var runnedMigrations = _migratedRepo.GetAll();
            foreach (var migrationStep in _finder.FindAllMigrationSteps())
            {
                var exist = runnedMigrations.FirstOrDefault(x => x.MigrationId == migrationStep.Id);
                if (exist != null)
                {
                    list.Add(exist);
                }
                else
                {
                    list.Add(migrationStep.ConvertToRegisteredMigration());
                }
                
            }
            var missingMigrations = runnedMigrations.Except(list).ToList();
            foreach (var missingMigration in missingMigrations)
            {
                missingMigration.Status = MigrationStatus.IsMissing;
                list.Add(missingMigration);
            }
            return list;
        }

        public void Up(IMigrationStep migrationStep)
        {
            if (!_migratedRepo.HasBeenRun(migrationStep))
            {
                migrationStep.Up();
                _migratedRepo.MarkAsRunned(migrationStep);
            }
        }
        public void Down(IMigrationStep migrationStep)
        {
            if (_migratedRepo.HasBeenRun(migrationStep))
            {
                migrationStep.Down();
                _migratedRepo.MarkAsNotRunned(migrationStep);
            }
        }
        public void UpAll()
        {
            foreach (var migrationStep in _finder.FindAllMigrationSteps())
            {
                Up(migrationStep);
            }
        }

        public void DownAll()
        {
            foreach (var migrationStep in _finder.FindAllMigrationSteps())
            {
                Down(migrationStep);
            }
        }

        public bool HasBeenRunned(IMigrationStep migrationStep)
        {
            return _migratedRepo.HasBeenRun(migrationStep);
        }
    }
}