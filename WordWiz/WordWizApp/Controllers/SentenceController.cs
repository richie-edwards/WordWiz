using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WordWizApp.Models;

namespace WordWizApp.Controllers
{
    public class SentenceController : Controller
    {
        private ApplicationDbContext db;

        public SentenceController()
        {
            db = new ApplicationDbContext();
        }


        // GET: Sentence
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create(int wordId)
        {            
            Word word = db.Words.Find(wordId);
            Sentence sentence = new Sentence();
            sentence.Word = word;
            sentence.WordId = word.Id;
           
            return View(sentence);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sentence sentence)
        {
            if (ModelState.IsValid)
            {
                var test = db.Sentences.Include(x => x.Word);
                sentence.IsDone = false;
                var word = db.Words.Find(sentence.WordId);
                word.Sentences.Add(sentence);                
                db.SaveChanges();

                return RedirectToAction("Sentences", "Word", new RouteValueDictionary(new { word.Id }));
            }
            return View();
        }

        // GET: Sentence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sentence sentence = db.Sentences.Find(id);
            if (sentence == null)
            {
                return HttpNotFound();
            }            
            return View(sentence);
        }

        // POST: Sentence/Edit/5  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sentence sentence)
        {
            if (ModelState.IsValid)
            {
                var word = db.Words.Where(w => w.Sentences.Any(s => s.Id == sentence.Id)).FirstOrDefault();
                sentence.WordId = word.Id;
                db.Entry(sentence).State = EntityState.Modified;                
                db.SaveChanges();                
                return RedirectToAction("Sentences", "Word", new RouteValueDictionary(new { word.Id }));
            }            
            return View(sentence);
        }

    }
}