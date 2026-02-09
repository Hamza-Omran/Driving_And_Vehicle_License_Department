# Driving and Vehicle License Department (DVLD) System

## Overview

The **Driving and Vehicle License Department (DVLD) System** is a comprehensive desktop application designed to manage all operations related to driving licenses, vehicle licenses, and driver records. Built using C# and the .NET Framework, this system implements a robust 3-layer architecture to ensure maintainability, scalability, and separation of concerns.

The system streamlines the entire lifecycle of driving license management, from applicant registration to license issuance, renewal, replacement, and detention. It also handles various test appointments, international licenses, and maintains comprehensive records of people, drivers, and users.

---

## System Architecture

The application follows a **3-Layer Architecture** pattern, which separates the system into three distinct layers:

```
┌─────────────────────────────────────────┐
│      PRESENTATION LAYER (UI)           │
│  - Windows Forms                        │
│  - User Interface Components            │
│  - Forms and Controls                   │
└──────────────┬──────────────────────────┘
               │
               ├─ User Input/Output
               │
┌──────────────▼──────────────────────────┐
│      BUSINESS LOGIC LAYER (BLL)         │
│  - Business Rules                       │
│  - Validations                          │
│  - Domain Models                        │
│  - Application Logic                    │
└──────────────┬──────────────────────────┘
               │
               ├─ Data Operations
               │
┌──────────────▼──────────────────────────┐
│      DATA ACCESS LAYER (DAL)            │
│  - Database Connection                  │
│  - SQL Queries                          │
│  - CRUD Operations                      │
│  - SQL Server Database                  │
└─────────────────────────────────────────┘
```

---

## Layer 1: Data Access Layer (DAL)

### Purpose
The Data Access Layer is responsible for all direct interactions with the SQL Server database. It encapsulates database operations and provides a clean interface for the Business Layer to perform CRUD (Create, Read, Update, Delete) operations.

### Key Responsibilities
- Execute SQL queries and stored procedures
- Manage database connections
- Handle data retrieval and persistence
- Convert database records to data transfer objects

### Core Components

#### 1. **clsPersonData** 
Manages all person-related database operations.
- `GetPersonInfoByID()` - Retrieve person by ID
- `GetPersonInfoByNationalNo()` - Retrieve person by national number
- `AddPerson()` - Insert new person record
- `UpdatePerson()` - Update existing person
- `DeletePerson()` - Remove person record
- `GetAllPersons()` - Retrieve all persons
- `IsPersonExist()` - Check person existence

#### 2. **clsApplicationsData**
Handles application database operations.
- `GetApplicationByID()` - Retrieve application details
- `AddApplication()` - Create new application
- `UpdateApplication()` - Modify application
- `DeleteApplication()` - Remove application
- `UpdateStatus()` - Change application status

#### 3. **clsLocalDrivingLicenseApplicationData**
Manages local driving license application data.
- Handles local DL application CRUD operations
- Manages test appointments
- Tracks application progress

#### 4. **clsLicensesData**
Manages all license-related data operations.
- `GetLicenseByID()` - Retrieve license information
- `AddLicense()` - Create new license
- `UpdateLicense()` - Modify license
- `GetActiveLicenseIDByPersonID()` - Find active licenses
- `DeactivateLicense()` - Deactivate expired or replaced licenses

#### 5. **clsTestsDate** & **clsTestsAppointmentData**
Handle test scheduling and results.
- Manage test appointments (Vision, Written, Practical)
- Store test results
- Track test attempts

#### 6. **clsDriversData**
Manages driver records.
- `GetDriverByID()` - Retrieve driver information
- `GetDriverByPersonID()` - Find driver by person
- `AddDriver()` - Create new driver record
- `UpdateDriver()` - Modify driver information

#### 7. **clsUsersData**
Handles system users (administrators).
- `GetUserByID()` - Retrieve user details
- `GetUserByUsername()` - Find user by username
- `AddUser()` - Create new system user
- `UpdateUser()` - Modify user information
- `DeleteUser()` - Remove user account
- `ValidateUser()` - Authenticate user credentials

