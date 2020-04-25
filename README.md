# Mono
Mono zadatak

What you should study 

Git

General - https://git-scm.com/doc
GitHub for Windows Users - https://mva.microsoft.com/en-US/training-courses/github-for-windows-users-16749?l=KTNeW39wC_6006218965
Git Succinctly - https://www.syncfusion.com/ebooks/git
GitFlow - https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow,  
A "quick" introduction to git - https://dev.to/jmourtada/a-quick-introduction-to-git
First aid git - http://firstaidgit.io/#/
C#

C# Fundamentals for Absolute Beginners - https://mva.microsoft.com/en-US/training-courses/c-fundamentals-for-absolute-beginners-16169?l=Lvld4EQIC_2706218949
C# Programming Yellow Book - http://www.robmiles.com/c-yellow-book/
Naming guidelines - https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines
C# tutorial for beginners - https://www.youtube.com/playlist?list=PLAC325451207E3105 
async/await
https://msdn.microsoft.com/library/hh191443%28vs.110%29.aspx?f=255&MSPPError=-2147217396
https://blog.stephencleary.com/2012/02/async-and-await.html
OOP via C#

General - http://www.c-sharpcorner.com/UploadFile/84c85b/object-oriented-programming-using-C-Sharp-net/ 
General - https://www.youtube.com/watch?v=e7Yj6vLyYOI 
Architecture

Design Patterns - http://www.dofactory.com/net/design-patterns 
Dependency Injection

General
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection
https://msdn.microsoft.com/en-us/library/ff921152.aspx
(Ninject based) - http://www.mono.hr/Pdf/Dependency-Injection-in-practice-CodeCAMP.pdf 
(AutoFac based) - https://autofac.readthedocs.io/en/latest/getting-started/index.html
Examples: https://github.com/MonoSoftware/DependencyInjectionInPractice (Follow tags for step by step guide)
Dependency Injection in ASP.NET Core 2.0 - https://code.msdn.microsoft.com/Dependency-Injection-in-ce9c8edb
Dependency Injection - https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Dependency-Injection
Entry level books (ASP.NET MVC, ASP. NET Web API, Entity framework, Angular JS ...)

https://www.syncfusion.com/resources/techportal/ebooks 
ORMs

SQL
SQL Database Fundamentals - https://mva.microsoft.com/en-US/training-courses/sql-database-fundamentals-16944?l=w7qq6nAID_6805121157
SQL Queries Succinctly - https://www.syncfusion.com/ebooks/sql_queries_succinctly
 

EF (Entity Framework)
Entity Framework Core - https://www.syncfusion.com/ebooks/entity_frame_work_core_succinctly
http://www.asp.net/entity-framework
https://channel9.msdn.com/Blogs/Seth-Juarez/An-Introduction-to-Entity-Framework-with-Rowan-Miller
https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
https://channel9.msdn.com/Blogs/EF/Code-First-to-Existing-Database-EF6-1-Onwards-
https://www.youtube.com/watch?v=Z7713GBhi4k Part 1 What is Entity Framework
https://www.youtube.com/watch?v=kbH-rqMl8cE Part 3 Entity Framework Code First Approach
ASP.NET MVC 

ASP.NET Core - Beginner - https://mva.microsoft.com/en-US/training-courses/aspnet-core-beginner-18153?l=VM5gy36dE_6611787171
Little ASP.NET Core Book - https://s3.amazonaws.com/recaffeinate-files/LittleAspNetCoreBook.pdf

 

Note: You don't have to know every detail from the above articles and videos they are here for you to learn new stuff and to help you build your test project.

What is your test project

Summary: develop a minimalistic application of your choice by following technologies and concepts mentioned above and requirements defined below.

Requirements

Create a database with following elements
VehicleMake (Id,Name,Abrv) e.g. BMW,Ford,Volkswagen,
VehicleModel (Id,MakeId,Name,Abrv) e.g. 128,325,X5 (BWM), 
Create the solution (back-end) with following projects and elements
Project.Service
EF models for above database tables
VehicleService class - CRUD for Make and Model (Sorting, Filtering & Paging)
Project.MVC 
Make administration view (CRUD with Sorting, Filtering & Paging)
Model administration view (CRUD with Sorting, Filtering & Paging)
Filtering by Make

Implementation details 

async/await should be enforced in all layers (async all the way)
all classes should be abstracted (have interfaces so that they can be unit tested)
IoC (Inversion of Control) and DI (Dependency Injection) should be enforced in all layers (constructor injection preferable) 
Ninject DI container should be used (https://github.com/ninject/ninject/wiki)
Mapping should be done by using AutoMapper (http://automapper.org/)
EF 6, Core or above with Code First approach (EF Power Tools can be used) should be used  
MVC project
return view models rather than EF database models
return proper Http status codes

Candidate should open a dedicated GitHub repository for the purpose of test project and occasionally report for code review.

Note: Try to use agile approach while building project, our suggestion is to build services with EF database models for above elements and report for first code review, then MVC project for the same part of the application following with report for second code review.

Lijepi pozdrav,
Jelena Tufeković

 
Attachments area
Preview YouTube video C# Object Oriented Programming Basic to Advance

Preview YouTube video Part 1 What is Entity Framework

Preview YouTube video Part 3 Entity Framework Code First Approach



https://www.youtube.com/watch?v=Z7713GBhi4k

https://www.youtube.com/watch?v=Z7713GBhi4k

https://www.youtube.com/watch?v=kbH-rqMl8cE


------------------------------------------------------------------------------------
majne : 
https://www.c-sharpcorner.com/article/implement-crud-operations-with-sorting-searching-and-paging-using-ef-core-in-as/

https://www.c-sharpcorner.com/article/implement-crud-operations-with-sorting-searching-and-paging-using-ef-core-in-as/

https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx

https://www.entityframeworktutorial.net/entityframework6/dbcontext.aspx


.NET core :

  https://www.devart.com/dotconnect/oracle/docs/Tutorial_EFCore_NETCore.html

  https://www.c-sharpcorner.com/article/understanding-entity-framework-core-and-code-first-migrations-in-ef-core/



  .net core and EF

  https://code-maze.com/net-core-web-development-part4/#context

  https://code-maze.com/net-core-web-api-ef-core-code-first/



  .net core offical

  https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-3.1&tabs=visual-studio



  https://www.youtube.com/watch?v=nN9jOORIFtc&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=48&t=0s




DI
https://www.youtube.com/watch?v=EPv9-cHEmQw

CLI

  dotnet tool uninstall --global dotnet-ef

followed by

dotnet tool install --global dotnet-ef --version 2.1.0


.net core CLI crossplaorm

View > others > package manegr console

commands 

get-help about_entityframeworkcore - Provides entity framework core help
Add-Migration - Adds a new migration
Update-Database - Updates the database to a specified migration

Please note : You can use get-help command with any of the above commands. For example get-help Add-Migration provides help for Add-Migration command.


Automapper
https://www.youtube.com/watch?v=GCbmUpyzkQw

https://www.youtube.com/watch?v=5WP36DIwdlI

//sve
https://www.youtube.com/watch?v=xD-33-6GLYo

//instalirao :

https://www.nuget.org/packages/X.PagedList.Mvc.Core/
https://www.youtube.com/watch?v=LpT0KL2bOAM

https://www.youtube.com/watch?v=LpT0KL2bOAM



#
https://www.mikesdotnetting.com/article/315/viewmodels-and-automapper-in-razor-pages