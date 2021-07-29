using BookKeeper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Services
{
    public class JsonFileService : IFileService
    {
        public const string DATA_URL = "data.json";

        public List<BookModel> GetDataFromFile()
        {
            if (!System.IO.File.Exists(DATA_URL))
            {
                System.IO.File.WriteAllText(DATA_URL, "[]");
            }

            string dataString = System.IO.File.ReadAllText(DATA_URL);
            List<BookModel> books = JsonConvert.DeserializeObject<List<BookModel>>(dataString);

            if (books == null)
            {
                books = new();
            }

            return books;
        }

        public void WriteDataToFile(List<BookModel> books)
        {
            string dataString = JsonConvert.SerializeObject(books);
            System.IO.File.WriteAllText(DATA_URL, dataString);
        }

    }
}
