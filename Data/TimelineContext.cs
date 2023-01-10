using timeline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;

namespace timeline.Data
{
    public class TimelineContext : DbContext
    {
        public TimelineContext(DbContextOptions<TimelineContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Event> Events { get; set; }

        public void SeedData()
        {
            if (!Persons.Any())
            {
                var p = new Person { PersonId = 1, FullName = "Albert Einstein", Code = "ae1" };
                Persons.Add(p);
                p = new Person { PersonId = 2, FullName = "Nathan Rosen", Code = "nr1" };
                Persons.Add(p);
                p = new Person { PersonId = 3, FullName = "Boris Podolsky", Code = "bp1" };
                Persons.Add(p);
                SaveChanges();
            }

            if (!Events.Any())
            {
                //var pIds = new List<int> { 1, 2, 3 };
                var pcs = new List<string> { "ae1" };
                //var ps = Persons.Where(s => pIds.Contains(s.PersonId)).ToList();
                var pc = Persons.Where(s => pcs.Contains(s.Code)).ToList();
                var e = new Event
                {
                    Title = "Albert Einstein blir født 14. mars 1879",
                    Ingress = "Albert Einstein blir født 14. mars 1879 i en jødisk familie i Tyskland.<br />Han ble født i byen Ulm i Kongeriket Württemberg som var en stat i det tyske keiserriket.",
                    Body = "Allerede året etter i 1880 flyttet familien til München, hvor faren Hermann Einstein og onkelen grunnla produksjon av elektriske apparater basert på likestrøm \"Elektrotechnische Fabrik J. Einstein & Cie\".<br />Gjennom faren ble han interessert i både elektromagnetisme og mekanikk.",
                    DisplayTime = "1879 - 14. mars",
                    Time = DateTime.Parse("1879-03-14"),
                    Type = "personal",
                    Persons = pc
                };
                Events.Add(e);

                pcs = new List<string> { "ae1", "bp1", "nr1" };
                pc = Persons.Where(s => pcs.Contains(s.Code)).ToList();
                e = new Event
                {
                    Title = "Kvantekorrelasjon",
                    Ingress = "Et fenomen som beskriver hvordan subatomiske partikler, som elektroner, kan påvirke hverandre på avstand uten å måtte sende noe form for signal eller energi.",
                    Body = "Dette fenomenet ble først beskrevet av Albert Einstein, Boris Podolsky og Nathan Rosen i en artikkel fra 1935 som ble kjent som \"Can Quantum-Mechanical Description of Physical Reality Be Considered Complete?\" (Kan kvantemekanisk beskrivelse av fysisk virkelighet anses som fullstendig?).<br /><br />I denne artikkelen argumenterer de for at kvantemekanikken, som er teorien som beskriver hvordan subatomiske partikler oppfører seg, ikke kan være fullstendig uten å ta hensyn til kvantekorrelasjonen.<br />De hevdet at kvantemekanikken måtte kompletteres med en teori som forklarer hvordan subatomiske partikler påvirker hverandre på avstand.",
                    DisplayTime = "1935 - 15. mai",
                    Time = DateTime.Parse("1935-05-15"),
                    Type = "discovery",
                    Persons = pc
                };
                Events.Add(e);

                SaveChanges();
            }

        }
    }
}