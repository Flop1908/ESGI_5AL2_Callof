using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Fabrique
{
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

        public ZoneAbstrait() { }


    }
}
