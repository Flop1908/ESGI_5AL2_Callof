namespace DesignPattern.Observer
{
    internal class EtatEnAction : EtatAbstrait
    {
        public override void ModifieEtat(Personnage perso)
        {
            perso.EtatCourant = new EtatEnAttente();
        }
    }
}