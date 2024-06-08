namespace MedicDefense.API.Payment.Interfaces.Resources;

public record CreateCardInfoResource(string CardNumber, 
    string SecurityNumber, 
    string CardHolderName);