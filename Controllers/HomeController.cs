using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var orders = Repository.GetOrders();

        ViewData["CafeteriaName"] = "Sakarya University Main Cafeteria";
        ViewData["TodayDate"] = DateTime.Now.ToString("dd MMMM yyyy");
        ViewData["CollectedOrdersCount"] = orders.Count(o => o.Collected);

        // Ana sayfada teslim alınan siparişler listeliyor
        var collectedOrders = orders.Where(o => o.Collected).ToList();

        return View(collectedOrders);
    }
}