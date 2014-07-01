using System.Collections.Generic;
using DesignPattern.Objet;
using DesignPattern.Observer;

namespace DesignPattern.Fabrique
{
    /// <summary>
    /// Création d'un plateau de jeu
    /// </summary>
    internal class PlateauDeJeu : PlateauDeJeuAbstrait
    {
        public List<Item> ItemList;
        public List<Personnage> PersonnageList;

        public PlateauDeJeu()
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    var zone = new Zone();
                    zone.column = i;
                    zone.row = j;

                    AjouteZone(zone);
                }
            }

            PersonnageList = new List<Personnage>();
            ItemList = new List<Item>();
        }
    }
}