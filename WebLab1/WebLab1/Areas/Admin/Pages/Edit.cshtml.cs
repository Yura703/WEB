using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;

namespace WebLab.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebLab.DAL.Data.ApplicationDbContext _context;

        private IWebHostEnvironment _environment;
        public EditModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }
        [BindProperty]
        public Plane Plane { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }        


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plane = await _context.Planes
                .Include(p => p.Group).FirstOrDefaultAsync(m => m.PlaneId == id);

            if (Plane == null)
            {
                return NotFound();
            }
           ViewData["PlaneGroupId"] = new SelectList(_context.PlaneGroups, "PlaneGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    if (Image != null)
        //    {
        //        var fileName = $"{Plane.PlaneId}" + Path.GetExtension(Image.FileName);
        //        Plane.Image = fileName;
        //        var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
        //        using (var fStream = new FileStream(path, FileMode.Create))
        //        {
        //            await Image.CopyToAsync(fStream);
        //        }
        //    }
        //}




        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Image != null)
            {
                var fileName = $"{Plane.PlaneId}" + Path.GetExtension(Image.FileName);
                Plane.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }

            _context.Attach(Plane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaneExists(Plane.PlaneId))
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

        private bool PlaneExists(int id)
        {
            return _context.Planes.Any(e => e.PlaneId == id);
        }
    }
}