#### 8. **clsInternationalData**
Manages international driving license data.
- International license CRUD operations
- Track international license issuance

#### 9. **clsDetainedLicensesData**
Handles detained license records.
- `DetainLicense()` - Create detention record
- `ReleaseDetainedLicense()` - Release license
- `GetDetainedLicenseByID()` - Retrieve detention details
- `IsLicenseDetained()` - Check detention status

#### 10. **Supporting Data Classes**
- **clsCountryData** - Country reference data
- **clsLicenseClassesData** - License categories (A, B, C, etc.)
- **clsApplicationTypesData** - Application types and fees
- **clsTestTypesData** - Test types and configurations
- **clsSettingsData** - System configuration settings

#### 11. **clsDataAccessSettings**
Central configuration for database connection strings.

---

## Layer 2: Business Logic Layer (BLL)

### Purpose
The Business Logic Layer contains all business rules, validations, and application logic. It acts as an intermediary between the Presentation Layer and the Data Access Layer, ensuring that all business constraints are enforced.

### Key Responsibilities
- Enforce business rules and validations
- Implement domain logic
- Coordinate data access operations
- Provide object-oriented interfaces to the UI layer
- Handle complex workflows

### Core Entities and Their Capabilities

#### 1. **clsPerson**
Represents a person in the system (applicant, driver, or user).

**Properties:**
- PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName
- DateOfBirth, Gender, Address, Phone, Email
- NationalityCountryID, ImagePath

**Capabilities:**
- `Find()` - Locate person by ID or national number
- `Save()` - Add or update person information
- `Delete()` - Remove person record
- Full name concatenation
- Age calculation
- Image management

#### 2. **clsApplications**
Base class for all application types.

**Properties:**
- ApplicationID, ApplicantPersonID, ApplicationDate
- ApplicationTypeID, ApplicationStatus, PaidFees
- CreatedByUserID, LastStatusDate

**Application Statuses:**
- New
- Cancelled
- Completed

**Capabilities:**
- `Save()` - Create or update application
- `Cancel()` - Cancel pending application
- `SetComplete()` - Mark application as completed
- `Delete()` - Remove application
- Status management and tracking

#### 3. **clsLocalDrivingLicenseApplication**
Manages local driving license applications (inherits from Applications).

**Additional Properties:**
- LocalDrivingLicenseApplicationID
- LicenseClassID
- Test pass status (Vision, Written, Practical)

**Capabilities:**
- Schedule and manage test appointments
- Track test results
- Determine application completion based on passed tests
- Issue driving license upon completion
- Validate test prerequisites

#### 4. **clsLicenses**
Represents a driving license.

**Properties:**
- LicenseID, ApplicationID, DriverID
- LicenseClassID, IssueDate, ExpirationDate
- Notes, PaidFees, IsActive
- IssueReason (FirstTime, Renew, ReplacementDamaged, ReplacementLost)
- CreatedByUserID

**Capabilities:**
- `Find()` - Retrieve license by ID
- `Save()` - Issue or update license
- `RenewLicense()` - Renew expired license
- `ReplaceLicense()` - Replace lost or damaged license
- `DetainLicense()` - Detain license for violations
- `ReleaseDetainedLicense()` - Release detained license
- `IssueInternationalLicense()` - Create international license
- `DeactivateCurrentLicense()` - Mark license as inactive
- `IsLicenseExpired()` - Check expiration status
- `GetActiveLicenseIDByPersonID()` - Find active license for a person

#### 5. **clsTests**
Represents a test result.

**Properties:**
- TestID, TestAppointmentID, TestResult
- Notes, CreatedByUserID

**Capabilities:**
- `Save()` - Record test result
- `Find()` - Retrieve test details
- Link to test appointments

#### 6. **clsTestsAppointments**
Manages test scheduling.

**Properties:**
- TestAppointmentID, TestTypeID
- LocalDrivingLicenseApplicationID
- AppointmentDate, PaidFees
- CreatedByUserID, IsLocked

**Test Types:**
- Vision Test
- Written Test
- Practical Driving Test

**Capabilities:**
- `Save()` - Schedule or update appointment
- `Find()` - Retrieve appointment details
- Lock appointment after test is taken
- Manage retake fees

