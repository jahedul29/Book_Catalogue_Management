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
        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }
    }
}