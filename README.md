# Contact Management System

A desktop-based **Contact Management System** built with **C# and .NET Framework 4.8**. The solution uses a layered architecture to separate data access, business logic, and user-interface responsibilities.

The project currently contains a **Windows Forms application** as the main graphical client and a separate **console-based UI** for contact and country management.

## ✨ Features

### Contact Management
- Add new contacts.
- Update existing contacts.
- Delete contacts.
- Retrieve contacts by ID.
- Display all contacts.
- Check whether a contact exists.
- Store contact information such as:
  - First name
  - Last name
  - Email
  - Phone
  - Address
  - Country
- Associate contact images with contacts.

### Country Management
- Add countries.
- Update countries.
- Delete countries.
- Retrieve countries by ID or name.
- Display all countries.
- Validate country codes.
- Store country phone codes.

### Image Management
- Add contact images.
- Update contact images.
- Retrieve contact-image information.
- Delete contact images.
- Check whether an image/contact-image record exists.

### User Interfaces
- **Windows Forms UI** for graphical contact management.
- **Console UI** with reusable CRUD functionality for contacts and countries.
- Console input validation and formatted status messages.

## 🏗️ Architecture

The solution follows a layered architecture:

```text
┌─────────────────────────────────────────────┐
│              User Interface Layer           │
│                                             │
│  Windows Forms Application   Console UI     │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│            Business Logic Layer             │
│                                             │
│  Contact   Country   ContactsImage          │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│             Data Access Layer               │
│                                             │
│ ContactDB   CountryDB   ImageContactDB      │
│ DTOs        SQL Queries   DB Connection     │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│                SQL Server                   │
│                  ContactsDB                 │
└─────────────────────────────────────────────┘
```

### Project Structure

```text
ContactManagementSolution_v1/
│
├── BusinessLogicLayer/
│   ├── Contact.cs
│   ├── Country.cs
│   ├── ContactsImage.cs
│   ├── enMode.cs
│   └── BusinessLogicLayer.csproj
│
├── DataAccessLayer/
│   ├── ContactDB.cs
│   ├── CountryDB.cs
│   ├── ImageContactDB.cs
│   ├── DTOs/
│   │   ├── ContactDTO.cs
│   │   ├── CountryDTO.cs
│   │   └── ImageContactDTO.cs
│   └── DatabaseConfig/
│       ├── Contact_Queries.cs
│       ├── Country_Queries.cs
│       ├── ContactImage_Queries.cs
│       └── DataConnections/
│           └── ContactsDB_Connection.cs
│
├── ContactManagmrnt_WindowsFormsApp/
│   ├── ContactManagment_Form.cs
│   ├── AddEditForm.cs
│   ├── AddContact.cs
│   ├── EditContact.cs
│   └── Program.cs
│
├── UIContactConsole/
│   ├── Screens/
│   │   ├── AbstractCrud.cs
│   │   ├── ContactScreen.cs
│   │   ├── CountryScreen.cs
│   │   ├── Interfaces/
│   │   └── Delegates/
│   └── Program.cs
│
└── ContactManagementSolution_v1.sln
```

## 🛠️ Technologies

- **C#**
- **.NET Framework 4.8**
- **Windows Forms**
- **SQL Server**
- **ADO.NET**
- **Visual Studio**
- Object-oriented programming
- Layered architecture
- DTO-based data transfer
- Generic CRUD abstractions
- Delegates and interfaces

## 🗄️ Database

The application is designed to use a SQL Server database named:

```text
ContactsDB
```

The current connection configuration uses Windows Authentication:

```text
Server=.;
Database=ContactsDB;
Trusted_Connection=True;
TrustServerCertificate=True;
```

> **Important:** Make sure SQL Server is installed and the `ContactsDB` database exists before running the application.

The database access code is centralized in the `DataAccessLayer`, while SQL statements are organized under:

```text
DataAccessLayer/
└── DatabaseConfig/
```

## 🚀 Getting Started

### Prerequisites

Before running the project, install:

1. **Visual Studio** with .NET Framework development tools.
2. **.NET Framework 4.8 Developer Pack**.
3. **SQL Server**.
4. A SQL Server instance accessible using Windows Authentication.

### 1. Clone the Repository

```bash
git clone <your-repository-url>
```

Then open the solution:

```text
ContactManagementSolution_v1.sln
```

### 2. Configure SQL Server

Create or restore the required `ContactsDB` database and make sure the database contains the tables required by the data-access classes.

