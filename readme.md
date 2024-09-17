# CodingTracker

## Overview

Coding Tracker is a console-based application built using .NET that helps users track the time spent on coding activities. This project expands on the concepts of habit tracking and integrates more sophisticated features to enhance user experience and data management.

## Project Structure

The project is organized into the following key directories and files:

- **Program.cs**: The entry point of the application, containing the main logic to run the Coding Tracker.
- **Helpers**:
  - `ConsoleHelper.cs`: Utilities for console interactions, including input/output handling.
  - `DatabaseHelper.cs`: Functions for interacting with the SQLite database.
  - `ValidationHelper.cs`: Provides validation methods to ensure data integrity and user input correctness.
- **Database**:
  - SQLite database file `coding-tracker.db` is used to store and manage the tracked coding sessions.

## Features

- Track coding sessions with start and end times.
- View, update, and delete recorded sessions.
- Validate user inputs to prevent errors and ensure data integrity.
- Store and retrieve data using an SQLite database.

## Improvements Over Previous Project

- **Enhanced Database Management**:
  - The previous project used a simple database structure. The Coding Tracker has improved database handling with better data validation, ensuring accurate and reliable data storage.
- **Input Validation**:
  - The Coding Tracker introduces more comprehensive input validation (via `ValidationHelper.cs`), reducing the likelihood of incorrect or inconsistent data being stored.
- **Advanced Console Interaction**:
  - Enhanced console interaction with better error handling and user guidance, providing a smoother user experience compared to the habit tracker.
- **Configuration File**:
  - The usage (no matter how simple) of a configuration file allows the developer to define keys and values that can be used in the entire application with ease.

## Getting Started

### Prerequisites

- .NET SDK (version 8.0 or higher)

### Running the Application

1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Run the following command to build and run the application:

   ```bash
   dotnet run
   ```

## Using the Application

Once the application is running, follow the console prompts to log, view, update, and delete your coding sessions.

## Future Enhancements

- Graphical User Interface (GUI): Transition from a console-based to a GUI-based application for better user interaction.
- Report Generation: Add functionality to generate detailed reports on coding activities over time.
- Multi-user Support: Expand the application to support multiple users with individual coding logs.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
