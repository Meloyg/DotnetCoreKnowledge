# Dotnet Core Knowledge

## Table of Contents
- [Entity Framework Core](#entity-framework-core)
- [Design Patterns](#design-patterns)

## Entity Framework Core

### Description

This repository contains the EF core portion of the knowledge for dotnet development.

### Pre-requisites

- .NET Core SDK 8.0
- Entity Framework Core

### Topics

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

## Design Patterns

### Description

This repository contains the design patterns for dotnet development.

### Builder Pattern

- The director class is used to create the object with the help of the builder class.
- The builder pattern is used to create an object with multiple properties.
- It is used to create an object with multiple properties.
