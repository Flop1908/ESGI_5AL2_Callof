namespace DesignPattern.Fabrique
{
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