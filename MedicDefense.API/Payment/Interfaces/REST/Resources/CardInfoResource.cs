namespace MedicDefense.API.Payment.Interfaces.Resources;

public record CardInfoResource(int Id,string CardNumber, 
    string SecurityNumber, 
    string CardHolderName, 
    int Month, 
    int Year);