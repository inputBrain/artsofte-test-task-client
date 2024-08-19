using Microsoft.AspNetCore.Mvc;

namespace ArtsofteClient.ViewComponents;

public class Sidebar : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Pages/Components/SidebarView.cshtml");
    }
}