#### 7. **clsDrivers**
Represents a driver in the system.

**Properties:**
- DriverID, PersonID, CreatedByUserID
- CreatedDate

**Capabilities:**
- `Find()` - Locate driver by ID or person ID
- `Save()` - Create or update driver record
- Link person to driver status
- Track all licenses for a driver

#### 8. **clsUsers**
System users (administrators/staff).

**Properties:**
- UserID, PersonID, Username, Password
- IsActive, CreatedByUserID

**Capabilities:**
- `Find()` - Retrieve user by ID or username
- `Save()` - Create or update user account
- `Delete()` - Remove user
- User authentication
- Password management
- Access control

#### 9. **clsInternationalLicense**
International driving license.

**Properties:**
- InternationalLicenseID, ApplicationID
- DriverID, IssuedUsingLocalLicenseID
- IssueDate, ExpirationDate
- IsActive, CreatedByUserID

**Capabilities:**
- `Save()` - Issue international license
- `Find()` - Retrieve international license
- Validate local license prerequisite
- Track international license validity

#### 10. **clsDetainedLicenses**
Manages license detentions.

**Properties:**
- DetainID, LicenseID, DetainDate
- FineFees, CreatedByUserID
- IsReleased, ReleaseDate
- ReleasedByUserID, ReleaseApplicationID

**Capabilities:**
- `Save()` - Create detention record
- `Find()` - Retrieve detention details
- `ReleaseDetainedLicense()` - Process release with payment
- Track detention history

#### 11. **Supporting Business Classes**
- **clsApplicationTypes** - Manage application types and fees
- **clsTestTypes** - Test type configurations and fees
- **clsLicenseClasses** - License categories (Motorcycle, Small Vehicle, Heavy Vehicle, etc.)
- **clsCountry** - Country reference data
- **clsSettings** - System configuration

---

## Layer 3: Presentation Layer (UI)

### Purpose
The Presentation Layer provides the user interface through which users interact with the system. Built using Windows Forms, it displays data, captures user input, and coordinates user workflows.

### Key Responsibilities
- Display data to users
- Capture and validate user input
- Navigate between different screens
- Handle user events and actions
- Display error messages and confirmations

### Main Modules

#### 1. **Login Module**
- `frmLogin` - User authentication and system access

#### 2. **People Management**
- `frmManagePeople` - List and search all persons
- `frmAddOrEditPerson` - Add new person or edit existing
- `frmPersonInfo` - Display person details
  
**Features:**
- Search by ID, national number, or name
- Add/Edit person information
- Attach person photo
- Manage contact details

#### 3. **Users Management**
- `frmManageUsers` - List all system users
- `frmAddOrEditUser` - Create or modify user accounts
- `frmChangePassword` - Update user password
- `frmUserInfo` - Display user details

**Features:**
- User CRUD operations
- Role and permission management
- Activate/Deactivate users
- Password management

#### 4. **Applications Module**

##### 4.1 Local Driving License Applications
- `frmManageLocalDrivingApplications` - List all local DL applications
- `frmAddOrEditLDL` - Create or update local DL application
- `frmShowApplicationDetails` - View application information
- `frmRenewLocalDrivingLicense` - Renew expired license
- `frmReplaceLicense` - Replace lost or damaged license

**Features:**
- Create new driving license applications
- Schedule test appointments
- Track application progress
- Cancel applications
- Issue licenses

##### 4.2 International License Applications
- `frmManageInternationalLicenses` - List international licenses
- `frmNewInternationalLicenseApplication` - Issue international license
- `frmInternationalLicenseInfo` - View international license details

**Features:**
- Issue international licenses based on local licenses
- Track international license validity
- Search and filter

##### 4.3 Application Types Management
- `frmManageApplicationTypes` - View all application types
- `frmUpdateApplicationType` - Modify application fees

**Features:**
- Configure application types
- Update service fees

#### 5. **Tests Module**
- `frmManageAppointmentsTests` - List test appointments
- `frmAddOrEditTestAppointment` - Schedule or modify test
- `frmTakeTest` - Conduct and record test
- `frmManageTestTypes` - Manage test configurations
- `frmUpdateTestType` - Update test fees

