namespace MigrationManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Finder;
    using Migration;
    using Repository;
    using Repository.Models;

    public class MigrationService
    {
        private readonly IMigrationFinder _finder;
        private readonly IProcessedRepository _processedRepo;

        public MigrationService(
            IProcessedRepository processedRepo,
            IMigrationFinder finder)
        {
            _processedRepo = processedRepo;
            _finder = finder;
        }

        public IMigrationStep GetMigration(Guid guid)
        {
            return _finder.GetMigration(guid);
        }

        public IList<IDiscoveredMigration> GetAllMigrationSteps()
        {
            var list = new List<IDiscoveredMigration>();
            var runnedMigrations = _processedRepo.GetAll();
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
            return list;
        }

        public void Up(IMigrationStep migrationStep)
        {
            if (!_processedRepo.HasBeenRun(migrationStep))
            {
                migrationStep.Up();
                _processedRepo.MarkAsRunned(migrationStep);
            }
        }
        public void Down(IMigrationStep migrationStep)
        {
            if (_processedRepo.HasBeenRun(migrationStep))
            {
                migrationStep.Down();
                _processedRepo.MarkAsNotRunned(migrationStep);
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
            return _processedRepo.HasBeenRun(migrationStep);
        }
    }
}