using MedicDefense.API.Profiles.Application.CommandServices;
using MedicDefense.API.Profiles.Application.QueryServices;
using MedicDefense.API.Profiles.Domain.Model.Commands;
using MedicDefense.API.Profiles.Domain.Model.Queries;
using MedicDefense.API.Profiles.Domain.Services;
using MedicDefense.API.Profiles.Interfaces.REST.Resources;
using MedicDefense.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Profiles.Infrastructure.Controllers;

[ApiController]
[Route("api/profiles")]
public class ProfileController : ControllerBase
{
    private readonly IProfileCommandService _profileCommandService;
    private readonly IProfileQueryService _profileQueryService;

    public ProfileController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    {
        _profileCommandService = profileCommandService;
        _profileQueryService = profileQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileRes resource)
    {
        var command = CreateProfileCommandFromResAssembler.ToCommandFromResource(resource);
        var profile = await _profileCommandService.HandleCreateProfileCommand(command);
        return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, resource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfileRes>> GetProfile(int id)
    {
        var query = new GetProfileByIdQuery(id);
        var profile = await _profileQueryService.HandleGetProfileByIdQuery(query);
        if (profile == null) return NotFound();
        var profileRes = ProfileResFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileRes);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProfileRes>>> GetAllProfiles()
    {
        var profiles = await _profileQueryService.GetAllProfilesAsync();
        var profileResList = profiles.Select(ProfileResFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResList);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfile(int id)
    {
        await _profileCommandService.DeleteProfile(id);
        return NoContent();
    }
}
