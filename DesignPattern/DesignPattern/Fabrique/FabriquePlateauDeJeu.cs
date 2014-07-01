namespace DesignPattern.Fabrique
{
    internal class FabriquePlateauDeJeu : FabriquePlateauDeJeuAbstrait
    {
        public override PlateauDeJeuAbstrait CreerPlateauDeJeu()
        {
            return new PlateauDeJeu();
        }

        public override PlateauDeJeuAbstrait CreerPlateauFinal()
        {
            return new PlateauFinal();
        }
    }
}