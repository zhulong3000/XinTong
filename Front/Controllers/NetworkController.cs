using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class NetworkController : Controller
    {
        //
        // GET: /Network/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Network/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Network/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Network/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Network/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Network/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Network/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Network/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
