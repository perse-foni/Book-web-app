using BooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext db;

		public EditModel(ApplicationDbContext db)
		{
            this.db = db;
		}
        [BindProperty]
        public Books Books { get; set; }

        public async Task OnGet(int id)
        {
            Books = await db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
                var BookFromDB = await db.Books.FindAsync(Books.Id);
                BookFromDB.Name = Books.Name;
                BookFromDB.Author = Books.Author;
                BookFromDB.ISBN = Books.ISBN;

                await db.SaveChangesAsync();

                return RedirectToPage("Index");
			}
            return RedirectToPage();
        }  
       

    }
}
