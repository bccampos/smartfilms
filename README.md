# Smart Catalog Films 

The project involved the implementation of JWT (JSON Web Tokens) in an application designed to manage a film catalog using ASP.NET Core MVC, WebAPI, and XUnit for testing. To achieve a well-structured and maintainable codebase, I adopted the CQRS (Command Query Responsibility Segregation) and MediatR patterns, while adhering to Clean Architecture and Domain-Driven Design (DDD) principles. 

![image](https://github.com/bccampos/smartfilms/assets/36283909/8b707be3-de6c-4b85-a444-4b0fa3246966)


## How to use and run the project

Open the solution and build the application. After the successful build run, you can create the SmartCatalogFilms using the script in the main folder or you can run the command migration update-database. 
```bash
update-database
```
Also you will need to startup 3 projects (MVC / API / Identity.API)
![image](https://github.com/bccampos/smartfilms/assets/36283909/16efc3c2-bd43-4034-aea7-29a52fb4a004)

## :hammer:  API Core

![image](https://github.com/bccampos/smartfilms/assets/36283909/f600dae8-cde6-45b3-8df0-f83eecfb79e3)

- `Application`: Commands e Command Handler / Queries (Using EF)
- `Domain`: Entities / Value Objects / Interfaces / Validation 
- `Infrastructure`: Context EF / Repositories / Mappings / Migrations

## XUnit - Tests cover some business rules requirements 
![image](https://github.com/bccampos/smartfilms/assets/36283909/bc38301b-4e9e-4209-8669-b6697a6b8701)

## Swagger Catalog Films API ( with authorized configurated ) 
![image](https://github.com/bccampos/smartfilms/assets/36283909/6c9bbd20-a5a3-46e3-b74f-65eb6cbef748)

## Swagger Identity API 
![image](https://github.com/bccampos/smartfilms/assets/36283909/ffaf846a-0bae-442b-9640-8ed5805fcc42)

## MVC UI
> **_NOTE:_** The application has a user-friendly approach where the "List All" functionality is open for everyone to access without requiring authentication. However, when users click on a film to view its details, the system prompts them to log in for added security. Once logged in, users gain access to additional features such as adding new films, editing existing ones, removing films, and obtaining comprehensive film details.

### Before authentication
![image](https://github.com/bccampos/smartfilms/assets/36283909/6d43bfeb-7a55-4f89-ab51-b9b441029396)

### Login
![image](https://github.com/bccampos/smartfilms/assets/36283909/cf3d87d5-bcc8-4b06-b23a-a793af1d4545)

### After authentication
![image](https://github.com/bccampos/smartfilms/assets/36283909/24503782-aec8-4dcf-ba59-108bdc348221)

### Films details
![image](https://github.com/bccampos/smartfilms/assets/36283909/aa8150b5-bf97-4eb6-a8ed-7bf285d36664)

  


