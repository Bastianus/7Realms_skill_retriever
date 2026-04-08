using _7Realms_skill_retriever.Data;
using OfficeOpenXml;

namespace _7Realms_skill_retriever.Excel
{
    internal class ExcelGegevens
    {
        private const string _andereAmbacht = "Anders, nl.:";
        private ExcelWorksheet _sheet;
        public string SpelerNaam { get;}
        public string KarakterNaam { get; }
        public List<Ambacht> Ambachten { get; private set; } = null!;
        public List<Vaardigheid> Vaardigheden { get; private set; } = null!;
        public List<Mutatie> Mutaties { get; private set; } = null!;

        public ExcelGegevens(ExcelWorksheet worksheet)
        {
            _sheet= worksheet;

            KarakterNaam = _sheet.Cells["C2"].Text;
            SpelerNaam = _sheet.Cells["C3"].Text;

            VulAmbachten();

            VulVaardigheden();

            VulMutaties();
        }

        private void VulAmbachten()
        {
            Ambachten = new List<Ambacht>();

            for(int i = 6; i < 9; i++)
            {
                var currentAmbacht = _sheet.Cells[$"B{i}"].Text;

                if(string.IsNullOrEmpty(currentAmbacht))
                {
                    continue;
                }
                else if (currentAmbacht == _andereAmbacht)
                {
                    var andereAmbacht = _sheet.Cells[$"C{i}"].Text;

                    if (string.IsNullOrEmpty(andereAmbacht))
                    {
                        continue;
                    }

                    Ambachten.Add(
                        new Ambacht(
                            andereAmbacht,
                            AmbachtNiveauParser.Parse(_sheet.Cells[$"D{i}"].Text)
                        )
                    );
                }
                else
                {
                    Ambachten.Add(
                        new Ambacht(
                            currentAmbacht,
                            AmbachtNiveauParser.Parse(_sheet.Cells[$"D{i}"].Text)
                            )
                        );
                }
            }

            if (Ambachten.Count == 0) 
            {
                Ambachten.Add(
                        new Ambacht(
                            "<<geen>>",
                            AmbachtNiveau.Geen)
                        );
            }
        }

        private void VulVaardigheden()
        {
            Vaardigheden = new List<Vaardigheid>();

            VulVaardighedenLichaam();
            VulVaardighedenZiel();
            VulVaardighedenGeest();

            void VulVaardighedenLichaam()
            {
                var vaardighedenNaam = _sheet.Cells["B28:B36"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["C28:C36"].Select(x => Int32.Parse(string.IsNullOrWhiteSpace(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenZiel()
            {
                var vaardighedenNaam = _sheet.Cells["G28:G32"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["H28:H32"].Select(x => Int32.Parse(string.IsNullOrWhiteSpace(x.Text) ? "0" : x.Text)).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenGeest()
            {
                var vaardighedenNaam = _sheet.Cells["K28:K36"].Select(x => x.Text).ToList();
                var vaardighedenNiveau = _sheet.Cells["L28:L36"].Select(x => Int32.Parse(string.IsNullOrWhiteSpace(x.Text) ? "0" : x.Text)).ToList();

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

            bool isFae = _sheet.Cells["C10"].Single().Text == "Vrije_Fae";

            if (isFae)
            {
                VulMutaties("I14:I17","J14:J17");
            }
            else
            {
                VulMutaties("F19:F22","G19:G22");
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
