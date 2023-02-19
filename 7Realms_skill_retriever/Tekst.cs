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

            Console.WriteLine("De volgende spelers met hun karakters waren geselecteerd:");

            Console.WriteLine();

            var uniekeVaardigheden = new List<VaardigheidMetAantal>();

            foreach (var karakter in gegevens)
            {
                Console.WriteLine($"Speler naam: {karakter.SpelerNaam}. Karakter naam: {karakter.KarakterNaam}");

                VoegVaardighedenToe();

                void VoegVaardighedenToe()
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
            }
           
            var geordend = uniekeVaardigheden.OrderBy(x => x.Naam).ThenBy(x => x.Niveau).ToList();

            Console.WriteLine();
            Console.WriteLine("Deze vaardigheden zijn gevonden:");

            int longestNameLength = 0;
            geordend.Select(g => g.Naam).ToList().ForEach(n => longestNameLength = n.Length > longestNameLength ? n.Length : longestNameLength);


            geordend.ForEach(v =>
            {
                var karakters = new StringBuilder();
                karakters.AppendJoin(", ", v.Karakters.OrderBy(k => k));

                Console.WriteLine($"{v.Naam} {new string(' ', longestNameLength - v.Naam.Length)}, niveau: {v.Niveau}, aantal:{v.Aantal}. Spelers: {karakters}");
            });
        }

        internal static void Afsluiting()
        {
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om af te sluiten.");
            Console.ReadKey();
        }
    }
}
