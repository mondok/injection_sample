using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkDISample.Models;

namespace EntityFrameworkDISample.Controllers
{
    public class PeopleController : Controller
    {
        private EfSampleContext DataContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="dataContext">The data context that is injected via the IoC container</param>
        public PeopleController(EfSampleContext dataContext)
        {
            this.DataContext = dataContext;
        }

        // GET: /People/
        public async Task<ActionResult> Index()
        {
            return View(await DataContext.People.ToListAsync());
        }

        // GET: /People/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await DataContext.People.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: /People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DateOfBirth")] Person person)
        {
            if (ModelState.IsValid)
            {
                DataContext.People.Add(person);
                await DataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: /People/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await DataContext.People.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: /People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateOfBirth")] Person person)
        {
            if (ModelState.IsValid)
            {
                DataContext.Entry(person).State = EntityState.Modified;
                await DataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: /People/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await DataContext.People.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: /People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Person person = await DataContext.People.FindAsync(id);
            DataContext.People.Remove(person);
            await DataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DataContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
