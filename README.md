# Key-Value As A Service

## Introduction

In the era of the Internet of Things (IoT), there is a growing need for reliable cloud storage solutions. Many IoT projects only require storing key-value pairs, where each entity consists of a searchable key and its corresponding value. This project aims to provide a Key-Value As A Service API, allowing users to store, retrieve, update, and delete key-value pairs in a cloud-based environment.

## Requirements

The following public APIs have been created to meet the project requirements:

1. **GET /keys/{key}**: Retrieve a key-value pair by its key. Returns 404 (Not Found) if the key does not exist.
2. **POST or PUT /keys**: Add a new key-value pair. Accepts a JSON body with the schema {""key"": ""temp_dev0"", ""value"": ""87""}. Returns 409 (Conflict) if the key already exists.
3. **PATCH /keys/{key}/{value}**: Update the value of an existing key. Returns 404 (Not Found) if the key does not exist.
4. **DELETE /keys/{key}**: Delete a key-value pair by its key. Returns 404 (Not Found) if the key does not exist.

## Implementation Details

- The project is implemented using ASP.NET Core Web API.
- PostgreSQL database is used to store key-value pairs.
- Entity Framework Core is used for database operations.
- Model validation ensures that both the key and value fields are required.
- Error handling is implemented to return appropriate HTTP status codes for different scenarios.

## Getting Started

To run the project locally, follow these steps:

1. Clone this repository to your local machine.
2. Set up a PostgreSQL database and update the connection string in `appsettings.json`.
3. Open the project in Visual Studio or your preferred IDE.
4. Build and run the project.

## Usage

You can interact with the Key-Value As A Service API using tools like Postman or cURL. Here are some example requests:

- **GET /keys/temp_dev0**: Retrieve the value associated with the key ""temp_dev0"".
- **POST /keys**: Add a new key-value pair with the payload {""key"": ""temp_dev1"", ""value"": ""75""}.
- **PATCH /keys/temp_dev0/90**: Update the value associated with the key ""temp_dev0"" to ""90"".
- **DELETE /keys/temp_dev1**: Delete the key-value pair with the key ""temp_dev1"".

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
