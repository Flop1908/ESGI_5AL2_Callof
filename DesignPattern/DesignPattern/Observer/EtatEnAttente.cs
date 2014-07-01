namespace DesignPattern.Observer
{
    internal class EtatEnAttente : EtatAbstrait
    {
        public override void ModifieEtat(Personnage perso)
        {
            perso.EtatCourant = new EtatEnAction();
        }
    }
}