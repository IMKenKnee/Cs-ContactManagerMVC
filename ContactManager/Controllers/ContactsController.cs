//Kenny Hedlund
//Chapter 4 Contact 
//COP.4813

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactManager.Controllers
{
    // Handles actions related to managing contacts
    public class ContactsController : Controller
    {
        private readonly ContactManagerContext _context; // Database context for accessing contacts and categories

        // Constructor to inject the database context
        public ContactsController(ContactManagerContext context)
        {
            _context = context;
        }

        // Method to populate the dropdown
        private IEnumerable<SelectListItem> GetCategories()
        {
            return _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            }).ToList();
        }

        // List all contacts
        public IActionResult Index()
        {
            var contacts = _context.Contacts.Include(c => c.Category)
                .ToList();
            return View(contacts);
        }

        // Display contact details
        public IActionResult Details(int id)
        {
            var contact = _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // Show the form to add a contact
        public IActionResult Add()
        {
            ViewBag.FormAction = "Add";
            ViewBag.Categories = GetCategories();
            return View("AddEdit", new Contact());
        }

        // Handle the POST request to add a contact
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.DateAdded = DateTime.Now;
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.FormAction = "Add";
            ViewBag.Categories = GetCategories();
            return View("AddEdit", contact);
        }

        // Show form to edit a contact
        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            ViewBag.FormAction = "Edit";
            ViewBag.Categories = GetCategories();
            return View("AddEdit", contact);
        }

        // Handle the POST request to edit a contact
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                    _context.Contacts.Update(contact); // Updates the contact in the database
                    _context.SaveChanges();           // Saves the changes
                    return RedirectToAction("Index", "Home"); // Redirects to Index
            }

            // If ModelState is invalid, reload the form with validation errors
            ViewBag.FormAction = "Edit";
            ViewBag.Categories = GetCategories();
            return View("AddEdit", contact);
        }

        // Show the form to confirm deletion of a contact
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // Handle the POST request to delete a contact
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
