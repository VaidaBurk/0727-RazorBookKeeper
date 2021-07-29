using BookKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Services
{
    public class MemoryFileService : IFileService
    {
        private List<BookModel> _books = new();
        public List<BookModel> GetDataFromFile()
        {
            return _books;
        }

        public void WriteDataToFile(List<BookModel> books)
        {
            _books = books;
        }
    }
}
