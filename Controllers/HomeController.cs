using Microsoft.AspNetCore.Mvc;
using mission09_jrencher.Models;
using mission09_jrencher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_jrencher.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            //Num Books Per Page
            int pageSize = 10;

            //Organizes the List of Books
            var x = new ProjectsViewModel
            {
                Book = repo.Books
                //Allows us to filter by Category
                .Where(b => b.Category == categoryType || categoryType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (categoryType == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category == categoryType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
