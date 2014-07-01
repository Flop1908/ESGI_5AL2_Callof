namespace DesignPattern.Fabrique
{
    /// <summary>
    /// Classe abstraite des zones
    /// </summary>
    public abstract class ZoneAbstrait
    {
        //public string unNom;
        //private List<Personnage> observateurList = new List<Personnage>();
        //private List<Objet> observateurList = new List<Objet>();

        /*public ZoneAbstrait(string unNom)
{
// TODO: Complete member initialization
this.unNom = unNom;
}*/

        public int column { get; set; }
        public int row { get; set; }
    }
}