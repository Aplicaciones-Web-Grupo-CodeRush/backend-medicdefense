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
public class CardInfoController : ControllerBase
{
    private readonly ICardInfoCommandService cardInfoCommandService;
    private readonly ICardInfoQueryService cardInfoQueryService;

    public CardInfoController(
        ICardInfoCommandService cardInfoCommandService,
        ICardInfoQueryService cardInfoQueryService)
    {
        this.cardInfoCommandService = cardInfoCommandService;
        this.cardInfoQueryService = cardInfoQueryService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCardInfo([FromBody] CreateCardInfoResource createCardInfoResource)
    {
        var createCardInfoCommand =
            CreateCardInfoCommandFromResourceAssembler.ToCommandFromResource(createCardInfoResource);
        var card = await cardInfoCommandService.Handle(createCardInfoCommand);
        if (card is null) return BadRequest();
        var resource = CardInfoResourceFromEntityAssembler.ToResourceFromEntity(card);
        return CreatedAtAction(nameof(GetCardInfoById), new { cardId = resource.Id }, resource);
    }
    
    [HttpGet("{cardId}")]
    public async Task<IActionResult> GetCardInfoById(int cardId)
    {
        var getCardInfoByIdQuery = new GetCardInfoByIdQuery(cardId);
        var card = await cardInfoQueryService.Handle(getCardInfoByIdQuery);
        var resource = CardInfoResourceFromEntityAssembler.ToResourceFromEntity(card);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCardInfo()
    {
        var getAllCardInfoQuery = new GetAllCardInfoQuery();
        var cards = await cardInfoQueryService.Handle(getAllCardInfoQuery);
        var resources = cards.Select(CardInfoResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}