namespace _7Realms_skill_retriever.Data
{
    internal class VaardigheidMetAantal : Vaardigheid
    {
        public int Aantal { get; private set; }
        public List<string> Karakters { get; private set; }

        internal VaardigheidMetAantal(string naam, int niveau, int aantal, string karakterNaam) : base(naam, niveau) 
        {
            Aantal = aantal;
            Karakters = new List<string> { karakterNaam};
        }

        public VaardigheidMetAantal HoogAantalOp() 
        {
            Aantal++;

            return this;
        }

        public VaardigheidMetAantal VoegKarakterToe(string naam)
        {
            Karakters.Add(naam);

            return this;
        }
    }
}
