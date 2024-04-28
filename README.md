# Library Management System

This project is a Library Management System developed using .NET Core MVC, Repository Pattern, and SQL Server. It allows for CRUD operations on entities such as Books, Authors, Members, and BorrowedBooks. Additionally, operators can create, update, and delete Authors, Books, and Members. The system also includes functionalities for checking borrow history and authentication level-wise views.

## Database Schema

1. **Authors**
   - AuthorID (Primary Key, Auto Increment)
   - AuthorBio (String)

2. **Books**
   - BookID (Primary Key, Auto Increment)
   - Title (String)
   - ISBN (String)
   - AuthorID (Foreign Key)

3. **Members**
   - MemberID (Primary Key, Auto Increment)
   - FirstName (String)
   - LastName (String)
   - Email (String)

4. **BorrowedBooks**
   - BorrowID (Primary Key, Auto Increment)
   - MemberID (Foreign Key)
   - BookID (Foreign Key)
   - BorrowDate (Date)
   - ReturnDate (Date)
   - Status (String: Borrowed, Returned, Overdue)

## Relationships

- **Authors.AuthorID** is a foreign key referencing **Authors.AuthorID**.
- **Books.AuthorID** is a foreign key referencing **Authors.AuthorID**.
- **BorrowedBooks.MemberID** is a foreign key referencing **Members.MemberID**.
- **BorrowedBooks.BookID** is a foreign key referencing **Books.BookID**.

## Features

- **CRUD Operations**: Allows for creating, reading, updating, and deleting Authors, Books, and Members.
- **Borrow History**: Tracks the borrowing history of books by members.

- **Authorization**: Implements authorization to control access to various functionalities based on user roles.
- **Dependency Injection**: Utilizes dependency injection for better code maintainability and testability.

## Setup Instructions

1. Clone the repository.
2. Install .NET Core SDK if not already installed.
3. Setup the SQL Server database using the provided schema.
4. Update the connection string in the appsettings.json file.
5. Run the database migrations to create the database schema.
6. Run the application.

## Technologies Used

- .NET Core MVC
- C#
- SQL Server
- Entity Framework Core
- Repository Pattern
- Dependency Injection

## Contributors

- [Kamrul Hasan](https://github.com/khpolash)

## License

This project is licensed under the [MIT License](LICENSE).
