namespace _7Realms_skill_retriever
{
    internal static class Folders
    {
        internal static void CreateFoldersIfNotExist(string inputDirectory)
        {
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
            }
        }
    }
}
