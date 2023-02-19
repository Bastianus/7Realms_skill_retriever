using _7Realms_skill_retriever.Data;
using _7Realms_skill_retriever.Excel;

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
            Console.WriteLine("De volgende spelers met hun karakters waren geselecteerd:");

            var vaardigheden = new List<Vaardigheid>();

            foreach (var karakter in gegevens)
            {
                Console.WriteLine($"Speler naam: {karakter.SpelerNaam}. Karakter naam: {karakter.KarakterNaam}");

                vaardigheden.AddRange(karakter.Vaardigheden);
            }
            var uniekeVaardigheden = new List<VaardigheidMetAantal>();

            vaardigheden.ForEach(vaardigheid =>
            {
                if (!uniekeVaardigheden.Any(x => x.Naam == vaardigheid.Naam && x.Niveau == vaardigheid.Niveau))
                {
                    uniekeVaardigheden.Add(new VaardigheidMetAantal(vaardigheid.Naam, vaardigheid.Niveau, 1));
                }
                else
                {
                    uniekeVaardigheden.Single(x => x.Naam == vaardigheid.Naam && x.Niveau == vaardigheid.Niveau).HoogAantalOp();
                }
            });

            var geordend = uniekeVaardigheden.OrderBy(x => x.Naam).ThenBy(x => x.Niveau).ToList();

            Console.WriteLine();
            Console.WriteLine("Deze vaardigheden zijn gevonden:");
            geordend.ForEach(v =>
            {
                Console.WriteLine($"{v.Naam}, niveau: {v.Niveau}, aantal:{v.Aantal}.");
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
