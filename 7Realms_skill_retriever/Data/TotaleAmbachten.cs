namespace _7Realms_skill_retriever.Data
{
    internal class TotaleAmbachten
    {
        public string Naam { get; }
        public int Aantal { get; private set; }
        public AmbachtNiveau Niveau { get; }
        public List<string> Karakters { get; private set; }
        public TotaleAmbachten(string naam, AmbachtNiveau niveau, string karakter)
        {
            Naam = naam;
            Niveau = niveau;
            Aantal = 1;
            Karakters = new List<string> { karakter };
        }

        public TotaleAmbachten VoegKarakterToe(string naam)
        {
            Aantal++;
            Karakters.Add(naam);

            return this;
        }
    }
}
