using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Wpf.Game.Observer
{
    class Chevalier : Personnage
    {
        public Chevalier(string _Nom, int _Vie = 300)
            : base(_Nom, _Vie)
        {
            //ComportementCombat = new ComportementApiedAvecHache();
            //ComportementEmettreUnSon = new ComportementCrier();
        }
    }
}
