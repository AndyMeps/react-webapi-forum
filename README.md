# react-webapi-forum

Demo site to combine React with ASP.NET Web Api

## Setup

* React front end uses `webpack-dev-server`, easiest way to run is to install [NPM Task Runner](https://visualstudiogallery.msdn.microsoft.com/8f2f2cbc-4da5-43ba-9de2-c9d08ade4941) 
and open the solution, NPM Task Runner will install dependencies and start up the webpack server automatically at: [localhost:8080](http://localhost:8080).
* Create the database and seed with some data by running `Update-Database` from the Package Manager Console.
* Start the API with the `Mepham.Forum.Api` project, running at: [localhost:54499](http://localhost:54499).
* Login with a user that can be found in the `Configuration.cs` file in `Mepham.Forum.DataAccess/Migrations`.

## Technology Used

* ASP.NET Web Api
* React
* Webpack and Babel
* Redux
* ES6
* Code first SQL Server Database
* Ninject
* AutoMapper
* Entity Framework