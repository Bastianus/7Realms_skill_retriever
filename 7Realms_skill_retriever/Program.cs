namespace _7Realms_skill_retriever
{
    public class Program 
    {
        static void Main()
        {
            try
            {
                var mainDirectory = Directory.GetCurrentDirectory();

                var inputDirectory = mainDirectory + "\\Input";

                Folders.CreateFoldersIfNotExist(inputDirectory);

                Tekst.DisplayStartInstructions(inputDirectory);

                var gegevens = new DataReader(inputDirectory).ReadData();

                Tekst.DisplayResultaten(gegevens);

                Tekst.Afsluiting();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}