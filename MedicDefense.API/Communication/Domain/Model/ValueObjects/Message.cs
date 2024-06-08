namespace MedicDefense.API.Communication.Domain.Model.ValueObjects;

public record Message(string Information)
{
    public Message() : this(string.Empty)
    {
    }
}