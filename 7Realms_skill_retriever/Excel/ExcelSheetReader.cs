using IronXL;

namespace _7Realms_skill_retriever.Excel
{
    internal static class ExcelSheetReader
    {
        public static ExcelGegevens ReadDataFromExcelFile(string fullname)
        {
            var workbook = WorkBook.Load(fullname);

            var firstSheet = workbook.DefaultWorkSheet;

            return new ExcelGegevens(firstSheet);
        }
    }
}
