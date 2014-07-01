namespace DesignPattern.Fabrique
{
    internal abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait CreerPlateauDeJeu();
        public abstract PlateauDeJeuAbstrait CreerPlateauFinal();
    }
}