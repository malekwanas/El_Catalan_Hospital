# El Catalan Hospital

El Catalan Hospital is a hospital management system developed as a graduation project for the ITI 9-months diploma. The system is designed to facilitate various hospital operations including appointment scheduling, patient management, and more.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- Appointment scheduling
- Patient management
- Doctor management
- Receptionist management
- Department management

## Technologies Used

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/malekwanas/El_Catalan_Hospital.git
    ```

2. Navigate to the project directory:
    ```sh
    cd El_Catalan_Hospital
    ```

3. Restore the NuGet packages:
    ```sh
    dotnet restore
    ```

4. Update the database connection string in `appsettings.json`.

5. Apply the database migrations:
    ```sh
    dotnet ef database update
    ```

## Usage

1. Run the application:
    ```sh
    dotnet run
    ```

2. Open your browser and navigate to `http://localhost:5000` to access the application.

## Contributing

Contributions are welcome! Please follow these steps to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a pull request.
