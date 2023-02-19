namespace _7Realms_skill_retriever.Data
{
    internal class Vaardigheid
    {
        public string Naam { get; }
        public int Niveau { get; }
        internal Vaardigheid(string naam, int niveau)
        {
            Naam = naam;
            Niveau = niveau;
        }
    }
}
