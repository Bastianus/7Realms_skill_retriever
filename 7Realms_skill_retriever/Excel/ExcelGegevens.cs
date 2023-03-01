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
        public List<Mutatie> Mutaties { get; private set; } = null!;

        public ExcelGegevens(ExcelWorksheet worksheet)
        {
            _sheet= worksheet;

            KarakterNaam = _sheet.Cells["C2"].Text;
            SpelerNaam = _sheet.Cells["C3"].Text;            

            Ambacht = _sheet.Cells["C5"].Text == "Anders, nl.:" ? _sheet.Cells["D5"].Text : _sheet.Cells["C5"].Text;

            VulVaardigheden();

            VulMutaties();
        }

        private void VulVaardigheden()
        {
            Vaardigheden = new List<Vaardigheid>();

            VulVaardighedenLichaam();
            VulVaardighedenZiel();
            VulVaardighedenGeest();

            void VulVaardighedenLichaam()
            {
                var vaardighedenNaam = _sheet.Cells["B25:B33"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["C25:C33"].Select(x => Int32.Parse(string.IsNullOrWhiteSpace(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenZiel()
            {
                var vaardighedenNaam = _sheet.Cells["G25:G29"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["H25:H29"].Select(x => Int32.Parse(string.IsNullOrWhiteSpace(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenGeest()
            {
                var vaardighedenNaam = _sheet.Cells["K25:K33"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["L25:L33"].Select(x => Int32.Parse(string.IsNullOrWhiteSpace(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulDeVaardigheden(List<string> vaardigheidNamen, List<int> niveaus)
            {
                for(int i = 0; i < vaardigheidNamen.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(vaardigheidNamen[i]))
                    {
                        Vaardigheden.Add(new Vaardigheid(vaardigheidNamen[i]!, niveaus[i]));
                    }
                }                
            }
        }

        private void VulMutaties()
        {
            Mutaties = new List<Mutatie>();

            bool isFae = _sheet.Cells["C7"].Single().Text == "Vrije_Fae";

            if (isFae)
            {
                VulMutaties("I11:I14","J11:J14");
            }
            else
            {
                VulMutaties("F16:F19","G16:G19");
            }

            void VulMutaties(string gebiedNaam, string gebiedNiveau)
            {
                var mutatiesNamen = _sheet.Cells[gebiedNaam].Select(x => x.Text).ToList();
                var mutatiesNiveaus = _sheet.Cells[gebiedNiveau].Select(x => Int32.Parse(string.IsNullOrWhiteSpace(x.Text) ? "0" : x.Text)).ToList();

                for (int i = 0; i < mutatiesNamen.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(mutatiesNamen[i]))
                    {
                        Mutaties.Add(new Mutatie(mutatiesNamen[i], mutatiesNiveaus[i]));
                    }
                }
            }
        }
    }
}
