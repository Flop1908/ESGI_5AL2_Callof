using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wpf.Game.Observer;
using Wpf.Game.Fabrique;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

using Wpf.Game;
using Wpf.Game.Objet;

namespace Wpf.Game.Simulation
{
    class SimulationJeu
    {
        public List<Personnage> PersonnageList;
        public List<Item> ItemList;
        PlateauDeJeu plateau;
        private EnvironnementDeJeu Environnement;
        //private eMode EtatMajor;

        public SimulationJeu()
        {
            PersonnageList = new List<Personnage>();
            ItemList = new List<Item>();
            Environnement = new EnvironnementDeJeu();

            //EtatMajor = new eMode();

            CreerPlateauDeJeu();
            CreerPersonnage();
            CreerItem();
        }

        public void CreerPersonnage()
        {
            Fantassin perso1 = new Fantassin("Bomberman", 200);            
            perso1.SetAvatar();

            foreach (Zone z in plateau.GetZoneList())
            {
                if (z.column == 0 && z.row == 0)
                {
                    perso1.Position = z;
                    break;
                }
            }
            PersonnageList.Add(perso1);
        }

        public void CreerItem()
        {
            Goal goal = new Goal();
            goal.Potion = 100;
            goal.SetAvatar();

            foreach (Zone z in plateau.GetZoneList())
            {
                if (z.column == 8 && z.row == 8)
                {
                    goal.Position = z;
                    break;
                }
            }

            ItemList.Add(goal);

            /*PotionVie potion = new PotionVie();
            potion.Potion = 100;
            potion.SetAvatar();

            foreach (Zone z in plateau.GetZoneList())
            {
                if (z.column == 4 && z.row == 5)
                {
                    potion.Position = z;
                    break;
                }
            }

            ItemList.Add(potion);*/
        }

        public void CreerPlateauDeJeu()
        {
            FabriquePlateauDeJeu FPlateau = new FabriquePlateauDeJeu();
            plateau = Environnement.CreerPlateauDeJeu(FPlateau);

            
        }

       
    }
}
