namespace DesignPattern.Observer
{
    /// <summary>
    /// Classe représentant les états des personnages
    /// </summary>
    public abstract class EtatAbstrait
    {
        public abstract void ModifieEtat(Personnage perso);
    }
}