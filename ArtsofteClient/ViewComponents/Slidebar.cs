using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.ViewComponents;

public class Slidebar : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Pages/Components/SlidebarView.cshtml");
    }
}