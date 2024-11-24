//Kenny Hedlund
//Chapter 4 Contact 
//COP.4813

using System.Diagnostics;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;

namespace ContactManager.Controllers
{
    // HomeController handles requests for main pages
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger for tracking events and errors
        private readonly ContactManagerContext _context; // Database context for accessing contacts and categories

        // Constructor to inject logger and database contexts
        public HomeController(ILogger<HomeController> logger, ContactManagerContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Displays Index page with contact list
        public IActionResult Index()
        {
            // Retrieves list of contacts from database, including their associated categories
            var contacts = _context.Contacts.Include(c => c.Category).ToList();
            
            // Passes list of contacts to Index view
            return View(contacts);
        }

        // Display an error page on given triggers
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Creates an ErrorViewModel with the current request ID and passes it to the Error view
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
