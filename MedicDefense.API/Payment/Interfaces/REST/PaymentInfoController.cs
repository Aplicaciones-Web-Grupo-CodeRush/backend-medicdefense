using System.Net.Mime;
using MedicDefense.API.Payment.Domain.Model.Queries;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Payment.Interfaces.Resources;
using MedicDefense.API.Payment.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Payment.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentInfoController : ControllerBase
{
    private readonly IPaymentInfoCommandService paymentInfoCommandService;
    private readonly IPaymentInfoQueryService paymentInfoQueryService;

    public PaymentInfoController(
        IPaymentInfoCommandService paymentInfoCommandService,
        IPaymentInfoQueryService paymentInfoQueryService)
    {
        this.paymentInfoCommandService = paymentInfoCommandService;
        this.paymentInfoQueryService = paymentInfoQueryService;
    }
    [HttpPost]
    public async Task<IActionResult> CreatePaymentInfo([FromBody] CreatePaymentInfoResource createPaymentInfoResource)
    {
        var createPaymentInfoCommand =
            CreatePaymentInfoCommandFromResourceAssembler.ToCommandFromResource(createPaymentInfoResource);
        var payment = await paymentInfoCommandService.Handle(createPaymentInfoCommand);
        if (payment is null) return BadRequest();
        var resource = PaymentInfoResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return CreatedAtAction(nameof(GetPaymentInfoById), new { paymentId = resource.Id }, resource);
    }
    
    [HttpGet("{paymentId}")]
    public async Task<IActionResult> GetPaymentInfoById(int paymentId)
    {
        var getPaymentInfoByIdQuery = new GetPaymentInfoByIdQuery(paymentId);
        var payment = await paymentInfoQueryService.Handle(getPaymentInfoByIdQuery);
        var resource = PaymentInfoResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPaymentInfo()
    {
        var getAllPaymentInfosQuery = new GetAllPaymentInfosQuery();
        var payments = await paymentInfoQueryService.Handle(getAllPaymentInfosQuery);
        var resources = payments.Select(PaymentInfoResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}