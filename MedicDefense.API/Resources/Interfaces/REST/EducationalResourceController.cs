using System.Net.Mime;
using MedicDefense.API.Resources.Domain.Model.Queries;
using MedicDefense.API.Resources.Domain.Services;
using MedicDefense.API.Resources.Interfaces.REST.Resources;
using MedicDefense.API.Resources.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Resources.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class EducationalResourceController(
    IEducationalResourceCommandService educationalResourceCommandService,
    IEducationalResourceQueryService educationalResourceQueryService)
    : ControllerBase
{
    [HttpPost]
    
    public async Task<ActionResult> CreateEducationalResource([FromBody]CreateEducationalResourceR resource)
    {
        var createEducationalResourceCommand =
            CreateEducationalResourceCommandFromRAssembler.ToCommandFromResource(resource);
        var result = await educationalResourceCommandService.Handle(createEducationalResourceCommand);
        return CreatedAtAction(nameof(GetEducationalResourceById), new { id = result.Id },
            EducationalResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    
    public async Task<ActionResult> GetEducationalResourceById(string id)
    {
        var getEducationalResourceByIdQuery = new GetEducationalResourceByIdQuery(id);
        var result = await educationalResourceQueryService.Handle(getEducationalResourceByIdQuery);
        var resource = EducationalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    public async Task<ActionResult> GetEducationalResourceByTitle(string title)
    {
        var getEducationalResourceByTitleQuery = new GetEducationalResourceByTitleQuery(title);
        var result = await educationalResourceQueryService.Handle(getEducationalResourceByTitleQuery);
        var resource = EducationalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    public async Task<ActionResult> GetEducationalResourceByTitleAndAuthor(string title, string author)
    {
        var getEducationalResourceByTitleAndAuthorQuery = new GetEducationalResourceByTitleAndAuthorQuery(title, author);
        var result = await educationalResourceQueryService.Handle(getEducationalResourceByTitleAndAuthorQuery);
        var resource = EducationalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    public async Task<ActionResult> GetAllEducationalResources()
    {
        var getAllEducationalResourcesQuery = new GetAllEducationalResourceQuery();
        var result = await educationalResourceQueryService.Handle(getAllEducationalResourcesQuery);
        var resources = result.Select(EducationalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}