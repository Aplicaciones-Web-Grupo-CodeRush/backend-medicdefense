using System.Net.Mime;
using MedicDefense.API.Consultation.Application.CommandServices;
using MedicDefense.API.Consultation.Application.QueryServices;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MedicDefense.API.Consultation.Domain.Model.Queries;
using MedicDefense.API.Consultation.Domain.Services;
using MedicDefense.API.Consultation.Interfaces.REST.Resources;
using MedicDefense.API.Consultation.Interfaces.REST.Transform;

namespace MedicDefense.API.Consultation.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class ConsultationController : ControllerBase
{
    private readonly IConsultCommandService _consultCommandService;
    private readonly IConsultQueryService _consultQueryService;

    public ConsultationController(IConsultCommandService consultCommandService, IConsultQueryService consultQueryService)
    {
        _consultCommandService = consultCommandService;
        _consultQueryService = consultQueryService;
    }

    // GET: api/Consultation/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ConsultRes>> GetConsult(int id)
    {
        var consult = await _consultQueryService.Handle(new GetConsultByIdQuery(id));
        if (consult == null)
        {
            return NotFound();
        }
        var consultRes = ConsultResFromEntityAssembler.ToResourceFromEntity(consult);
        return consultRes;
    }
    
    // GET: api/Consultation
    [HttpGet]
    public ActionResult<List<Consult>> Get()
    {
        return Ok(_consultCommandService.GetAllConsults());
    }
    
    // POST: api/Consultation
    [HttpPost]
    public async Task<IActionResult> CreateConsult([FromBody] CreateConsultRes consultRes)
    {
        var createConsultCommand = CreateConsultCommandFromResAssembler.ToCommandFromResource(consultRes);
        var consult = await _consultCommandService.HandleCreateConsultCommand(createConsultCommand);
        return CreatedAtAction(nameof(GetConsult), new { id = consult.Id }, consultRes);
    }
    
    //POST: api/Doctor
    [HttpPost("Doctor")]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorRes doctorRes)
    {
        var createDoctorCommand = CreateDoctorCommandFromResAssembler.ToCommandFromResource(doctorRes);
        var doctor = await _consultCommandService.HandleCreateDoctorCommand(createDoctorCommand);
        return CreatedAtAction(nameof(GetConsult), new { id = doctor.Id }, doctorRes);
    }
    
    //POST: api/Lawyer
    [HttpPost("Lawyer")]
    public async Task<IActionResult> CreateLawyer([FromBody] LawyerRes lawyerRes)
    {
        var createLawyerCommand = CreateLawyerCommandFromResAssembler.ToCommandFromResource(lawyerRes);
        var lawyer = await _consultCommandService.HandleCreateLawyerCommand(createLawyerCommand);
        return CreatedAtAction(nameof(GetConsult), new { id = lawyer.Id }, lawyerRes);
    }
    
    
 

    // PUT: api/Consultation/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateConsult(int id, [FromBody] Consult consult)
    {
        if (id != consult.Id)
        {
            return BadRequest();
        }
        _consultCommandService.UpdateConsult(consult);
        return NoContent();
    }

    // DELETE: api/Consultation/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteConsult(int id)
    {
        _consultCommandService.DeleteConsult(id);
        return NoContent();
    }
    
    
}