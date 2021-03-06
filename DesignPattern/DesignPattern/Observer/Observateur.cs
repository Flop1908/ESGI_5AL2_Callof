﻿namespace DesignPattern.Observer
{
    /// <summary>
    /// Classe d'observateur pour les personnages
    /// </summary>
    internal class Observateur : ObservateurAbstrait
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