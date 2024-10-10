using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTracker.Add;
using MovieTracker.Models;
using System.Text.Json;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;

            // Load data from JSON and seed the database if it's empty
            if (!_context.Movies.Any())
            {
                var movieData = LoadMoviesFromFile();
                if (movieData != null)
                {
                    _context.Movies.AddRange(movieData);
                    _context.SaveChanges();
                }
            }
        }

        // Method to load movies from the JSON file in the Movies folder
        private List<Movie> LoadMoviesFromFile()
        {
            try
            {
                // Construct the file path
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Movies", "movies.json");

                // Read the file content
                var jsonData = System.IO.File.ReadAllText(filePath);

                // Deserialize JSON into a list of Movie objects
                return JsonSerializer.Deserialize<List<Movie>>(jsonData);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error loading movie data: {ex.Message}");
                return null;
            }
        }

        // Get all movies or filter by category
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies([FromQuery] string category = null)
        {
            if (!string.IsNullOrEmpty(category))
            {
                return _context.Movies
                               .Where(m => m.Categories.Contains(category))
                               .ToList();
            }
            return _context.Movies.ToList();
        }

        // Get a single movie by ID
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // Add a new movie (if needed)
        [HttpPost]
        public ActionResult<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        // Update an existing movie
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // Delete a movie by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
