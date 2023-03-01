using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Realms_skill_retriever.Data
{
    internal class Mutatie
    {
        public string Naam { get; }
        public int Niveau { get; }
        
        public Mutatie(string naam, int niveau)
        {
            Naam = naam;
            Niveau = niveau;
        }
    }
}
