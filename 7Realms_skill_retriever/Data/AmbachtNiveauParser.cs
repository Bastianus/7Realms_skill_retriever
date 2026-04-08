namespace _7Realms_skill_retriever.Data
{
    internal static class AmbachtNiveauParser
    {
        internal static AmbachtNiveau Parse(string? input)
        {
            if (string.IsNullOrEmpty(input)) return AmbachtNiveau.Geen;

            AmbachtNiveau ambacht;

            if (!Enum.TryParse(input, out ambacht))
            {
                return AmbachtNiveau.Geen;
            }

            return ambacht;
        }
    }
}
