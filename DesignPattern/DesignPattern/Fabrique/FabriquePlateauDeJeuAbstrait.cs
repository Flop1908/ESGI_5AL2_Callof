namespace DesignPattern.Fabrique
{
    /// <summary>
    /// Classe de fabrique abstraite d'un plateau
    /// </summary>
    internal abstract class FabriquePlateauDeJeuAbstrait
    {
        public abstract PlateauDeJeuAbstrait CreerPlateauDeJeu();
        public abstract PlateauDeJeuAbstrait CreerPlateauFinal();
    }
}