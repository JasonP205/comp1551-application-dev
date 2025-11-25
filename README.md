A desktop information management system that allows managing information for Admin, Teacher, and Student.

## System Architecture

### Person Class (Abstract)
An abstract class that serves as the parent class for all types of users in the system.

**Properties:**
- `ID` (int): Unique identifier, auto-incremented
- `Name` (string): User name
- `Telephone` (string): Phone number (10 digits)
- `Email` (string): Email address
- `Role` (RoleType): User role (Admin/Teacher/Student)
- `idCounter` (static int): Auto-increment ID counter

**Methods:**
- `DisplayInfor()`: Display basic user information
- `UpdateInfor()`: Update basic information (Name, Telephone, Email)
- `UpdateAdvanceInfor()`: Abstract method to update advanced information (overridden by child classes)

**RoleType Enum:**
- `Admin`: Administrator
- `Teacher`: Teacher
- `Student`: Student

---

### Admin Class
Inherits from Person, represents an administrator in the system.

**Additional Properties:**
- `Salary` (decimal): Salary amount
- `WorkingHours` (decimal): Working hours
- `WType` (workingType): Type of employment

**workingType Enum:**
- `FullTime`: Full-time
- `PartTime`: Part-time

**Overridden Methods:**
- `DisplayInfor()`: Display basic info + salary, employment type, working hours
- `UpdateAdvanceInfor()`: Update salary, employment type, and working hours

---

### Teacher Class
Inherits from Person, represents a teacher in the system.

**Additional Properties:**
- `Salary` (decimal): Salary amount
- `SubjectOne` (string): First subject
- `SubjectTwo` (string): Second subject

**Overridden Methods:**
- `DisplayInfor()`: Display basic info + salary and 2 subjects
- `UpdateAdvanceInfor()`: Update salary and information for 2 subjects

---

### Student Class
Inherits from Person, represents a student in the system.

**Additional Properties:**
- `SubjectOne` (string): First subject
- `SubjectTwo` (string): Second subject
- `SubjectThree` (string): Third subject

**Overridden Methods:**
- `DisplayInfor()`: Display basic info + 3 subjects
- `UpdateAdvanceInfor()`: Update information for 3 subjects

---

### Program Class
The main class that controls the entire system and handles the user interface.

**Properties:**
- `persons` (static List<Person>): List storing all users
- `PhoneNumberRegex` (static Regex): Regex for phone number validation (10 digits)
- `EmailRegex` (static Regex): Regex for email format validation

**Main Methods:**

#### Menu Control
- `Main(string[] args)`: Program entry point
- `startMainMenu()`: Display main menu and handle user selections

#### Data Management
- `AddPerson()`: Add new user (Admin/Teacher/Student)
- `ViewAllPersons()`: View all users in the system
- `ViewPersonsByGroup()`: View users by group (Admin/Teacher/Student)
- `EditPersonInformation()`: Edit user information by ID
- `DeletePerson()`: Delete user by ID

#### Validation and Helper
- `validStringInput(string prompt, bool allowEmpty)`: Validate non-empty string input
- `validPhoneNumberInput(bool allowEmpty)`: Validate valid phone number (10 digits)
- `validEmailInput(bool allowEmpty)`: Validate valid email
- `validDecimalInput(string prompt, bool allowEmpty)`: Validate non-negative decimal input
- `ValidWorkingType(bool allowEmpty)`: Validate and select employment type (FullTime/PartTime)
- `Console_Output(string message, string color)`: Display text with custom color
- `Pause()`: Pause screen waiting for user keypress

---

## System Features

### 1. Add Person
- Add Admin, Teacher, or Student
- Validate all inputs (name, phone, email, salary, subjects, etc.)
- Auto-assign incrementing ID

### 2. View all current Persons
- Display complete list of all users
- Include detailed information for each person

### 3. View Person by Group
- Filter and display by role: Admin, Teacher, or Student
- Easily manage each user group

### 4. Edit Person Information
- Find user by ID
- Update basic information (name, phone, email)
- Update advanced information (salary, subjects, employment type)
- Can skip (keep current) any field you don't want to change

### 5. Delete Person
- Remove user from the system by ID

### 6. Exit
- Exit the program

---

## Validation Rules

### Phone Number
- Must be exactly 10 digits
- Regex: `^\d{10}$`

### Email
- Must have valid email format
- Regex: `^[^@\s]+@[^@\s]+\.[^@\s]+$`

### Salary and Working Hours
- Must be non-negative decimal numbers

### Strings (Name, Subjects)
- Cannot be empty (when adding new)
- Can be skipped when updating (keeps old value)

---

## Technologies Used

- **Language:** C# (.NET 9.0)
- **Framework:** .NET Console Application
- **Design Patterns:** Inheritance, Polymorphism
- **Data Structures:** List<T>, Enum
- **Validation:** Regular Expression (Regex)

---

## How to Run

```bash
# Debug mode
dotnet run

# Build and run Release mode
dotnet build -c Release
dotnet run -c Release

# Publish for macOS (ARM64)
dotnet publish -c Release -r osx-arm64 --self-contained

# Publish for Windows (x64)
dotnet publish -c Release -r win-x64 --self-contained
```
