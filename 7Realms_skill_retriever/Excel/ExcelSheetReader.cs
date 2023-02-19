using OfficeOpenXml;

namespace _7Realms_skill_retriever.Excel
{
    internal static class ExcelSheetReader
    {
        public static ExcelGegevens ReadDataFromExcelFile(string fullname)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var workbook = new ExcelPackage(new FileInfo(fullname));

            var firstSheet = workbook.Workbook.Worksheets[0];

            return new ExcelGegevens(firstSheet);
        }
    }
}
