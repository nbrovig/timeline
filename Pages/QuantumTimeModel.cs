using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using timeline.Models;

namespace timeline.Pages
{
    public class QuantumTimeModel : PageModel
    {
        private readonly AppDbContext _context;

        public QuantumTimeModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Event>? Events { get; set; }
        public IList<Person>? Persons { get; set; }

        public async Task OnGetAsync()
        {
            Persons = await _context.Persons.ToListAsync();
            Events = await _context.Events.ToListAsync();
        }
    }
}
