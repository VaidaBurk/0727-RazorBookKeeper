using BookKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Services
{
    public class TextFileService : IFileService
    {
        public List<BookModel> GetDataFromFile()
        {
            if (!System.IO.File.Exists("data.txt"))
            {
                System.IO.File.WriteAllText("data.txt", "");
            }
            List<BookModel> books = new();
            string[] textData = System.IO.File.ReadAllLines("data.txt");
            foreach (string line in textData)
            {
                string[] parameters = line.Split(";");
                BookModel book = new()
                {
                    BookName = parameters[0],
                    Author = parameters[1],
                    Date = parameters[2]
                };
                books.Add(book);
            }
            return books;
        }

        public void WriteDataToFile(List<BookModel> books)
        {
            System.IO.File.WriteAllText("data.txt", "");
            foreach (BookModel book in books)
            {
                System.IO.File.AppendAllText("data.txt", $"{book.BookName};{book.Author};{book.Date}\n");
            }
        }
    }
}
