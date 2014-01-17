using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wpf.Game.Fabrique;
using Wpf.Game.Objet;


namespace Wpf.Game.Observer
{
    public abstract class Personnage : ObservateurAbstrait
    {
        public string Nom { get; set; }
        public int PointDeVie { get; set; }
        public Zone Position {get;set;}
        public Image Avatar;

        public bool ObjectifAtteint;
        public bool EstMort;
        public bool PrendPotion;

        public Zone ProchainCoupGagnant;

        public List<ZoneAbstrait> ZoneAcessibleList;

        //public ComportementCombat ComportementCombat { get; set; }
        //public ComportementEmettreUnSon ComportementEmettreUnSon { get; set; }
        //public eMode EtatFoncionnement { get; set; }

        public Personnage()
        {

        }

        protected Personnage(string _Nom, int _Vie)
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
            //ComportementCombat = null;
            //ComportementEmettreUnSon = null;
        }

        
        public void SetAvatar()
        {
            Avatar.Source = new BitmapImage(new Uri(@"pack://application:,,/perso.png"));
            Avatar.Stretch = Stretch.Fill;
        }

        //-----------------------------------------------------------------------------
        public void SeDeplacer()
        {
            if (ProchainCoupGagnant == null)
            {
                
                Random random = new Random();
                int i = random.Next(0, ZoneAcessibleList.Count);
                Zone zone = (Zone)ZoneAcessibleList[i];
                Position = zone;

                
            }
            else
            {
                Position.column = ProchainCoupGagnant.column;
                Position.row = ProchainCoupGagnant.row;

                ProchainCoupGagnant = null;
            }

        }

        public int GetPointDeVie()
        {
            return PointDeVie;
        }

        public void AnalyseSituation(List<Item> ListItem)
        {
            ZoneAcessibleList.Clear();

            Zone z1 = new Zone();
            z1.row = Position.row + 1;
            z1.column = Position.column;
            if (z1.row <= 9 && z1.row >= 0) ZoneAcessibleList.Add(z1);

            Zone z2 = new Zone();
            z2.row = Position.row -1;
            z2.column = Position.column;
            if (z2.row <= 9 && z2.row >= 0) ZoneAcessibleList.Add(z2);

            Zone z3 = new Zone();
            z3.row = Position.row;
            z3.column = Position.column - 1;
            if (z3.column <= 9 && z3.column >= 0) ZoneAcessibleList.Add(z3);

            Zone z4 = new Zone();
            z4.row = Position.row;
            z4.column = Position.column + 1;
            if (z4.column <= 9 && z4.column >= 0) ZoneAcessibleList.Add(z4);

            


            foreach (Item item in ListItem)
            {
                if (typeof(Goal) == item.GetType())
                {
                    if (item.Position.row == this.Position.row && item.Position.column == this.Position.column) ObjectifAtteint = true;
                    else if ((z1.row == item.Position.row && z1.column == item.Position.column) ||
                             (z2.row == item.Position.row && z2.column == item.Position.column) ||
                             (z3.row == item.Position.row && z3.column == item.Position.column) ||
                             (z4.row == item.Position.row && z4.column == item.Position.column))
                    {
                        /*this.Position.row = item.Position.row;
                        this.Position.column = item.Position.column;*/
                        ProchainCoupGagnant = item.Position;
                    }
                }
                else if (typeof(PotionVie) == item.GetType() && item.Pris == false)
                {
                    if (item.Position.row == this.Position.row && item.Position.column == this.Position.column)
                    {
                        PointDeVie += item.Potion;
                        PrendPotion = true;
                        item.Pris = true;
                        //ListItem.Remove(item);
                    }
                    else if ((z1.row == item.Position.row && z1.column == item.Position.column) ||
                             (z2.row == item.Position.row && z2.column == item.Position.column) ||
                             (z3.row == item.Position.row && z3.column == item.Position.column) ||
                             (z4.row == item.Position.row && z4.column == item.Position.column))
                    {
                        ProchainCoupGagnant = item.Position;

                    }
                }
 
            }
           
            PointDeVie -= 20;

            if (PointDeVie <= 0) EstMort = true;
        }

        public string Execution()
        {
            return "";
        }

    }
}
