## Custom repository


To create an custom repositoty. Make an class that implements the interface IMigratedRepository

#### Example

```
public class InMemoryRepository : IMigratedRepository
{
    public IList<IDiscoveredMigration> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool HasBeenRun(IMigrationStep migrationStep)
    {
        throw new NotImplementedException();
    }

    public void MarkAsRunned(IMigrationStep migrationStep)
    {
        throw new NotImplementedException();
    }

    public void MarkAsNotRunned(IMigrationStep migrationStep)
    {
        throw new NotImplementedException();
    }
}
```
