using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstProject.Data;
using firstProject.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstProject.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesContext _dbContext;

        public MoviesController(MoviesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            var movies = await _dbContext.Movies.ToListAsync();

            return View("Index", movies);
        }

        [HttpPost]
        public async Task<IActionResult> Link(int id)
        {
            Movie movie =_dbContext.Movies.Find(id);
            ViewData["Id"] = movie.Id;
            ViewData["Name"] = movie.Name;
            ViewData["Description"] = movie.Description;
            ViewData["Poster"] = movie.Poster;
            ViewData["Duration"] = movie.DurationInMinutes;
            return View("Edit", movie);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            var movies = await _dbContext.Movies.ToListAsync();

            return View("Index", movies);
        }


        public async Task<IActionResult> Search(string text)
        {
            text = text.ToLower();
            var searchedMovies = await _dbContext.Movies.Where(movie => movie.Name.ToLower().Contains(text)
                                            )
                                        .ToListAsync();
            return View("Index", searchedMovies);
        }

    }
}

