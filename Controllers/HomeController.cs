using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private Mission06Context _context;
    public HomeController(Mission06Context temp) //constructor
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult GetToKnow()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovies()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }
    [HttpPost]
    public IActionResult EnterMovies(Movie response)
    {
        _context.Movies.Add(response); //add record to Database
        _context.SaveChanges();
        ViewBag.Categories = _context.Categories.ToList();
        return View("Confirmation", response);
    }

    public IActionResult List()
    {
        // Retrieve all movies from the database and include the Category data
        var movies = _context.Movies.Include(m => m.Category).ToList();

        // Pass the movies list to the view
        return View(movies);
    }
    [HttpGet]
    public IActionResult Edit(int MovieId)
    {
        var movie = _context.Movies.Find(MovieId);
        if (movie == null)
        {
            return NotFound();
        }
        ViewBag.Categories = _context.Categories.ToList();

        return View(movie);
    }

    [HttpPost]

    [ValidateAntiForgeryToken]
    public IActionResult Edit(int MovieId, Movie movie)
    {
        if (MovieId != movie.MovieId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(movie);
    }

    public IActionResult Delete(int MovieId)
    {
        var movie = _context.Movies.Find(MovieId);
        return View(movie);
        
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int MovieId)
    {
        var movie = _context.Movies.Find(MovieId);
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction(nameof(List));
        
    }
    
    

}