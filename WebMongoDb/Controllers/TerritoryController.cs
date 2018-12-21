using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebMongoDb.Context;
using WebMongoDb.Models;

namespace WebMongoDb.Controllers
{
    public class TerritoryController : Controller
    {
        private MongoContext dbContext = null;

        public MongoContext DbContext => dbContext ?? (dbContext = new MongoContext());

        public IMongoCollection<Territory> Territories => DbContext.Database.GetCollection<Territory>("Territory");


        // GET: Territory
        public ActionResult Index()
        {
            var ters = DbContext.Database.GetCollection<Territory>("Territory");
            var cons = DbContext.Database.GetCollection<Continent>("Continent");
            var flags = DbContext.Database.GetCollection<Flag>("Flag");

            var query = from c in cons.AsQueryable()
                        join t in ters.AsQueryable() on c.Id equals t.ContinentId
                        into joined
                        select new Continent()
                        {
                            Name = c.Name,
                            Code = c.Code,
                            Territories = joined
                        };

            var result = query.ToList();

            var query2 = from t in ters.AsQueryable<Territory>()
                         join c in cons.AsQueryable<Continent>() on t.ContinentId equals c.Id
                         into joined2
                         select new Territory()
                         {
                             Id = t.Id,
                             Name = t.Name,
                             FullName = t.FullName,
                             Continents = joined2
                         };

            var result2 = query2.ToList();

            //var query3 = ters.AsQueryable<Territory>().Join(
            //                cons.AsQueryable<Continent>(),
            //                t => t.ContinentId,
            //                c => c.Id,
            //                (t, c) => CreateTerr(t, c));

            //var result3 = query3.ToList();

            var query4 = ters.AsQueryable<Territory>().Join(
                            cons.AsQueryable<Continent>(),
                            t => t.ContinentId,
                            c => c.Id,
                            (t, c) => new Territory()
                            {
                                Name = t.Name,
                                Continent = c
                            });



            var result4 = query4.ToList();

            var query5 = ters.AsQueryable<Territory>()
                            .Join(
                                flags.AsQueryable<Flag>(),
                                t => t.FlagId,
                                f => f.Id,
                                (territory, flag) => new Territory()
                                {
                                    Name = territory.Name,
                                    Continent = territory.Continent,
                                    Flag = flag
                                }
                            );

            var result5 = query5.ToList();

            var query6 = ters.AsQueryable<Territory>()
                           .Join(
                               cons.AsQueryable<Continent>(),
                               territory => territory.ContinentId,
                               continent => continent.Id,
                               (territory, continent) => new Territory()
                               {
                                   Id = territory.Id,
                                   Name = territory.Name,
                                   FullName = territory.FullName,
                                   ContinentId = territory.ContinentId,
                                   Continent = continent,
                                   Population = territory.Population,
                                   Flag = territory.Flag,
                                   FlagId = territory.FlagId
                               }
                           )
                           .Join(
                               flags.AsQueryable<Flag>(),
                               t => t.FlagId,
                               f => f.Id,
                               (t, f) => new Territory()
                               {
                                   Name = t.Name,
                                   Continent = t.Continent,
                                   Flag = f
                               }
                           );



            return View(result2);

            //var query = DbContext.Database.GetCollection<Territory>("Territory").AsQueryable<Territory>().
            //                Join<Territory, Continent, ObjectId, Territory>(
            //                DbContext.Database.GetCollection<Continent>("Continent").AsQueryable<Continent>().ToList(),
            //                territory => territory.ContinentId,
            //                continent => continent.Id,
            //                (territory, continent) => territory);

            //var query = DbContext.Database.GetCollection<Continent>("Continent").AsQueryable<Continent>().
            //                           Join<Continent, Territory, ObjectId, Continent>(
            //                           DbContext.Database.GetCollection<Territory>("Territory").AsQueryable<Territory>(),
            //                           continent => continent.Id,
            //                           territory => territory.ContinentId,
            //                           (continent, territory) => continent);

            // var result = query.ToJson();

            //var territories = Territories.Find(x => true).ToList<Territory>();
            //return View(territories);
            // return View(result);

        }

        private Territory CreateTerr(Territory t, Continent c)
        {
            t.Continent = c;
            return t;
        }

        // GET: Territory/Details/5
        public ActionResult Details(string id)
        {
            var model = Territories.Find(x => x.Id == new ObjectId(id));
            return View(model.FirstOrDefault());
        }

        // GET: Territory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Territory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Territory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Territory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Territory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Territory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}