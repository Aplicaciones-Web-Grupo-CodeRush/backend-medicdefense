namespace MedicDefense.API.Communication.Interfaces.ACL;

public interface INotificationContextFacade
{
    Task<int> CreateNotification(string information);
    
    Task<int> FetchNotificationIdByInformation(string information);
}