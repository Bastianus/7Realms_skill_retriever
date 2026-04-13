using _7Realms_skill_retriever.Excel;

namespace _7Realms_skill_retriever
{
    internal class DataReader
    {
        private string _inputDirectory;
        internal DataReader(string inputDirectory)
        {
            _inputDirectory= inputDirectory;
        }

        public List<ExcelGegevens> ReadData()
        {
            var gegevens = new List<ExcelGegevens>();

            var inputInfo = new DirectoryInfo(_inputDirectory);

            foreach(var file in inputInfo.GetFiles()) 
            { 
                if (file.Exists) 
                {
                    try
                    {
                        gegevens.Add(ExcelSheetReader.ReadDataFromExcelFile(file.FullName));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Fout opgetreden bij het lezen van het bestand {file.FullName}.");
                        Console.WriteLine("### Exception ###");
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine("### End exception ###");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Er is een file gevonden, {file.Name}, die vanwege een foutieve extensie wordt overgeslagen.");
                }
            }

            return gegevens;
        }
    }
}
