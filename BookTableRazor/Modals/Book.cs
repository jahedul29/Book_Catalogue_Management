using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookTableRazor.Modals
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Book Name")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(15)]
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "Author of Book")]
        public string Author { get; set; }
    }
}
