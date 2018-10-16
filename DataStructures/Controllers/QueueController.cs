/*
    Authors: Alec Ostheimer, Ben Walbrecht, Cash Allred, Zach McQuiston
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        static Queue<string> menuQueue = new Queue<string>();
        public ActionResult Queue()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            menuQueue.Enqueue("New Entry " + Convert.ToString(menuQueue.Count + 1));
            return View("Queue");
        }
        public ActionResult AddBunch()
        {
            menuQueue.Clear();
            for (int i = 0; i < 2000; i++)
            {
                menuQueue.Enqueue("New Entry " + Convert.ToString(menuQueue.Count + 1));
            }
            return View("Queue");
        }
        public ActionResult Display()
        {
            ViewBag.Output = "";
            if (menuQueue.Count > 0)
            {
                foreach (var item in menuQueue)
                {
                    ViewBag.Output += item + "<br>";
                }
            }
            else
            {
                ViewBag.Output = "<h2>Your data structure is empty :(</h2>";
            }
            return View("Queue");
        }
        public ActionResult Delete()
        {
            if (menuQueue.Count > 0)
            {
                menuQueue.Dequeue();
            }
            else
            {
                ViewBag.Output = "<h2>Your data structure is empty :(</h2>";
            }
            return View("Queue");
        }
        public ActionResult Clear()
        {
            menuQueue.Clear();
            return View("Queue");
        }
        public ActionResult Search()
        {
            ViewBag.Search = "You searched for New Entry 504 <br>";
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();

            //Look for item
            bool itemFound = false;
            foreach (var item in menuQueue)
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
            return View("Queue");
        }
        public ActionResult Return()
        {
            return View();
        }
    }
}