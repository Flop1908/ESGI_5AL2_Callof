using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DesignPattern.Fabrique;
using DesignPattern.Objet;

namespace DesignPattern.Observer
{
    public abstract class Personnage
    {
        public string Nom { get; set; }
        public int PointDeVie { get; set; }
        public Zone Position { get; set; }
        public Image Avatar;
        

        public bool ObjectifAtteint;
        public bool EstMort;
        public bool PrendPotion;

        public Zone ProchainCoupGagnant;

        public List<ZoneAbstrait> ZoneAcessibleList;
        private EtatAbstrait etatCourant;
       

        public Personnage()
        {

        }

        protected Personnage(string _Nom, int _Vie, EtatAbstrait _Etat)
        {
            Nom = _Nom;
            PointDeVie = _Vie;
            Position = new Zone();
            Avatar = new Image();
            ZoneAcessibleList = new List<ZoneAbstrait>();
            ObjectifAtteint = false;
            EstMort = false;
            ProchainCoupGagnant = null;
            PrendPotion = false;
            etatCourant = _Etat;
        }

        public EtatAbstrait EtatCourant
        {
            get { return etatCourant; }
            set
            {
                etatCourant = value;
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

        public virtual void AnalyseSituation(List<Item> ListItem)
        {
            
        }

        public void Execution()
        {
            etatCourant.ModifieEtat(this);
        }

    }
}
