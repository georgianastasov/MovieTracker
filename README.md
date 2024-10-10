# 🎬 MovieTracker

MovieTracker is a RESTful web API built with ASP.NET Core, designed to manage a collection of movies. It uses an in-memory database to store movie data and includes several endpoints for retrieving, adding, updating, and deleting movies. The project also supports CORS and provides Swagger integration for API documentation.

## 🚀 Features

- **In-Memory Database**: The application uses an in-memory database to store movie details, making it easy to set up and run without requiring an external database.
- **RESTful Endpoints**: Provides full CRUD operations (Create, Read, Update, Delete) for movie records.
- **Swagger Integration**: Automatically generates API documentation and allows testing through the Swagger UI.
- **CORS Support**: Cross-Origin Resource Sharing (CORS) is configured to allow API access from any origin.
- **JSON Seed Data**: Automatically seeds the in-memory database with movie data loaded from a JSON file.

## 📡 Endpoints

- **GET /api/movies**: Retrieve all movies or filter by category (optional query parameter `category`).
- **GET /api/movies/{id}**: Retrieve a movie by its ID.
- **POST /api/movies**: Add a new movie.
- **PUT /api/movies/{id}**: Update an existing movie by ID.
- **DELETE /api/movies/{id}**: Delete a movie by ID.

## 🛠 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- ASP.NET Core

## 📖 Setup Instructions

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/MovieTracker.git
    cd MovieTracker
    ```

2. **Build the project**:
    ```bash
    dotnet build
    ```

3. **Run the project**:
    ```bash
    dotnet run
    ```

4. **Access the API**:
    The API will be running at `https://localhost:5001/api/movies`. You can also access the Swagger UI for API documentation and testing at `https://localhost:5001/swagger`.

## 📂 Project Structure

- **Controllers**: Handles incoming HTTP requests. Contains the `MoviesController` to manage the movie-related endpoints.
- **Models**: Contains the `Movie` model, representing the structure of a movie object.
- **Data**: Contains the `AppDbContext` class, which manages the in-memory database.
- **Movies/movies.json**: The initial seed data for movies loaded into the in-memory database.

## 📥 Example Request

To retrieve all movies, send a GET request to:
GET https://localhost:5001/api/movies

To retrieve movies by category (e.g., "Popular"), use:
GET https://localhost:5001/api/movies?category=Popular

## 📑 Swagger API Documentation

If Swagger is enabled in the `appsettings.json`, you can view the API documentation and test the endpoints directly from the Swagger UI:
https://localhost:5001/swagger


## 📜 License

This project is licensed under the MIT License.
