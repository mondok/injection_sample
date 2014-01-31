using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkDISample.Models;

namespace EntityFrameworkDISample.Controllers
{
    public class HomeController : Controller
    {
        private EfSampleContext DataContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="dataContext">The data context that is injected via the IoC container</param>
        public HomeController(EfSampleContext dataContext)
        {
            this.DataContext = dataContext;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}