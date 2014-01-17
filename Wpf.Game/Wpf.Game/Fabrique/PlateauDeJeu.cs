using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Game.Fabrique
{
    class PlateauDeJeu : PlateauDeJeuAbstrait
    {
        public PlateauDeJeu()
            : base()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Zone Zone = new Zone();
                    Zone.column = i;
                    Zone.row = j;

                    this.AjouteZone(Zone);

                }
            }           
        }
    }
}
