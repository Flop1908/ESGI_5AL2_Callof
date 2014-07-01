using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Fabrique
{
    class EnvironnementDeJeu
    {
        public PlateauDeJeu CreerPlateauDeJeu(FabriquePlateauDeJeuAbstrait fabrique)
        {
            return (PlateauDeJeu)fabrique.CreerPlateauDeJeu();
        }

        public PlateauFinal CreerPlateauFinal(FabriquePlateauDeJeuAbstrait fabrique)
        {
            return (PlateauFinal)fabrique.CreerPlateauFinal();
        }
    }
}
