using Microsoft.AspNetCore.Mvc;
using Portfolio.Misc.Services.EmailSender;
using Portfolio.Misc.Services.Logger;

namespace Portfolio.Controllers;

public class ContactsController : Controller
{
    private readonly IEmailService _emailService;
    private readonly IResponseLogger _responseLogger;

    public ContactsController(IEmailService emailService, IResponseLogger responseLogger)
    {
        _emailService = emailService;
        _responseLogger = responseLogger;
    }

    [HttpGet]
    public IActionResult Index() => 
        View();

    public record MessageModel(string Name, string Email, string Subject, string Message);
    
    [HttpPost]
    public IActionResult SendMessage([FromForm] MessageModel message1)
    {
        _emailService.SendMessageAsync(message1.Email, message1.Message, message1.Name, message1.Subject);
        _responseLogger.AddLog(message1.Email, message1.Message, message1.Name, message1.Subject);
        return RedirectToAction("Index");
    }
}