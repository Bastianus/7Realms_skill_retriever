using _7Realms_skill_retriever.Data;
using _7Realms_skill_retriever.Excel;
using System.Text;

namespace _7Realms_skill_retriever
{
    internal static class Tekst
    {
        internal static void DisplayStartInstructions(string inputDirectory)
        {
            Console.WriteLine("Plaats alle excel karakter formulieren die je wilt analyseren in de input folder van dit programma.");
            Console.WriteLine();
            Console.WriteLine($"Deze is te vinden in: {inputDirectory}");
            Console.WriteLine();
            Console.WriteLine("Zorg dat je zelf geen van deze excel bestanden open hebt.");
            Console.WriteLine();
            Console.WriteLine("Druk daarna op een toets (met deze window geselecteerd) om verder te gaan.");
            Console.ReadKey();
        }

        internal static void DisplayResultaten(List<ExcelGegevens> gegevens)
        {
            Console.Clear();

            DisplaySpelersAndKarakters(gegevens);

            DisplayVaardigheden(gegevens);

            DisplayAmbachten(gegevens);
        }

        internal static void Afsluiting()
        {
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om af te sluiten.");
            Console.ReadKey();
        }

        private static void DisplaySpelersAndKarakters(List<ExcelGegevens> gegevens)
        {
            Console.WriteLine("De volgende spelers met hun karakters waren geselecteerd:");

            Console.WriteLine();

            foreach (var karakter in gegevens)
            {
                Console.WriteLine($"Speler naam: {karakter.SpelerNaam}. Karakter naam: {karakter.KarakterNaam}");
            }
        }

        private static void DisplayVaardigheden(List<ExcelGegevens> gegevens)
        {
            var uniekeVaardigheden = new List<VaardigheidMetAantal>();

            foreach (var karakter in gegevens)
            {
                karakter.Vaardigheden.ForEach(kv =>
                {
                    if (!uniekeVaardigheden.Any(uv => uv.Naam == kv.Naam && uv.Niveau == kv.Niveau))
                    {
                        uniekeVaardigheden.Add(new VaardigheidMetAantal(kv.Naam, kv.Niveau, 1, karakter.KarakterNaam));
                    }
                    else
                    {
                        uniekeVaardigheden.Single(x => x.Naam == kv.Naam && x.Niveau == kv.Niveau)
                            .HoogAantalOp()
                            .VoegKarakterToe(karakter.KarakterNaam);
                    }
                });

            }

            Console.WriteLine();
            Console.WriteLine("Deze vaardigheden zijn gevonden:");

            var geordend = uniekeVaardigheden.OrderBy(x => x.Naam).ThenBy(x => x.Niveau).ToList();

            int longestNameLength = 0;
            geordend.Select(g => g.Naam).ToList().ForEach(n => longestNameLength = n.Length > longestNameLength ? n.Length : longestNameLength);

            geordend.ForEach(v =>
            {
                var karakters = new StringBuilder();
                karakters.AppendJoin(", ", v.Karakters.OrderBy(k => k));

                Console.WriteLine($"{v.Naam} {new string(' ', longestNameLength - v.Naam.Length)}, niveau: {v.Niveau}, aantal:{v.Aantal}. Spelers: {karakters}");
            });
        }

        private static void DisplayAmbachten(List<ExcelGegevens> gegevens)
        {
            var uniekeAmbachten = new List<Ambacht>();

            foreach (var karakter in gegevens)
            {
                if(!uniekeAmbachten.Any(a => a.Naam == karakter.Ambacht))
                {
                    uniekeAmbachten.Add(new Ambacht(karakter.Ambacht, karakter.KarakterNaam));
                }
                else
                {
                    uniekeAmbachten.Single(a => a.Naam == karakter.Ambacht).VerhoogAantal().VoegKarakterToe(karakter.KarakterNaam);
                }
            }

            var geordend = uniekeAmbachten.OrderBy(a => a.Naam).ToList();

            int longestNameLength = 0;
            geordend.Select(g => g.Naam).ToList().ForEach(n => longestNameLength = n.Length > longestNameLength ? n.Length : longestNameLength);

            Console.WriteLine();
            Console.WriteLine("De volgende ambachten zijn gevonden:");

            geordend.ForEach(v =>
            {
                var karakters = new StringBuilder();
                karakters.AppendJoin(", ", v.Karakters.OrderBy(k => k));

                Console.WriteLine($"{v.Naam} {new string(' ', longestNameLength - v.Naam.Length)}, aantal:{v.Aantal}. Spelers: {karakters}");
            });
        }
    }
}
