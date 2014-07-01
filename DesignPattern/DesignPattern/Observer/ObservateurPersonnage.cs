using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    class ObservateurPersonnage : ObservateurAbstrait
    {
        private readonly string nom;
        private string etatObserve;

        public Personnage Perso { get; set; }

        public ObservateurPersonnage(Personnage perso, string name)
        {
            Perso = perso;
            nom = name;
        }

        

        public override void MiseAjour()
        {
            etatObserve = Perso.Etat;
            Console.WriteLine("Observeur {0} : nouvel Etat est {1}", nom, etatObserve);
        }
    }
}
