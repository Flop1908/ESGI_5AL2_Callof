using System;
using DesignPattern.Fabrique;
using DesignPattern.Objet;
using DesignPattern.Observer;

namespace DesignPattern.Simulation
{
    /// <summary>
    /// Classe de gestion de la simaulation de jeu
    /// </summary>
    internal class SimulationJeu
    {
        private static SimulationJeu _uneInstance;
        private EnvironnementDeJeu _environnement;
        private FabriquePlateauDeJeu _fPlateau;
        public PlateauDeJeu Plateau;
        public PlateauFinal Plateaufinal;

        private Random _rdm;

        private SimulationJeu()
        {
        }

        public static SimulationJeu Instance
        {
            get
            {
                if (_uneInstance == null)
                {
                    _uneInstance = new SimulationJeu();
                }

                return _uneInstance;
            }
        }

        public void Initialisation(int parameterPlateau, int parameterPointdevie, int parameterPosition)
        {
            _environnement = new EnvironnementDeJeu();
            Plateau = new PlateauDeJeu();
            Plateaufinal = new PlateauFinal();


            CreerPlateauDeJeu(parameterPlateau);
            CreerPersonnage(parameterPointdevie, parameterPosition);
            CreerItem(parameterPlateau);
            if (parameterPlateau == 1) CreerPortail();
        }

        public void CreerPersonnage(int paramPdv, int paramPos)
        {
            _rdm = new Random();

            var perso1 = new Chevalier();
            var perso2 = new Archer();

            if (paramPdv == 0)
            {
                perso1 = new Chevalier("Bomberman", new EtatEnAttente(), _rdm.Next(150, 350));
                perso1.SetAvatar();

                perso2 = new Archer("Archer", new EtatEnAttente(), _rdm.Next(150, 350));
                perso2.SetAvatar();
            }
            else if (paramPdv > 1)
            {
                perso1 = new Chevalier("Bomberman", new EtatEnAttente(), paramPdv);
                perso1.SetAvatar();

                perso2 = new Archer("Archer", new EtatEnAttente(), paramPdv);
                perso2.SetAvatar();
            }
            else if (paramPdv == 1)
            {
                perso1 = new Chevalier("Bomberman", new EtatEnAttente());
                perso1.SetAvatar();

                perso2 = new Archer("Archer", new EtatEnAttente());
                perso2.SetAvatar();
            }

            if (paramPos == 0)
            {
                perso1.Position = (Zone) Plateau.GetZoneList()[_rdm.Next(0, 80)];
                perso2.Position = (Zone) Plateau.GetZoneList()[_rdm.Next(0, 80)];
            }
            else if (paramPos > 1)
            {
                perso1.Position = (Zone) Plateau.GetZoneList()[0];
                perso2.Position = (Zone) Plateau.GetZoneList()[0];
            }
            else if (paramPos == 1)
            {
                perso1.Position = (Zone) Plateau.GetZoneList()[25];
                perso2.Position = (Zone) Plateau.GetZoneList()[45];
            }


            Plateau.PersonnageList.Add(perso1);
            Plateau.PersonnageList.Add(perso2);
        }

        public void CreerItem(int paramPlat)
        {
            var goal = new Goal();
            goal.Potion = 100;
            goal.SetAvatar("goal.jpg");
            if (paramPlat == 1)
            {
                goal.Position = (Zone) Plateaufinal.GetZoneList()[4];
                Plateaufinal.ItemList.Add(goal);
            }
            else
            {
                foreach (var zoneAbstrait in Plateau.GetZoneList())
                {
                    var z = (Zone) zoneAbstrait;
                    if (z.column == 8 && z.row == 8)
                    {
                        goal.Position = z;
                        break;
                    }
                }

                Plateau.ItemList.Add(goal);
            }

            var potion = new PotionVie();
            potion.Potion = 250;
            potion.SetAvatar("potion.gif");

            foreach (var zoneAbstrait in Plateau.GetZoneList())
            {
                var z = (Zone) zoneAbstrait;
                if (z.column == 4 && z.row == 5)
                {
                    potion.Position = z;
                    break;
                }
            }

            Plateau.ItemList.Add(potion);
        }

        public void CreerPortail()
        {
            var portailbleu = new Portail();
            portailbleu.SetAvatar("portalbleu.jpg");

            portailbleu.Position = (Zone) Plateau.GetZoneList()[_rdm.Next(0, Plateau.GetZoneList().Count - 1)];
            Plateau.ItemList.Add(portailbleu);

            var portailrouge = new Portail();
            portailrouge.SetAvatar("portalrouge.jpg");

            portailrouge.Position = (Zone) Plateaufinal.GetZoneList()[0];
            Plateaufinal.ItemList.Add(portailrouge);
        }

        public void CreerPlateauDeJeu(int paramPlateau)
        {
            _fPlateau = new FabriquePlateauDeJeu();
            Plateau = _environnement.CreerPlateauDeJeu(_fPlateau);
            if (paramPlateau == 1) Plateaufinal = _environnement.CreerPlateauFinal(_fPlateau);
        }
    }
}