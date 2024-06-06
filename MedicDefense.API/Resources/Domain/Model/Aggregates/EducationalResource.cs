using MedicDefense.API.Resources.Domain.Model.Commands;

namespace MedicDefense.API.Resources.Domain.Model.Aggregates;

public class EducationalResource
{
    public int Id { get; private set; }
    
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ContentType { get; private set; }
    public string VideoUrl { get; private set; }
    
    protected EducationalResource()
    {
        this.Title = string.Empty;
        this.Author = string.Empty;
        this.ContentType = string.Empty;
        this.VideoUrl = string.Empty;
    }

    public EducationalResource(CreateEducationalResourceCommand command)
    {
        this.Title = command.Title;
        this.Author = command.Author;
        this.ContentType = command.ContentType;
        this.VideoUrl = command.VideoUrl;
    }
}