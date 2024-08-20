using ArtsofteClient.API.Language;
using ArtsofteClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.Controllers;

public class LanguageController : Controller
{
    private const string BaseUrl = "http://localhost:5000/api/Language/";

    private readonly IRequestSender _requestSender;


    public LanguageController(IRequestSender requestSender)
    {
        _requestSender = requestSender;
    }


    public async Task<IActionResult> Index()
    {
        var collection = await _requestSender.SendPostRequest<GetAllLanguageResponse>(BaseUrl + "ListAllLanguage", new object());

        return View(collection);
    }
}