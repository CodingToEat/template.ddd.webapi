# .NET Web API Template with Domain Driven Design

## Description

This project serves as a starter template for organizing folders following the principles of Domain-Driven Design (DDD). Additionally, it includes a simple CRUD example. It's important to note that while Domain-Driven Design is not typically recommended for CRUD operations due to its complexity for simple tasks like CRUD, this example can be valuable for individuals who are learning about Domain-Driven Design.

Feel free to explore and adapt this template for your projects, keeping in mind the educational benefits it provides for those diving into the world of Domain-Driven Design.

## Technologies

- **Programming Language:** C#
- **Framework:** Net 8
- **Database:** SQL Server Developer
- **Other Dependencies:** 

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [Net 8.0] (https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed
- [SQL Server 2022 Developer] (https://www.microsoft.com/en-us/sql-server/sql-server-downloads) installed

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/CodingToEat/template.ddd.webapi.git
    ```

2. Navigate to the project directory:

    ```bash
    cd template.ddd.webapi
    ```

3. Install template:

    ```bash
    dotnet new install .\
    ```
## Template Usage

1. **Create a Folder in Your Desired Location:**
   
   ```bash
   mkdir YourProjectFolder
   ```

2. Navigate to the Created Folder:

    ```bash
   cd YourProjectFolder
   ```
    
3. Create new project using the template:

    ```bash
   dotnet new ddd.webapi
   ```

## Running Your Project

Once you have set up the template for your project, follow these steps to run it:

1. **Review the Connection String:**
   Open `appsettings.Development.json` and ensure the `connectionString` is correct:

   ```json
   {
     "ConnectionStrings": "your_database_connection_string_here",
     // Other settings...
   }
   ```
2. **Run Entity Framework Migrations (if needed):**

  ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
   
3. **Run your project**

   ```bash
   dotnet run
   ```

## Contributing

We welcome contributions from the community. If you want to contribute to template.ddd.webapi, please follow these steps:

1. Fork the repository by clicking on the 'Fork' button.
2. Clone the forked repository to your local machine:

    ```bash
    git clone https://github.com/CodingToEat/template.ddd.webapi.git
    ```

3. Create a new branch to work on:

    ```bash
    git checkout -b feature/your-feature-name
    ```

4. Make your changes and commit them:

    ```bash
    git commit -m 'Add some feature'
    ```

5. Push to the branch:

    ```bash
    git push origin feature/your-feature-name
    ```

6. Create a pull request on the original repository.

We will review your changes and merge them if they align with the project's goals. Thank you for contributing!

## License

This project is licensed under the [MIT License](LICENSE.md) - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- Mention any credits or inspirations if applicable.

Thank you for using template.ddd.webapi! Feel free to reach out if you have any questions or issues.

