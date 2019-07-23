.NET Core 2.2
    Cross-Platform Framework for
        web Apps
        console app
ASP.NET Core 2.2
    .NET Core 2.2 Runtime
        dotnet.exe, executes .NET Core apps across all platforms
    .NET Core 2.2.300 SDK
        VS 2019 with latest udates
ASP.NET Core + EF Core for Application Development
===================================================================================================================================================
# ASP.NET Core 2.2
1. ASP.NET Core
   1. Web Forms + WEB API + MVC
   2. Sinle Http pipeline for all
   3. Integratin with Angular, React, React+Redux
2. ASP.NET Core MVC Project Structure
   1. Dependencies
      1. NuGet
         1. Internal and External Packages
      2. SDK 
         1. .NET Core SDK Libs
   2. Program.cs
      1. This has main() method() for Hosting ASP.NET Core App 
      2. The main() method is responsible for Coress-Platform Web Hosting using IWebHost interface
      3. The main() method loads 'StartUp' class from StartUp.cs
   3. StartUp.cs
      1. Handles Application Configuration from appsettings.json file using IConfiguration interface
      2. There exists te ConfigureServices() method having IServiceCollection interface as input parameter
         1.  This manages all dependencies in default Dependency Injection Container in ASP.NET Core using
             1.  Singleton
             2.  Scopped
             3.  Transient
         2.  Objects generally Registerd as Services are
             1.  Database objects with Data Access
             2.  Business Logic
             3.  Security
                 1.  Authentication 
                 2.  Authorization
             4.  Other configirations like
                 1.  Filters
                 2.  Message Formatters
                 3.  MVC 
         3. The Configure() method with IApplicationBuiler and IHostingEnvironment interfaces as Input parmeters
            1. IApplicatoinBuiler builds required object for Execution  
               1. Provides required objects from Services(DI) to execute app e.g. these objects are
                  1. Security
                  2. Errors aka Exceptions
                  3. Request Routing
                  4. etc. 
            2. IHostingEnvironmet provides required objects for Hosting application
               1. IsDevelopment
               2. IsProduction

==================================================================================================
# Programming with ASP.NET Core 2.2

1. Creating Models
   1. Entity Classes with public properties and relationship across them
      1. Apply Constraints using Data Annotataions
         1. System.ComponentModel.DataAnnotations.dll
            1. ValiationAttribute Class, the abstratc class
            2. RequiredAttribute
            3. CompareAttribute
            4. RegExAttribute
            5. StringLength
            6. EmailAttribute
            7. KeyAtribute
               1. Primary Identity Key
               2. 
   2. Data Access Logic
      1. Using EntityFramework, the Object-Relational-Mapping (ORM) by Microsoft
         1. Install-Package Microsoft.EntityFrameworkCore
         2. Microsoft.EntityFrameworkCore.Relational
         3. Microsoft.EntityFrameworkCore.SqlServer
         4. Microsot.EntityFrameworkCore.Tools 
   3. Business Logic

#======================================================================================================

# Using EF Core
1. EF Core Object Model
   1. DbContext
      1. Class for
         1. Establish Db Connection based on Connection String
         2. Manages Table Mappings of CLR Classes aka Entity Classes ith DB Tables using DbSet<T> class
         3. Manage and Commit Db Transactions using SaveChanges() or SaveChangesAsync() method
      2. DbSet<T>
         1. Represents class of name T map ith table of name T
         2. Provides method for CRUD operations
      3. Psuduo
         1. Consider ctx is an instance of DbContext and DbSet<Emp> is Emps
         2. To read all Employees 
            1. var emps = ctx.Emps.ToList();
         3. To search Emp based on Primary Key (P.K.)
            1. var emp = ctx.Emps.Find(P.K.);
            2. var emps = await ctx.Emps.FindAsync(P.K.)
         4. To Append new Record
            1. Create an instance of Emp
            2. Set its property values
            3. await ctx.Emps.AddAsync(<Instance of Emp>);
            4. Commit Trsanctions
            5. await ctx.SaveChangesAsync()
         5. To Update Record
            1. Option 1
               1. Search record based on P.K.
               2. Update all values of Searched Record
               3. Commit Transaction
            2. Option 2
               1. ctx.Entity<Emp>.State = EntityState.Modified;
               2. Commit Transactions
         6. To Delete Record
            1. Search Recods based on P.K.
            2. ctx.Emps.Remove(Searched Record)
            3. Commit Transaction
   2. EF Core Approaches
      1. Database First
         1. If database is production ready then use scaffold-database command to generate entities
      2. Code-First
         1. Create Entity Classes
         2. Constraint them
         3. Geneate Db-Migration Script 
            1. Generate Classes to Creae Table and Map Entity Class with Table
            2. Command
               1. dotnet ef migrations add <NAME> -c <DbCntextClass> 
         4. Apply Migration AKA Update Database
            1. Database will be generated if not exist else updated
            2. Command
               1. dotnet ef database update -c <DbContext-Class>



