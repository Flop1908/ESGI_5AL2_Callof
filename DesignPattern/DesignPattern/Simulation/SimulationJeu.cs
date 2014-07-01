using System;
using DesignPattern.Fabrique;
using DesignPattern.Objet;
using DesignPattern.Observer;

namespace Wpf.Game.Simulation
{
    internal class SimulationJeu
    {
        private static SimulationJeu uneInstance;
        private EnvironnementDeJeu Environnement;
        private FabriquePlateauDeJeu FPlateau;
        public PlateauDeJeu plateau;
        public PlateauFinal plateaufinal;

        private Random rdm;

        private SimulationJeu()
        {
        }

        public static SimulationJeu Instance
        {
            get
            {
                if (uneInstance == null)
                {
                    uneInstance = new SimulationJeu();
                }

                return uneInstance;
            }
        }

        public void Initialisation(int parameter_plateau, int parameter_pointdevie, int parameter_position)
        {
            Environnement = new EnvironnementDeJeu();
            plateau = new PlateauDeJeu();
            plateaufinal = new PlateauFinal();


            CreerPlateauDeJeu(parameter_plateau);
            CreerPersonnage(parameter_pointdevie, parameter_position);
            CreerItem(parameter_plateau);
            if (parameter_plateau == 1) CreerPortail();
        }

        public void CreerPersonnage(int param_pdv, int param_pos)
        {
            rdm = new Random();

            var perso1 = new Chevalier();
            var perso2 = new Archer();

            if (param_pdv == 0)
            {
                perso1 = new Chevalier("Bomberman", new EtatEnAttente(), rdm.Next(150, 350));
                perso1.SetAvatar();

                perso2 = new Archer("Archer", new EtatEnAttente(), rdm.Next(150, 350));
                perso2.SetAvatar();
            }
            else if (param_pdv > 1)
            {
                perso1 = new Chevalier("Bomberman", new EtatEnAttente(), param_pdv);
                perso1.SetAvatar();

                perso2 = new Archer("Archer", new EtatEnAttente(), param_pdv);
                perso2.SetAvatar();
            }
            else if (param_pdv == 1)
            {
                perso1 = new Chevalier("Bomberman", new EtatEnAttente());
                perso1.SetAvatar();

                perso2 = new Archer("Archer", new EtatEnAttente());
                perso2.SetAvatar();
            }

            if (param_pos == 0)
            {
                perso1.Position = (Zone) plateau.GetZoneList()[rdm.Next(0, 80)];
                perso2.Position = (Zone) plateau.GetZoneList()[rdm.Next(0, 80)];
            }
            else if (param_pos > 1)
            {
                perso1.Position = (Zone) plateau.GetZoneList()[0];
                perso2.Position = (Zone) plateau.GetZoneList()[0];
            }
            else if (param_pos == 1)
            {
                perso1.Position = (Zone) plateau.GetZoneList()[25];
                perso2.Position = (Zone) plateau.GetZoneList()[45];
            }


            plateau.PersonnageList.Add(perso1);
            plateau.PersonnageList.Add(perso2);
        }

        public void CreerItem(int param_plat)
        {
            var goal = new Goal();
            goal.Potion = 100;
            goal.SetAvatar("goal.jpg");
            if (param_plat == 1)
            {
                goal.Position = (Zone) plateaufinal.GetZoneList()[4];
                plateaufinal.ItemList.Add(goal);
            }
            else
            {
                foreach (Zone z in plateau.GetZoneList())
                {
                    if (z.column == 8 && z.row == 8)
                    {
                        goal.Position = z;
                        break;
                    }
                }

                plateau.ItemList.Add(goal);
            }

            var potion = new PotionVie();
            potion.Potion = 250;
            potion.SetAvatar("potion.gif");

            foreach (Zone z in plateau.GetZoneList())
            {
                if (z.column == 4 && z.row == 5)
                {
                    potion.Position = z;
                    break;
                }
            }

            plateau.ItemList.Add(potion);
        }

        public void CreerPortail()
        {
            var portailbleu = new Portail();
            portailbleu.SetAvatar("portalbleu.jpg");

            portailbleu.Position = (Zone) plateau.GetZoneList()[rdm.Next(0, plateau.GetZoneList().Count - 1)];
            plateau.ItemList.Add(portailbleu);

            var portailrouge = new Portail();
            portailrouge.SetAvatar("portalrouge.jpg");

            portailrouge.Position = (Zone) plateaufinal.GetZoneList()[0];
            plateaufinal.ItemList.Add(portailrouge);
        }

        public void CreerPlateauDeJeu(int param_plateau)
        {
            FPlateau = new FabriquePlateauDeJeu();
            plateau = Environnement.CreerPlateauDeJeu(FPlateau);
            if (param_plateau == 1) plateaufinal = Environnement.CreerPlateauFinal(FPlateau);
        }
    }
}