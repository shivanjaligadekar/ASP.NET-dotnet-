using Microsoft.AspNetCore.Mvc;
using StateManagementDemo.Models;

namespace StateManagementDemo.Controllers
{
    public class UsersController : Controller
    {
        static List<UsersViewModels> userslist = new List<UsersViewModels>()
        {
            new UsersViewModels{UserName="shivanjali",Password="shiv1234"},
            new UsersViewModels{UserName="anjali",Password="anjali1234"},
            new UsersViewModels{UserName="priya",Password="priya1234" }
        };
        public IActionResult Index()
        { 
            ViewBag.userame = "Riya";
            ViewBag.usersData=userslist;

            ViewData["newname"] = "Nikeeta";
            ViewData["newUserList"] = userslist;
            return View();
        }

        public ActionResult SendData()
        {
            TempData["v1"] = "Greetings";
            TempData.Put("loggedUsers", userslist);

            return RedirectToAction("ReceiveData");
        }

        public ActionResult ReceiveData()
        {
            string s = TempData["v1"].ToString();
            ViewBag.receivedData = s;

            List<UsersViewModels> newlist = new List<UsersViewModels>();
            newlist = (List<UsersViewModels>)TempData.Get< List<UsersViewModels>>("loggedUsers");

            return View(newlist);
        }

        

    }
}
