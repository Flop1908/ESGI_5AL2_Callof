using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DesignPattern.Fabrique;
using DesignPattern.Objet;

namespace DesignPattern.Observer
{
    /// <summary>
    /// Classe de personnage représentant un archer
    /// </summary>
    internal class Archer : Personnage
    {
        public Archer()
        {
        }

        public Archer(string nom, EtatAbstrait etat, int vie = 150)
            : base(nom, vie, etat)
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
                var random = new Random();
                var i = random.Next(0, ZoneAcessibleList.Count);
                var zone = (Zone)ZoneAcessibleList[i];
                Position = zone;
            }

            else
            {
                Position.column = ProchainCoupGagnant.column;
                Position.row = ProchainCoupGagnant.row;

                ProchainCoupGagnant = null;
            }
        }


        public override bool AnalyseSituation(List<Item> listItem, int maxRow, int maxColumn)
        {
            ZoneAcessibleList.Clear();
            
            var z1 = new Zone();
            z1.row = Position.row + 1;
            z1.column = Position.column;
            if (z1.row <= maxRow && z1.row >= 0) ZoneAcessibleList.Add(z1);

            var z2 = new Zone();
            z2.row = Position.row - 1;
            z2.column = Position.column;
            if (z2.row <= maxRow && z2.row >= 0) ZoneAcessibleList.Add(z2);

            var z3 = new Zone();
            z3.row = Position.row;
            z3.column = Position.column - 1;
            if (z3.column <= maxColumn && z3.column >= 0) ZoneAcessibleList.Add(z3);

            var z4 = new Zone();
            z4.row = Position.row;
            z4.column = Position.column + 1;
            if (z4.column <= maxColumn && z4.column >= 0) ZoneAcessibleList.Add(z4);


            foreach (var item in listItem)
            {
                if (typeof (Goal) == item.GetType())
                {
                    if (item.Position.row == Position.row && item.Position.column == Position.column)
                        ObjectifAtteint = true;
                    else if ((z1.row == item.Position.row && z1.column == item.Position.column) ||
                             (z2.row == item.Position.row && z2.column == item.Position.column) ||
                             (z3.row == item.Position.row && z3.column == item.Position.column) ||
                             (z4.row == item.Position.row && z4.column == item.Position.column))
                    {
                        ProchainCoupGagnant = item.Position;
                    }
                }
                else if (typeof (PotionVie) == item.GetType() && item.Pris == false)
                {
                    if (item.Position.row == Position.row && item.Position.column == Position.column)
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
                else if (typeof(Portail) == item.GetType() && PortailAtteint == false)
                {
                    if (item.Position.row == Position.row && item.Position.column == Position.column)
                    {
                        PortailAtteint = true;
                        return true;
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

            return false;
        }
    }
}