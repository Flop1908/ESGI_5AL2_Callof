namespace DesignPattern.Fabrique
{
    /// <summary>
    /// Classe de création globale du jeu
    /// </summary>
    internal class EnvironnementDeJeu
    {
        public PlateauDeJeu CreerPlateauDeJeu(FabriquePlateauDeJeuAbstrait fabrique)
        {
            return (PlateauDeJeu) fabrique.CreerPlateauDeJeu();
        }

        public PlateauFinal CreerPlateauFinal(FabriquePlateauDeJeuAbstrait fabrique)
        {
            return (PlateauFinal) fabrique.CreerPlateauFinal();
        }
    }
}