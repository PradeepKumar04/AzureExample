using AzureWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _dbContext;

        public MovieController(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Movie> movies = _dbContext.Movies.ToList<Movie>();
            return View(movies);
        }

        public async Task<IActionResult> GetMovieById(int id)
        {
            Movie movie = await _dbContext.Movies.FindAsync(id);
            return View(movie);
        }


        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if(movie.Id==0)
            {
                _dbContext.Movies.Add(movie);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Movie movie1 =await  _dbContext.Movies.FindAsync(movie.Id);
                movie1.MovieImage = movie.MovieImage;
                movie1.Name = movie.Name;
                movie1.Rating = movie.Rating;
                movie1.Genre = movie.Genre;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            Movie movie = await _dbContext.Movies.FindAsync(id);
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateMovie(int id)
        {
            Movie movie = await _dbContext.Movies.FindAsync(id);
            return View("AddMovie",movie);
        }

    }
}
