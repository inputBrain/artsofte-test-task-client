using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.ViewComponents;

public class Footer : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Pages/Components/FooterView.cshtml");
    }
}