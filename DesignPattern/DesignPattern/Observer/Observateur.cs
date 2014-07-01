﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    class Observateur : ObservateurAbstrait
    {
        private readonly string nom;
        private EtatAbstrait etatObservé;

        public Observateur(Personnage perso, string name)
        {
            Personnage = perso;
            nom = name;
        }

        public Personnage Personnage { get; set; }

        public override void MiseAjour()
        {
            etatObservé = Personnage.EtatCourant;
            
        }
    }
}
