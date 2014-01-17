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

        public SimulationJeu(int parameter_pointdevie, int parameter_position)
        {
            PersonnageList = new List<Personnage>();
            ItemList = new List<Item>();
            Environnement = new EnvironnementDeJeu();

            //EtatMajor = new eMode();

            CreerPlateauDeJeu();
            CreerPersonnage(parameter_pointdevie, parameter_position);
            CreerItem();
        }

        public void CreerPersonnage(int param_pdv, int param_pos)
        {
            Random rdm = new Random();

            Fantassin perso1 = new Fantassin();
            Archer perso2 = new Archer();

            if (param_pdv == 0)
            {               
                perso1 = new Fantassin("Bomberman", rdm.Next(150, 350));
                perso1.SetAvatar();

                perso2 = new Archer("Archer", rdm.Next(150, 350));
                perso2.SetAvatar();
            }
            else if (param_pdv > 1)
            {
                
                perso1 = new Fantassin("Bomberman", param_pdv);
                perso1.SetAvatar();

                perso2 = new Archer("Archer", param_pdv);
                perso2.SetAvatar();
            }
            else if (param_pdv == 1)
            {
                perso1 = new Fantassin("Bomberman");
                perso1.SetAvatar();

                perso2 = new Archer("Archer");
                perso2.SetAvatar();
            }

            if (param_pos == 0)
            {
                perso1.Position = (Zone)plateau.GetZoneList()[rdm.Next(0, 80)];
                perso2.Position = (Zone)plateau.GetZoneList()[rdm.Next(0, 80)];
            }
            else if (param_pos > 1)
            {
                perso1.Position = (Zone)plateau.GetZoneList()[0];
                perso2.Position = (Zone)plateau.GetZoneList()[0];
            }
            else if (param_pos == 1)
            {
                perso1.Position = (Zone)plateau.GetZoneList()[25];
                perso2.Position = (Zone)plateau.GetZoneList()[45];
            }

           

            /*foreach (Zone z in plateau.GetZoneList())
            {
                if (z.column == 0 && z.row == 0)
                {
                    perso1.Position = z;
                    break;
                }
            }*/

            PersonnageList.Add(perso1);
            PersonnageList.Add(perso2);
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

            PotionVie potion = new PotionVie();
            potion.Potion = 250;
            potion.SetAvatar();

            foreach (Zone z in plateau.GetZoneList())
            {
                if (z.column == 4 && z.row == 5)
                {
                    potion.Position = z;
                    break;
                }
            }

            ItemList.Add(potion);
        }

        public void CreerPlateauDeJeu()
        {
            FabriquePlateauDeJeu FPlateau = new FabriquePlateauDeJeu();
            plateau = Environnement.CreerPlateauDeJeu(FPlateau);

            
        }

       
    }
}
