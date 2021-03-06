﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordWizApp.Helpers;
using WordWizApp.Models;

namespace WordWizApp.Controllers
{
    [Authorize]
    public class WordController : Controller
    {
        private ApplicationDbContext db;
        WordHelper wh = new WordHelper();


        public WordController()
        {
            db = new ApplicationDbContext();
        }


        // GET: Word
        public ActionResult Index()
        {
            var myWords = wh.GetMyWords(db);

            return View(myWords.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Word word)
        {
            if (ModelState.IsValid)
            {                
                word.UserId = User.Identity.GetUserId();
                word.CreatedDate = DateTime.Now;
                word.IsDone = false;
                

                db.Words.Add(word);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Word word)
        {
            if (ModelState.IsValid)
            {
                word.UserId = User.Identity.GetUserId();
                word.CreatedDate = DateTime.Now;
                word.IsDone = false;


                db.Words.Add(word);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Sentences(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }

            return View(word);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }

            return View(word);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}