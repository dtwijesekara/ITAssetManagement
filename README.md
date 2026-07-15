# IT Asset Management

![C#](https://img.shields.io/badge/C%23-WinForms-68217A)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.7.2-blue)
![SQL Server](https://img.shields.io/badge/Database-SQL_Server-CC2927)

IT Asset Management is a Windows Forms application for tracking IT assets and running vulnerability audits against a SQL Server database. It supports role-based access, asset registration, employee assignment, and security reporting for vulnerable endpoints.

## Features

- Secure login with SHA-256 password hashing
- Role-based access control:
  - **Admin**: add, delete, and manage assets
  - **Auditor**: run vulnerability audits and export reports
  - **ReadOnly**: view-only access
- Asset management for:
  - **Laptops**
  - **Routers**
- Employee assignment for assets
- Vulnerability detection based on deprecated operating systems
- Security status calculation per asset type
- Audit results with severity highlighting
- Export audit reports to text files

## Tech Stack

- C# / WinForms
- .NET Framework 4.7.2
- SQL Server Express
- ADO.NET (`System.Data.SqlClient`)

## Project Structure

- `Program.cs` - application entry point
- `Forms/` - UI screens for login, assets, and audits
- `BusinessLogic/` - asset models and security rules
- `DataAccess/` - SQL Server access and audit queries
- `DatabaseSchema.sql` - database creation and seed data
- `App.config` - connection string and app settings

## Database Setup

1. Install SQL Server Express or another compatible SQL Server instance.
2. Open `DatabaseSchema.sql` in SQL Server Management Studio.
3. Run the script to create:
   - `ITAssetManagementDB`
   - `tbl_Users`
   - `tbl_Employees`
   - `tbl_Assets`
   - `tbl_Vulnerabilities`
4. Update `App.config` if your SQL Server instance name is different:

```xml
<add name="ITAssetManagementDB"
     connectionString="Server=.\SQLEXPRESS;Database=ITAssetManagementDB;Integrated Security=True;TrustServerCertificate=True;"
     providerName="System.Data.SqlClient" />
```

## Running the Application

1. Open `ITAssetManagement.slnx` in Visual Studio.
2. Restore/build the solution.
3. Make sure the database is created and seeded.
4. Start the app.

## Default Seed Data

The schema script includes:

- sample users
- sample employees
- sample assets
- sample vulnerability definitions

## How It Works

- Users log in through `LoginForm`.
- Admins can add or delete assets from `MainForm`.
- Asset details are stored in SQL Server.
- `AuditForm` finds assets whose OS versions match known vulnerable versions and shows severity levels.
- Audit reports can be exported to a `.txt` file.

## Security Rules

The application uses built-in rules in the asset models:

- **Laptop**: checks for deprecated OS versions, disk encryption, and corporate management
- **Router**: checks for default credentials, firewall status, and firmware tracking

## Future Improvements

- Add screenshot-based asset inventory
- Support edit/update asset workflows
- Add richer report export formats such as PDF or CSV
- Replace hardcoded security rules with configurable policies

## License

No license has been specified yet.