If your SQL Server instance is different from the default local instance, update:

```text
DataAccessLayer/DatabaseConfig/DataConnections/ContactsDB_Connection.cs
```

For example:

```csharp
public const string ContactsDBConnectionString =
    @"Server=YOUR_SERVER;
      Database=ContactsDB;
      Trusted_Connection=True;
      TrustServerCertificate=True;";
```

### 3. Build the Solution

In Visual Studio:

```text
Build → Build Solution
```

or use:

```text
Ctrl + Shift + B
```

### 4. Run the Windows Forms Application

Set:

```text
ContactManagmrnt_WindowsFormsApp
```

as the **Startup Project**, then press:

```text
F5
```

The application starts with the main contact-management form.

## 🖥️ Windows Forms Application

The Windows Forms client provides the main graphical interface for managing contacts.

The main form supports operations such as:

- Viewing contacts
- Adding contacts
- Updating contacts
- Deleting contacts
- Selecting a contact
- Managing contact images
- Working with country information

The application entry point is:

```text
ContactManagmrnt_WindowsFormsApp/Program.cs
```

## 💻 Console UI

The solution also contains a separate console project:

```text
UIContactConsole
```

It provides reusable CRUD functionality through:

```text
AbstractCrud<T>
```

and specialized screens:

```text
ContactScreen
CountryScreen
```

The console UI demonstrates:

- Generic programming
- Interfaces
- Delegates
- CRUD abstraction
- Input validation
- Console-based navigation

> The current `UIContactConsole/Program.cs` contains the screen startup calls commented out. Uncomment the appropriate screen call when you want to launch the console management UI.

For example:

```csharp
_contactScreen.Show();
```

or:

```csharp
_Country.Show();
```

## 🧩 Layer Responsibilities

### DataAccessLayer

Responsible for communication with SQL Server.

Examples:

```text
ContactDB
CountryDB
ImageContactDB
```

This layer also contains DTOs and database query configuration.

### BusinessLogicLayer

Contains application/domain logic for:

```text
Contact
Country
ContactsImage
```

It coordinates operations between the UI and the data-access layer.

### ContactManagmrnt_WindowsFormsApp

Provides the graphical user interface.

It communicates with the business layer instead of directly handling database operations.

### UIContactConsole

Provides a console-based interface and demonstrates reusable CRUD behavior through generic abstractions, interfaces, and delegates.

## 🔄 CRUD Flow

A typical operation follows this structure:

```text
User
 │
 ▼
Windows Forms / Console UI
 │
 ▼
Business Logic Layer
 │
 ▼
Data Access Layer
 │
 ▼
SQL Server
```

For example, adding a contact follows the general flow:

```text
Enter Contact Information
        ↓
Create Contact Object
        ↓
BusinessLogicLayer.Contact.Save()
        ↓
DataAccessLayer.ContactDB.AddNew()
        ↓
SQL Server
        ↓
Return Contact ID / Result
        ↓
Display Result to User
```

## 📌 Design Goals

The project is structured to practice and demonstrate:

- Separation of concerns
- Layered application architecture
- Reusable CRUD operations
- Object-oriented programming
- Database abstraction
- DTO usage
- UI/database separation
- Code reuse through generic classes
- Interfaces and delegates
- Windows Forms application development

## ⚠️ Current Project Notes

- The solution targets **.NET Framework 4.8**, not modern .NET (`.NET 6/7/8/9`).
- The SQL Server connection string is currently stored in source code and should be moved to configuration or a secure configuration mechanism for a production application.
- The repository should avoid committing generated folders such as `bin/`, `obj/`, and `.vs/`.
- Database setup scripts would make the project easier for other developers to reproduce.
- The console project's `Program.cs` currently has its screen startup calls commented out.

## 🔮 Possible Future Improvements

- Add authentication and authorization.
- Move the database connection string to configuration.
- Add database migration/setup scripts.
- Add stronger validation for contact fields.
- Improve error handling and logging.
- Add unit tests for business logic.
- Add repository/service abstractions.
- Improve dependency injection.
- Add search and filtering.
- Add pagination for large contact lists.
- Modernize the project to current .NET if appropriate.
- Improve the Windows Forms UI/UX.
- Add automated database initialization.

## 📄 License

This project is currently provided for educational and development purposes. Add a specific open-source license such as MIT if you intend to distribute the project under that license.

## 👨‍💻 Author

**Kazem Ayeed**

---

⭐ If you find this project useful, consider giving the repository a star on GitHub.
