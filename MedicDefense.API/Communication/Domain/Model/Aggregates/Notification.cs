using MedicDefense.API.Communication.Domain.Model.Commands;
using MedicDefense.API.Communication.Domain.Model.ValueObjects;

namespace MedicDefense.API.Communication.Domain.Model.Aggregates;

public partial class Notification
{
    public Notification()
    {
        Information = new Message();
    }

    public Notification(string information)
    {
        Information = new Message(information);
    }

    public Notification(CreateNotificationCommand command)
    {
        Information = new Message(command.Information);
    }
    
    public int Id { get; }
    public Message Information { get; private set; }

    public string Message => Information.Information;
}