**Features:**
- Schedule Vision, Written, and Practical tests
- Record test results (Pass/Fail)
- Manage retake fees
- Lock appointments after test completion

#### 6. **Licenses Module**

##### 6.1 License Management
- `frmShowLicense` - Display license details
- `frmShowLicenseHistory` - View license history for a person
- `frmIssueLicense` - Issue new license

**Features:**
- View active and inactive licenses
- Display license details
- Track license history

##### 6.2 Detained Licenses
- `frmManageDetainedLicenses` - List all detained licenses
- `frmDetainLicense` - Detain a license
- `frmReleaseDetainLicense` - Release detained license

**Features:**
- Detain licenses for violations
- Set fine amounts
- Release licenses upon payment
- Track detention history

#### 7. **Drivers Module**
- `frmManageDrivers` - List all drivers
- `frmShowDriverInfo` - Display driver information

**Features:**
- View all drivers in the system
- Search drivers
- Display driver licenses

#### 8. **Main Dashboard**
- `frmMain` - Central navigation hub

**Features:**
- Access all system modules
- Quick navigation menu
- User session management
- System overview

---

## Core Workflows

### 1. New Driving License Application Workflow

```
1. Register Person (if not exists)
   └─> frmAddOrEditPerson

2. Create Local Driving License Application
   └─> frmAddOrEditLDL
       - Select applicant person
       - Choose license class
       - Pay application fee

3. Schedule Vision Test
   └─> frmAddOrEditTestAppointment
       - Set appointment date
       - Pay test fee

4. Take Vision Test
   └─> frmTakeTest
       - Record result (Pass/Fail)
       - If fail, schedule retake

5. Schedule Written Test (after passing Vision)
   └─> frmAddOrEditTestAppointment

6. Take Written Test
   └─> frmTakeTest

7. Schedule Practical Test (after passing Written)
   └─> frmAddOrEditTestAppointment

8. Take Practical Test
   └─> frmTakeTest

9. Issue Driving License (after passing all tests)
   └─> frmIssueLicense
       - Generate license
       - Set validity period
       - Create driver record (if first license)
```

### 2. License Renewal Workflow

```
1. Find Person and Active License
   └─> frmRenewLocalDrivingLicense

2. Verify License Eligibility
   - Check if license is not detained
   - Check license class

3. Create Renewal Application
   - Pay renewal fee
   - Set new expiration date

4. Issue Renewed License
   - Deactivate old license
   - Create new license record
```

### 3. International License Workflow

```
1. Verify Local License
   - Must have active local license
   - License must not be detained
   - License must not be expired

2. Create International License Application
   └─> frmNewInternationalLicenseApplication
       - Pay application fee

3. Issue International License
   - Valid for 1 year
   - Linked to local license
```

### 4. License Detention and Release Workflow

```
Detention:
1. Select Active License
   └─> frmDetainLicense

2. Set Fine Amount

3. Create Detention Record
   - License becomes detained
   - Cannot renew or use

Release:
1. Select Detained License
   └─> frmReleaseDetainLicense

2. Pay Fine and Release Fee

3. Release License
   - Create release application
   - License becomes active again
```

---

## Key Features

### 1. **Comprehensive Person Management**
- Store complete person details
- National ID validation
- Photo management
- Contact information

### 2. **Multi-Test System**
- Vision Test - Basic sight verification
- Written Test - Traffic rules and regulations
- Practical Test - Actual driving skills
- Retake management with fees

### 3. **Application Lifecycle Management**
- Application creation and tracking
- Status management (New, Cancelled, Completed)
- Application history
- Fee management

### 4. **License Operations**
- First-time issuance
- License renewal
- License replacement (Lost/Damaged)
- International license issuance
- License detention and release
- License history tracking

### 5. **User and Security**
- User authentication
- User management
- Password protection
- Activity logging (CreatedByUserID tracking)

### 6. **Financial Tracking**
- Application fees
- Test fees
- Renewal fees
- Replacement fees
- Detention fines
- Release fees

