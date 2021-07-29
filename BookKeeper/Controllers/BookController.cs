using BookKeeper.Models;
using BookKeeper.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Controllers
{
    public class BookController : Controller
    {
        private IFileService _jsonFileService;
        //private DataManagingService _dataManagingService;

        public BookController(IFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
            //_dataManagingService = dataManagingService;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            List<BookModel> books = _jsonFileService.GetDataFromFile();
            return View(books);
        }

        public IActionResult Add(BookModel book)
        {
            List<BookModel> books = _jsonFileService.GetDataFromFile();
            books.Add(book);
            _jsonFileService.WriteDataToFile(books);
            return RedirectToAction("Index");
        }


        public IActionResult ListAuthors()
        {
            List<string> authors = _jsonFileService.GetDataFromFile().Select(book => book.Author).Distinct().ToList();
            return View(authors);
        }

        public IActionResult ListAuthorBooks(string bookAuthor)
        {
            List<BookModel> booksByAuthor = _jsonFileService.GetDataFromFile().Where(book => book.Author == bookAuthor).ToList();
            return View(booksByAuthor);
        }
    }
}
