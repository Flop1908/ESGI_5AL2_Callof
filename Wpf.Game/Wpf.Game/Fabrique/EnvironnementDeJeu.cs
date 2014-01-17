using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Game.Fabrique
{
    class EnvironnementDeJeu
    {
        public PlateauDeJeu CreerPlateauDeJeu(FabriquePlateauDeJeuAbstrait fabrique)
        {
            return (PlateauDeJeu)fabrique.CreerPlateauDeJeu();
        }
    }
}
