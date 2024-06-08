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
public class PriceController : ControllerBase
{
    private readonly IPriceCommandService priceCommandService;
    private readonly IPriceQueryService priceQueryService;

    public PriceController(
        IPriceCommandService priceCommandService,
        IPriceQueryService priceQueryService)
    {
        this.priceCommandService = priceCommandService;
        this.priceQueryService = priceQueryService;
    }
    [HttpPost]
    public async Task<IActionResult> CreatePrice([FromBody] CreatePriceResource createPriceResource)
    {
        var createPriceCommand =
            CreatePriceCommandFromResourceAssembler.ToCommandFromResource(createPriceResource);
        var price = await priceCommandService.Handle(createPriceCommand);
        if (price is null) return BadRequest();
        var resource = PriceResourceFromEntityAssembler.ToResourceFromEntity(price);
        return CreatedAtAction(nameof(GetPriceById), new { priceId = resource.Id }, resource);
    }
    
    [HttpGet("{priceId}")]
    public async Task<IActionResult> GetPriceById(int priceId)
    {
        var getPriceByIdQuery = new GetPriceByIdQuery(priceId);
        var price = await priceQueryService.Handle(getPriceByIdQuery);
        var resource = PriceResourceFromEntityAssembler.ToResourceFromEntity(price);
        return Ok(resource);
    }
    [HttpGet("LawyerId/{lawyerId}")]
    public async Task<ActionResult> GetPriceByLawyerId(int lawyerId)
    {
        var getPriceByLawyerIdQuery = new GetAllPriceByLawyerIdQuery(lawyerId);
        var prices = await priceQueryService.Handle(getPriceByLawyerIdQuery);
        var resources = prices.Select(PriceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}