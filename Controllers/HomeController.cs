using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsAndDishes.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context=context;
    }


    public IActionResult Index()
    {
        ViewBag.allChefs=_context.Chefs.Include(a=>a.CreatedDishes).ToList();
        return View();
    }

    [HttpGet("/dishes")]
    public IActionResult DishPage()
    {
        ViewBag.allDishes=_context.Dishes.Include(a=>a.Chef).ToList();
        return View("DishPage");
    }

    [HttpGet("new")]
    public IActionResult NewChef()
    {
        return View();
    }

    [HttpPost("addChef")]
    public IActionResult addChef(Chef newChef)
    {
        if(ModelState.IsValid){
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else{
            return View("NewChef");
        }
    }

    [HttpGet("newDish")]
    public IActionResult newDish()
    {
        ViewBag.allChefs=_context.Chefs.ToList();
        return View();
    }

    [HttpPost("addDish")]
    public IActionResult addDish(Dish newDish)
    {
        ViewBag.allChefs=_context.Chefs.ToList();
        if (ModelState.IsValid){
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("DishPage");
        }
        else{
            return View("newDish");
        }
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
