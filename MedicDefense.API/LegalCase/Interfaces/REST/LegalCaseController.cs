using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MedicDefense.API.LegalCase.Domain.Model.Queries;
using MedicDefense.API.LegalCase.Domain.Services;
using MedicDefense.API.LegalCase.Interfaces.REST.Resources;
using MedicDefense.API.LegalCase.Interfaces.REST.Transform;

namespace MedicDefense.API.LegalCase.Interfaces.REST
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class LegalCaseController : ControllerBase
    {
        private readonly ILegalCaseCommandService legalCaseCommandService;
        private readonly ILegalCaseQueryService legalCaseQueryService;

        public LegalCaseController(
            ILegalCaseCommandService legalCaseCommandService,
            ILegalCaseQueryService legalCaseQueryService)
        {
            this.legalCaseCommandService = legalCaseCommandService;
            this.legalCaseQueryService = legalCaseQueryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLegalCase([FromBody] CreateLegalCaseResource resource)
        {
            var createLegalCaseCommand = CreateLegalCaseCommandFromResourceAssembler.toCommandFromResource(resource);
            var result = await legalCaseCommandService.Handle(createLegalCaseCommand);
            return CreatedAtAction(nameof(GetLegalCaseById), new { id = result.Id },
                LegalCaseResourceFromEntityAssembler.toResourceFromEntity(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLegalCases()
        {
            var getAllLegalCasesQuery = new GetAllLegalCasesQuery();
            var result = await legalCaseQueryService.Handle(getAllLegalCasesQuery);
            var resource = result.Select(LegalCaseResourceFromEntityAssembler.toResourceFromEntity);
            return Ok(resource);
        }
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetLegalCaseById(int id)
        {
            var getLegalCaseByIdQuery = new GetLegalCasesByIdQuery(id);
            var result = await legalCaseQueryService.Handle(getLegalCaseByIdQuery);
            var resource = result.Select(LegalCaseResourceFromEntityAssembler.toResourceFromEntity);
            return Ok(resource);
        }

        [HttpGet("CaseNumber/{caseNumber}")]
        public async Task<ActionResult> GetLegalCaseByCaseNumber(string caseNumber)
        {
            var getLegalCaseByCaseNumberQuery = new GetLegalCaseByCaseNumberQuery(caseNumber);
            var result = await legalCaseQueryService.Handle(getLegalCaseByCaseNumberQuery);
            var resource = LegalCaseResourceFromEntityAssembler.toResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("Description/{description}")]
        public async Task<ActionResult> GetLegalCaseByDescription(string description)
        {
            var getLegalCaseByDescriptionQuery = new GetLegalCaseByDescriptionQuery(description);
            var result = await legalCaseQueryService.Handle(getLegalCaseByDescriptionQuery);
            var resource = LegalCaseResourceFromEntityAssembler.toResourceFromEntity(result);
            return Ok(resource);
        }

        [HttpGet("Status/{status}")]
        public async Task<ActionResult> GetLegalCaseByStatus(string status)
        {
            var getLegalCaseByStatusQuery = new GetLegalCaseByStatusQuery(status);
            var result = await legalCaseQueryService.Handle(getLegalCaseByStatusQuery);
            var resource = result.Select(LegalCaseResourceFromEntityAssembler.toResourceFromEntity);
            return Ok(resource);
        }
    }
}