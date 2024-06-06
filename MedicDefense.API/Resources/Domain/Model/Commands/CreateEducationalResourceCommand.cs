namespace MedicDefense.API.Resources.Domain.Model.Commands;

public record CreateEducationalResourceCommand(string Title, string Author, string ContentType, string VideoUrl);