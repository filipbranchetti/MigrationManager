namespace MigrationManager.Tests
{
    using Finder;
    using NUnit.Framework;

    [TestFixture]
    public class MigrationFinderTests
    {
        [Test]
        public void GetAllMigrations_returnOne()
        {
            //initial
            var finder = new MigrationFinder();

            //expected
            var expected = 1;

            //test
            var allMigrations = finder.FindAllMigrationSteps();

            Assert.AreEqual(expected, allMigrations.Count ,"Method did not find the migration");
        }
    }
}