

# ?? Student Manager (C# Console App)

## ?? Overview

This is a simple **C# Console Application** that demonstrates **CRUD operations** (Create, Read, Update, Delete) on a list of students.
The program uses a **menu-driven interface** that runs in a loop until the user chooses to exit.

It is designed for learning purposes, focusing on:

* Object-Oriented Programming (OOP) in C#.
* Organizing code with **Models** and **Services**.
* Exception handling and user interaction.

---

## ? Features

*  **Add Student** – Insert new students with ID, Name, Age, and Grade.
* **Update Student** – Modify existing student details by ID.
* **Delete Student** – Remove a student by ID.
* **Display Student** – View details of a single student by ID.
* **Display All Students** – Show all students currently stored.
* **Exit** – Close the program gracefully.
*  Confirmation messages after each operation.
*  Error handling for invalid operations (e.g., duplicate IDs, student not found).

---

## ??? Project Structure

```
?? Program.cs           // Main entry point & menu
?? Models/
?  ?? Student.cs        // Student model (Id, Name, Age, Grade + ToString)
?? Services/
?  ?? StudentManager.cs // CRUD operations logic
```

---

## ?? Requirements

* .NET 8.0 SDK or later
* Any C# IDE or text editor (Visual Studio, VS Code, etc.)

---

## ?? How to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/student-manager.git
   ```
2. Navigate to the project folder:

   ```bash
   cd student-manager
   ```
3. Run the program:

   ```bash
   dotnet run
   ```

---

## ?? Example Usage

```
===================================================
             Welcome to Our School            
===================================================
  [1]  Add Student
  [2]  Update Student
  [3]  Delete Student
  [4]  Display Student
  [5]  Display All Students
  [6]  Exit
===================================================
 Enter your choice: 1
Enter Id: 101
Enter Name: Ahmed
Enter Age: 20
Enter Grade: 3.5

 Student added successfully!
```

---

## ?? Sample Code Snippet

```csharp
public void AddStudent(Student student)
{
    if (_students.Any(s => s.Id == student.Id))
        throw new Exception("Student with Same Id Already Exist");
    _students.Add(student);
}
```

---

## ?? Future Improvements

* Save and load students from a file (JSON/CSV).
* Add input validation (prevent invalid values like negative age).
* Search students by name or grade.
* Unit testing for CRUD methods.

---



