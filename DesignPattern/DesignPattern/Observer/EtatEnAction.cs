namespace DesignPattern.Observer
{
    /// <summary>
    /// Classe représentant l'état en action d'un personnage
    /// </summary>
    internal class EtatEnAction : EtatAbstrait
    {
        public override void ModifieEtat(Personnage perso)
        {
            perso.EtatCourant = new EtatEnAttente();
        }
    }
}