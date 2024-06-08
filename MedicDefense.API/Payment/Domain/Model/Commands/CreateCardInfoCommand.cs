namespace MedicDefense.API.Payment.Domain.Model.Commands;

public record CreateCardInfoCommand(
    string CardNumber, 
    string SecurityNumber, 
    string CardHolderName);