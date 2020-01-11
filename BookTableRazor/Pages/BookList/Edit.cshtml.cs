using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTableRazor.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTableRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly AplicationDbContext _db;

        public EditModel(AplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }
            var bookFromDb = await _db.Books.FindAsync(Book.Id);
            bookFromDb.Name = Book.Name;
            bookFromDb.Author = Book.Author;
            bookFromDb.ISBN = Book.ISBN;

            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}