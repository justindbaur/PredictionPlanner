namespace PredictionPlanner.Storage.Entities;

public class Prediction
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string TextHash { get; set; } = default!;
    public string EncryptedText { get; set; } = default!;
    public Guid AuthorId { get; set; }
    public ApplicationUser Author { get; set; } = default!;
}