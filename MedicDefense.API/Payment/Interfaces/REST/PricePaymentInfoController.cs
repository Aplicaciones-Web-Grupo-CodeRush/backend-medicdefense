using System.Net.Mime;
using MedicDefense.API.Payment.Domain.Model.Queries;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Payment.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Payment.Interfaces;

[ApiController]
[Route("/api/v1/prices/{priceId}/payments")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Prices")]
public class PricePaymentInfoController(IPaymentInfoQueryService paymentInfoQueryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPaymentInfoByPriceId([FromRoute] int priceId)
    {
        var getAllPaymentInfoByPriceIdQuery = new GetAllPaymentInfoByPriceIdQuery(priceId);
        var payments = await paymentInfoQueryService.Handle(getAllPaymentInfoByPriceIdQuery);
        var resources = payments.Select(PaymentInfoResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}