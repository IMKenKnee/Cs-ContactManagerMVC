//Kenny Hedlund
//Chapter 4 Contact 
//COP.4813

using System.ComponentModel.DataAnnotations; // Provides data validation attributes

namespace ContactManager.Models
{
    // Contact class entity
    public class Contact
    {
        // Primary key for the Contact entity
        public int ContactId { get; set; }

        // First Name field with a required validation attribute
        [Required(ErrorMessage = "Please enter a first name.")]
        public string? FirstName { get; set; }

        // Last Name field with a required validation attribute
        [Required(ErrorMessage = "Please enter a last name.")]
        public string? LastName { get; set; }

        // Phone number field with a required validation attribute
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string? Phone { get; set; }

        // Email field with a required and email validation attribute
        [Required, EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string? Email { get; set; }

        // Organization field -> optional
        public string? Organization { get; set; }

        // CategoryId field with required and range validation -> set by dropdown list
        [Required]
        [Range(1, 3, ErrorMessage = "You must choose between the 3 options.")]
        public int CategoryId { get; set; }

        // Navigation property for the associated Category -> made nullible as dropdown forces validated input
        public Category? Category { get; set; }

        // DateAdded field to store when the contact was added
        public DateTime DateAdded { get; set; }
    }
}