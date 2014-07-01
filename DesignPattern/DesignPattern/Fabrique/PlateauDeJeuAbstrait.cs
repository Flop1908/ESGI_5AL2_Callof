using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Fabrique
{
    abstract class PlateauDeJeuAbstrait 
    {
        List<ZoneAbstrait> ZoneList;
        List<AccesAbstrait> AccesList;

        

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
            return this.ZoneList;
        }
    }
}
