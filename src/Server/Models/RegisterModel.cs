using System.ComponentModel.DataAnnotations;

namespace PredictionPlanner.Server.Models;

public class RegisterModel
{
    [StringLength(256)]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [StringLength(300)]
    public string PasswordHash { get; set; } = default!;
}
