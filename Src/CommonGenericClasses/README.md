# CommonGenericClasses

## Base generic implementation using Repository & Unit of Work Design Pattern of CRUD operations in .NET 6.0

# Installation
CLI
``` cli
 dotnet add package CommonGenericClasses --version 8.0.0
```
PM 
``` cli
Install-Package CommonGenericClasses -Version 8.0.0
```

# Usage
``` C#
using CommonGenericClasses;
```

# Code sample
```C#
using CommonGenericClasses;
public class PlayerRepository : BaseRepo<Player>
{
    public PlayerRepository(DbContext db) : base(db)
    {
    }
}
```
Now all CRUD operations are available for `PlayerRepository`
# Source code 
### https://github.com/Badea741/CommonGenericClasses

