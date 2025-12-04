using System.ComponentModel.DataAnnotations;

namespace IMQ.Web.Models;

public class AddQualificationModel
{
    [Required(ErrorMessage = "Qualification Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Qualification Type is required")]
    public string Type { get; set; } = string.Empty;

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
    public string? Description { get; set; }

    [Range(0.1, 50, ErrorMessage = "Years of Experience must be between 0.1 and 50")]
    public decimal? YearsExperience { get; set; }

    [StringLength(200, ErrorMessage = "Issuing Organization cannot exceed 200 characters")]
    public string? IssuingOrganization { get; set; }

    [Required(ErrorMessage = "Date Acquired is required")]
    public DateTime DateAcquired { get; set; } = DateTime.Today;

    public DateTime? ExpirationDate { get; set; }

    [Range(typeof(bool), "true", "true", ErrorMessage = "You must confirm this qualification is valid and current")]
    public bool SelfAttestation { get; set; }
}
