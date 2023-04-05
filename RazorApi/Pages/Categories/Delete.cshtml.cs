using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApi.Data;
using RazorApi.Model;

namespace RazorApi.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public DeleteModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Category category { get; set; }
        public void OnGet(int id)
        {
            category = context.Categories.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
             
                var categoryFromDb = context.Categories.Find(category.Id);
                if(categoryFromDb != null)
                {
                    context.Categories.Remove(categoryFromDb);
                    await context.SaveChangesAsync();
                TempData["success"] = "category deleted succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
