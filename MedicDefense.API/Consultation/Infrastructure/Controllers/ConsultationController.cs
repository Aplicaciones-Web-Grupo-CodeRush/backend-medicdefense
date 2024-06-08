using MedicDefense.API.Consultation.Application.Interfaces;
using MedicDefense.API.Consultation.Application.Services;
using MedicDefense.API.Consultation.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Consultation.Infrastructure.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ConsultationController : ControllerBase
{
    private readonly IConsultationService _consultationService;

    public ConsultationController(IConsultationService consultationService)
    {
        _consultationService = consultationService;
    }

    // GET: api/Consultation/{id}
    [HttpGet("{id}")]
    public ActionResult<Consult> GetConsult(int id)
    {
        var consult = _consultationService.GetConsult(id);
        if (consult == null)
        {
            return NotFound();
        }
        return consult;
    }

    // POST: api/Consultation
    [HttpPost]
    public ActionResult<Consult> CreateConsult([FromBody] Consult consult)
    {
        _consultationService.CreateConsult(consult);
        return CreatedAtAction(nameof(GetConsult), new { id = consult.Id }, consult);
    }

    // PUT: api/Consultation/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateConsult(int id, [FromBody] Consult consult)
    {
        if (id != consult.Id)
        {
            return BadRequest();
        }
        _consultationService.UpdateConsult(consult);
        return NoContent();
    }

    // DELETE: api/Consultation/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteConsult(int id)
    {
        _consultationService.DeleteConsult(id);
        return NoContent();
    }
}