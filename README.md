# Movie Consumer

## Objective

Develop an API that presents the next films to be released in the cinema.
### API site
  - https://developers.themoviedb.org/3/getting-started/introduction
### APIs consumed
  - https://developers.themoviedb.org/3/movies/get-upcoming
  - https://developers.themoviedb.org/3/genres/get-movie-list

## Instructions for use
Run the "dotnet run" command inside the Filmes.Api folder or run the project using IISExpress in visual studio 2019

Available APIs:
  - https: // localhost: 5001 / api / film (Retrieves films to be released with default parameters: language = pt-BR, page = 1 and region = "")
  - https: // localhost: 5001 / api / film? language = en-US (Retrieves films to be released according to the selected language example: [en-US, de, pt-BR])
  - https: // localhost: 5001 / api / film? language = en-US & page = 2 (Retrieves films to be released according to the selected language example: [en-US, de, pt-BR] and the page you want view example [2])

## Project Architecture

### Filme.Api
   - Web API layer responsible for intermediating clients with business rules (Filme.Core).
### Movie.Core
   - Business layer, responsible for any type of interaction that corresponds to the business. Has DTO, Services and Interfaces
### Movie.Utils
   - Layer responsible for infrastructure operations, consume API using rest sharp and configuration file.
### Movie.Tests
   - Layer responsible for integration tests between the structure of the Film Consumer application and The Movie Database API

## Standards Used
### TDD
 - Test Driven Development was used to improve security in future development and maintenance.
### DTO (Data Transfer Object)
 - It was used to represent the json structures consumed in the API responses.
### VM (View Model)
 - It was used to present the information of the DTOs returned from the Core project in the layer of the Web API.
### Dependency Injection
 - Used to avoid high compliance and facilitate testing.
### DRY (don't repeat yourself)
 - Encapsulate similar / equal logic in unique methods to try to minimize as much duplicate code.
### Single Responsibility Principle
 - Principle of single responsibility was used to simplify classes and methods so that each one has a minimum of responsibilities to facilitate the reuse of code and maintenance.
### Principles of Object Oriented Programming (Abstraction, Encapsulation, Inheritance)
  - Used to structure and create the Film Consumer project

## Libraries Used
 - http://restsharp.org/
   According to the website, one of the most popular libraries to work with REST API.
   It was chosen to facilitate interaction with the movie database's REST API. Because it has a large community, it is a constantly evolving library with few bugs.
 - https://www.newtonsoft.com/json
   NewtonSoft to facilitate serialization and deserialization.
 - https://www.nuget.org/packages/Microsoft.NET.Test.SDK
   Microsoft testing library
   
## Other information
- Test project made to perform integration tests with the consumed API.
- Run all tests every time you change something or to ensure that the integration part between the application and the API is working as expected.
