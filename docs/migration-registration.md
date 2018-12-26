## Migration registration

Register an migration. Make an class that implements the interface IMigrationStep

#### Example

```
public class MigrationsStep : IMigrationStep
  {
      public Guid Id => Guid.NewGuid(); 
      public int Order => 1; 
      public string Name => "name"; 
      public string Description => "description"; 

      public void Up()
      {
          throw new NotImplementedException();
      }

      public void Down()
      {
          throw new NotImplementedException();
      }
  } 
```
