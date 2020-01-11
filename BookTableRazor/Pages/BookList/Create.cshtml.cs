using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTableRazor.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTableRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly AplicationDbContext _db;

        public CreateModel(AplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            Message = "Book added succesfuly";
            return RedirectToPage("Index");
        }
    }
}