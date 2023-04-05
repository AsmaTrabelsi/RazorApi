using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApi.Data;
using RazorApi.Model;

namespace RazorApi.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public EditModel(ApplicationDbContext context)
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
            
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name&order", "the dispalyOrder cannot match name");
            }
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                await context.SaveChangesAsync();
                TempData["success"] = "category updated succesfully";

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
