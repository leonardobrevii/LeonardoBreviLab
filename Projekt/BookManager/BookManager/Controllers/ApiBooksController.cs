using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BookManager.Models;
using BookManager.Data;

namespace BookManager.Controllers
{
    public class ApiBooksController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly BookManagerContext _context;

        public ApiBooksController(BookManagerContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string title)
        {
            string url =
                $"https://openlibrary.org/search.json?q={title}";

            var response = await _httpClient.GetStringAsync(url);

            var books = JsonSerializer.Deserialize<OpenLibraryResponse>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View("Results", books?.Docs);


        }
        [HttpPost]
        public async Task<IActionResult> AddToLibrary(
    string title,
    string author,
    int? year)
        {
            var book = new Books
            {
                Title = title,
                Author = author,
                Year = year ?? 0
            };

            _context.Book.Add(book);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Books");
        }
    }
}