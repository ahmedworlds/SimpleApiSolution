# Simple API and Client Application

This solution contains a simple ASP.NET Core Web API and a console client application that consumes the API. 

## Project Structure

```
SimpleApiSolution
├── SimpleApi
│   ├── Controllers
│   │   └── WeatherController.cs
│   ├── Program.cs
│   ├── Startup.cs
│   └── SimpleApi.csproj
├── SimpleApiClient
│   ├── Program.cs
│   └── SimpleApiClient.csproj
└── SimpleApiSolution.sln
```

## Getting Started

### Prerequisites

- .NET SDK (version 6.0 or later)

### Running the API

1. Navigate to the `SimpleApi` directory:
   ```
   cd SimpleApi
   ```

2. Run the API application:
   ```
   dotnet run
   ```

3. The API will start and listen on `http://localhost:5000` (or another port if configured).

### Running the Client

1. Open a new terminal and navigate to the `SimpleApiClient` directory:
   ```
   cd SimpleApiClient
   ```

2. Run the client application:
   ```
   dotnet watch run
   ```

3. The client will make a request to the API and display the weather data in the console.

## API Endpoint

- **GET** `/weather` - Retrieves weather information in JSON format.

## License

This project is licensed under the MIT License.