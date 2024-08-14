using MyLibrary_BooksAPIs.Models.DTO;

namespace MyLibrary_BooksAPIs.Data
{
    public class BooksStore
    {
        public static List<BooksDTO> BooksList = new List<BooksDTO>
            {
                new BooksDTO {Id = 1, Title = "Harry Potter"},
                new BooksDTO {Id = 2, Title = "Batatyachi chowl"}
            };
    }
}
