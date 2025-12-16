using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoRazor.Data;
using ProyectoRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoRazor.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly UniversityContext _context;

        public CreateModel(UniversityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["StudentId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Students.ToListAsync(), "Id", "FirstName");
            ViewData["CourseId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Courses.ToListAsync(), "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["StudentId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Students.ToListAsync(), "Id", "FirstName");
                ViewData["CourseId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Courses.ToListAsync(), "Id", "Title");
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
