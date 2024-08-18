using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.ViewComponents;

public class Header : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Pages/Components/HeaderView.cshtml");
    }
}