# PayBridge

PayBridge is a modern, transparent payment gateway designed for freelancers and clients to manage contracts, milestones, and fund releases with absolute clarity and security.

## Core Features

- **🛡️ Escrowed Milestones**: Link project milestones directly to payments. Funds are held securely and released only when work is approved.
- **📝 Contract Management**: Create, sign, and track professional agreements with ease.
- **🏦 Multi-Account Support**: Manage multiple bank accounts for flexible fund settlement.
- **⚡ Real-time Updates**: Track payment statuses from "Pending" to "Released" in real-time.
- **🔒 Secure by Design**: Built with modern security standards using JWT-based authentication.

## Tech Stack

- **Backend**: .NET 10 Web API
- **ORM**: Entity Framework Core
- **Database**: PostgreSQL (Npgsql)
- **Authentication**: JWT Bearer Tokens
- **Documentation**: Swagger/OpenAPI
- **Testing**: Bruno API Collection

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL](https://www.postgresql.org/)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/PayBridge.git
   cd PayBridge
   ```

2. **Configure Environment**:
   Update `appsettings.json` or create a `.env` file with your database connection string and JWT settings.

3. **Database Setup**:
   Run the following command to apply migrations and create the database schema:
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:7111` (or your configured port).

## API Documentation

Once the application is running, you can explore the API using Swagger at `/swagger`.

Alternatively, use the provided **Bruno** collections located in the `/bruno` directory for local testing.

## Contributing

We welcome contributions! Please feel free to submit a Pull Request or open an issue for any bugs or feature requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
