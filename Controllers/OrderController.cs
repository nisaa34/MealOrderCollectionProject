using Microsoft.AspNetCore.Mvc;

public class OrderController : Controller
{
    public IActionResult List()
    {
        var orders = Repository.GetOrders();
        return View(orders);
    }

// Displays the meal collection form page (GET: /Order/Collect)
    [HttpGet]
    public IActionResult Collect()
    {
        return View();
    }

// Handles the form submission to mark an order as collected (POST: /Order/Collect)
    [HttpPost]
    public IActionResult Collect(string orderID)
    {
        var order = Repository.GetOrderByID(orderID);
        if (order == null)
        {
            ModelState.AddModelError("", "Invalid Order ID. Please check and try again.");
            return View();
        }

        Repository.CollectOrder(orderID);
        return RedirectToAction("Details", new { id = orderID });
    }

// Displays detailed information for a specific order (GET: /Order/Details/{id})
    public IActionResult Details(string id)
    {
        var order = Repository.GetOrderByID(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }
}