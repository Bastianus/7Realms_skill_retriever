namespace _7Realms_skill_retriever
{
    internal static class Folders
    {
        internal static void CreateFoldersIfNotExist(string inputDirectory, string outputDirectory)
        {
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
        }

        internal static void EmptyOutputFolder(string outputDirectory) 
        {
            DirectoryInfo outputInfo = new DirectoryInfo(outputDirectory);

            foreach (FileInfo file in outputInfo.GetFiles())
            {

                file.Delete();
            }
            foreach (DirectoryInfo dir in outputInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
