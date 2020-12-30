using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvc.Models;
namespace DemoMvc.Controllers
{
    public class MoviesController : Controller
    {
        List<Movies> movielist = null;
        public void CreateList()
        {
            movielist = new List<Movies>
            {
                new Movies{MovieId=1,Name="Gold",Year=2018,Rating=4},
                  new Movies{MovieId=2,Name="LootCase",Year=2020,Rating=3},
                    new Movies{MovieId=3,Name="Gunjan",Year=2020,Rating=2},
                      new Movies{MovieId=4,Name="War",Year=2019,Rating=4},
                        new Movies{MovieId=5,Name="Ludo",Year=2020,Rating=3}

            };
        }
        public ActionResult Show(int movieid)
        {
            CreateList();
            var movie = movielist.Where(mov=>mov.MovieId==movieid).FirstOrDefault();
            return View(movie);
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            Movies movies = new Movies { MovieId = 1, Name = "Gold", Year = 2018, Rating = 4 };
            return View(movies);
        }
        public ActionResult List()
        {
            CreateList();
            return View(movielist);
        }
    }
}