# Working with database connections and exceptions.

This repository is for a Microsoft TechNet article/code sample where the main purpose is to show VB.NET and C# developers a more elegant way to connect to databases and how to better handle runtime exception.

## Project names
Project names are very generic but when viewed in Solution Explorer within Visual Studio these 
projects are setup in several Solution folders which allows easiy identification for what each project is for.

![Figure 1](Assets/SolutionExplorer.png)

### NuGet packages
The folowing packages will be introduced in the Microsoft TechNet article.

[BaseConnectionLibrary](https://www.nuget.org/packages/BaseConnectionLibrary/)

This package contains classes for connecting to SQL-Server and OleDb compatible databases using managed data providers for VB.NET programming language.


**Package manager**
> Install-Package BaseConnectionLibrary -Version 1.0.0

Classes in this package are designed to work with the following databases.
- SQL-Server
- MS-Access
- Oracle
___

[DataProviderCommandHelpers](https://www.nuget.org/packages/DataProviderCommandHelpers/1.0.0#)

This package contains a language extension method to reveal a parameterized SQL statement written using a managed data provider in C# or VB.NET programming languages.

**Package manager**
> Install-Package DataProviderCommandHelpers -Version 1.0.0

___

#### Code samples
Examples are done in a conventual manner writing data access code directly in a form then move on to writing data access in data classes in two flavors.

**Requires for code samples**
- Microsoft SQL-Server installed.