using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class StackController : Controller
    {
        // Create the stack for the stack page
        static Stack<string> menuStack = new Stack<string>();
        public ActionResult Stack()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            menuStack.Push("New Entry " + Convert.ToString(menuStack.Count + 1));
            return View("Stack");
        }
        public ActionResult AddBunch()
        {
            menuStack.Clear();
            for (int i = 0; i < 2000; i++)
            {
                menuStack.Push("New Entry " + Convert.ToString(menuStack.Count + 1));
            }
            return View("Stack");
        }
        public ActionResult Display()
        {
            ViewBag.Output = "";
            if (menuStack.Count > 0)
            {
                foreach (var item in menuStack)
                {
                    ViewBag.Output += item + "<br>";
                }
            }
            else
            {
                ViewBag.Output = "<h2>Your data structure is empty :(</h2>";
            }
            return View("Stack");
        }
        public ActionResult Delete()
        {
            if (menuStack.Count > 0)
            {
                menuStack.Pop();
            }
            else
            {
                ViewBag.Output = "<h2>Your data structure is empty :(</h2>";
            }
            return View("Stack");
        }
        public ActionResult Clear()
        {
            menuStack.Clear();
            return View("Stack");
        }
        public ActionResult Search()
        {
            ViewBag.Search = "You searched for New Entry 504 <br>";
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();

            //Look for item
            bool itemFound = false;
            foreach (var item in menuStack)
            {
                if (item == "New Entry 504")
                {
                    itemFound = true;
                    break;
                }
            }
            stopWatch.Stop();
            if (itemFound)
            {
                ViewBag.Search += "Your item was found! <br>";
            }
            else
            {
                ViewBag.Search += "Your item was not found! <br>";
            }

            TimeSpan timeSpan = stopWatch.Elapsed;
            if (itemFound)
            {
                ViewBag.Search += "It took " + Convert.ToString(timeSpan) + " to search for your item";
            }
            return View("Stack");
        }
        public ActionResult Return()
        {
            return View();
        }
    }
}