namespace MedicDefense.API.Educational.Domain.Model.Commands;

public record CreateEducationalResourceCommand(string Title, string Author, string ContentType, string VideoUrl);