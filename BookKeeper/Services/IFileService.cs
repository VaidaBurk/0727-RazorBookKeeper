using BookKeeper.Models;
using System.Collections.Generic;

namespace BookKeeper.Services
{
    public interface IFileService
    {
        List<BookModel> GetDataFromFile();
        void WriteDataToFile(List<BookModel> books);
    }
}