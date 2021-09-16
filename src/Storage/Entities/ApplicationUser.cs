namespace PredictionPlanner.Storage.Entities;

public class ApplicationUser
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string NormalizedEmail { get; set; } = default!;
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; } = default!;
    public string PublicKey { get; set; } = default!;
    public string PrivateKey { get; set; } = default!;
    public ICollection<Prediction> Predictions { get; set; } = default!;
}
