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
   2. Single Http pipeline for all
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

#=================================================================================================
#Programming with ASP.NET Core 2.2
1. Creation of Model, Views and Controllers
   1. Models
      1. Entities
         1. Validations
         2. Custom Validations
      2. Data Access
      3. Repositories
      4. Dependency Injections
   2. Controllers
      1. Presentation Logic for MVC
      2. The Controller Contains 'Action Methods (?)'
         1. This Represents 'What is Requested and What is appening'
         2. These methods contains 
            1. calls to Repository
            2. Validation Check
            3. Exception Management
         3. These methods returns
            1. Views, ViewResult
            2. JSON, JsonResult
            3. Redirect To Other Action from same or different Controller
               1. RedirectToActionResult
            4. Http Status Result
               1. Ok, OkResult()
               2. NotFound NotFoundResult
               3. BadRequest
               4. NoContent
               5. Internal Server Error
            5. ObjectResult
               1. Serialized JSON Data
            6. Files
               1. FileContentResult
               2. FilePathResult
               3. FileStreamResult
         4. The 'IActionResult' is the interface returned from all Action Methods by default
         5. The Cotroller contauns HttpGet and HttpPost methods. HttpGet is Default
         6. Controller is used for
            1. Accepting Request
            2. Validate Request for Security
               1. Authorization
            3. Loads and executes Action Filter (?)
            4. Providing Action Method to Execute 
      3. ControllerBase Properties
         1. ModelStateDictionary
            1. Class used to validate the Entity Model class
         2. HttpRequest
            1. Current Http Request
         3. HttpContext
            1. The Current HttpContext
               1. Request
               2. Response
               3. Security
         4. ControllerContext
            1. The Current Controller (MVC/API)
         5. RouteData
            1. The MVC/API Request Routing
2. The View Generation aka Scaffolding
   1. The Razor Views integration between C# and Html .cshtml
   2. View Categories
      1. Strongly-Typed Views aka View with Model object
         1. Page View, Executed as Page
         2. Partial View, used as User-controls
      2. UnTyped Views aka Views with No Model
         1. Use these view for Fornt-End Code or Pure HTML and JavaScript
   3. Strongly Typed Views uses 'Tag-Helpers(?)'
      1. They are Custom Html Attributes, these are used for 'Binding' Model/Entity Class Property with UI element 
      2. Tage Helpers starts with 'asp-'
         1. asp-for, bind Model Property with <input type="text/radio/check">
         2. asp-controller, send request to contrller, generally used for <a>
         3. asp-action, decides which action method to be requested,  generally used for <a>
         4. asp-items, like DataSource, generates <option> for <select> element
         5. asp-route, asp-route-parameter
      3. We can use Html Helper Extension Methods
   4. View Templates
      1. List, accepts IEnumerable of Model class
      2. Create, acepts an empty Model class that represents new Model to be created
      3. Edit, accepts model to be Updated
      4. Delete, accepts model to be deleted
      5. Details, accepts read-only molde to be viewed
      6. Empty View, free hand View 
   5. The 'RazorPage<TModel>' is a base class for Razor Views
      1. TModel represnts the Model class and its type used while scaffolding View 
         1. e.g. Is View Template is 'List' and Model class is Category, then Model will be IEnumerable<Category> 
   6. A View can have only One Model clas during Scaffolding
      1. If we need to pass data from different Model to View then use ViewData or ViewBag objects of ASP.NET Core 
3. Validation of Models
   1. Default Validations using DataAnotations
      1. View is rendered with JQuery Validations for Server-Side validations to execute on client
   2. Custom Validation using Class derived from ValidationAttribute
      1. Override IsValid() method for writing logic for Custom Validations
4. ASP.NET Core state Management
   1. ViewData, of the type ViewDataDictionary. This is used to define K/V pair for data to be passed from Controller to View and Back
      1. ViewData["Key"] = Value;  
   2. ViewBag, is same as ViewData but this is Dynamic object and runtime it will be used as ViewDataDictionary.
      1. ViewBag.Key = Value;
   3. To show List of Data <select> on View use following
      1. <select asp-for="<Model-Property>" asp-items="new SelectList(Data Source, DataValueField, DataTextField)">
   4. ViewBag and ViewData are Scoped to Action Method
      1. If a action method is passing ViewData or ViewBag to View then all action methods returning to same view Must pass ViewData or ViewBag to the View.
5. Extensibility  
   1. Filters
      1. They are value added objects for Request procesing
      2. They are executed for a action method, a controller or Global scope for all controllers and actions
      3. IActionFiter Interface and ActionFilterAttribute abstract base class for custom filter  
   2. Error Management
      1. IExceptionFilter interface
         1. OnException(ExceptionContext context)
            1. ExceptionContext
               1. Handle Exception
               2. Write Logic to navigate to Error Page
6. Middlewares
   1. Security
      1. Microsoft.AspNetCore.Identity
         1. UserManager and IdentityUser
            1. Perform CRUD Operations on User using IdentitUser class
         2. RoleManager and IdentityRole
            1. CRUD operations on Role using IdentityRole
         3. SignInManager
            1. Manages LogIn and LogOut
      2. AuthorizeAttribute
         1. Used to provide and control secure access of the application
         2. Used to Manage Roles and Users
         3. Also provides Policy Management for Roles
         4. Add a Role Controller to create Roles
         5. Modify the Register.cshtml.cs for adding User in Role
         6. Create Role Policies for Role based Authorization
   2. Creation of  Custom Midlewares
      1. Middlewares are custom logic added in Request and Responses, they have their own capacility to generate Http Response
      2. Creation of Custom Middleware
         1. Decide Logic e.g. Exception, Security, Logging
         2. Define class, that is injected with 'RequestDelegate' object. This object is used to handle request and responses
         3. The RequestDelegate handled Current HttpContext. So we need 'InvokeAsync()' method taht contains logic for Middleware
         4. Create a Extesion class for IApplicationBuider that will register and use the custom middleware.
7. API in ASP.NET Core
   1. Controllers for REST API
   2. Used when the app need front-end Frameworks
      1. Angular, Vue, Ember, etc
      2. React, jQuery, etc.
   3. Contains Action Method that returns ObjectResult<T> e.g. Ok(), NotFound(), etc.
   4. Controller contains RouteAttribute [Route] for Routing Expression e.g. api/[controller]
   5. The 'ApiControllerAttribute' class is used to execute the JSON to CLR Object Mapping in POST and PUT Request
   6. By default WEB API accepts HttpGet Request only. To define request types use Http Method attributes
      1. HttpGet / HttpGet("<template string>")
         1. e.g. if URI is 
            1. http://server/mysite/api/CategoryAPI/10
               1. [HttpGet("{id}")]
      2. HttpPost / HttpPost("<template string>")
      3. HttpPut / HttpPut("<template string>")
      4. HttpDelete / HttpDelete("<template string>")
      5. The WEB API mus be configured for Cross-Origin-Resource-Sharing (CORS)
8. Deployment






