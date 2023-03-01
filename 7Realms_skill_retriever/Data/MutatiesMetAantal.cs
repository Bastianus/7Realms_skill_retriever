namespace _7Realms_skill_retriever.Data
{
    internal class MutatiesMetAantal : Mutatie
    {
        public int Aantal { get; private set; }
        public List<string> Karakters { get; private set; }

        internal MutatiesMetAantal(string naam, int niveau, int aantal, string karakternaam) : base(naam, niveau)
        {
            Aantal = aantal;
            Karakters = new List<string> { karakternaam };
        }

        public MutatiesMetAantal HoogAantalOp()
        {
            Aantal++;

            return this;
        }

        public MutatiesMetAantal VoegKarakterToe(string naam)
        {
            Karakters.Add(naam);

            return this;
        }
    }
}
