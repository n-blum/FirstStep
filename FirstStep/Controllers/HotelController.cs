using FirstStep.Data;
using FirstStep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstStep.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            //Mapping auf: /Hotel/Index
            // /Hotel/
            var rep = new HotelRepository();
            var hotels = rep.FindAll();
            return View("Index", hotels);
            // return View(Hotels);
        }

        //Zum Editieren abrufen:
        public ActionResult Edit(int id)
        {
            ViewBag.SterneAuswahl = CreateSterne();
            var rep = new HotelRepository();
            var hotel = rep.FindById(id);
            return View(hotel);
        }

        //Zum Speichern des Hotels:
        [HttpPost]
        public ActionResult Edit(Hotel h)
        {
            ViewBag.SterneAuswahl = CreateSterne();
            var rep = new HotelRepository();
            rep.Save(h);
            ViewBag.Message =
            "Ihr Hotel wurde gespeichert!";
            return View(h);
        }

        //public ActionResult Delete(int id)
        //{
        //    var rep = new HotelRepository();
        //    var hotel = rep.FindById(id);
        //    rep.Delete(id);
        //    ViewBag.Message =
        //    "Ihr Hotel wurde gelöscht!";
        //    return View(hotel);
        //}

        //Zum Löschen abrufen:
        public ActionResult Delete(int id)
        {
            var rep = new HotelRepository();
            var hotel = rep.FindById(id);
            return View(hotel);
        }

        //Zum Löschen des Hotels:
        [HttpPost]
        public ActionResult Delete(Hotel h)
        {
            var rep = new HotelRepository();
            rep.Delete(h);
            ViewBag.Message =
            "Ihr Hotel wurde gelöscht!";
            return View(h);
        }

        public ActionResult Details(int id)
        {
            var rep = new HotelRepository();
            var hotel = rep.FindById(id);
            return View(hotel);
        }

        private static List<SelectListItem> CreateSterne()
        {
            var items = new List<SelectListItem>();
            for (int i = 1; i < 6; i++)
            {
                var item = new SelectListItem();
                item.Text = i + " Stern(e)";
                item.Value = i.ToString();
                items.Add(item);
            }
            return items;
        }

    }
}