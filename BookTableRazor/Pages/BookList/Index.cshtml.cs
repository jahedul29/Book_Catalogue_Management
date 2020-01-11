using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using BookTableRazor.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookTableRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly AplicationDbContext _db;

        public IndexModel(AplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }

        [TempData] 
        public string Message { get; set; }
        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bookFromDb = await _db.Books.FindAsync(id);
            if (bookFromDb == null)
            {
                return NotFound();
            }

            _db.Books.Remove(bookFromDb);
            await _db.SaveChangesAsync();

            Message = "The book was deleted";
            return RedirectToPage("Index");
        }
    }
}