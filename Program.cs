using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public abstract class Person
{
    public enum RoleType
    {
        Admin,
        Teacher,
        Student,
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public RoleType Role { get; protected set; }
    private static int idCounter = 1;

    public Person(string name, string telephone, string email)
    {
        ID = idCounter++;
        Name = name;
        Telephone = telephone;
        Email = email;
    }

    public virtual void DisplayInfor()
    {
        Console.WriteLine($"||ID: {ID}");
        Console.WriteLine($"||Name: {Name}");
        Console.WriteLine($"||Telephone: {Telephone}");
        Console.WriteLine($"||Email: {Email}");
        Console.WriteLine($"||Role: {Role}");
    }

    public virtual void UpdateInfor()
    {
        Console.WriteLine($"Current Name: {Name} ");
        string newName = Program.validStringInput("Enter Name: ", true);
        if (!string.IsNullOrEmpty(newName))
        {
            Name = newName;
        }

        Console.WriteLine($"Current Telephone: {Telephone} ");
        string newTelephone = Program.validPhoneNumberInput(true);
        if (!string.IsNullOrEmpty(newTelephone))
        {
            Telephone = newTelephone;
        }

        Console.WriteLine($"Current Email: {Email} ");
        string newEmail = Program.validEmailInput(true);
        if (!string.IsNullOrEmpty(newEmail))
        {
            Email = newEmail;
        }
    }

    public abstract void UpdateAdvanceInfor();
}

public class Admin : Person
{
    public enum workingType
    {
        FullTime,
        PartTime,
    }

    public decimal Salary { get; set; }
    public decimal WorkingHours { get; set; }
    public workingType WType { get; set; }

    public Admin(
        string name,
        string telephone,
        string email,
        decimal salary,
        workingType WType,
        decimal workingHours
    )
        : base(name, telephone, email)
    {
        Role = RoleType.Admin;
        Salary = salary;
        this.WorkingHours = workingHours;
        this.WType = WType;
    }

    public override void DisplayInfor()
    {
        base.DisplayInfor();
        Console.WriteLine($"||Salary: {Salary.ToString("C0")}");
        Console.WriteLine($"||Working Type: {WType}");
        Console.WriteLine($"||Working Hours: {WorkingHours.ToString("F2")}");
    }

    public override void UpdateAdvanceInfor()
    {
        Console.WriteLine($"Current salary: {Salary.ToString("C0")} ");
        decimal? newSalary = Program.validDecimalInput("Enter Salary: ", true);
        if (newSalary.HasValue)
        {
            Salary = newSalary.Value;
        }

        Console.WriteLine($"Current working type: {WType} ");
        Admin.workingType? newWType = Program.ValidWorkingType(true);
        if (newWType.HasValue)
        {
            WType = newWType.Value;
        }
        Console.WriteLine($"Current working hours: {WorkingHours.ToString("F2")} ");
        decimal? newWorkingHours = Program.validDecimalInput("Enter Working Hours: ", true);
        if (newWorkingHours.HasValue)
        {
            WorkingHours = newWorkingHours.Value;
        }

        Program.Console_Output("Information updated successfully.", "Green");
    }
}

public class Teacher : Person
{
    public decimal Salary { get; set; }
    public string SubjectOne { get; set; }
    public string SubjectTwo { get; set; }

    public Teacher(
        string name,
        string telephone,
        string email,
        decimal salary,
        string SubjectOne,
        string SubjectTwo
    )
        : base(name, telephone, email)
    {
        Role = RoleType.Teacher;
        Salary = salary;
        this.SubjectOne = SubjectOne;
        this.SubjectTwo = SubjectTwo;
    }

    public override void DisplayInfor()
    {
        base.DisplayInfor();
        Console.WriteLine($"||Salary: {Salary.ToString("C0")}");
        Console.WriteLine($"||Subject One: {SubjectOne}");
        Console.WriteLine($"||Subject Two: {SubjectTwo}");
    }

    public override void UpdateAdvanceInfor()
    {
        Console.WriteLine($"Current salary: {Salary.ToString("C0")} ");
        decimal? newSalary = Program.validDecimalInput("Enter new Salary: ", true);
        if (newSalary.HasValue)
        {
            Salary = newSalary.Value;
        }

        Console.WriteLine($"Current subject one: {SubjectOne} ");
        string newSubjectOne = Program.validStringInput("Enter name of Subject One", true);
        if (!string.IsNullOrEmpty(newSubjectOne))
        {
            SubjectOne = newSubjectOne;
        }

        Console.WriteLine($"Current subject two: {SubjectTwo} ");
        string newSubjectTwo = Program.validStringInput("Enter name of Subject Two", true);
        if (!string.IsNullOrEmpty(newSubjectTwo))
        {
            SubjectTwo = newSubjectTwo;
        }

        Program.Console_Output("Information updated successfully.", "Green");
    }
}

public class Student : Person
{
    public string SubjectOne { get; set; }
    public string SubjectTwo { get; set; }
    public string SubjectThree { get; set; }

    public Student(
        string name,
        string telephone,
        string email,
        string SubjectOne,
        string SubjectTwo,
        string SubjectThree
    )
        : base(name, telephone, email)
    {
        Role = RoleType.Student;
        this.SubjectOne = SubjectOne;
        this.SubjectTwo = SubjectTwo;
        this.SubjectThree = SubjectThree;
    }

    public override void DisplayInfor()
    {
        base.DisplayInfor();
        Console.WriteLine($"||Subject One: {SubjectOne}");
        Console.WriteLine($"||Subject Two: {SubjectTwo}");
        Console.WriteLine($"||Subject Three: {SubjectThree}");
    }

    public override void UpdateAdvanceInfor()
    {
        Console.WriteLine($"Current subject one: {SubjectOne} ");
        string newSubjectOne = Program.validStringInput("Enter name of Subject One", true);
        if (!string.IsNullOrEmpty(newSubjectOne))
        {
            SubjectOne = newSubjectOne;
        }

        Console.WriteLine($"Current subject two: {SubjectTwo} ");
        string newSubjectTwo = Program.validStringInput("Enter name of Subject Two", true);
        if (!string.IsNullOrEmpty(newSubjectTwo))
        {
            SubjectTwo = newSubjectTwo;
        }

        Console.WriteLine($"Current subject three: {SubjectThree} ");
        string newSubjectThree = Program.validStringInput("Enter name of Subject Three", true);
        if (!string.IsNullOrEmpty(newSubjectThree))
        {
            SubjectThree = newSubjectThree;
        }

        Program.Console_Output("Information updated successfully.", "Green");
    }
}

public class Program
{
    private static List<Person> persons = new List<Person>();
    private static readonly Regex PhoneNumberRegex = new Regex(@"^\d{10}$");
    private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    public static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            isRunning = startMainMenu();
        }
    }

    private static bool startMainMenu()
    {
        Console.Clear();
        Console.WriteLine("======================================");
        Console.WriteLine("||    Desktop Information System    ||");
        Console.WriteLine("||----------------------------------||");
        Console.WriteLine("|| 1. Add Person                    ||");
        Console.WriteLine("|| 2. View all current Persons      ||");
        Console.WriteLine("|| 3. View Person by Group          ||");
        Console.WriteLine("|| 4. Edit Person Information       ||");
        Console.WriteLine("|| 5. Delete Person                 ||");
        Console.WriteLine("|| 6. Exit                          ||");
        Console.WriteLine("======================================");
        Console.WriteLine("Please select an option (1-6): ");
        string choice = Console.ReadLine();
        List<string> validChoices = new List<string> { "1", "2", "3", "4", "5", "6" };

        if (!validChoices.Contains(choice))
        {
            Console_Output("Invalid selection. Please try again.", "Yellow");
            Pause();
            return true;
        }
        switch (choice)
        {
            case "1":
                AddPerson();
                break;
            case "2":
                ViewAllPersons();
                break;
            case "3":
                ViewPersonsByGroup();
                break;
            case "4":
                EditPersonInformation();
                break;
            case "5":
                DeletePerson();
                break;
            case "6":
                Console_Output("Exiting the program. Goodbye!", "Green");
                return false;
        }
        return true;
    }

    private static void AddPerson()
    {
        Console.Clear();
        Console.WriteLine("Select Role to Add:");
        Console.WriteLine("1. Admin");
        Console.WriteLine("2. Teacher");
        Console.WriteLine("3. Student");
        string roleChoice = Console.ReadLine();
        List<string> validRoles = new List<string> { "1", "2", "3" };
        if (!validRoles.Contains(roleChoice))
        {
            Console_Output("Invalid role selection.", "Yellow");
            Pause();
            return;
        }
        string name = validStringInput("Enter Name: ");
        string telephone = validPhoneNumberInput();
        string email = validEmailInput();
        Person newPerson = null;
        switch (roleChoice)
        {
            case "1":
                decimal? adminSalary = validDecimalInput("Enter Salary: ");
                Admin.workingType? wType = ValidWorkingType();
                decimal? workingHours = validDecimalInput("Enter Working Hours: ");
                newPerson = new Admin(
                    name,
                    telephone,
                    email,
                    adminSalary.Value,
                    wType.Value,
                    workingHours.Value
                );
                break;
            case "2":
                decimal? teacherSalary = validDecimalInput("Enter Salary: ");
                string subjectOne = validStringInput("Enter name of Subject One: ");
                string subjectTwo = validStringInput("Enter name of Subject Two: ");
                newPerson = new Teacher(
                    name,
                    telephone,
                    email,
                    teacherSalary.Value,
                    subjectOne,
                    subjectTwo
                );
                break;
            case "3":
                string stuSubjectOne = validStringInput("Enter name of Subject One: ");
                string stuSubjectTwo = validStringInput("Enter name of Subject Two: ");
                string stuSubjectThree = validStringInput("Enter name of Subject Three: ");
                newPerson = new Student(
                    name,
                    telephone,
                    email,
                    stuSubjectOne,
                    stuSubjectTwo,
                    stuSubjectThree
                );
                break;
        }

        if (newPerson != null)
        {
            persons.Add(newPerson);
            Console_Output($"{newPerson.Role} added successfully.", "Green");
        }
        Pause();
    }

    private static void ViewAllPersons()
    {
        Console.Clear();
        if (persons.Count == 0)
        {
            Console.Clear();
            Console_Output("No persons available.", "Yellow");
            Pause();
            return;
        }
        Console.Clear();
        foreach (var person in persons)
        {
            Console.WriteLine($"||==================================");
            person.DisplayInfor();
        }
        Console.WriteLine($"||==================================");
        Pause();
    }

    private static void ViewPersonsByGroup()
    {
        Console.Clear();
        Console.WriteLine("Select Group to View:");
        Console.WriteLine("1. Admins");
        Console.WriteLine("2. Teachers");
        Console.WriteLine("3. Students");
        string groupChoice = Console.ReadLine();
        Person.RoleType selectedRole;
        switch (groupChoice)
        {
            case "1":
                selectedRole = Person.RoleType.Admin;
                break;
            case "2":
                selectedRole = Person.RoleType.Teacher;
                break;
            case "3":
                selectedRole = Person.RoleType.Student;
                break;
            default:
                Console_Output("Invalid group selection.", "Yellow");
                Pause();
                return;
        }
        var filteredPersons = persons.Where(p => p.Role == selectedRole).ToList();
        if (filteredPersons.Count == 0)
        {
            Console_Output($"No {selectedRole}s available.", "Yellow");
            Pause();
            return;
        }
        Console.Clear();
        foreach (var person in filteredPersons)
        {
            Console.WriteLine($"||==================================");
            person.DisplayInfor();
        }
        Console.WriteLine($"||==================================");
        Pause();
    }

    private static void EditPersonInformation()
    {
        Console.Clear();
        Console.WriteLine("Enter Person ID to Edit:");
        if (!int.TryParse(Console.ReadLine(), out int personID))
        {
            Console_Output("Invalid ID format.", "Yellow");
            Pause();
            return;
        }
        var person = persons.FirstOrDefault(p => p.ID == personID);
        if (person == null)
        {
            Console_Output("Person not found.", "Yellow");
            Pause();
            return;
        }
        Console.Clear();
        person.DisplayInfor();
        person.UpdateInfor();
        person.UpdateAdvanceInfor();
        Pause();
    }

    private static void DeletePerson()
    {
        Console.Clear();
        Console.WriteLine("Enter Person ID to Delete:");
        if (!int.TryParse(Console.ReadLine(), out int personID))
        {
            Console_Output("Invalid ID format.", "Yellow");
            Pause();
            return;
        }
        var person = persons.FirstOrDefault(p => p.ID == personID);
        if (person == null)
        {
            Console_Output("Person not found.", "Yellow");
            Pause();
            return;
        }
        persons.Remove(person);
        Console_Output("Person deleted successfully.", "Green");
        Pause();
    }

    public static void Pause()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static Admin.workingType? ValidWorkingType(bool allowEmpty = false)
    {
        string workingTypeInput = "";
        bool isValid = false;

        do
        {
            Console.WriteLine("--- Working Type Selection ---");
            Console.WriteLine("Enter Working Type (1/2):");
            Console.WriteLine("1. Fulltime");
            Console.WriteLine("2. Parttime");
            Console.Write("Your selection: ");

            string input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input) && allowEmpty)
            {
                return null;
            }

            if (string.IsNullOrEmpty(input))
            {
                Console_Output(
                    "\n[Warning] Working Type cannot be empty. Please try again.",
                    "Yellow"
                );
                continue;
            }
            if (input == "1" || input == "fulltime")
            {
                workingTypeInput = "FullTime";
                isValid = true;
            }
            else if (input == "2" || input == "parttime")
            {
                workingTypeInput = "PartTime";
                isValid = true;
            }
            else
            {
                Console_Output(
                    "\n[Warning] Invalid Working Type. Please enter '1' for Fulltime or '2' for Parttime.",
                    "Yellow"
                );
            }
        } while (!isValid);

        return (Admin.workingType)Enum.Parse(typeof(Admin.workingType), workingTypeInput);
    }

    public static string validStringInput(string prompt, bool allowEmpty = false)
    {
        string nameInput = "";
        bool isValid = false;

        do
        {
            if (allowEmpty)
            {
                Console.Write($"{prompt} (Leave blank to keep current): ");
            }
            else
            {
                Console.Write($"{prompt}");
            }
            nameInput = Console.ReadLine()?.Trim();

            if (allowEmpty && string.IsNullOrEmpty(nameInput))
            {
                return nameInput;
            }

            if (string.IsNullOrEmpty(nameInput))
            {
                Console_Output(
                    "\n[Warning] This field cannot be empty. Please try again.",
                    "Yellow"
                );
            }
            else
            {
                isValid = true;
            }
        } while (!isValid);
        return nameInput;
    }

    public static string validPhoneNumberInput(bool allowEmpty = false)
    {
        string phoneInput = "";
        bool isValid = false;

        do
        {
            Console.Write("Enter Telephone (10 digits): ");
            phoneInput = Console.ReadLine()?.Trim();

            if (allowEmpty && string.IsNullOrEmpty(phoneInput))
            {
                return phoneInput;
            }

            if (!PhoneNumberRegex.IsMatch(phoneInput))
            {
                Console_Output(
                    "\n[Warning] Invalid telephone number. Please enter a 10-digit number.",
                    "Yellow"
                );
                continue;
            }
            else
            {
                isValid = true;
            }
        } while (!isValid);
        return phoneInput;
    }

    public static string validEmailInput(bool allowEmpty = false)
    {
        string emailInput = "";
        bool isValid = false;

        do
        {
            Console.Write("Enter Email: ");
            emailInput = Console.ReadLine()?.Trim();

            if (allowEmpty && string.IsNullOrEmpty(emailInput))
            {
                return emailInput;
            }

            if (!EmailRegex.IsMatch(emailInput))
            {
                Console_Output(
                    "\n[Warning] Invalid email format. Please enter a valid email.",
                    "Yellow"
                );
                continue;
            }
            else
            {
                isValid = true;
            }
        } while (!isValid);
        return emailInput;
    }

    public static decimal? validDecimalInput(string prompt, bool allowEmpty = false)
    {
        decimal decimalInput = 0;
        bool isValid = false;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input) && allowEmpty)
            {
                return null;
            }

            if (!decimal.TryParse(input, out decimalInput) || decimalInput < 0)
            {
                Console_Output(
                    $"\n[Warning] Invalid input. {prompt} must be a non-negative decimal number.",
                    "Yellow"
                );
                continue;
            }
            else
            {
                isValid = true;
            }
        } while (!isValid);
        return decimalInput;
    }

    public static void Console_Output(string message, string color)
    {
        ConsoleColor targetColor;
        bool success = Enum.TryParse(color, true, out targetColor);
        if (success)
        {
            Console.ForegroundColor = targetColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(message);
        }
    }
}
