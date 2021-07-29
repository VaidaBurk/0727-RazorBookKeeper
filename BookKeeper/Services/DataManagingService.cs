using BookKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Services
{
    public class DataManagingService
    {
        public List<string> SelectAuthors(List<BookModel> books)
        {
            return books.Select(book => book.Author).Distinct().ToList();
        }

        public List<BookModel> SelectBookByAuthor(List<BookModel> books, string bookAuthor)
        {
            return books.Where(book => book.Author == bookAuthor).ToList();
        }
    }
}
