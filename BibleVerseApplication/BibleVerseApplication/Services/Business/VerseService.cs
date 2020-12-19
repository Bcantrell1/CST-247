using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Data;
using BibleVerseApplication.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApplication.Services.Business
{
    public class VerseService 
    {
        private DAO dao;

        public VerseService(VerseModel model)
        {
            dao = new DAO(model);
        }

        public List<string> SearchVerses()
        {
            MyLogger.GetInstance().Info("Now using SearchVerses()");
            List<string> verse = dao.SearchVerse();
            if (verse[0] != "No results found!")
            {
                MyLogger.GetInstance().Info("Verse: " + verse[4]);
            }
            else
            {
                MyLogger.GetInstance().Info("Could not find results for that search.");
            }
            return verse;
        }

        public bool InsertVerse()
        {

            if (dao.CheckExisting())
            {
                dao.InsertVerse();
                MyLogger.GetInstance().Info("Verse has been added.");
                return true;
            }
            else
            {
                MyLogger.GetInstance().Info("This verse already exists.");
                return false;
            }
        }
    }
}