namespace _7Realms_skill_retriever.Data
{
    internal class Ambacht
    {
        public string Naam { get; set; }
        public AmbachtNiveau Niveau { get; set; }

        public Ambacht(string naam, AmbachtNiveau niveau)
        {
            Naam = naam;
            Niveau = niveau;
        }
    }
}
