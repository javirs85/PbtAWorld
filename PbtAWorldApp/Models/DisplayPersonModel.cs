using System.ComponentModel.DataAnnotations;

namespace PbtAWorldApp.Models;

public class DisplayPersonModel
{
    [Required]
    [StringLength(15, ErrorMessage = "First name is too long.")]
    [MinLength(5, ErrorMessage = "First name is too short")]
    public string FirstName { get; set; } = "";

    [Required]
    [StringLength(15, ErrorMessage = "Second name is too long.")]
    [MinLength(5, ErrorMessage = "Second name is too short")]
    public string LastName { get; set; } = "";

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = "";
}
