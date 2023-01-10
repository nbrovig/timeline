using timeline.Models;
using timeline.Data;
using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace timeline.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TimelineContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }
            var persons = new Person[]
            {
            new Person{PersonId=1,FullName="Albert Einstein",Code="ae1"},
            new Person{PersonId=2,FullName="Nathan Rosen",Code="nr1"},
            new Person{PersonId=3,FullName="Boris Podolsky",Code="bp1"},
            };
            foreach (Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();

        }
    }
}