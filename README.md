# dotnet-grpc-test

A simple project to demonstrate gRPC with .NET.

## Features

- gRPC server and client implementation
- Example service and message definitions
- Easy to extend for your own use cases

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [gRPC tools](https://grpc.io/docs/)

## Getting Started

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/dotnet-grpc-test.git
    cd dotnet-grpc-test
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Run the server:
    ```bash
    dotnet run --project Server
    ```

4. Run the client (in a new terminal):
    ```bash
    dotnet run --project Client
    ```

## Project Structure

- `Server/` - gRPC server implementation
- `Client/` - gRPC client implementation
- `Protos/` - Protocol Buffers definitions

## License

This project is licensed under the MIT License.
