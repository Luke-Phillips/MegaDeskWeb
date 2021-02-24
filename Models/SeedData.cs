using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Models
{
    public class SeedData
    {
        /*public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.ScriptureJournalEntry.Any())
                {
                    return;   // DB has been seeded
                }

                context.ScriptureJournalEntry.AddRange(
                    new ScriptureJournalEntry
                    {
                        Date = DateTime.Now,
                        Book = "1 Nephi",
                        Chapter = "1",
                        Verse = "1",
                        Note = "Despite having many afflictions in his life, Nephi feels blessed and grateful"
                    },
                    new ScriptureJournalEntry
                    {
                        Date = DateTime.Now,
                        Book = "John",
                        Chapter = "3",
                        Verse = "16",
                        Note = "For God so loved the world... a classic"
                    }
                );
                context.SaveChanges();
            }
        }*/
    }
}
