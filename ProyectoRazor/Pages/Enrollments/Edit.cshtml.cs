using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoRazor.Data;
using ProyectoRazor.Models;

namespace ProyectoRazor.Pages.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly UniversityContext _context;

        public EditModel(UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            Enrollment = enrollment;
            ViewData["StudentId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Students.ToListAsync(), "Id", "FirstName", Enrollment.StudentId);
            ViewData["CourseId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Courses.ToListAsync(), "Id", "Title", Enrollment.CourseId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["StudentId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Students.ToListAsync(), "Id", "FirstName");
                ViewData["CourseId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _context.Courses.ToListAsync(), "Id", "Title");
                return Page();
            }

            _context.Attach(Enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id == id);
        }
    }
}
