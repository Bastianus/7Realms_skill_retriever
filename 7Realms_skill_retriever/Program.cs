using _7Realms_skill_retriever;
namespace _7Realms_skill_retriever
{
    public class Program 
    {
        static void Main()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();

                var mainDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\"));

                var inputDirectory = mainDirectory + "Input";
                var outputDirectory = mainDirectory + "Output";

                Folders.CreateFoldersIfNotExist(inputDirectory, outputDirectory);

                Folders.EmptyOutputFolder(outputDirectory);

                Tekst.DisplayStartInstructions(inputDirectory);

                var dataReader = new DataReader(inputDirectory);

                var gegevens = dataReader.ReadData();

                Tekst.DisplayResultaten(gegevens);

                Tekst.Afsluiting();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}