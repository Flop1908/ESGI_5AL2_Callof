namespace DesignPattern.Fabrique
{
    /// <summary>
    /// Classe de fabriqcation intermediare de plateau
    /// </summary>
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