using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Wpf.Game.Observer
{
    class Archer : Personnage
    {
        public Archer(string _Nom, int _Vie = 150)
            : base(_Nom, _Vie)
        {
            //ComportementCombat = new ComportementApiedAvecHache();
            //ComportementEmettreUnSon = new ComportementCrier();
        }
    }
}
