using _7Realms_skill_retriever.Data;
using OfficeOpenXml;

namespace _7Realms_skill_retriever.Excel
{
    internal class ExcelGegevens
    {
        private ExcelWorksheet _sheet;
        public string SpelerNaam { get;}
        public string KarakterNaam { get; }
        public string Ambacht { get; }
        public List<Vaardigheid> Vaardigheden { get; private set; } = null!;

        public ExcelGegevens(ExcelWorksheet worksheet)
        {
            _sheet= worksheet;

            KarakterNaam = _sheet.Cells["C2"].Text;
            SpelerNaam = _sheet.Cells["C3"].Text;            

            Ambacht = _sheet.Cells["C5"].Text == "Anders, nl.:" ? _sheet.Cells["D5"].Text : _sheet.Cells["C5"].Text;

            VulVaardigheden();
        }

        private void VulVaardigheden()
        {
            Vaardigheden = new List<Vaardigheid>();

            VulVaardighedenLichaam();
            VulVaardighedenZiel();
            VulVaardighedenGeest();

            void VulVaardighedenLichaam()
            {
                var vaardighedenNaam = _sheet.Cells["B26:B34"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["C26:C34"].Select(x => Int32.Parse(string.IsNullOrEmpty(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenZiel()
            {
                var vaardighedenNaam = _sheet.Cells["G26:G30"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["H26:H30"].Select(x => Int32.Parse(string.IsNullOrEmpty(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenGeest()
            {
                var vaardighedenNaam = _sheet.Cells["K26:K34"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["L26:L34"].Select(x => Int32.Parse(string.IsNullOrEmpty(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulDeVaardigheden(List<string> vaardigheidNamen, List<int> niveaus)
            {
                for(int i = 0; i < vaardigheidNamen.Count; i++)
                {
                    if (!string.IsNullOrEmpty(vaardigheidNamen[i]))
                    {
                        Vaardigheden.Add(new Vaardigheid(vaardigheidNamen[i]!, niveaus[i]));
                    }
                }                
            }
        }
    }
}
