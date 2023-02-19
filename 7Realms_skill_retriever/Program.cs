using _7Realms_skill_retriever;
namespace _7Realms_skill_retriever
{
    public class Program 
    {
        static void Main()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var mainDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\"));

            var inputDirectory = mainDirectory + "\\Input";
            var outputDirectory = mainDirectory + "\\Output";

            Folders.CreateFoldersIfNotExist(inputDirectory, outputDirectory);

            Folders.EmptyOutputFolder(outputDirectory);

            Tekst.DisplayStartInstructions(inputDirectory);
        }
    }
}