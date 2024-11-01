using Microsoft.AspNetCore.Mvc;
using PRN231_PE_Trial_Client.Models.PRN231_PE_Trial_Client.Models; // Include your Member model

namespace PRN231_PE_Trial_Client.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            // Here you might typically retrieve member data from the database or an API

            return View();
        }

        // You can add other actions to handle creating, updating, and deleting members
        // For example:
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                // Save the member to the database or call an API
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // Add similar actions for Edit, Delete, etc.

        public IActionResult Details(int id)
        {
            ViewData["MemberId"] = id;
            return View();
        }

        public IActionResult Update(int id)
        {
            ViewData["MemberId"] = id;
            return View();
        }

    }
}

