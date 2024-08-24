# Entity Framework Core Knowledge

## Description

This repository contains the EF core portion of the knowledge for dotnet development.

## Pre-requisites

- .NET Core SDK 8.0
- Entity Framework Core

## Topics

### Migraions

Create your first migration
    
```bash 
dotnet ef migrations add InitialCreate
```
Create your database and schema

```bash
dotnet ef database update
```


### Entity Framework Core Interceptors
  - The interceptors are used to intercept the database operations like `SaveChanges`, `Query`, `ExecuteSqlCommand`, etc.
  - It helps to log the database operations, modify the database operations, etc.