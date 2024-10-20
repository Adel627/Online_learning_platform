# Online_learning_platform

This project is an **Online Learning Platform** built using **ASP.NET Core MVC**, designed to manage online courses and student enrollments. The platform provides user authentication, role-based access control, and the ability to manage courses, categories, and enrollments.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup and Installation](#setup-and-installation)
- [User Registration Notes](#user-registration-notes)

  

## Features
- **User Authentication**: Users can register, log in, and access different features based on their roles (admin, instructor, student).
- **Role-based Access Control**: Admins can manage courses, categories, and users. Instructors can create and manage their courses, while students can enroll in courses.
- **Course Management**: Instructors can create, update, and delete courses, including adding descriptions, selecting categories, and setting prices.
- **Category Management**: Admins can manage course categories.
- **Student Enrollment**: Students can browse courses, enroll, and track their progress.
- **Responsive Design**: The platform is mobile-friendly and uses **Bootstrap** for responsiveness.

## Technologies Used
- **ASP.NET Core MVC**: Backend framework for building the platform.
- **Entity Framework Core**: ORM for database interactions.
- **SQL Server**: Database to store course and user information.
- **Bootstrap**: Frontend framework for responsive design.
- **C#**: Programming language used for server-side logic.

## Setup and Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/Adel627/Online_learning_platform.git

2. **Navigate to the project folder**:
   ```bash
   cd Online_learning_platform

4. **Install dependencies: Make sure you have the required .NET SDK installed. Run the following command to restore dependencies**:
   ```bash
   dotnet restore

6.  **Database Setup: Update the appsettings.json file with your database connection string. Then, run migrations to set up the database schema**:
    ```bash
    dotnet ef database update

7.  **Run the application**:
    ```bash
    dotnet run


# User Registration Notes


## Summary
This note outlines the user registration process for the Online Learning Platform.

---

## Registration Process
- When the program is run for the first time, the first email used to register will be assigned the **Admin** role.
- Any subsequent emails registered will be assigned the **User** role.

---

## Important Points
- Ensure that the first registration email is correctly designated as the Admin to manage the platform effectively.
- After the Admin account is created, all further registrations will default to regular User accounts.

---

## Action Items
1. **Test the registration process** to confirm that the first email correctly receives Admin privileges.
2. **Document any issues** encountered during the registration process.

---

## Additional Notes
- Consider implementing a feature that allows the Admin to promote Users to Admin if needed in the future.


