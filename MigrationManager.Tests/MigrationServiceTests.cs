namespace MigrationManager.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Finder;
    using Migration;
    using Moq;
    using NUnit.Framework;
    using Repository;
    using Repository.Models;
    using Services;

    [TestFixture]
    public class MigrationServiceTests
    {
        private readonly Mock<IMigratedRepository> _migratedRepo;
        private readonly Mock<IMigrationFinder> _finder;

        public MigrationServiceTests()
        {
            _migratedRepo = new Mock<IMigratedRepository>();
            _finder = new Mock<IMigrationFinder>();
        }

        [Test]
        public void GetAllMigrations_returnOneStatusMissing()
        {
            //setup mocks
            _migratedRepo.Setup(x => x.GetAll()).Returns(new List<IDiscoveredMigration>{new DiscoveredMigration
            {
                MigrationId = Guid.NewGuid(),
                Name = "name"
            }});
            _finder.Setup(x => x.FindAllMigrationSteps()).Returns(new List<IMigrationStep>());

            //initial
            var service = new MigrationService(_migratedRepo.Object, _finder.Object);

            //expected
            var expected = MigrationStatus.IsMissing;

            //test
            var migration = service.GetAllMigrationSteps().FirstOrDefault();

            Assert.AreEqual(expected, migration?.Status, $"Migration did have status: {expected}");
        }
    }
}