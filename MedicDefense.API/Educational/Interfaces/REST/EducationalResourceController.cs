using System.Net.Mime;
using MedicDefense.API.Educational.Domain.Model.Queries;
using MedicDefense.API.Educational.Domain.Services;
using MedicDefense.API.Educational.Interfaces.REST.Resources;
using MedicDefense.API.Educational.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Educational.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    
    public class EducationalResourceController : ControllerBase
    {
        private readonly IEducationalResourceCommandService educationalResourceCommandService;
        private readonly IEducationalResourceQueryService educationalResourceQueryService;

        public EducationalResourceController(
            IEducationalResourceCommandService educationalResourceCommandService,
            IEducationalResourceQueryService educationalResourceQueryService)
        {
            this.educationalResourceCommandService = educationalResourceCommandService;
            this.educationalResourceQueryService = educationalResourceQueryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEducationalResource([FromBody] CreateEducationalResourceRes resource)
        {
            var createEducationalResourceCommand = CreateEducationalResourceCommandFromResAssembler.toCommandFromResource(resource);
            var result = await educationalResourceCommandService.Handle(createEducationalResourceCommand);
            return CreatedAtAction(nameof(GetEducationalResourceById), new { id = result.Id },
                EducationalResourceResFromEntityAssembler.toResourceFromEntity(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEducationalResourceById(int id)
        {
            var getEducationalResourceByIdQuery = new GetEducationalResourceByIdQuery(id);
            var result = await educationalResourceQueryService.Handle(getEducationalResourceByIdQuery);
            var resource = result.Select(EducationalResourceResFromEntityAssembler.toResourceFromEntity);
            return Ok(resource);
        }

        [HttpGet("Title/{title}")]
        public async Task<ActionResult> GetEducationalResourceByTitle(string title)
        {
            var getEducationalResourceByTitleQuery = new GetEducationalResourceByTitleQuery(title);
            var result = await educationalResourceQueryService.Handle(getEducationalResourceByTitleQuery);
            var resource = EducationalResourceResFromEntityAssembler.toResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("Author/{author}")]
        public async Task<ActionResult> EducationalResourceByAuthor(string author)
        {
            var getEducationalResourceByAuthorQuery = new GetEducationalResourceByAuthorQuery(author);
            var result = await educationalResourceQueryService.Handle(getEducationalResourceByAuthorQuery);
            var resource = EducationalResourceResFromEntityAssembler.toResourceFromEntity(result);
            return Ok(resource);
        }
    }
}