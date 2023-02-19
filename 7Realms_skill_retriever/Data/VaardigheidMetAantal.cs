namespace _7Realms_skill_retriever.Data
{
    internal class VaardigheidMetAantal : Vaardigheid
    {
        public int Aantal { get; private set; }
        internal VaardigheidMetAantal(string naam, int niveau, int aantal) : base(naam, niveau) 
        {
            Aantal = aantal;
        }

        public void HoogAantalOp() 
        {
            Aantal++;
        }
    }
}
