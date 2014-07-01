using DesignPattern.Objet;
using DesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Fabrique
{
    class PlateauDeJeu : PlateauDeJeuAbstrait
    {

        public List<Personnage> PersonnageList ;
        public List<Item> ItemList;


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

            PersonnageList = new List<Personnage>();
            ItemList = new List<Item>();
        }

    }
}
