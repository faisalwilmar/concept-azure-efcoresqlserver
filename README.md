# Entity Framework SQL Server with Hexagonal Architecture

## About

This **Concept Repository** was created for practicing Entity Framework implementation with Azure SQL Database. This project combine several references to create an .NET Web API with Hexagonal Architecture where Controller, Business Logic, and Data Access are separated in different *(visual studio) project*.

------

## References

Visual Studio scaffolding features are demonstrated [here](https://www.youtube.com/watch?v=32iBQvIZQxU).

Entity Framework Migrations are demonstrated [here](https://www.youtube.com/watch?v=umCUX1gL5Ek).

We are separating DbContext from Startup assembly. Reference can be read [here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=vs).

If you want to add Migrations from already created database, reference can be read [here](https://website-development.ch/blog/ef-core-migrations-existing-database).

------

## How to Setup the Database?

Our first priority is to create DbContext and connect to the *real* database.

1. Create ASP.NET Core Web API project (We call it **FrontEndAPI project**). Make sure to check *Use Controllers* when creating the project, since we are intended to use Hexagonal Architecture.

2. Create new Class Library project (We call it **DataAccess project**) in the same solution.

3. Add project reference from FrontEndAPI project to DataAccess project.

4. Install Entity Framework required libraries. `Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools`. In this project, we are using version 6.0.15 (since we are using .NET6 LTS). `Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.SqlServer` can be installed in DataAccess project only, but `Microsoft.EntityFrameworkCore.Tools` need to be installed in both (FrontEndAPI and DataAccess) project since it is required for modifying the *real* database.

5. We can manually create the Models and DbContext class. Use this Concept Repository as reference. Pretty straightforward, we don't need to explain that, do we?

6. Add the Data Context to the builder in the startup class. In this Concept Repository, startup class can be found in FrontEndAPI Program.cs. 

   ```c#
   // Entity Framework Initialization
               builder.Services.AddDbContext<BisonDataContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("BisonDataContext") ?? throw new InvalidOperationException("Connection string 'BisonDataContext' not found."),
                  x => x.MigrationsAssembly("Concept.Azure.EfCoreSqlServer.DataAccess"))); // Assembly of Data Context
   ```

7. Open **Visual Studio Package Manager Console**. This can be found in *View -> Other Windows -> Package Manager Console*.

8. Set the DataAccess project as default project. Run `add-migration <migration_name>` to create a new Migrations files and directory. Files will be created in the project where DbContext can be found (which is DataAccess project). This command will create Migrations files which will modify the *real* database later, and Snapshot to record the *real* database current state.

9. If we want to update our database model, we can run `add-migration <migration_name>` again. The EF tools will automatically define which changes need to be made to the *real* database based on the snapshot.

10. To update the *real* database, we can run `update-database` command. Make sure the connection string in appsettings.json is defined and Azure SQL Database's Firewall is opened for our IP Address.