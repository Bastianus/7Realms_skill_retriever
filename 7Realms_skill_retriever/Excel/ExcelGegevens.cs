using _7Realms_skill_retriever.Data;
using IronXL;

namespace _7Realms_skill_retriever.Excel
{
    internal class ExcelGegevens
    {
        private WorkSheet _sheet;
        public string SpelerNaam { get;}
        public string KarakterNaam { get; }
        public List<Vaardigheid> Vaardigheden { get; private set; } = null!;

        public ExcelGegevens(WorkSheet worksheet)
        {
            _sheet= worksheet;

            SpelerNaam = _sheet["C3"].StringValue;
            KarakterNaam = _sheet["C2"].StringValue;

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
                var vaardighedenNaam = _sheet.GetColumn(1).Skip(25).Take(9).Select(x => x.StringValue).ToList();
                var vaardighedenNiveau = _sheet.GetColumn(2).Skip(25).Take(9).Select(x => x.Int32Value).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenZiel()
            {
                var vaardighedenNaam = _sheet.GetColumn(5).Skip(25).Take(5).Select(x => x.StringValue).ToList();
                var vaardighedenNiveau = _sheet.GetColumn(6).Skip(25).Take(5).Select(x => x.Int32Value).ToList();

                VulDeVaardigheden(vaardighedenNaam, vaardighedenNiveau);
            }

            void VulVaardighedenGeest()
            {
                var vaardighedenNaam = _sheet.GetColumn(9).Skip(25).Take(9).Select(x => x.StringValue).ToList();
                var vaardighedenNiveau = _sheet.GetColumn(10).Skip(25).Take(9).Select(x => x.Int32Value).ToList();

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
