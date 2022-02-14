using BooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksRazor.Controllers
{

	[Route("api/book")]
	[ApiController]
	public class BookController : Controller
	{
		private readonly ApplicationDbContext db;

		public BookController(ApplicationDbContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Json(new { data = await db.Books.ToListAsync() });
		}

		public async Task<IActionResult> Delete(int id)
		{
			var bookFromDb = await db.Books.FirstOrDefaultAsync(u => u.Id == id);
			if (bookFromDb == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}
			db.Books.Remove(bookFromDb);
			await db.SaveChangesAsync();
			return Json(new { success = true, message = "Delete successful" });

		}




	}
}
