using System;
using System.Collections.Generic;
using DesignPattern.Fabrique;
using DesignPattern.Objet;

namespace DesignPattern.Observer
{
    /// <summary>
    /// Classe de personnage représentant un chevalier
    /// </summary>
    internal class Chevalier : Personnage
    {
        public Chevalier()
        {
        }

        public Chevalier(string nom, EtatAbstrait etat, int vie = 300)
            : base(nom, vie, etat)
        {
        }

        public override void SeDeplacer()
        {
            if (ProchainCoupGagnant == null)
            {
                var random = new Random();
                var i = random.Next(0, ZoneAcessibleList.Count);
                var zone = (Zone) ZoneAcessibleList[i];
                Position = zone;
            }
            else
            {
                Position.column = ProchainCoupGagnant.column;
                Position.row = ProchainCoupGagnant.row;

                ProchainCoupGagnant = null;
            }
        }


        public override void AnalyseSituation(List<Item> listItem)
        {
            ZoneAcessibleList.Clear();


            var z1 = new Zone();
            z1.row = Position.row + 1;
            z1.column = Position.column;
            if (z1.row <= 9 && z1.row >= 0) ZoneAcessibleList.Add(z1);

            var z2 = new Zone();
            z2.row = Position.row - 1;
            z2.column = Position.column;
            if (z2.row <= 9 && z2.row >= 0) ZoneAcessibleList.Add(z2);

            var z3 = new Zone();
            z3.row = Position.row;
            z3.column = Position.column - 1;
            if (z3.column <= 9 && z3.column >= 0) ZoneAcessibleList.Add(z3);

            var z4 = new Zone();
            z4.row = Position.row;
            z4.column = Position.column + 1;
            if (z4.column <= 9 && z4.column >= 0) ZoneAcessibleList.Add(z4);

            var z5 = new Zone();
            z5.row = Position.row + 2;
            z5.column = Position.column;
            if (z5.row <= 9 && z5.row >= 0) ZoneAcessibleList.Add(z5);

            var z6 = new Zone();
            z6.row = Position.row - 2;
            z6.column = Position.column;
            if (z6.row <= 9 && z6.row >= 0) ZoneAcessibleList.Add(z6);

            var z7 = new Zone();
            z7.row = Position.row;
            z7.column = Position.column - 2;
            if (z7.column <= 9 && z7.column >= 0) ZoneAcessibleList.Add(z7);

            var z8 = new Zone();
            z8.row = Position.row;
            z8.column = Position.column + 2;
            if (z8.column <= 9 && z8.column >= 0) ZoneAcessibleList.Add(z8);


            foreach (var item in listItem)
            {
                if (typeof (Goal) == item.GetType())
                {
                    if (item.Position.row == Position.row && item.Position.column == Position.column)
                        ObjectifAtteint = true;
                    else if ((z1.row == item.Position.row && z1.column == item.Position.column) ||
                             (z2.row == item.Position.row && z2.column == item.Position.column) ||
                             (z3.row == item.Position.row && z3.column == item.Position.column) ||
                             (z4.row == item.Position.row && z4.column == item.Position.column) ||
                             (z5.row == item.Position.row && z5.column == item.Position.column) ||
                             (z6.row == item.Position.row && z6.column == item.Position.column) ||
                             (z7.row == item.Position.row && z7.column == item.Position.column) ||
                             (z8.row == item.Position.row && z8.column == item.Position.column))
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
                             (z4.row == item.Position.row && z4.column == item.Position.column) ||
                             (z5.row == item.Position.row && z5.column == item.Position.column) ||
                             (z6.row == item.Position.row && z6.column == item.Position.column) ||
                             (z7.row == item.Position.row && z7.column == item.Position.column) ||
                             (z8.row == item.Position.row && z8.column == item.Position.column))
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