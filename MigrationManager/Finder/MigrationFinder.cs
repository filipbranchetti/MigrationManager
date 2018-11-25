namespace MigrationManager.Finder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Migration;

    public class MigrationFinder : IMigrationFinder
    {
        public List<IMigrationStep> FindAllMigrationSteps()
        {
            var types = GetAllEntities<IMigrationStep>();
            var migrations = new List<IMigrationStep>();
            foreach (var type in types)
            {
                if (Activator.CreateInstance(type) is IMigrationStep instance)
                {
                    if (migrations.Any(x => x.Id == instance.Id))
                    {
                        throw new DuplicatedMigrationException($"Migration with id:{instance.Id} exist");
                    }
                    migrations.Add(instance);
                }
            }
            
            return migrations;
        }

        public IMigrationStep GetMigration(Guid guid)
        {
            var migrations = FindAllMigrationSteps();
            return migrations.FirstOrDefault(x => x.Id == guid);
        }

        private List<Type> GetAllEntities<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x).ToList();
        }
    }
}
