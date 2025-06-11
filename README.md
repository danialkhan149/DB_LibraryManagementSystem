# DB_LibraryManagementSystem

## Group Members

* **Hafiz Danial Ahmed Khan** - 241881

## Project Title

**Library Management System**

## Project Description

This is a comprehensive relational database system built using Microsoft SQL Server and C# Windows Forms. It simulates a real-world library management application with full support for data normalization, complex relationships, sample data population, CRUD operations, and a basic user interface.

## Features

* It has 13 normalized tables

* An EERD with generalization

* 10 realistic records per table

* CRUD SQL queries for Creating, Reading, Updating and Deleting records

* It also has a Frontend (Windows Forms) for basic data entry and reporting

## Setup Instructions

### 1. Database

* Open `SQL_Scripts.sql` file in SQL Server

* Run all queries to create all tables and insert sample data

* For Checking CRUD Queries:

  * Open `CRUD_Queries.sql` file in SQL Server and connect to the `libraryDB` Database. There are two kinds of CRUD Queries: Simple CRUD Queries and Stored       Procedures
  
  * To check stored Procedures, run the procedures first and then run the EXEC commands.

### 2. Frontend

* Open `LibraryWindowsFormsApp` solution in Visual Studio

* Update the connectionString in App.config as needed:
  string connectionString = "Data Source=localhost;Initial Catalog=LibraryDB;Integrated Security=True";

* Build and run the project

## Frontend Integration

* Developed in C# using Windows Forms

* Features:

  * Have 4 forms for MainMenu, View Books, Manage Genre, Manage Publisher

  * MainMenu can be used to access the rest of the forms

  * View Books:

    * View all books
  
    * Add a new member

    * Create a loan

    * Add new Staff

  * Manage Genre: Can Add, Update and Delete Genre Records

  * Manage Publisher: Can Add, Update, and Delete Publisher Records

* Connected directly to the SQL Server backend

## Submission
* Submitted on: 11/06/2025
