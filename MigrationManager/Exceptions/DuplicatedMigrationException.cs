namespace MigrationManager.Exceptions
{
    using System;

    public class DuplicatedMigrationException : Exception
    {
        public DuplicatedMigrationException()
        {
        }

        public DuplicatedMigrationException(string message) : base(message)
        {
        }

        public DuplicatedMigrationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