### 7. **Validation and Business Rules**
- Age validation for license classes
- Test prerequisites (must pass Vision before Written)
- License validity checks
- Detention status verification
- National ID uniqueness

---

## Database Entities

The system uses SQL Server with approximately **15+ core tables**:

1. **People** - Person information
2. **Countries** - Country reference data
3. **Users** - System users
4. **ApplicationTypes** - Types of applications and fees
5. **Applications** - Base applications table
6. **LocalDrivingLicenseApplications** - Local DL applications
7. **TestTypes** - Test configurations
8. **TestAppointments** - Scheduled tests
9. **Tests** - Test results
10. **LicenseClasses** - License categories
11. **Drivers** - Driver records
12. **Licenses** - Issued licenses
13. **InternationalLicenses** - International licenses
14. **DetainedLicenses** - Detained license records
15. **Settings** - System configuration

---

## Technology Stack

- **Language:** C# (.NET Framework)
- **UI Framework:** Windows Forms
- **Database:** Microsoft SQL Server
- **Architecture:** 3-Layer (DAL, BLL, Presentation)
- **Data Access:** ADO.NET (SqlConnection, SqlCommand, SqlDataReader)
- **Design Patterns:** 
  - Repository Pattern (DAL)
  - Business Object Pattern (BLL)
  - MVC-inspired separation

---

## Project Structure

```
Driving_And_Vehicle_License_Department-master/
│
├── DVLD Data Access Layer/
│   ├── clsPersonData.cs
│   ├── clsApplicationsData.cs
│   ├── clsLocalDrivingLicenseApplicationData.cs
│   ├── clsLicensesData.cs
│   ├── clsDriversData.cs
│   ├── clsUsersData.cs
│   ├── clsTestsDate.cs
│   ├── clsTestsAppointmentData.cs
│   ├── clsInternationalData.cs
│   ├── clsDetainedLicensesData.cs
│   ├── clsCountryData.cs
│   ├── clsLicenseClassesData.cs
│   ├── clsApplicationTypesData.cs
│   ├── clsTestTypesData.cs
│   ├── clsSettingsData.cs
│   ├── clsDataAccessSettings.cs
│   └── clsUtil.cs
│
├── DVLD Business Layer/
│   ├── clsPerson.cs
│   ├── clsApplications.cs
│   ├── clsLocalDrivingLicenseApplication.cs
│   ├── clsLicenses.cs
│   ├── clsDrivers.cs
│   ├── clsUsers.cs
│   ├── clsTests.cs
│   ├── clsTestsAppointments.cs
│   ├── clsInternationalLicense.cs
│   ├── clsDetainedLicenses.cs
│   ├── clsCountry.cs
│   ├── clsLicenseClasses.cs
│   ├── clsApplicationTypes.cs
│   ├── clsTestTypes.cs
│   └── clsSettings.cs
│
├── DVLD Presentation Layer/
│   ├── Login/
│   │   └── frmLogin.cs
│   │
│   ├── People/
│   │   ├── frmManagePeople.cs
│   │   ├── frmAddOrEditPerson.cs
│   │   └── frmPersonInfo.cs
│   │
│   ├── Users/
│   │   ├── frmManageUsers.cs
│   │   ├── frmAddOrEditUser.cs
│   │   ├── frmChangePassword.cs
│   │   └── frmUserInfo.cs
│   │
│   ├── Applications/
│   │   ├── Local Driving License/
│   │   │   ├── frmManageLocalDrivingApplications.cs
│   │   │   ├── frmAddOrEditLDL.cs
│   │   │   ├── frmShowApplicationDetails.cs
│   │   │   └── frmRenewLocalDrivingLicense.cs
│   │   │
│   │   ├── International Driving License/
│   │   │   ├── frmManageInternationalLicenses.cs
│   │   │   ├── frmNewInternationalLicenseApplication.cs
│   │   │   └── frmInternationalLicenseInfo.cs
│   │   │
│   │   ├── Replace Licenses/
│   │   │   └── frmReplaceLicense.cs
│   │   │
│   │   └── ManageApplicationsTypes/
│   │       ├── frmManageApplicationTypes.cs
│   │       └── frmUpdateApplicationType.cs
│   │
│   ├── Tests/
│   │   ├── frmManageAppointmentsTests.cs
│   │   ├── frmAddOrEditTestAppointment.cs
│   │   ├── frmTakeTest.cs
│   │   ├── Test Types/
│   │   │   ├── frmManageTestTypes.cs
│   │   │   └── frmUpdateTestType.cs
│   │
│   ├── Licenses/
│   │   ├── frmShowLicense.cs
│   │   ├── frmShowLicenseHistory.cs
│   │   ├── frmIssueLicense.cs
│   │   └── Detain/
│   │       ├── frmManageDetainedLicenses.cs
│   │       ├── frmDetainLicense.cs
│   │       └── frmReleaseDetainLicense.cs
│   │
│   ├── Drivers/
│   │   ├── frmManageDrivers.cs
│   │   └── frmShowDriverInfo.cs
│   │
│   ├── Global Classes/
│   │   └── (Shared utilities and helpers)
│   │
│   ├── frmMain.cs
│   └── Program.cs
│
├── DVLD.bak (Database backup)
├── DVLD Presentation Layer.sln
└── README.md
```

