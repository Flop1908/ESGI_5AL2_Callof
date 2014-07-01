using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    class EtatEnAction : EtatAbstrait
    {
        public override void ModifieEtat(Personnage perso)
        {
            perso.EtatCourant = new EtatEnAttente();
        }
    }
}
