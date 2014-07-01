using System.Collections.Generic;
using DesignPattern.Objet;
using DesignPattern.Observer;

namespace DesignPattern.Fabrique
{
    /// <summary>
    /// Classe de création d'un plateau de jeu complet
    /// </summary>
    internal class PlateauFinal : PlateauDeJeuAbstrait
    {
        public PlateauFinal()
        {
            for (var i = 0; i < 1; i++)
            {
                for (var j = 0; j < 5; j++)
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

        public List<Personnage> PersonnageList { get; set; }
        public List<Item> ItemList { get; set; }
    }
}