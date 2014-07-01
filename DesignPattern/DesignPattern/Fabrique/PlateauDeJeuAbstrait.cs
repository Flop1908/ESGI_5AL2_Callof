using System.Collections.Generic;

namespace DesignPattern.Fabrique
{
    /// <summary>
    /// Classe de création abstraite des plateaux
    /// </summary>
    internal abstract class PlateauDeJeuAbstrait
    {
        private readonly List<AccesAbstrait> AccesList;
        private readonly List<ZoneAbstrait> ZoneList;


        public PlateauDeJeuAbstrait()
        {
            ZoneList = new List<ZoneAbstrait>();
            AccesList = new List<AccesAbstrait>();
        }

        public void AjouteAcces(AccesAbstrait a)
        {
            AccesList.Add(a);
        }

        public void AjouteZone(ZoneAbstrait z)
        {
            ZoneList.Add(z);
        }

        public List<ZoneAbstrait> GetZoneList()
        {
            return ZoneList;
        }
    }
}