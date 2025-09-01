#                  Backend Beginner Projects           #


This repository contains simple C# console applications designed to practice 
C# fundamentals, object-oriented programming (OOP), methods, 
and basic data structures. Each project focuses on a different scenario 
to help improve programming skills gradually.


## Projects Overview


| Project Name              | Description                                                                 |
|----------------------------|-----------------------------------------------------------------------------|
| **Banking System**         | Simulates basic banking operations (e.g., deposits, withdrawals, account balance). |
| **Currency Converter**     | Converts amounts between two currencies using fixed or user-defined rates. |
| **Number Guessing Game**   | A console game where the user tries to guess a randomly chosen number.     |
| **Quiz Application**       | Presents quiz questions and evaluates user input to calculate a score.     |
| **To-Do List**             | Allows users to add, display, and remove simple to-do items via console.   |
| **User Auth System**       | Demonstrates basic user authentication logic, using simple credential checks and in-memory user storage. |


## Project Details

### Banking System
- Console-based banking application.
- Demonstrates OOP concepts: abstract classes, inheritance, polymorphism.
- Users can deposit, withdraw, transfer money, and check balance.
- Payment methods include Cash, Credit Card, and EFT.
- Good practice for classes, methods, and polymorphism.

---------------------------------------------------------------------------------------------------------------------------------

### Currency Converter
- Converts amounts between different currencies.
- Exchange rates stored in a `Dictionary<string, double>`.
- Users select FROM and TO currencies and enter an amount.
- Practices user input handling, loops, and calculations.

---------------------------------------------------------------------------------------------------------------------------------

### Number Guessing Game
- Guess the random number within a selected difficulty level.
- Difficulty affects number range and attempts allowed.
- Gives feedback if the guess is too high or too low.
- Practices loops, conditionals, and random number generation.

---------------------------------------------------------------------------------------------------------------------------------

### Quiz Application
- Multiple-choice quiz with 5 questions.
- Each question has 5 options (A–E).
- Records user answers and calculates total score.
- Uses arrays, loops, and input validation.

---------------------------------------------------------------------------------------------------------------------------------

### To-Do List
- Console-based task management app.
- Allows adding, completing, and deleting tasks.
- Uses a struct to store task data (ID, title, description, due date, status).
- Practices arrays, loops, struct usage, and user input handling.

---------------------------------------------------------------------------------------------------------------------------------

### User Auth System
- Simple registration and login system.
- Users can register with username and password.
- Passwords validated (minimum 6 characters, at least one letter).
- Login allows maximum 3 attempts.
- Demonstrates classes, methods, and basic authentication logic.
