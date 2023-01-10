using timeline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;

namespace timeline.Data
{
    public class TimelineContext : DbContext
    {
        public TimelineContext(DbContextOptions<TimelineContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Event>().ToTable("Events");
        }

        public void SeedData()
        {
            if (!Persons.Any())
            {
                var p = new Person { FullName = "Albert Einstein", Code = "ae1" };
                Persons.Add(p);
                p = new Person { FullName = "Nathan Rosen", Code = "nr1" };
                Persons.Add(p);
                p = new Person { FullName = "Boris Podolsky", Code = "bp1" };
                Persons.Add(p);
                SaveChanges();
            }

            if (!Events.Any())
            {
                var e = new Event
                {
                    Title = "Albert Einstein blir født 14. mars 1879",
                    Ingress = "Albert Einstein blir født 14. mars 1879 i en jødisk familie i Tyskland.<br />Han ble født i byen Ulm i Kongeriket Württemberg som var en stat i det tyske keiserriket.",
                    Body = "Allerede året etter i 1880 flyttet familien til München, hvor faren Hermann Einstein og onkelen grunnla produksjon av elektriske apparater basert på likestrøm \"Elektrotechnische Fabrik J. Einstein & Cie\".<br />Gjennom faren ble han interessert i både elektromagnetisme og mekanikk.",
                    DisplayTime = "1879 - 14. mars",
                    Time = DateTime.Parse("1879-03-14"),
                    Type = "personal",
                    PersonCodes = "ae1"
                };
                Events.Add(e);

                e = new Event
                {
                    Title = "Kvantekorrelasjon",
                    Ingress = "Et fenomen som beskriver hvordan subatomiske partikler, som elektroner, kan påvirke hverandre på avstand uten å måtte sende noe form for signal eller energi.",
                    Body = "Dette fenomenet ble først beskrevet av Albert Einstein, Boris Podolsky og Nathan Rosen i en artikkel fra 1935 som ble kjent som \"Can Quantum-Mechanical Description of Physical Reality Be Considered Complete?\" (Kan kvantemekanisk beskrivelse av fysisk virkelighet anses som fullstendig?).<br /><br />I denne artikkelen argumenterer de for at kvantemekanikken, som er teorien som beskriver hvordan subatomiske partikler oppfører seg, ikke kan være fullstendig uten å ta hensyn til kvantekorrelasjonen.<br />De hevdet at kvantemekanikken måtte kompletteres med en teori som forklarer hvordan subatomiske partikler påvirker hverandre på avstand.",
                    DisplayTime = "1935 - 15. mai",
                    Time = DateTime.Parse("1935-05-15"),
                    Type = "discovery",
                    PersonCodes = "ae1,bp1,nr1"
                };
                Events.Add(e);

                e = new Event
                {
                    Title = "Einsteins \"Annus mirabilis\"",
                    Ingress = "I 1905 publiserte Albert Einstein flere artikler som skulle vise seg å ha stor betydning for fysikken og for vår forståelse av universet. Artiklene ble publisert i det tyske vitenskapelige tidsskriftet \"Annalen der Physik\".",
                    Body = "<div class='content-div'><i class='fa-regular fa-file-lines' aria-hidden='true'></i><p>\"Eine neue Bestimmung der Moleküldimensionen\"<br>(En ny bestemmelse av molekyldimensjonene).<br>Der Einstein foreslo en ny metode for å bestemme størrelsen på molekyler ved å bruke Brownsk bevegelse. Publisert 30. mai 1905.</p></div><div class='content-div'><i class='fa-regular fa-file-lines' aria-hidden='true'></i><p>\"Zur Elektrodynamik bewegter Körper\"<br>(Om elektrodynamikken for bevegelige kropper).<br>Der Einstein foreslo den såkalte spesielle relativitetsteorien, som innebærer at tid og rom er relativt og at lys alltid reiser med samme hastighet uavhengig av hvor man befinner seg i universet. Publisert 30. juni 1905.</p></div><div class='content-div'><i class='fa-regular fa-file-lines' aria-hidden='true'></i><p>\"Eine Theorie der Photochemischen Reaktionen\"<br>(En teori om fotokjemiske reaksjoner).<br>Der Einstein viste at lys kan overføre energi til kjemiske reaksjoner, noe som senere ble bekreftet av eksperimenter. Publisert 6. september 1905.</p></div><div class='content-div'><i class='fa-regular fa-file-lines' aria-hidden='true'></i><p>\"Über einen die Erzeugung und Verwandlung des Lichtes betreffenden heuristischen Gesichtspunkt\"<br>(Om en heuristisk betraktning som gjelder generering og forvandling av lys).<br>Der Einstein foreslo at lys kan oppfattes både som partikler og som bølger, som senere ble bekreftet av eksperimenter. Publisert 17. december 1905.</p></div>",
                    DisplayTime = "1905 - mai til desember",
                    Time = DateTime.Parse("1905-05-30"),
                    Type = "discovery",
                    PersonCodes = "ae1"
                };
                Events.Add(e);

                SaveChanges();
            }

        }
    }
}