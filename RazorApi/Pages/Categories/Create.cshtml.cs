using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApi.Data;
using RazorApi.Model;

namespace RazorApi.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Category category { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            
            if (category.Name == category.DisplayOrder.ToString())
            {
                if (category.Name.Contains(category.DisplayOrder.ToString()))
                {
                    ModelState.AddModelError("name&order", "the dispalyOrder cannot match name");

                }
            }
            if (ModelState.IsValid)
            {
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                TempData["success"] = "category created succesfully";

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