---

## Setup and Installation

### Prerequisites
- Windows Operating System
- .NET Framework 4.7.2 or higher
- Microsoft SQL Server 2014 or higher
- Visual Studio 2017 or higher (for development)

### Installation Steps

1. **Restore Database**
   - Open SQL Server Management Studio
   - Restore the database from `DVLD.bak` file
   - Note the database name and server instance

2. **Configure Connection String**
   - Open `App.config` in the Presentation Layer project
   - Update the connection string to match your SQL Server instance:
   ```xml
   <connectionStrings>
     <add name="ConnectionString" 
          connectionString="Server=YOUR_SERVER;Database=DVLD;Integrated Security=true;" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

3. **Build Solution**
   - Open `DVLD Presentation Layer.sln` in Visual Studio
   - Rebuild the entire solution
   - Ensure all three layers compile successfully

4. **Run Application**
   - Set `DVLD Presentation Layer` as the startup project
   - Press F5 to run
   - Use default credentials (if configured in database)

---

## Usage Guidelines

### For Administrators

1. **Initial Setup**
   - Configure application types and fees
   - Configure test types and fees
   - Create user accounts for staff
   - Set up license classes

2. **Daily Operations**
   - Process new license applications
   - Schedule and conduct tests
   - Issue, renew, and replace licenses
   - Manage detained licenses
   - Handle international license requests

3. **Maintenance**
   - Manage user accounts
   - Update fee structures
   - Monitor application statuses
   - Generate reports

### For Staff Users

1. **Application Processing**
   - Verify applicant information
   - Create applications
   - Schedule tests
   - Record test results

2. **License Management**
   - Issue new licenses
   - Process renewals
   - Handle replacements
   - Manage detentions

---

## Security Features

- **User Authentication** - Username and password validation
- **Role-Based Access** - Different user permissions
- **Audit Trail** - Track who created/modified records (CreatedByUserID)
- **Data Validation** - Input validation at all layers
- **Password Protection** - Encrypted password storage

---

## Business Rules Summary

1. **Age Requirements** - Minimum age varies by license class
2. **Test Sequence** - Vision → Written → Practical (must pass in order)
3. **Detention Rules** - Detained licenses cannot be renewed or replaced
4. **Expiration Handling** - Expired licenses must be renewed
5. **International License Prerequisites** - Requires valid local license
6. **Application Fees** - Non-refundable, paid at application creation
7. **Test Retakes** - Additional fees for failed tests
8. **License Validity** - Licenses have defined validity periods

---

## Future Enhancements

- Web-based interface for applicants
- Online payment integration
- SMS/Email notifications
- Automated test scheduling
- Digital license generation
- Mobile application
- Reporting and analytics dashboard
- Integration with national ID systems

---

## Contact and Support

For questions, issues, or contributions, please contact the development team or submit issues through the project repository.

---

**Version:** 1.0  
**Last Updated:** February 2026  
**Platform:** Windows Desktop Application  
**Framework:** .NET Framework + Windows Forms
