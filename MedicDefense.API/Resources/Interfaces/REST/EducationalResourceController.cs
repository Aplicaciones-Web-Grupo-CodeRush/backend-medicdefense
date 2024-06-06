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
    public async Task<ActionResult> GetEducationalResourceById(int id)
    {
        var getEducationalResourceByIdQuery = new GetEducationalResourceByIdQuery(id);
        var result = await educationalResourceQueryService.Handle(getEducationalResourceByIdQuery);

        if (result == null)
        {
            return NotFound();
        }

        var resource = EducationalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
}