using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DesignPattern.Fabrique;
using DesignPattern.Objet;

namespace DesignPattern.Observer
{
    /// <summary>
    /// Classe abstraite représentant les personnages du jeu
    /// </summary>
    public abstract class Personnage
    {
        public Image Avatar;


        public bool EstMort;
        public bool ObjectifAtteint;
        public bool PrendPotion;
        public bool PortailAtteint;

        public Zone ProchainCoupGagnant;

        public List<ZoneAbstrait> ZoneAcessibleList;
        private EtatAbstrait _etatCourant;


        public Personnage()
        {
        }

        protected Personnage(string nom, int vie, EtatAbstrait etat)
        {
            Nom = nom;
            PointDeVie = vie;
            Position = new Zone();
            Avatar = new Image();
            ZoneAcessibleList = new List<ZoneAbstrait>();
            ObjectifAtteint = false;
            PortailAtteint = false;
            EstMort = false;
            ProchainCoupGagnant = null;
            PrendPotion = false;
            _etatCourant = etat;
        }

        public string Nom { get; set; }
        public int PointDeVie { get; set; }
        public Zone Position { get; set; }

        public EtatAbstrait EtatCourant
        {
            get { return _etatCourant; }
            set
            {
                _etatCourant = value;
                //Console.WriteLine("Etat : " + etatCourant.GetType().Name);
            }
        }


        public virtual void SetAvatar()
        {
            Avatar.Source = new BitmapImage(new Uri(@"pack://application:,,/perso.png"));
            Avatar.Stretch = Stretch.Fill;
        }

        //-----------------------------------------------------------------------------
        public virtual void SeDeplacer()
        {
        }

        public int GetPointDeVie()
        {
            return PointDeVie;
        }

        public virtual bool AnalyseSituation(List<Item> listItem, int maxRow, int maxColumn)
        {
            return false;
        }

        public void Execution()
        {
            _etatCourant.ModifieEtat(this);
        }
    }
}