using DesignPattern.Fabrique;
using DesignPattern.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesignPattern.Observer
{
    class Archer : Personnage
    {
        public Archer()
        { }

        public Archer(string _Nom, EtatAbstrait _Etat, int _Vie = 150)
            : base(_Nom, _Vie, _Etat)
        {

        }

        public override void SetAvatar()
        {
            Avatar.Source = new BitmapImage(new Uri(@"pack://application:,,/archer.png"));
            Avatar.Stretch = Stretch.Fill;
        }

        public override void SeDeplacer()
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


        public override void AnalyseSituation(List<Item> ListItem)
        {
            ZoneAcessibleList.Clear();

            List<int> listPortee = new List<int>(new int[] { 1, -1, -1, 1 });

            Zone z1 = new Zone();
            z1.row = Position.row + 1;
            z1.column = Position.column;
            if (z1.row <= 9 && z1.row >= 0) ZoneAcessibleList.Add(z1);

            Zone z2 = new Zone();
            z2.row = Position.row - 1;
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
    }
}
