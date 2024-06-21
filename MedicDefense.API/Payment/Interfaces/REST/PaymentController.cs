using System.Net.Mime;
using MedicDefense.API.Payment.Domain.Model.Queries;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Payment.Interfaces.REST.Resources;
using MedicDefense.API.Payment.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Payment.Interfaces.REST
{
    [ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentController : ControllerBase
{
    private readonly IPaymentCommandService paymentCommandService;
    private readonly IPaymentQueryService paymentQueryService;
    
    public PaymentController(
        IPaymentCommandService paymentCommandService,
        IPaymentQueryService paymentQueryService)
    {
        this.paymentCommandService = paymentCommandService;
        this.paymentQueryService = paymentQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var createPaymentCommand = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await paymentCommandService.Handle(createPaymentCommand);
        return CreatedAtAction(nameof(GetPaymentById), new { id = result.Id },
            PaymentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetPaymentById([FromRoute] int id)
    {
        var getPaymentByIdQuery = new GetPaymentByIdQuery(id);
        var result = await paymentQueryService.Handle(getPaymentByIdQuery);
        var resource = result.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllPayments()
    {
        var getAllPaymentsQuery = new GetAllPaymentsQuery();
        var result = await paymentQueryService.Handle(getAllPaymentsQuery);
        var resources = result.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet("Payer/{payerId}")]
    public async Task<ActionResult> GetAllPaymentsByPayerId([FromRoute] long payerId)
    {
        var getPaymentsByPayerIdQuery = new GetPaymentsByPayerIdQuery(payerId);
        var result = await paymentQueryService.Handle(getPaymentsByPayerIdQuery);
        var resources = result.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet("Receiver/{receiverId}")]
    public async Task<ActionResult> GetAllPaymentsByReceiverId([FromRoute] long receiverId)
    {
        var getPaymentsByReceiverIdQuery = new GetPaymentsByReceiverIdQuery(receiverId);
        var result = await paymentQueryService.Handle(getPaymentsByReceiverIdQuery);
        var resources = result.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
}

