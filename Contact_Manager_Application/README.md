# 📘 Contact Manager Application

## 📌 Overview

The **Contact Manager Application** is a C# console-based project that allows users to manage their contacts.
It supports adding, updating, viewing, and deleting user information including **addresses, phone numbers, and emails**.
The project is designed using **object-oriented programming principles** and structured with **Models, Services, and Utilities** for clean maintainable code.

---

## 🚀 Features

* Add a new user with:

  * Basic info (ID, First Name, Last Name, Gender, City).
  * Multiple Addresses.
  * Multiple Phone Numbers.
  * Multiple Email Addresses.
* Update existing user details via a menu:

  * Update first name, last name, gender, city.
  * Add new addresses, phones, or emails.
* Display user details in a **formatted table view**.
* Manage multiple users in memory.
* Modular and extensible design (Services + Factories/Utilities).

---

## 🏗️ Project Structure

```
ContactManagerApp/
│
├─ Program.cs                  // Entry point, runs the app
│
├─ Models/                     // Entities
│   ├─ User.cs
│   ├─ Address.cs
│   ├─ Phone.cs
│   └─ EmailAddress.cs
│
├─ Services/                   // Business logic
│   └─ ContactService.cs       // Add, Update, ShowAll, Delete
│
├─ Utilities/                  // Helpers/Factories
│   ├─ InputUtility.cs         // ReadInput()
│   ├─ UserDataFactory
│
└─ UI/
    └─ Menu.cs                 // Console menu system
```

---

## ⚙️ Installation & Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/ContactManagerApp.git
   ```
2. Open the project in **Visual Studio** or **Visual Studio Code**.
3. Build the solution:

   ```bash
   dotnet build
   ```
4. Run the program:

   ```bash
   dotnet run
   ```

---

## 📖 Usage

When you run the app, you will be presented with a **Main Menu**:

```
[1] Add User
[2] Show All Users
[3] Update User
[4] Delete User
[0] Exit
```

### ➕ Add User

* Enter ID, First Name, Last Name, Gender, City.
* Add multiple addresses, phones, and emails.

### 🔍 Show All Users

* Displays all users with basic info.

### ✏️ Update User

* Choose which field to update:

  ```
  [1] Update First Name
  [2] Update Last Name
  [3] Update Gender
  [4] Update City
  [5] Add Email
  [6] Add Phone
  [7] Add Address
  [0] Exit
  ```

### 🗑️ Delete User

* Removes a user by ID.

---

## 📊 Example Output

```
=================================================================
USER INFORMATION (ID: 1)
=================================================================
Field        | Value                         
--------------------------------------------------
Name         | Ahmed Ali
Gender       | Male
City         | Cairo
Added Date   | 9/13/2025 12:00:00 PM

-- Addresses --
Type         | Address                        | Description         
----------------------------------------------------------------------
Home         | 123 Street                     | Main house          
Work         | 456 Office Rd                  | Office              

-- Phones --
Type         | Phone                | Description         
------------------------------------------------------------
Mobile       | 01012345678          | Personal phone      
Work         | 0223456789           | Work phone          

-- Emails --
Type         | Email                         | Description         
----------------------------------------------------------------------
Personal     | ahmed@example.com              | Main email          
Work         | ahmed.work@company.com         | Office email        

=================================================================
```

---

## 🔮 Future Improvements

* Save and load contacts from **JSON / Database**.
* Add **search functionality** (by name, city, or email).
* Implement **delete specific phone/email/address**.
* Create a **GUI (WPF/WinForms/Blazor)** version.

---


