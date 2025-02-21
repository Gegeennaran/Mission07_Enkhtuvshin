using Microsoft.AspNetCore.Mvc;
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
        return View();
    }
    [HttpPost]
    public IActionResult EnterMovies(Application response)
    {
        _context.Applications.Add(response); //add record to Database
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
}