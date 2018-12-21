using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Driver;
using WebMongoDb.Context;
using WebMongoDb.Models;

namespace WebMongoDb.Controllers
{
    public class ContinentController : Controller
    {
        public TestContext Context { get; set; }

        public ContinentController(TestContext context)
        {
            Context = context;
        }

        private MongoContext dbContext = null;

        public MongoContext DbContext => dbContext ?? (dbContext = new MongoContext());

        public IMongoCollection<Continent> Continents => DbContext.Database.GetCollection<Continent>("Continent");

        

        // GET: Continent
        public IActionResult Index()
        {
            //Can use LINQ here

            int i = 0;
            //TestContext conext = new TestContext();
            //var test = conext.Continents.ToList();

            

                foreach (var item in Context.Continents)
                {
                    i++;
                }

            


                //var continents = await Continents.Find(x => true).ToListAsync<Continent>();


                // return View(test.ToList());
                return View();
            
        }

        // GET: Continent/Details/5
        public async Task<IActionResult> Details(string id)
        {
            

            //var model = from e in Continents.AsQueryable<Continent>()
            //            where e.Code == "222"
            //            orderby e.Name
            //            select e;


            var model = await Continents.FindAsync(x => x.Id == new ObjectId(id));

            return View(model.FirstOrDefault());
        }

        // GET: Continent/Create
        public async Task<IActionResult> Create()
        {
            var continents = await Continents.Find(x => true).ToListAsync<Continent>();
            ViewBag.Continents = new SelectList(continents, "Id", "Name");

            return View();
        }

        // POST: Continent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,ParentId")] Continent item)
        {
            try
            {
                var count = Continents.Find<Continent>(x => (x.Name == item.Name) && (x.Code == item.Code)).CountDocuments();

                if (count == 0)
                {
                    await Continents.InsertOneAsync(item);
                }
                else
                {
                    TempData["Message"] = "Continent Already Exists";
                    return View("Create", item);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Continent/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var model = await Continents.FindAsync(x => x.Id == new ObjectId(id));
            return View(model.FirstOrDefault());
        }

        // POST: Continent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Code")] string id, Continent item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var filter = Builders<Continent>.Filter.Eq("_id", new ObjectId(id));
                    var update = Builders<Continent>.Update.Set("Name", item.Name)
                                                            .Set("Code", item.Code);

                    await Continents.UpdateOneAsync(filter, update);

                    //TODO is replace better? Can use continent object
                    //Continents.ReplaceOne()

                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Details", new { id = id });
            }
            return View(item);
        }

        // GET: Continent/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var continents = await Continents.FindAsync(x => x.Id == new ObjectId(id));
            var model = continents.FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(string id)
        {
            //var filter = Builders<Continent>.Filter.Eq("_id", new ObjectId(id));
            //await Continents.DeleteOneAsync(filter);

            await Continents.DeleteOneAsync(x => x.Id == new ObjectId(id));


            return RedirectToAction(nameof(Index));
        }
    }
}