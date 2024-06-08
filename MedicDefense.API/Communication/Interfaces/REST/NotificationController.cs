using System.Net.Mime;
using MedicDefense.API.Communication.Domain.Model.Queries;
using MedicDefense.API.Communication.Domain.Services;
using MedicDefense.API.Communication.Interfaces.REST.Resources;
using MedicDefense.API.Communication.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace MedicDefense.API.Communication.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class NotificationController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationResource resource)
    {
        var createNotificationCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        if (notification is null) return BadRequest();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return CreatedAtAction(nameof(GetNotificationById), new { notificationId = notificationResource.Id },
            notificationResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotifications()
    {
        var getAllNotificationsQuery = new GetAllNotificationsQuery();
        var notifications = await notificationQueryService.Handle(getAllNotificationsQuery);
        var notificationResources = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(notificationResources);
    }

    [HttpGet("{notificationId:int}")]
    public async Task<IActionResult> GetNotificationById(int notificationId)
    {
        var getNotificationByIdQuery = new GetNotificationByIdQuery(notificationId);
        var notification = await notificationQueryService.Handle(getNotificationByIdQuery);
        if (notification == null) return NotFound();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return Ok(notificationResource);
    }
}