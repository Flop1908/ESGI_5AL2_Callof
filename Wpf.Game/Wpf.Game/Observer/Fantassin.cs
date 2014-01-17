using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wpf.Game.Fabrique;

namespace Wpf.Game.Observer
{
    class Fantassin : Personnage
    {

        public Fantassin(string _Nom, int _Vie)
            : base(_Nom, _Vie)
        {
            //ComportementCombat = new ComportementApiedAvecHache();
            //ComportementEmettreUnSon = new ComportementCrier();
        }

        /*public override string Afficher()
        {
            return "Fantassin " + Nom;
        }

       
        public override string SeDeplacer()
        {
            return "Je marche à pied";
        }*/
    }
}
