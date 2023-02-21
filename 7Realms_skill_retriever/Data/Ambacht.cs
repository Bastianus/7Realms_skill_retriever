namespace _7Realms_skill_retriever.Data
{
    internal class Ambacht
    {
        public string Naam { get; }
        public int Aantal { get; private set; }
        public List<string> Karakters { get; private set; }
        public Ambacht(string naam, string karakter)
        {
            Naam = naam;
            Aantal = 1;
            Karakters = new List<string> { karakter };
        }
        public Ambacht VerhoogAantal(int aantal = 1)
        {
            Aantal += aantal;

            return this;
        }

        public Ambacht VoegKarakterToe(string naam)
        {
            Karakters.Add(naam);

            return this;
        }
    }
}
