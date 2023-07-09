
<h1> GPT-FineTune <h1/>

### ***About***

GPT-FineTune is a WebApi project developed in ASP.NET Core that integrates with the OpenAI platform services, aiming to make AI model training simpler and more accurate.

Artificial intelligence is becoming increasingly relevant, and using it for complex tasks is already a reality. If you have specific business rules or need greater accuracy in your tasks, you may consider "training" an AI model to achieve more consistent results. For more information about the FineTune process, please refer to the OpenAI documentation.

### ***Key features***

- Prompt formatter for JSONL (creation of training files)
- File upload to the OpenAI server
- FineTuning/model training
- Management of status and events for your FineTune

### ***Technologies implemented***

- ASP.NET Core
- ASP.NET Core WebApi
- .NET Core Native DI
- MediatR
- Swagger UI
- .NET DevPack

### ***Architecture***

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Clean Architeture
- Domain Driven Design
- CQRS
- Repository

<div>
  <h1>Installation<h1/>
</div>

### ***Step 1: Prerequisites***
  Requirements to run the API:

  ```
  - SDK .NET 7
  - PowerShell or Any Command Prompt
  ```

### ***Step 2: Navigate to API folder***
  Navigate to the API project folder using PowerShell or Any Command Prompt, as the example below:
  
  ```
  cd "C:\GPT-FineTune\GPT-FineTune.API"
  ```

### ***Step 3: Run the API***
  While in the API project directory, execute the following commands:
  
  ```
  dotnet restore
  dotnet watch run
  ```

### ***Step 4: Swagger***
  When the API is started, the Swagger interface should be ready for making requests. <br/>
  If the Swagger does not open automatically, you need to navigate to the URL: <br/>https://localhost:8080/swagger/index.html or http://localhost:8081/swagger/index.html

<h1> Setting up for usage <h1/>

### ***OpenAI Api Key***

In the API project, there is an AppSettings.json file that contains the necessary configurations for using the API (default path: "GPT-FineTune\GPT-FineTune.API\appsettings.json").

The ApiKey property is essential for the full functioning of the application, as it is the authentication key used to access OpenAI services.

```
"ApiKey": "Your API key"

Required to use OpenAI services. This key is necessary for any requests to OpenAI.
```
