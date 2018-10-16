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
    public class DictionaryController : Controller
    {
        static Dictionary<int, string> menuDictionary = new Dictionary<int, string>();
        public ActionResult Dictionary()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            menuDictionary.Add(menuDictionary.Count + 1, "New Entry ");
            return View("Dictionary");
        }
        public ActionResult AddBunch()
        {
            menuDictionary.Clear();
            for (int i = 0; i < 2000; i++)
            {
                menuDictionary.Add(menuDictionary.Count + 1, "New Entry ");
            }
            return View("Dictionary");
        }
        public ActionResult Display()
        {
            ViewBag.StopWatch = "";
            ViewBag.Output = "";
            if (menuDictionary.Count > 0)
            {
                foreach (var item in menuDictionary)
                {
                    ViewBag.Output += item.Value + " " + item.Key + "<br>";
                }
            }
            else
            {
                ViewBag.Output = "<h2>Your data structure is empty!</h2>";
            }
            return View("Dictionary");
        }
        public ActionResult Delete()
        {
            if (menuDictionary.Count > 0)
            {
                menuDictionary.Remove(menuDictionary.Count);
            }
            else
            {
                ViewBag.Output = "<h2>Your data structure is empty :(</h2>";
            }
            return View("Dictionary");
        }
        public ActionResult Clear()
        {
            menuDictionary.Clear();
            return View("Dictionary");
        }

        Random rand = new Random();


        public ActionResult Search()
        {
            ViewBag.Search = "You searched for New Entry 504 <br>";
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

            stopWatch.Start();

            //Look for item
            bool itemFound = false;
            if (menuDictionary.ContainsKey(504))
            {
                itemFound = true;
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
            return View("Dictionary");
        }
    }
}