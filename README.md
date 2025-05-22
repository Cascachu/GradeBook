# GradeBook

GradeBook is a web application based on ASP.NET Core Razor Pages, designed for managing student grades. The project allows easy addition, editing, and viewing of grades assigned to individual students.

## Features

- View the list of grades for a selected student
- Add new grades (subject, grade, date, description)
- Edit existing grades
- Delete grades
- User-friendly interface based on Razor Pages

## Requirements

- .NET 9.0
- Visual Studio 2022 or newer

## Installation

1. Clone the repository:
2. Open the project in Visual Studio 2022.
3. Restore NuGet dependencies.
4. Run the application (F5 or __Debug > Start Debugging__).

## Project Structure

- `Models/` – domain models, e.g. `Student`, `Grade`, `Class`
- `Views/Grades/` – Razor Pages for grade management (`AddGrade`, `EditGrade`, `DisplayGrades`)
- `wwwroot/` – static assets (CSS, JS)

## Usage

After launching the application:
- Select a student from the list.
- View, add, edit, or delete grades.
- Each grade includes a subject, value, and an optional description.
