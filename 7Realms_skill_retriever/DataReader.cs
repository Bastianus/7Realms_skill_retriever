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
                if (file.Exists && file.Extension == ".xlsx") 
                {
                    gegevens.Add(ExcelSheetReader.ReadDataFromExcelFile(file.FullName));
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
