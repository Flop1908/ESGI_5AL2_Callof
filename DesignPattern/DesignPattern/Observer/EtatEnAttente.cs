namespace DesignPattern.Observer
{
    /// <summary>
    /// Classe représentant l'état d'un personnage en attente
    /// </summary>
    internal class EtatEnAttente : EtatAbstrait
    {
        public override void ModifieEtat(Personnage perso)
        {
            perso.EtatCourant = new EtatEnAction();
        }
    }
}