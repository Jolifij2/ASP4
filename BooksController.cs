using FiltersApp.Filters;
using FiltersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersApp.Controllers
{
    // Логирование и запись в файл — для всех методов
    [LogActionFilter]
    [FileLogFilter]
    [TimingFilter]
    public class BooksController : Controller
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Война и мир", Author = "Лев Толстой", Year = 1869 },
            new Book { Id = 2, Title = "Преступление и наказание", Author = "Фёдор Достоевский", Year = 1866 },
            new Book { Id = 3, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Year = 1967 }
        };

        // GET: /Books
        [HttpGet]
        public IActionResult Index() => View(_books);

        // GET: /Books/Details/5
        [HttpGet]
        [PositiveIdFilter]
        public IActionResult Details(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound($"Книга с ID {id} не найдена");
            return Json(book);
        }

        // GET: /Books/Create
        [HttpGet]
        public IActionResult Create() => Content("Форма создания книги (GET)");

        // POST: /Books/Create
        [HttpPost]
        public IActionResult Create(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return Content($"Книга '{book.Title}' добавлена!");
        }

        // GET: /Books/Search?author=Толстой
        [HttpGet]
        public IActionResult Search(string author)
        {
            var results = _books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
            return Json(results);
        }

        // Другое имя действия
        [HttpGet]
        [ActionName("AllBooks")]
        public IActionResult GetAll() => Json(_books);

        // Не действие
        [NonAction]
        public string GetInternalInfo() => "Этот метод нельзя вызвать из браузера";

        // Только для админа
        [HttpGet]
        [AdminOnlyFilter]
        public IActionResult DeleteAll()
        {
            _books.Clear();
            return Content("Все книги удалены!");
        }
    }
}
