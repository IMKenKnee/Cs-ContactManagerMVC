//Kenny Hedlund
//Chapter 4 Contact 
//COP.4813

using ContactManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    // Category class entity
    public class Category
    {
        // Primary Key for category
        // Name field with a required validation attribute -> redundant
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please choose a category.")]
        public string? Name { get; set; }

        // Navigation property for the associated Contacts
        // This allows a Entity Framework relationship between Categories and Contacts
        public ICollection<Contact>? Contacts { get; set; }
    }
}

