using DesignPattern.Objet;
using DesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Fabrique
{
    class PlateauFinal : PlateauDeJeuAbstrait
    {
        public List<Personnage> PersonnageList { get; set; }
        public List<Item> ItemList { get; set; }


        public PlateauFinal()
            : base()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Zone Zone = new Zone();
                    Zone.column = i;
                    Zone.row = j;

                    this.AjouteZone(Zone);

                }
            }

            PersonnageList = new List<Personnage>();
            ItemList = new List<Item>();
        }

    }
}
