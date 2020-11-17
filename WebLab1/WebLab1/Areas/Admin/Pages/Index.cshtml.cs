using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;

namespace WebLab.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebLab.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebLab.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Plane> Plane { get;set; }

        public async Task OnGetAsync()
        {
            Plane = await _context.Planes
                .Include(p => p.Group).ToListAsync();
        }
    }
}
