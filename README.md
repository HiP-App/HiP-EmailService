HiP-EmailService
======

HiP-EmailService is a MicroServer to send Emails which is developed by the project group [History in 
Paderborn](http://is.uni-paderborn.de/fachgebiete/fg-engels/lehre/ss15/hip-app/pg-hip-app.html).
It is developed to send Emails form the system 'History in Paderborn'. 

See the LICENSE file for licensing information.

See [the graphs page](https://github.com/HiP-App/HiP-EmailService/graphs/contributors) 
for a list of code contributions.

## Technolgies and Requirements:
HiP-EmailService is a REST API built on .NET Core 1.1 . Below are the requirements needed to build and develop this project,
 * [.NET Core](https://www.microsoft.com/net/core#windows) for Windows, Linux or macOS.
 
## IDE Options
 * Visual Studio 2017
 * Visual Studio Code with [C# extention](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).

## Getting started

 * Clone the repository.
 * Create a new file `appsettings.Development.json` at `scr/EmailService`. (See `src/EmailService/appsettings.Development.json.example`).
 * Update the new `appsettings.Development.json` file to match your needs.
 * To run using Visual Studio, just start the app with/without debugging.
 * To run through terminal,
  * Navigate to `src/EmailService`
  * Set Environment Variable 
		* Windows: `set ASPNETCORE_ENVIRONMENT=Development`
		* Linux/macOS: `export ASPNETCORE_ENVIRONMENT=Development`
  * Before your first run, execute `dotnet restore`
  * Execute `dotnet run`
  * `{{BaseUrl}}/swagger` will give information about the service endpoints.

### VS Code Setup

For getting the project to run with Visual Studio Code, you will have to execute a few more steps:

 * go to the Debug view and click the run button - you will be asked if a launch configuration should be created (click yes)
 * in the created `tasks.json`, add the following line: `"options": { "cwd": "${workspaceRoot}/src/EmailService" },`
 * in the created `launch.json`:
   * replace every occurence of `${workspaceRoot}` with `${workspaceRoot}/src/EmailService`
   * add `"env": { "ASPNETCORE_ENVIRONMENT": "Development" }` to your run configurations

## How to develop

 * You can [fork](https://help.github.com/articles/fork-a-repo/) or [clone](https://help.github.com/articles/cloning-a-repository/) our repo.
   * To submit patches you should fork and then [create a Pull Request](https://help.github.com/articles/using-pull-requests/)
   * If you are part of the project group, you can create new branches on the main repo as described [in our internal
     Confluence](https://atlassian-hip.cs.uni-paderborn.de/confluence/display/DCS/Conventions+for+git)


## How to submit Defects and Feature Proposals

Please write an email to [hip-app@campus.upb.de](mailto:hip-app@campus.upb.de).

## Documentation

Documentation is currently collected in our [internal Confluence](https://atlassian-hip.cs.upb.de/confluence/). If something is missing in 
this README, just [send an email](mailto:hip-app@campus.upb.de).


## Contact

> HiP (History in Paderborn) ist eine Plattform der:
> Universität Paderborn
> Warburger Str. 100
> 33098 Paderborn
> http://www.uni-paderborn.de
> Tel.: +49 5251 60-0

You can also [write an email](mailto:hip-app@campus.upb.de).
