using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public abstract class EtatAbstrait
    {
        public abstract void ModifieEtat(Personnage perso);
    }
}
