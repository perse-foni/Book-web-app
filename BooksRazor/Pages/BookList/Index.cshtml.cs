using BooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BooksRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Books> Books { get; set; }


        public async Task OnGet()
        {
            Books = await db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
		{
            var book = await db.Books.FindAsync(id);
            if (book == null)
			{
                return NotFound();
			}
            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return RedirectToPage("Index");
		}
          

    }
}
